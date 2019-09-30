/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ParameterAutocompleteComponent } from './parameter-autocomplete.component';
var component;
var fixture;
describe('parameter-autocomplete component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ParameterAutocompleteComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterAutocompleteComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=parameter-autocomplete.component.spec.js.map