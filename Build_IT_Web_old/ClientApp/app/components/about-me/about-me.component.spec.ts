/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AboutMeComponent } from './about-me.component';

let component: AboutMeComponent;
let fixture: ComponentFixture<AboutMeComponent>;

describe('about-me component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [AboutMeComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AboutMeComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});