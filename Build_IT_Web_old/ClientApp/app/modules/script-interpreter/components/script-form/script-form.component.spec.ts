///// <reference path="../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ScriptFormComponent } from './script-form.component';

let component: ScriptFormComponent;
let fixture: ComponentFixture<ScriptFormComponent>;

describe('script-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ScriptFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});