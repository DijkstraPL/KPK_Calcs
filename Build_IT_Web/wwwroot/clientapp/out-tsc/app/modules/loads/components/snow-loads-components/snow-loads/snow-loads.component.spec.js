/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { SnowLoadsComponent } from './snow-loads.component';
var component;
var fixture;
describe('snow-loads component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [SnowLoadsComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SnowLoadsComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=snow-loads.component.spec.js.map