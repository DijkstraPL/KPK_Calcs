/// <reference path="../../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ValueOptionsFormComponent } from './value-options-form.component';

let component: ValueOptionsFormComponent;
let fixture: ComponentFixture<ValueOptionsFormComponent>;

describe('value-options-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ValueOptionsFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ValueOptionsFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});