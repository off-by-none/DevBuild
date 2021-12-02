/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { PlayerDeckComponent } from './player-deck.component';

let component: PlayerDeckComponent;
let fixture: ComponentFixture<PlayerDeckComponent>;

describe('player-deck component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ PlayerDeckComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(PlayerDeckComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});