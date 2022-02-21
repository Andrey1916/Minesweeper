import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GameState } from '../../../models/gameState';
import { FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'end-game-dialog',
  templateUrl: 'end-game-dialog.html',
})
export class EndGameDialog {

  playerName: string = '';

  playerNameControl = new FormControl(this.playerName, Validators.required);

  constructor(
    public dialogRef: MatDialogRef<GameState>,
    @Inject(MAT_DIALOG_DATA) public data: GameState,
  ) {
    dialogRef.disableClose = data.isWin ? true : false;
  }

  public onOkClick(): void {
    if (this.data.isWin){
      if (!this.playerNameControl.invalid){
        this.dialogRef.close();
      }
    } else {
      this.dialogRef.close();
    }
  }
}
