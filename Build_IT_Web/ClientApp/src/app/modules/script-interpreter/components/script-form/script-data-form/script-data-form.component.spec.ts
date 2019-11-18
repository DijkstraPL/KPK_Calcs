/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ScriptDataFormComponent } from './script-data-form.component';

let component: ScriptDataFormComponent;
let fixture: ComponentFixture<ScriptDataFormComponent>;

describe('script-data component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ScriptDataFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptDataFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});