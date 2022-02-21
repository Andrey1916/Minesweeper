import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CustomGameDialog } from './custom-game-dialog/custom-game-dialog';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.less']
})
export class MainMenuComponent {
  title = 'Minesweeper';

  constructor(
    public dialog: MatDialog,
    private router: Router )
  {}

  public onCustomGameBtnClick() : void{
    const dialogRef = this.dialog.open(CustomGameDialog, {
      width: '300px',
      data: null,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        this.router.navigate(['/game'], { queryParams: result });
      }
      });
  }
}
