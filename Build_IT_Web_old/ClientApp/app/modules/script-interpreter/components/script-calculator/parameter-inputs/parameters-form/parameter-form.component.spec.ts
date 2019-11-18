/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterFormComponent } from './parameter-form.component';

let component: ParameterFormComponent;
let fixture: ComponentFixture<ParameterFormComponent>;

describe('parameter-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});