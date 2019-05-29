/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { DataParametersFormComponent } from './data-parameters-form.component';

let component: DataParametersFormComponent;
let fixture: ComponentFixture<DataParametersFormComponent>;

describe('data-parameters-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ DataParametersFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DataParametersFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});