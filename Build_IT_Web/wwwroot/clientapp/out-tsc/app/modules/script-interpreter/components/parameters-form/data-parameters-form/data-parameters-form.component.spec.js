/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { DataParametersFormComponent } from './data-parameters-form.component';
var component;
var fixture;
describe('data-parameters-form component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [DataParametersFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DataParametersFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=data-parameters-form.component.spec.js.map