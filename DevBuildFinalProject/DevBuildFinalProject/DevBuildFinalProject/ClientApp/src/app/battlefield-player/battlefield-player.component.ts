import { Component, Input } from '@angular/core';
import { CardDataService } from '../card-data';
import { CharacterDataService } from '../character-data';
import { Card } from '../Interfaces/Card';
import { Character } from '../Interfaces/Character';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-battlefield-player',
    templateUrl: './battlefield-player.component.html',
    styleUrls: ['./battlefield-player.component.scss']
})
/** battlefield-player component*/
export class BattlefieldPlayerComponent {

  userId: number;
  cards: Card[];
  player: Character;
  enemy: Character;
  
    /** battlefield-player ctor */
  constructor(private cardData: CardDataService, private characterData: CharacterDataService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.userId = +params['userId'];
    });

    this.cardData.getAllCardsOwnedById(this.userId).subscribe(
      (data: Card[]) => {
        this.cards = data;
        console.log(this.cards);
      },
      error => console.error(error)
    );

  }
}
