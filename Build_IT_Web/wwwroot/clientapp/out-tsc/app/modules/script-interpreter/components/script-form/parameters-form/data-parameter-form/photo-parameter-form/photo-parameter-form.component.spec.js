/// <reference path="../../../../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule } from "@angular/platform-browser";
import { PhotoParameterFormComponent } from './photo-parameter-form.component';
var component;
var fixture;
describe('photo-parameter-form component', function () {
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [PhotoParameterFormComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(PhotoParameterFormComponent);
        component = fixture.componentInstance;
    }));
    it('should do something', async(function () {
        expect(true).toEqual(true);
    }));
});
//# sourceMappingURL=photo-parameter-form.component.spec.js.map