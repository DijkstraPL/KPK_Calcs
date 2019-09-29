/// <reference path="../../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { ExistingFiguresDialogComponent } from './existing-figures-dialog.component';
var component;
var fixture;
describe('existing-figures-dialog component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ExistingFiguresDialogComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ExistingFiguresDialogComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=existing-figures-dialog.component.spec.js.map