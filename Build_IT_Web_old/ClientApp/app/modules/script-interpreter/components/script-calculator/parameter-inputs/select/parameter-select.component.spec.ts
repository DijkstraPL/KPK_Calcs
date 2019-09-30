/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ParameterSelectComponent } from './parameter-select.component';

let component: ParameterSelectComponent;
let fixture: ComponentFixture<ParameterSelectComponent>;

describe('parameter-select component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ParameterSelectComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ParameterSelectComponent);
        component = fixture.componentInstance;
    }));

    it('changeValue function should emit valueChanged event', async(() => {
        let parameter = spyOnProperty(component, "parameter");

        component.changeValue();

        expect(component.valueChanged.emit).toHaveBeenCalledWith(parameter);
    }));
});