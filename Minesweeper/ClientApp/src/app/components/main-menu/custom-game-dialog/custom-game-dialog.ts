import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

/** @title Form field theming */
@Component({
  selector: 'custom-game-dialog',
  templateUrl: 'custom-game-dialog.html',
})
export class CustomGameDialog{
  config: CustomGameConfig = {
    height: 10,
    width: 10,
    mines: 10
  };

  widthControl = new FormControl(this.config.width, Validators.min(3));
  heightControl = new FormControl(this.config.height, Validators.min(3));
  minesCountControl = new FormControl(this.config.mines, Validators.min(3));

  constructor(
    public dialogRef: MatDialogRef<CustomGameDialog>
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }
}

export interface CustomGameConfig {
  width: number;
  height: number;
  mines: number;
}
