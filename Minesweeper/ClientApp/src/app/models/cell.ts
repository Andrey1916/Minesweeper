export class Cell {
  mined: boolean = false;
  minesAround: number = 0;
  isChecked: boolean = false;
  markAsMined: boolean = false;
  element: any = null;

  posX: number = 0;
  posY: number = 0;
}
