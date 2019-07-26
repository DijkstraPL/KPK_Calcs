var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SnowLoadMonopitchRoofComponent } from './snow-load-monopitch-roof/snow-load-monopitch-roof.component';
var routes = [
    { path: 'scripts/custom/10/1', component: SnowLoadMonopitchRoofComponent }
];
var CustomViewsRoutingModule = /** @class */ (function () {
    function CustomViewsRoutingModule() {
    }
    CustomViewsRoutingModule = __decorate([
        NgModule({
            imports: [RouterModule.forRoot(routes)],
            exports: [RouterModule],
        })
    ], CustomViewsRoutingModule);
    return CustomViewsRoutingModule;
}());
export { CustomViewsRoutingModule };
//# sourceMappingURL=custom-views-routing.module.js.map