import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AddPlayerComponent } from './add-player/add-player.component';
import { PlayerMenuComponent } from './player-menu/player-menu.component';
import { PlayerDeckComponent } from './player-deck/player-deck.component';
import { BattlefieldPlayerComponent } from './battlefield-player/battlefield-player.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddPlayerComponent,
    PlayerMenuComponent,
    PlayerDeckComponent,
    BattlefieldPlayerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'addplayer', component: AddPlayerComponent, pathMatch: 'full' },
      { path: 'playermenu', component: PlayerMenuComponent, pathMatch: 'full' },
      { path: 'deck', component: PlayerDeckComponent },
      { path: 'battlefield-player/:userId', component: BattlefieldPlayerComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
