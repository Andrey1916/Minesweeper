import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GameState } from '../../models/gameState';
import { MatDialog } from '@angular/material/dialog';
import { EndGameDialog } from './end-game-dialog/end-game-dialog';

@Component({
  selector: 'game-page',
  templateUrl: './game-page.component.html',
  styleUrls: ['./game-page.component.less']
})
export class GamePageComponent {
  width: number = 10;
  height: number = 10;
  mines: number = 10;

  markedAsMined: number = 0;

  private timerId: any;
  time: number = 0;
  successLoaded: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog){
    route.queryParams.subscribe(
      (queryParam: any) => {
        this.width  = +queryParam['width'];
        this.height = +queryParam['height'];
        this.mines  = +queryParam['mines'];

        if (isNaN(this.width) || isNaN(this.height) || isNaN(this.mines)){
          this.successLoaded = false;
          return;
        }

        if (this.height < 0 || this.width < 0 || this.mines < 0){
          this.successLoaded = false;
          return;
        }

        if (this.width * this.height < this.mines){
          this.mines = this.width * this.height;
        }

        this.successLoaded = true;
      }
    );
  }

  onGameOver(state: GameState){
    clearTimeout(this.timerId);

    const dialogRef = this.dialog.open(
      EndGameDialog,
      {
        width: '250px',
        data: state,
      });

    dialogRef.afterClosed().subscribe(result => {
        state.name = result;
        this.router.navigate(['/']);
      });
  }

  onGameStart(success: boolean){
    this.timerId = setInterval(
      () => { ++this.time; },
      1000);
  }

  onMarkedAsMined(markedAsMined: number){
    this.markedAsMined = markedAsMined;
  }

  getMinesLeft(): number {
    return this.mines - this.markedAsMined;
  }

  getFormattedTime(): string{
    if (this.time == 0){
      return "00:00";
    }

    if (this.time < 60){
      if (this.time < 10){
        return `00:0${ this.time }`;
      }

      return `00:${ this.time }`;
    }

    const minutes = Math.trunc(this.time / 60);
    const seconds = this.time - minutes * 60;

    let formattedTime = minutes < 10
      ? `0${ minutes }`
      : minutes;

    return seconds < 10
      ? `${ formattedTime }:0${ seconds }`
      : `${ formattedTime }:${ seconds }`;
  }
}
