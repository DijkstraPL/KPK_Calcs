/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { DeadLoadsDataComponent } from './dead-loads-data.component';

let component: DeadLoadsDataComponent;
let fixture: ComponentFixture<DeadLoadsDataComponent>;

describe('dead-loads-data component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [DeadLoadsDataComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DeadLoadsDataComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});