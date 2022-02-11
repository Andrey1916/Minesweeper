import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainMenuComponent } from './components/main-menu/main-menu.component';
import { GamePageComponent } from './components/game-page/game-page.component';
import { BestResultPageComponent } from './components/best-results-page/best-results-page.component';

const routes: Routes = [
  { path: "", redirectTo: "menu", pathMatch: "full" },

  { path: "menu", component: MainMenuComponent },
  { path: "game", component: GamePageComponent },
  { path: "score", component: BestResultPageComponent },

  { path: "**", redirectTo: "menu" },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
