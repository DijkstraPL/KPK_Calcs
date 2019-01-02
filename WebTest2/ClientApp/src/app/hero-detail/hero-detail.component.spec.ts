/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { HeroDetailComponent } from './hero-detail.component';

let component: HeroDetailComponent;
let fixture: ComponentFixture<HeroDetailComponent>;

describe('hero-detail component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ HeroDetailComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(HeroDetailComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});