/// <reference path="../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { DeadLoadsDataComponent } from './dead-loads-data.component';
var component;
var fixture;
describe('dead-loads-data component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [DeadLoadsDataComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DeadLoadsDataComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=dead-loads-data.component.spec.js.map