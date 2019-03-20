/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ScriptCardsComponent } from './script-cards.component';

let component: ScriptCardsComponent;
let fixture: ComponentFixture<ScriptCardsComponent>;

describe('script-cards component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ScriptCardsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptCardsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});