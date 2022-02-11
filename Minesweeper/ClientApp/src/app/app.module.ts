import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MainMenuComponent } from './components/main-menu/main-menu.component';
import { GamePageComponent } from './components/game-page/game-page.component';
import { GameAreaComponent } from './components/game-page/game-area/game-area.component';
import { CellButtonComponent } from './components/cell-btn/cell-btn.component';
import { BestResultPageComponent } from './components/best-results-page/best-results-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { EndGameDialog } from './components/game-page/end-game-dialog/end-game-dialog';
import { CustomGameDialog } from './components/main-menu/custom-game-dialog/custom-game-dialog';

import { MaterialExampleModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    GamePageComponent,
    MainMenuComponent,
    GameAreaComponent,
    CellButtonComponent,
    BestResultPageComponent,
    EndGameDialog,
    CustomGameDialog
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatNativeDateModule,
    MaterialExampleModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
