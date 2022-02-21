import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class GameResultService {

  constructor(private http: HttpClient){}

  getTopResults(take: number){
    return this.http.get(`https://localhost:7176/api/GameResult?skip=0&take=${ take }`);
  }

  addNewResult(result: NewResult){
    return this.http.post('https://localhost:7176/api/GameResult', result);
  }
}

export interface NewResult {
  mines: number,
  name: string,
  time: number,
  areaHeight: number,
  areaWidth: number
}
