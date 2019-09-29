/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { TranslationFormComponent } from './translation-form.component';

let component: TranslationFormComponent;
let fixture: ComponentFixture<TranslationFormComponent>;

describe('translation component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [TranslationFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(TranslationFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});