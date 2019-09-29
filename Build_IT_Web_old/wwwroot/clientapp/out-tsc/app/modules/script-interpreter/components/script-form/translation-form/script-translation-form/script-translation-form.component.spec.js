/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ScriptTranslationFormComponent } from './script-translation-form.component';
var component;
var fixture;
describe('script-translation component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ScriptTranslationFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptTranslationFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=script-translation-form.component.spec.js.map