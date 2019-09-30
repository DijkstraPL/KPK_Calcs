/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterRadioComponent } from './parameter-radio.component';

let component: ParameterRadioComponent;
let fixture: ComponentFixture<ParameterRadioComponent>;

describe('parameter-radio component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterRadioComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterRadioComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});