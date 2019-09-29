/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterAutocompleteComponent } from './parameter-autocomplete.component';

let component: ParameterAutocompleteComponent;
let fixture: ComponentFixture<ParameterAutocompleteComponent>;

describe('parameter-autocomplete component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterAutocompleteComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterAutocompleteComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});