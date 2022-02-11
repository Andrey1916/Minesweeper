import { Component, ViewEncapsulation, ElementRef, ViewChild,
  Input, Output, AfterViewInit, EventEmitter } from '@angular/core';
import { Cell } from '../../../models/cell';
import { GameState } from 'src/app/models/gameState';
import { randomNumber } from '../../../utils/math';

@Component({
  selector: 'game-area',
  templateUrl: './game-area.component.html',
  styleUrls: ['./game-area.component.less'],
  encapsulation: ViewEncapsulation.None
})
export class GameAreaComponent implements AfterViewInit {
  private cellSize: number = 25;

  @Input() width: number = 10; // rows
  @Input() height: number = 10; // column
  @Input() mines: number = 20;

  @ViewChild('gameArea') gameArea: ElementRef | undefined;

  areaDetails: Cell[][] = [];

  private gameStarted: Boolean = false;
  private startedAt: number = 0;
  private isGameOver: boolean = false;
  private markedAsMinedCount: number = 0;
  private openCellsCount: number = 0;

  @Output() onMarkedAsMined = new EventEmitter<number>();
  // true  - player win
  // false - player lose
  @Output() onGameOver = new EventEmitter<GameState>();
  @Output() onGameStart = new EventEmitter<boolean>();

  ngAfterViewInit(): void {
    // create area
    let gameAreaElement = this.gameArea!.nativeElement;

    gameAreaElement.addEventListener('click', this.onChecked);
    gameAreaElement.addEventListener('contextmenu', this.markedAsMined, false);

    gameAreaElement.style.setProperty(
      'grid-template-columns', `repeat(${ this.width }, ${ this.cellSize }px)`
      );

    gameAreaElement.style.setProperty(
      'grid-template-rows', `repeat(${ this.height }, ${ this.cellSize }px)`
      );

    for (let i = 0; i < this.height; i++){
      let row: Cell[] = [];

      for (let j = 0; j < this.width; j++){
        let cell = new Cell();
        cell.posX = j;
        cell.posY = i;
        cell.element = document.createElement('div');
        cell.element.classList.add('cell');
        cell.element.dataset.posX = j;
        cell.element.dataset.posY = i;

        gameAreaElement.append(cell.element);

        row.push(cell);
      }

      this.areaDetails.push(row);
    }

    // set mines
    for (let i = 0; i < this.mines; i++){
      let x = randomNumber(0, this.height - 1);
      let y = randomNumber(0, this.width - 1);

      this.areaDetails[x][y].mined = true;
    }

    // calc count of mines around each cell
    for (let h = 0; h < this.height; h++){
      for (let w = 0; w < this.width; w++){
        if (this.areaDetails[h][w].mined){
          continue;
        }

        let counter = 0;

        // [X] *
        if ((w - 1 >= 0) && this.areaDetails[h][w - 1].mined){
          counter++;
        }

        // [X]
        //     *
        if ((w - 1 >= 0)
         && (h - 1 >= 0)
         && this.areaDetails[h - 1][w - 1].mined){
          counter++;
        }

        // [X]
        //  *
        if ((h - 1 >= 0) && this.areaDetails[h - 1][w].mined){
          counter++;
        }

        //    [X]
        //  *
        if ((w + 1 < this.width)
         && (h - 1 >= 0)
         && this.areaDetails[h - 1][w + 1].mined){
          counter++;
        }

        //  * [X]
        if ((w + 1 < this.width) && this.areaDetails[h][w + 1].mined){
          counter++;
        }

        //  *
        //    [X]
        if ((w + 1 < this.width)
         && (h + 1 < this.height)
         && this.areaDetails[h + 1][w + 1].mined){
          counter++;
        }

        //  *
        // [X]
        if ((h + 1 < this.height)
         && this.areaDetails[h + 1][w].mined){
          counter++;
        }

        //     *
        // [X]
        if ((w - 1 >= 0)
         && (h + 1 < this.height)
         && this.areaDetails[h + 1][w - 1].mined){
          counter++;
        }

        this.areaDetails[h][w].minesAround = counter;
      }
    }
  }

  private markedAsMined = (event: any): boolean => {
    event.preventDefault();

    let posX = +event.target.dataset.posX;
    let posY = +event.target.dataset.posY;
    let currentCell = this.areaDetails[posY][posX];

    if (!currentCell.isChecked && !this.isGameOver){
      if (currentCell.markAsMined) {
        currentCell.markAsMined = false;
        this.markedAsMinedCount -= 1;
        currentCell.element.classList.remove('markAsMined');
      } else {
        currentCell.markAsMined = true;
        this.markedAsMinedCount += 1;
        currentCell.element.classList.add('markAsMined');
      }

      this.onMarkedAsMined.emit(this.markedAsMinedCount);
    }

    return false;
  }

