/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { TranslationFormComponent } from './translation-form.component';
var component;
var fixture;
describe('translation component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [TranslationFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(TranslationFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=translation-form.component.spec.js.map