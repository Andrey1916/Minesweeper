import { Component, OnInit } from '@angular/core';
import { GameResultService } from '../../services/game-result.service';

@Component({
  selector: 'best-results-page',
  templateUrl: './best-results-page.component.html',
  styleUrls: ['./best-results-page.component.less'],
  providers: [ GameResultService ]
})
export class BestResultPageComponent implements OnInit{

  successLoaded: boolean = true;
  results: Result[] = [];

  constructor(private gameResultService: GameResultService)
  { }

  ngOnInit(): void {
    this.gameResultService.getTopResults(20)
      .subscribe({
          next: (data: any) => {
            data.forEach((item: any) => {
              this.results.push(
                new Result(
                  item.name,
                  item.time,
                  item.score,
                  item.mines,
                  {
                    width: item.areaWidth,
                    height: item.areaHeight
                  }
                )
              );
            });
          },
          error: (error: any) => {
            this.successLoaded = false;
            console.error(error)
          }
        });
  }
}

class Result {
  constructor(
    public name: string,
    public time: number,
    public score: number,
    public mines: number,
    public size: { width: number, height: number }
  )
  {}
}
