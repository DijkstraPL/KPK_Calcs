/// <reference path="../../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { FigureParameterFormComponent } from './figure-parameter-form.component';

let component: FigureParameterFormComponent;
let fixture: ComponentFixture<FigureParameterFormComponent>;

describe('figure-parameter-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [FigureParameterFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(FigureParameterFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});