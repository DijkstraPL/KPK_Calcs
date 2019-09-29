/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterCheckboxComponent } from './parameter-checkbox.component';

let component: ParameterCheckboxComponent;
let fixture: ComponentFixture<ParameterCheckboxComponent>;

describe('parameter-checkbox component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterCheckboxComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterCheckboxComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});