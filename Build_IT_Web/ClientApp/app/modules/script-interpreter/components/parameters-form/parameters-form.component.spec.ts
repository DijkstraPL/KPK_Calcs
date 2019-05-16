/// <reference path="../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParametersFormComponent } from './parameters-form.component';

let component: ParametersFormComponent;
let fixture: ComponentFixture<ParametersFormComponent>;

describe('parameters-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ParametersFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParametersFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});