  private onChecked = (event: any): any => {

    if (!this.gameStarted){
      this.gameStarted = true;
      this.startedAt = Date.now();
      this.onGameStart.emit(true);
    }

    if (this.isGameOver){
      return;
    }

    let target = event.target;
    let posX = +target.dataset.posX;
    let posY = +target.dataset.posY;

    this.rerenderArea(posX, posY);
  }

  private rerenderArea(posX: number, posY: number): void {
    let currentCell = this.areaDetails[posY][posX];

    if (currentCell.markAsMined){
      return;
    }

    if (!currentCell.isChecked){
      ++this.openCellsCount;
    }

    currentCell.isChecked = true;

    this.setStyleForCell(currentCell);

    if (currentCell.mined){
      this.isGameOver = true;
      this.showAllMines();

      const isWin = false;

      this.onGameOver.emit(
        new GameState(
          this.width,
          this.height,
          this.mines,
          this.startedAt,
          Date.now(),
          isWin)
        );
      return;
    }

    if (currentCell.minesAround == 0){
      this.checkCellAround(posX, posY);
    } else {
      this.checkIsWin();
    }
  };

  checkCellAround = (posX: number, posY: number): void => {
    // [X]
    //     *
    if (posX - 1 >= 0 && posY - 1 >= 0){
      this.checkCell(posX - 1, posY - 1);
    }

    // [X]
    //  *
    if (posY - 1 >= 0){
      this.checkCell(posX, posY - 1);
    }

    //    [X]
    //  *
    if (posX + 1 < this.width && posY - 1 >= 0){
      this.checkCell(posX + 1, posY - 1);
    }

    //  * [X]
    if (posX + 1 < this.height){
      this.checkCell(posX + 1, posY);
    }

    //  *
    //    [X]
    if (posX + 1 < this.width && posY + 1 < this.height){
      this.checkCell(posX + 1, posY + 1);
    }

    //  *
    // [X]
    if (posY + 1 < this.height){
      this.checkCell(posX, posY + 1);
    }

    //     *
    // [X]
    if (posX - 1 >= 0 && posY + 1 < this.height){
      this.checkCell(posX - 1, posY + 1);
    }

    // [X] *
    if (posX - 1 >= 0){
      this.checkCell(posX - 1, posY);
    }
  }

  private checkCell(posX: number, posY: number): void {
    let cell = this.areaDetails[posY][posX];

    if (!cell.isChecked && !cell.mined && !cell.markAsMined){
      cell.isChecked = true;
      ++this.openCellsCount;
      this.setStyleForCell(cell);

      if (cell.minesAround == 0){
        setTimeout(this.checkCellAround, 0, posX, posY);
      }
    }

    this.checkIsWin();
  }

  private setStyleForCell(cell: Cell): void{
    if (cell.mined) {
      cell.element.classList.add('mined');
    }

    if (cell.isChecked) {
      cell.element.classList.add('checked');
      cell.element.innerText = cell.minesAround > 0
        ? cell.minesAround
        : '';

      switch(cell.minesAround) {
        case 1:
          cell.element.classList.add('oneMine');
          break;

        case 2:
          cell.element.classList.add('twoMines');
          break;

        case 3:
          cell.element.classList.add('threeMines');
          break;

        case 4:
          cell.element.classList.add('fourMines');
          break;

        case 5:
          cell.element.classList.add('fiveMines');
          break;

        case 6:
          cell.element.classList.add('sixMines');
          break;

        case 7:
          cell.element.classList.add('sevenMines');
          break;

        case 8:
          cell.element.classList.add('eightMines');
          break;
      }
    }
  }

  private showAllMines(): void{
    for (let i = 0; i < this.height; i++){
      for (let j = 0; j < this.width; j++){
        let current = this.areaDetails[i][j];

        if (current.mined){
          current.element.classList.add('mined');
        }
      }
    }
  }

  private checkIsWin(): void{
    const clearCells = this.width * this.height - this.mines;

    if (this.openCellsCount >= clearCells){
      this.isGameOver = true;
      this.showAllMines();

      const isWin = true;

      this.onGameOver.emit(
        new GameState(
          this.width,
          this.height,
          this.mines,
          this.startedAt,
          Date.now(),
          isWin)
        );
      return;
    }
  }
}
