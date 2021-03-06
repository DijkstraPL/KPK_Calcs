var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DeadLoadsComponent } from './components/dead-loads-components/dead-loads/dead-loads.component';
import { SnowLoadsComponent } from './components/snow-loads-components/snow-loads/snow-loads.component';
var routes = [
    { path: 'deadloads', component: DeadLoadsComponent },
    { path: 'snowloads', component: SnowLoadsComponent }
];
var LoadsRoutingModule = /** @class */ (function () {
    function LoadsRoutingModule() {
    }
    LoadsRoutingModule = __decorate([
        NgModule({
            imports: [RouterModule.forRoot(routes)],
            exports: [RouterModule],
        })
    ], LoadsRoutingModule);
    return LoadsRoutingModule;
}());
export { LoadsRoutingModule };
//# sourceMappingURL=loads-routing.module.js.map