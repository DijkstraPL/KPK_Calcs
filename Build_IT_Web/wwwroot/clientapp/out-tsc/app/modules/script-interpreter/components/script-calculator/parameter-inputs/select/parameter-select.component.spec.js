/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ParameterSelectComponent } from './parameter-select.component';
var component;
var fixture;
describe('parameter-select component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ParameterSelectComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterSelectComponent);
        component = fixture.componentInstance;
    }));
    it('changeValue function should emit valueChanged event', async(function () {
        //component.parameter = {};
        //component.valueChanged.subscribe(;
    }));
});
//# sourceMappingURL=parameter-select.component.spec.js.map