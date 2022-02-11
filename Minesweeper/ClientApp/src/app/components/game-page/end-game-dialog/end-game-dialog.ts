import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GameState } from '../../../models/gameState';

@Component({
  selector: 'end-game-dialog',
  templateUrl: 'end-game-dialog.html',
})
export class EndGameDialog {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: GameState,
  ) {}
}
