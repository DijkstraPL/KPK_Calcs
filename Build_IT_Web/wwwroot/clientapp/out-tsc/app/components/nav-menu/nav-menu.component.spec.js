/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { NavMenuComponent } from './nav-menu.component';
var component;
var fixture;
describe('nav-menu component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [NavMenuComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(NavMenuComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=nav-menu.component.spec.js.map