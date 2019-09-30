/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ParameterTranslationFormComponent } from './parameter-translation-form.component';
var component;
var fixture;
describe('parameter-translation component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ParameterTranslationFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterTranslationFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=parameter-translation-form.component.spec.js.map