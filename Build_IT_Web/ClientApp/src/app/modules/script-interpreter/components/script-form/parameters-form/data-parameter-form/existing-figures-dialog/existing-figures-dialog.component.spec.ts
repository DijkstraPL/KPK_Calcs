/// <reference path="../../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ExistingFiguresDialogComponent } from './existing-figures-dialog.component';

let component: ExistingFiguresDialogComponent;
let fixture: ComponentFixture<ExistingFiguresDialogComponent>;

describe('existing-figures-dialog component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ExistingFiguresDialogComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ExistingFiguresDialogComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});