/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterInputComponent } from './parameter-input.component';

let component: ParameterInputComponent;
let fixture: ComponentFixture<ParameterInputComponent>;

describe('parameter-input component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterInputComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterInputComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});