import { Component, Input } from '@angular/core';
import { CardDataService } from '../card-data';
import { Card } from '../Interfaces/Card';
import { ActivatedRoute, Router } from '@angular/router';
import { Character } from '../Interfaces/character';

@Component({
  selector: 'app-player-deck',
  templateUrl: './player-deck.component.html',
  styleUrls: ['./player-deck.component.scss']
})
/** player-deck component*/
export class PlayerDeckComponent {

  @Input() player: Character;
  cards: Card[];

  /** player-deck ctor */
  constructor(private cardData: CardDataService, private route: ActivatedRoute, private router: Router) { }

  //ngOnChanges() {
  //  console.log("you alive?");

  //  this.cardData.getAllCardsOwnedById(this.player.Id).subscribe(
  //    (data: Card[]) => {
  //      this.cards = data;
  //    },
  //    error => console.error(error)
  //  );
  //}

  ngOnInit() {
    this.cardData.getAllCardsOwnedById(this.player.Id).subscribe(
      (data: Card[]) => {
        this.cards = data;
      },
      error => console.error(error)
    );
    //this.ngOnChanges();
    //this.route.params.subscribe(params => {
    //  this.player.Id = +params['player'];
    //});
    //if (!this.player === null) {
    //  console.log(this.player.Id);
    //}
    //else {
    //  console.log("Nada");
    //}

  }
}
