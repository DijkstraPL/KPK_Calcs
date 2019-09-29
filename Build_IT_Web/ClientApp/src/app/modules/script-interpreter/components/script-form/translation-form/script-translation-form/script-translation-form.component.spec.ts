/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ScriptTranslationFormComponent } from './script-translation-form.component';

let component: ScriptTranslationFormComponent;
let fixture: ComponentFixture<ScriptTranslationFormComponent>;

describe('script-translation component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ScriptTranslationFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptTranslationFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});