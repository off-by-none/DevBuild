/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { BattlefieldPlayerComponent } from './battlefield-player.component';

let component: BattlefieldPlayerComponent;
let fixture: ComponentFixture<BattlefieldPlayerComponent>;

describe('battlefield-player component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ BattlefieldPlayerComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(BattlefieldPlayerComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});