/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterTranslationFormComponent } from './parameter-translation-form.component';

let component: ParameterTranslationFormComponent;
let fixture: ComponentFixture<ParameterTranslationFormComponent>;

describe('parameter-translation component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterTranslationFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterTranslationFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});