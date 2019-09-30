/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ParameterFiguresComponent } from './parameter-figures.component';
var component;
var fixture;
describe('parameter-figure component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ParameterFiguresComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterFiguresComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=parameter-figures.component.spec.js.map