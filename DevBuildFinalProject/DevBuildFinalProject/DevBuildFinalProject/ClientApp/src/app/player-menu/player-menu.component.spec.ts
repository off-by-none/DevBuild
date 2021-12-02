/// <reference path="../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { PlayerMenuComponent } from './player-menu.component';

let component: PlayerMenuComponent;
let fixture: ComponentFixture<PlayerMenuComponent>;

describe('player-menu component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ PlayerMenuComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(PlayerMenuComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});