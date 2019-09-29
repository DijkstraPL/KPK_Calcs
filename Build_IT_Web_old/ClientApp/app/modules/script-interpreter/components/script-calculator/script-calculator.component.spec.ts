/// <reference path="../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ScriptCalculatorComponent } from './script-calculator.component';

let component: ScriptCalculatorComponent;
let fixture: ComponentFixture<ScriptCalculatorComponent>;

describe('script-calculator component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ScriptCalculatorComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ScriptCalculatorComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});