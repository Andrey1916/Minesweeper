export class GameState{
  constructor(
    public width: number,
    public height: number,
    public mines: number,
    public startedAt: number,
    public endedAt:number,
    public isWin: Boolean,
    public name: string|null = null)
  {}
}
