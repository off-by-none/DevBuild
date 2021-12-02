/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AddPlayerComponent } from './add-player.component';

let component: AddPlayerComponent;
let fixture: ComponentFixture<AddPlayerComponent>;

describe('add-player component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AddPlayerComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AddPlayerComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});