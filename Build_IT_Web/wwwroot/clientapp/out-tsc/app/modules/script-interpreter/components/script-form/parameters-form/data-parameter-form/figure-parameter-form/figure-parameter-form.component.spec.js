/// <reference path="../../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { FigureParameterFormComponent } from './figure-parameter-form.component';
var component;
var fixture;
describe('figure-parameter-form component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [FigureParameterFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(FigureParameterFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=figure-parameter-form.component.spec.js.map