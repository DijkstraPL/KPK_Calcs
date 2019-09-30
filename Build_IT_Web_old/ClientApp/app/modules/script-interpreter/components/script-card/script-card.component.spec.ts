/// <reference path="../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ScriptCardComponent } from './script-card.component';

let component: ScriptCardComponent;
let fixture: ComponentFixture<ScriptCardComponent>;

describe('script-card component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ScriptCardComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptCardComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});