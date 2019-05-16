/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { DeadLoadsComponent } from './dead-loads.component';

let component: DeadLoadsComponent;
let fixture: ComponentFixture<DeadLoadsComponent>;

describe('dead-loads component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [DeadLoadsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DeadLoadsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});