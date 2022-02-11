import { Component } from '@angular/core';

@Component({
  selector: 'best-results-page',
  templateUrl: './best-results-page.component.html',
  styleUrls: ['./best-results-page.component.less']
})
export class BestResultPageComponent {

  results: Result[] = [
    { name: '545', score: 1, time: 0, size: { width: 0, height: 0}},
    new Result(),
    new Result(),
    new Result(),
    new Result(),
    new Result(),
    new Result(),
    new Result()
  ];
}

class Result{
  name: string = '';
  time: number = 0;
  score: number = 0;
  size: { width: number, height: number } = { width: 0, height: 0 };
}
