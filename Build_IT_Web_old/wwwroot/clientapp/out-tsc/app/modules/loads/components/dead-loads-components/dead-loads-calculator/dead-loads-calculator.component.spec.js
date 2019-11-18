/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { DeadLoadsCalculatorComponent } from './dead-loads-calculator.component';
var component;
var fixture;
describe('dead-loads-calculator component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [DeadLoadsCalculatorComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DeadLoadsCalculatorComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=dead-loads-calculator.component.spec.js.map