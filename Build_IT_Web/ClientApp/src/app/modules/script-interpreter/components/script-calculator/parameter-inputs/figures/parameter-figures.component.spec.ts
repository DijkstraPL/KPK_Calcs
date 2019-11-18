/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterFiguresComponent } from './parameter-figures.component';

let component: ParameterFiguresComponent;
let fixture: ComponentFixture<ParameterFiguresComponent>;

describe('parameter-figure component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterFiguresComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterFiguresComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});