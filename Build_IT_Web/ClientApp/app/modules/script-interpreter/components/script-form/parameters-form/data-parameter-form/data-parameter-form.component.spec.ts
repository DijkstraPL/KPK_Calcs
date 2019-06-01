/// <reference path="../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { DataParameterFormComponent } from './data-parameter-form.component';

let component: DataParameterFormComponent;
let fixture: ComponentFixture<DataParameterFormComponent>;

describe('data-parameter-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ DataParameterFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DataParameterFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});