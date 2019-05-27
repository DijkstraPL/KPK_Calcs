/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SnowLoadsComponent } from './snow-loads.component';

let component: SnowLoadsComponent;
let fixture: ComponentFixture<SnowLoadsComponent>;

describe('snow-loads component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [SnowLoadsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SnowLoadsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});