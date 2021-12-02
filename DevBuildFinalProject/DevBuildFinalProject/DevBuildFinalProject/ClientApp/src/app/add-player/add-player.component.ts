import { Component } from '@angular/core';
import { CharacterDataService } from '../character-data';
import { NewPlayer } from '../Interfaces/NewPlayer';
import { ActivatedRoute, Router } from '@angular/router'; //what do you do?


@Component({
    selector: 'app-add-player',
    templateUrl: './add-player.component.html',
    styleUrls: ['./add-player.component.scss']
})
/** add-player component*/
export class AddPlayerComponent {
  charName: string;

  /** add-player ctor */
  constructor(private characterData: CharacterDataService, private router: Router) {

  }

  submitPlayer() {
    if (this.charName == '') {
      return;
    }

    let newPlayer: NewPlayer = {
      CharName: this.charName,
      Player: true
    }

    this.characterData.addPlayer(newPlayer).subscribe();
    this.router.navigate(['playermenu']);
  }

}
