/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { DeadLoadsCalculatorComponent } from './dead-loads-calculator.component';

let component: DeadLoadsCalculatorComponent;
let fixture: ComponentFixture<DeadLoadsCalculatorComponent>;

describe('dead-loads-calculator component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [DeadLoadsCalculatorComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DeadLoadsCalculatorComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});