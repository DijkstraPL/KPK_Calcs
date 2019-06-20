/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { DataParameterFormComponent } from './data-parameter-form.component';
var component;
var fixture;
describe('data-parameter-form component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [DataParameterFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DataParameterFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=data-parameter-form.component.spec.js.map