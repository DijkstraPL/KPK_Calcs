/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterResultComponent } from './parameter-result.component';

let component: ParameterResultComponent;
let fixture: ComponentFixture<ParameterResultComponent>;

describe('parameter-result component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterResultComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterResultComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});