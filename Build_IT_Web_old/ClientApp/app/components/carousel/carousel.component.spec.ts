/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CarouselComponent } from './carousel.component';

let component: CarouselComponent;
let fixture: ComponentFixture<CarouselComponent>;

describe('carousel component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [CarouselComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CarouselComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});