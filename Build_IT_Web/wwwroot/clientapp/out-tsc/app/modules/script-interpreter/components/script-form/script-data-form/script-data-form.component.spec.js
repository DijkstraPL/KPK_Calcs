/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ScriptDataFormComponent } from './script-data-form.component';
var component;
var fixture;
describe('script-data component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ScriptDataFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptDataFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=script-data-form.component.spec.js.map