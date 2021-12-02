import { Component, Input, EventEmitter, Output } from '@angular/core';
import { CharacterDataService } from '../character-data';
import { Character } from '../Interfaces/character';

@Component({
  selector: 'app-player-menu',
  templateUrl: './player-menu.component.html',
  styleUrls: ['./player-menu.component.scss']
})
/** player-menu component*/
export class PlayerMenuComponent {

  player: Character;

  /** player-menu ctor */
  constructor(private characterData: CharacterDataService) { }


  ngOnInit() {
    this.characterData.getCurrentUser().subscribe(
      (data: Character) => {
        this.player = data;
        console.log(this.player);
      },
      error => console.error(error)
    );
  }
}
