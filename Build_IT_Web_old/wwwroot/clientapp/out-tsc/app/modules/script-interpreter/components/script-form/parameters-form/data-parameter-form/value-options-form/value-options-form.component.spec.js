/// <reference path="../../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ValueOptionsFormComponent } from './value-options-form.component';
var component;
var fixture;
describe('value-options-form component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ValueOptionsFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ValueOptionsFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=value-options-form.component.spec.js.map