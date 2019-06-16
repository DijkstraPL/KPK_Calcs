(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "../node_modules/raw-loader/index.js!./app/app.component.html":
/*!***********************************************************!*\
  !*** ../node_modules/raw-loader!./app/app.component.html ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <app-nav-menu></app-nav-menu>\r\n    <router-outlet></router-outlet>\r\n</div>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/components/about-me/about-me.component.html":
/*!************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/components/about-me/about-me.component.html ***!
  \************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"mt-2 ml-5 mr-5\">\r\n    <h3>Overall informations</h3>\r\n    <p>\r\n        The site contains a large number of calculators\r\n        which based mostly on Eurocodes with Polish national annexes.\r\n    </p>\r\n</div>\r\n\r\n<div class=\"m-5\">\r\n    <div>\r\n        <h3>Snow load calculators</h3>\r\n        <p>\r\n            Mostly based on <i>Eurocode 1 - Actions on structures Part 1-3: General actions - Snow loads</i> with Polish national annex.\r\n            This calculator contains all possible design situations and roof types which are described in the document.\r\n            This calculators shouldn't be used for or doesn't have informations how to calculate:\r\n        </p>\r\n        <ul>\r\n            <li>sites at altitudes above 1 500m,</li>\r\n            <li>impact snow loads resulting from sliding off or falling from a higher roof,</li>\r\n            <li>additional wind loads which could result from changes in shape or size of the construction works due to the presence of snow or the accretion of ice,</li>\r\n            <li>loads in areas where snow is present all year round,</li>\r\n            <li>ice loading,</li>\r\n            <li>lateral loading due to snow (e.g. lateral loads exerted by drifts),</li>\r\n            <li>snow loads on bridges.</li>\r\n        </ul>\r\n    </div>\r\n    <div>\r\n        <h3>Dead load calculator</h3>\r\n        <p>\r\n            Mostly based on <i>Eurocode 1 - Actions on structures Part 1-1: General actions - Densities, self-weight, imposed loads for buildings</i> with Polish national annex\r\n            and on Polish standard document <i>PN-82/B-02001 Building loads - permanent loads</i> which contains informations about the density of the building materials.\r\n            This calculator allows us to get the information about the weight of all layers in the structure.\r\n        </p>\r\n    </div>\r\n    <hr />\r\n    <div>\r\n        <h3>Author: Konrad Kania</h3>\r\n        <p>\r\n            I graduated at the Technical University in Łódź at the faculty of Civil Engineering.\r\n            Currently, I also finished postgraduate studies at Polish Academy of Science and work for building company as a programmer since the beginning of March 2017.\r\n            I treat building designing with great passion the same as the programming.\r\n            This way of doing things and possibilities which comes with those two branches bring me an idea to make something for overall usage.\r\n            I started working on this site since September 2018 and I hope that there will be only more and better content available for everyone.\r\n        </p>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/components/carousel/carousel.component.html":
/*!************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/components/carousel/carousel.component.html ***!
  \************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n    <div class=\"d-flex justify-content-center\">\r\n        <div id=\"carouselExampleIndicators\"\r\n             class=\"carousel slide w-50\"\r\n             data-ride=\"carousel\">\r\n            <ol class=\"carousel-indicators\">\r\n                <li data-target=\"#carouselExampleIndicators\"\r\n                    data-slide-to=\"0\"\r\n                    class=\"active\"></li>\r\n                <li data-target=\"#carouselExampleIndicators\"\r\n                    data-slide-to=\"1\"></li>\r\n                <li data-target=\"#carouselExampleIndicators\"\r\n                    data-slide-to=\"2\"></li>\r\n            </ol>\r\n            <div class=\"carousel-inner\">\r\n\r\n                <div class=\"carousel-item active\"\r\n                     [routerLinkActive]='[\"link-active\"]'\r\n                     [routerLinkActiveOptions]='{ exact: true }'>\r\n                    <div class=\"d-flex justify-content-center nav-item link\"\r\n                         [routerLink]=\"['/snowloads']\">\r\n                        <img src=\"https://lorempixel.com/600/300/?random=888\"\r\n                             alt=\"Snow load\">\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>Snow loads</h5>\r\n                            <p>Check out calculators for snow loads.</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"carousel-item\"\r\n                     [routerLinkActive]='[\"link-active\"]'\r\n                     [routerLinkActiveOptions]='{ exact: true }'>\r\n                    <div class=\"d-flex justify-content-center link\"\r\n                         [routerLink]=\"['/deadloads']\">\r\n                        <img src=\"https://lorempixel.com/600/300/?random=70\"\r\n                             alt=\"Lorem ipsum\">\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>Dead loads</h5>\r\n                            <p>Check out calculators for dead loads.</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"carousel-item\"\r\n                     [routerLinkActive]='[\"link-active\"]'\r\n                     [routerLinkActiveOptions]='{ exact: true }'>\r\n                    <div class=\"d-flex justify-content-center link\"\r\n                         [routerLink]=\"['/about']\">\r\n                        <img src=\"https://lorempixel.com/600/300/?random=70\"\r\n                             alt=\"Lorem ipsum\">\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>About me</h5>\r\n                            <p>Read more about the author of this site.</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <a class=\"carousel-control-prev\"\r\n               href=\"#carouselExampleIndicators\"\r\n               role=\"button\"\r\n               data-slide=\"prev\">\r\n                <span class=\"carousel-control-prev-icon\"\r\n                      aria-hidden=\"true\"></span>\r\n                <span class=\"sr-only\">Previous</span>\r\n            </a>\r\n            <a class=\"carousel-control-next\"\r\n               href=\"#carouselExampleIndicators\"\r\n               role=\"button\"\r\n               data-slide=\"next\">\r\n                <span class=\"carousel-control-next-icon\"\r\n                      aria-hidden=\"true\"></span>\r\n                <span class=\"sr-only\">Next</span>\r\n            </a>\r\n        </div>\r\n    </div>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/components/home/home.component.html":
/*!****************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/components/home/home.component.html ***!
  \****************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<app-carousel class=\"mt-2\"></app-carousel>\r\n\r\n<app-script-cards></app-script-cards>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/components/nav-menu/nav-menu.component.html":
/*!************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/components/nav-menu/nav-menu.component.html ***!
  \************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<nav class=\"navbar navbar-expand-lg navbar-dark bg-secondary\">\r\n    <a class=\"navbar-brand font-weight-bold\"\r\n       [routerLink]='[\"/\"]'><span class=\"fa fa-building-o\"></span>BUILD IT</a>\r\n    <button class=\"navbar-toggler\"\r\n            type=\"button\"\r\n            data-toggle=\"collapse\"\r\n            data-target=\"#navbarSupportedContent\"\r\n            aria-controls=\"navbarSupportedContent\"\r\n            aria-expanded=\"false\"\r\n            aria-label=\"Toggle navigation\">\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n    </button>\r\n\r\n    <div class=\"collapse navbar-collapse\" id=\"navbarSupportedContent\">\r\n        <ul class=\"navbar-nav mr-auto\">\r\n            <li class=\"nav-item active\"\r\n                [routerLinkActive]='[\"link-active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   [routerLink]='[\"/home\"]'>\r\n                    <span class=\"fa fa-home\"></span> Home <span class=\"sr-only\">(current)</span>\r\n                </a>\r\n            </li>\r\n            <li class=\"nav-item\"\r\n                [routerLinkActive]='[\"link-active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   [routerLink]=\"['/scripts/new']\">\r\n                    <span class=\"fa fa-file-code\"></span> New script\r\n                </a>\r\n            </li>\r\n            <li class=\"nav-item dropdown\">\r\n                <a class=\"nav-link dropdown-toggle\"\r\n                   href=\"#\"\r\n                   id=\"navbarDropdown\"\r\n                   role=\"button\"\r\n                   data-toggle=\"dropdown\"\r\n                   aria-haspopup=\"true\"\r\n                   aria-expanded=\"false\">\r\n                    <span class=\"fa fa-arrow-down\"></span> Loads\r\n                </a>\r\n                <div class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">\r\n                    <a class=\"dropdown-item\"\r\n                       [routerLink]=\"['/deadloads']\">\r\n                        <span class=\"fa fa-building\"></span> Dead Loads\r\n                    </a>\r\n                    <a class=\"dropdown-item\"\r\n                       [routerLink]=\"['/snowloads']\">\r\n                        <span class=\"fa fa-snowman\"></span> Snow Loads\r\n                    </a>\r\n                    <!--<a class=\"dropdown-item\" href=\"#\">Another action</a>\r\n            <div class=\"dropdown-divider\"></div>\r\n            <a class=\"dropdown-item\" href=\"#\">Something else here</a>-->\r\n                </div>\r\n            </li>\r\n\r\n            <li class=\"nav-item\"\r\n                [routerLinkActive]='[\"link-active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   [routerLink]=\"['/about']\">\r\n                    <span class=\"fa fa-user-circle\"></span> About\r\n                </a>\r\n            </li>\r\n            <!--<li class=\"nav-item\">\r\n        <a class=\"nav-link disabled\" href=\"#\">Disabled</a>\r\n    </li>-->\r\n        </ul>\r\n        <!--<form class=\"form-inline my-2 my-lg-0\">\r\n            <input class=\"form-control mr-sm-2\"\r\n                   type=\"search\"\r\n                   placeholder=\"Search\"\r\n                   aria-label=\"Search\">\r\n            <button class=\"btn btn-outline-success my-2 my-sm-0\" type=\"submit\">Search</button>\r\n        </form>-->\r\n    </div>\r\n</nav>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.html":
/*!**************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.html ***!
  \**************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"scroll-horizontal mb-4\">\r\n    <table mat-table\r\n           multiTemplateDataRows\r\n           [dataSource]=\"selectedMaterialDataSource\"\r\n           class=\"mat-elevation-z8 mt-4 center\"\r\n           cdkDropList\r\n           [cdkDropListData]=\"selectedMaterialDataSource\"\r\n           (cdkDropListDropped)=\"dropTable($event)\"\r\n           *ngIf=\"selectedMaterials.length > 0\">\r\n\r\n        <ng-container matColumnDef=\"position\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                No.\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\">\r\n                <div cdkDragHandle class=\"fa fa-reorder\"></div>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"category\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-left\">\r\n                    Category\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-left\">\r\n                <div class=\"mr-3\">\r\n                    {{materialForCalculation.categoryName}}\r\n                </div>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"name\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Name\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                <div class=\"mr-1\">\r\n                    {{materialForCalculation.material.name}}\r\n                </div>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"length\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Length [cm]\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                <mat-form-field *ngIf=\"materialForCalculation.material.unit > 0; else noLengthBlock\"\r\n                                class=\"ml-3\">\r\n                    <input matInput\r\n                           type=\"number\"\r\n                           class=\"text-center\"\r\n                           min=\"0\"\r\n                           (change)=\"calculate(materialForCalculation)\"\r\n                           [(ngModel)]=\"materialForCalculation.length\">\r\n                </mat-form-field>\r\n                <ng-template #noLengthBlock>-</ng-template>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"width\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Width [cm]\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n\r\n                <mat-form-field *ngIf=\"materialForCalculation.material.unit > 1; else noLengthBlock\"\r\n                                class=\"ml-3\">\r\n                    <input matInput\r\n                           type=\"number\"\r\n                           class=\"text-center\"\r\n                           min=\"0\"\r\n                           (change)=\"calculate(materialForCalculation)\"\r\n                           [(ngModel)]=\"materialForCalculation.width\">\r\n                </mat-form-field>\r\n                <ng-template #noLengthBlock>-</ng-template>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"thickness\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Thickness [cm]\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n\r\n                <mat-form-field *ngIf=\"materialForCalculation.material.unit > 2; else noLengthBlock\"\r\n                                class=\"ml-3\">\r\n                    <input matInput\r\n                           type=\"number\"\r\n                           class=\"text-center\"\r\n                           min=\"0\"\r\n                           (change)=\"calculate(materialForCalculation)\"\r\n                           [(ngModel)]=\"materialForCalculation.thickness\">\r\n                </mat-form-field>\r\n                <ng-template #noLengthBlock>-</ng-template>\r\n            </td>\r\n            <td mat-footer-cell\r\n                *matFooterCellDef\r\n                class=\"text-right\">\r\n                Total:\r\n            </td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"minDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Minimum<br />Density\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                {{materialForCalculation.calculatedMinimumLoad | number:'1.0-3'}}\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef>{{sumMinimumDeadLoads | number:'1.0-3'}}</td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"maxDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Maximum<br />Density\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                {{materialForCalculation.calculatedMaximumLoad | number:'1.0-3'}}\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef>{{sumMaximumDeadLoads | number:'1.0-3'}}</td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"unit\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Unit\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\"\r\n                [innerHTML]=\"units[materialForCalculation.unit].value\"></td>\r\n            <td mat-footer-cell *matFooterCellDef>\r\n                <div [innerHTML]=\"units[selectedMaterials[0].unit].value\"></div>\r\n            </td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"remove\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Remove\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                <button mat-stroked-button color=\"warn\"\r\n                        (click)=\"removeMaterial(materialForCalculation)\">\r\n                    <span class=\"fa fa-minus\"></span>\r\n                </button>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"additions\">\r\n            <td mat-cell\r\n                colspan=\"10\"\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-left\">\r\n                <div *ngFor=\"let addition of materialForCalculation.additions\">\r\n                    <mat-checkbox class=\"ml-1\"\r\n                                  [checked]=\"addition.isChecked\"\r\n                                  (change)=\"additionChecked(materialForCalculation, addition)\">\r\n                        {{addition.origin.name}}\r\n                        <span *ngIf=\"addition.origin.description\">\r\n                            - {{addition.origin.description}}\r\n                        </span>\r\n                    </mat-checkbox>\r\n                </div>\r\n            </td>\r\n        </ng-container>\r\n\r\n        <tr mat-header-row\r\n            *matHeaderRowDef=\"materialsForCalculationsDisplayedColumns\"></tr>\r\n        <tr mat-row\r\n            *matRowDef=\"let row; columns: materialsForCalculationsDisplayedColumns;\"\r\n            cdkDrag\r\n            [cdkDragData]=\"row\"></tr>\r\n        <!--<tr mat-row\r\n            class=\"example-custom-placeholder\"\r\n            *cdkDragPlaceholder>\r\n        </tr>-->\r\n        <tr mat-row\r\n            *matRowDef=\"let row; columns: ['additions'];\"\r\n            [class.additions-hidden]=\"row\"></tr>\r\n        <tr mat-footer-row\r\n            [class.summary-hidden]=\"!isUnitsProper()\"\r\n            *matFooterRowDef=\"materialsForCalculationsDisplayedColumns\"></tr>\r\n    </table>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.html":
/*!**************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.html ***!
  \**************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "    <mat-form-field class=\"m-2\">\r\n        <mat-label>Categories</mat-label>\r\n        <mat-select [(ngModel)]=\"selectedCategory\"\r\n                    name=\"category\"\r\n                    (selectionChange)=\"onCategoryChange()\">\r\n            <mat-option *ngFor=\"let category of categories\"\r\n                        [value]=\"category\">\r\n                {{category.name}}\r\n            </mat-option>\r\n        </mat-select>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\"\r\n                    *ngIf=\"subcategories\">\r\n        <mat-label>Subcategories</mat-label>\r\n        <mat-select [(ngModel)]=\"selectedSubcategory\"\r\n                    name=\"subcategory\"\r\n                    (selectionChange)=\"onSubcategoryChange()\">\r\n            <mat-option *ngFor=\"let subcategory of subcategories\"\r\n                        [value]=\"subcategory\">\r\n                {{subcategory.name}} - {{subcategory.documentName}}\r\n            </mat-option>\r\n        </mat-select>\r\n    </mat-form-field>\r\n\r\n    <table mat-table\r\n           [dataSource]=\"materials\"\r\n           class=\"mat-elevation-z8 center mt-4\"\r\n           *ngIf=\"materials\">\r\n        <ng-container matColumnDef=\"name\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                Name\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\"\r\n                class=\"text-left\">\r\n                {{material.name}}\r\n            </td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"minDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Minimum<br />Density\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\">\r\n                {{material.minimumDensity}}\r\n            </td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"maxDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Maximum<br />Density\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\">\r\n                {{material.maximumDensity}}\r\n            </td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"unit\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Unit\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\"\r\n                [innerHTML]=\"units[material.unit].value\"></td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"add\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    Add\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\">\r\n                <button mat-stroked-button color=\"accent\"\r\n                        (click)=\"addMaterial(material)\">\r\n                    <span class=\"fa fa-plus\"></span>\r\n                </button>\r\n            </td>\r\n        </ng-container>\r\n\r\n        <tr mat-header-row *matHeaderRowDef=\"materialsDisplayedColumns\"></tr>\r\n        <tr mat-row *matRowDef=\"let row; columns: materialsDisplayedColumns;\"></tr>\r\n    </table>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.html":
/*!****************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.html ***!
  \****************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"text-center\">\r\n\r\n    <h1>Dead loads calculator</h1>\r\n\r\n    <app-dead-loads-calculator [newMaterial]=\"newMaterial\"></app-dead-loads-calculator>\r\n    <app-dead-loads-data (materialAdded)=\"onMaterialAdded($event)\"></app-dead-loads-data>\r\n   \r\n</div>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.html":
/*!****************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.html ***!
  \****************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n    <h1 class=\"text-center\">Snow loads calculators</h1>\r\n\r\n<app-script-cards [groupFilters]=\"loadsGroupFilter\"\r\n                  [tagFilters]=\"loadsTagFilter\"></app-script-cards>\r\n\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.html":
/*!********************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.html ***!
  \********************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field>\r\n    <input type=\"text\"\r\n           aria-label=\"Number\"\r\n           matInput\r\n           [required]=\"isRequired()\"\r\n           [formControl]=\"valueOptionsForm\"\r\n           [attr.type]=\"parameter.valueType == 0 ? 'number' : 'text'\"\r\n           name=\"parameterInput\"\r\n           [ngClass]=\"parameter.name\"\r\n           [matAutocomplete]=\"auto\"\r\n           [(ngModel)]=\"parameter.value\"\r\n           (change)=\"changeValue()\">\r\n    <mat-placeholder>\r\n        <span [innerHtml]=\"parameter.name | html\"></span>\r\n    </mat-placeholder>\r\n    <span matSuffix\r\n          [innerHtml]=\"parameter.unit | html\"></span>\r\n</mat-form-field>\r\n\r\n<mat-autocomplete #auto=\"matAutocomplete\"\r\n                  autoActiveFirstOption>\r\n    <mat-option *ngIf=\"!isRequired()\"\r\n                class=\"default\"> </mat-option>\r\n    <mat-option *ngFor=\"let valueOption of filteredValueOptions | async\"\r\n                [value]=\"valueOption.value\"\r\n                [ngClass]=\"valueOption.name\">\r\n        {{valueOption.name }}\r\n    </mat-option>\r\n</mat-autocomplete>\r\n\r\n<p class=\"parameter-description\">{{parameter.description}}</p>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.html":
/*!************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.html ***!
  \************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"align-self-start parameter-radio\">\r\n    <label class=\"align-self-start mb-2\">\r\n        <span [innerHtml]=\"parameter.name | html\"></span>{{isRequired() ? '*' : ''}}\r\n    </label>\r\n\r\n    <div class=\"d-inline-flex\">\r\n        <mat-checkbox *ngIf=\"!isRequired()\"\r\n                      class=\"mr-3\"\r\n                      #defaultField\r\n                      (change)=\"defaultChecked($event)\">\r\n            default\r\n        </mat-checkbox>\r\n\r\n        <mat-checkbox *ngIf=\"!isDefault\"\r\n                      [required]=\"isRequired()\"\r\n                      #checkboxField\r\n                      (change)=\"changeValue($event)\">\r\n            true\r\n        </mat-checkbox>\r\n    </div>\r\n    <p class=\"parameter-description\">{{parameter.description}}</p>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.html":
/*!**********************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.html ***!
  \**********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-accordion *ngIf=\"figures.length > 0\">\r\n    <mat-expansion-panel (closed)=\"collapsed()\"\r\n                         (opened)=\"expanded()\">\r\n        <mat-expansion-panel-header>\r\n            <mat-panel-title>\r\n                Pictures\r\n            </mat-panel-title>\r\n        </mat-expansion-panel-header>\r\n        <div *ngIf=\"isExpanded\">\r\n            <img *ngFor=\"let figure of figures\"\r\n                 src=\"clientapp/uploads/parameters/{{figure.fileName}}\"\r\n                 alt=\"Parameter picture\" />\r\n        </div>\r\n    </mat-expansion-panel>\r\n</mat-accordion>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.html":
/*!******************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.html ***!
  \******************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field>\r\n    <input matInput\r\n           [required]=\"isRequired()\"\r\n           autocomplete=\"off\"\r\n           [ngClass]=\"parameter.name\"\r\n           [attr.type]=\"parameter.valueType == 0 ? 'number' : 'text'\"\r\n           [(ngModel)]=\"parameter.value\"\r\n           (change)=\"changeValue()\">\r\n    <mat-placeholder>\r\n        <span [innerHtml]=\"parameter.name | html\"></span>\r\n    </mat-placeholder>\r\n    <span matSuffix [innerHtml]=\"parameter.unit | html\"></span>\r\n</mat-form-field>\r\n<p class=\"parameter-description\">{{parameter.description}}</p>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.html":
/*!***************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.html ***!
  \***************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"parameter.valueOptionSetting != valueOptionSetting.Boolean && parameter.valueOptions.length == 0; else valueOptions\">\r\n    <parameter-input [parameter]=\"parameter\"\r\n                     (valueChanged)=\"onValueChanged($event)\"></parameter-input>\r\n</div>\r\n\r\n<ng-template #valueOptions>\r\n\r\n    <div *ngIf=\"parameter.valueOptionSetting == valueOptionSetting.UserInput; else fixedValueOptions\">\r\n        <parameter-autocomplete [parameter]=\"parameter\"\r\n                                (valueChanged)=\"onValueChanged($event)\"></parameter-autocomplete>\r\n    </div>\r\n\r\n    <ng-template #fixedValueOptions>\r\n\r\n        <div class=\"form-inline\"\r\n             *ngIf=\"parameter.valueOptionSetting == valueOptionSetting.Boolean; else severalValueOptions\">\r\n            <parameter-checkbox [parameter]=\"parameter\"\r\n                                (valueChanged)=\"onValueChanged($event)\"></parameter-checkbox>\r\n        </div>\r\n\r\n        <ng-template #severalValueOptions>\r\n            <div class=\"form-inline\"\r\n                 *ngIf=\"parameter.valueOptions.length > 0 && parameter.valueOptions.length <= 3\">\r\n                <parameter-radio [parameter]=\"parameter\"\r\n                                 (valueChanged)=\"onValueChanged($event)\"></parameter-radio>\r\n            </div>\r\n\r\n            <div *ngIf=\"parameter.valueOptions.length > 3\">\r\n                <parameter-select [parameter]=\"parameter\"\r\n                                  (valueChanged)=\"onValueChanged($event)\"></parameter-select>\r\n            </div>\r\n        </ng-template>\r\n    </ng-template>\r\n\r\n</ng-template>\r\n\r\n<parameter-figures [parameter]=\"parameter\"></parameter-figures>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.html":
/*!******************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.html ***!
  \******************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"justify-content-start parameter-radio\">\r\n    <label class=\"align-self-start mb-2\">\r\n        <span [innerHtml]=\"parameter.name | html\"></span>{{isRequired() ? '*' : ''}}\r\n    </label>\r\n    <mat-radio-group [(ngModel)]=\"parameter.value\">\r\n        <mat-radio-button value=\"\"\r\n                          *ngIf=\"!isRequired()\"\r\n                          selected\r\n                          class=\"mr-3\"\r\n                          (change)=\"changeValue($event)\">\r\n            default\r\n        </mat-radio-button>\r\n        <mat-radio-button *ngFor=\"let valueOption of parameter.valueOptions; index as i\"\r\n                          [value]=\"valueOption.value\"\r\n                          [required]=\"isRequired()\"\r\n                          class=\"mr-3\"\r\n                          (change)=\"changeValue($event)\">\r\n            {{valueOption.value }}\r\n        </mat-radio-button>\r\n        {{parameter.unit | html}}\r\n    </mat-radio-group>\r\n    <p class=\"parameter-description\">{{parameter.description}}</p>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.html":
/*!********************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.html ***!
  \********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field>\r\n    <mat-label [innerHtml]=\"parameter.name | html\"></mat-label>\r\n    <mat-select [(ngModel)]=\"parameter.value\"\r\n                [required]=\"isRequired()\"\r\n                (selectionChange)=\"changeValue()\">\r\n        <mat-option *ngIf=\"!isRequired()\"> </mat-option>\r\n        <mat-option *ngFor=\"let valueOption of parameter.valueOptions\"\r\n                    [value]=\"valueOption.value\">\r\n            {{valueOption.name }}\r\n        </mat-option>\r\n    </mat-select>\r\n    <span matSuffix [innerHtml]=\"parameter.unit | html\"></span>\r\n</mat-form-field>\r\n<p class=\"parameter-description\">{{parameter.description}}</p>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.html":
/*!*******************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.html ***!
  \*******************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [ngClass]=\"{'parameter-result-important': isImportant()}\">\r\n    <mat-list-item class=\"mt-3\">\r\n        <div class=\"d-inline-flex m-2\">\r\n            <h3 class=\"blockquote d-inline-block mr-2 parameter-result-header\"\r\n                [innerHtml]=\"parameter.name | html\"></h3>\r\n            <div class=\"d-inline-block\">\r\n                <p class=\"font-weight-bold mb-0 parameter-result-value\">\r\n                    <span *ngIf=\"parameter.valueType == valueTypesMapping['number']; else textValue\">\r\n                        {{parameter.value | toNumber | number:'1.0-3'}}\r\n                    </span>\r\n                    <ng-template #textValue>\r\n                        <span [ngClass]=\"parameter.name\">{{parameter.value}}</span>\r\n                    </ng-template>\r\n                    <span [innerHtml]=\"parameter.unit | html\"></span>\r\n                </p>\r\n                <p class=\"d-inline-block\"> {{ parameter.description }} </p>\r\n            </div>\r\n            <p innerHtml=\"{{parameter.equation | html}}\"></p>\r\n        </div>\r\n    </mat-list-item>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/script-calculator.component.html":
/*!*********************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-calculator/script-calculator.component.html ***!
  \*********************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div *ngIf=\"script\">\r\n    <div class=\"text-center\">\r\n        <h1>{{script.name}}</h1>\r\n    </div>\r\n\r\n    <p class=\"ml-2\">{{script.description}}</p>\r\n    <ul>\r\n        <li *ngFor=\"let tag of script.tags\">\r\n            {{tag.name}}\r\n        </li>\r\n    </ul>\r\n    <div *ngIf=\"!visibleParameters\">\r\n        <mat-progress-bar mode=\"indeterminate\"></mat-progress-bar>\r\n    </div>\r\n\r\n    <div *ngIf=\"staticDataParameters && staticDataParameters.length > 0\">\r\n        <h5 class=\"ml-2\">Static data</h5>\r\n        <mat-list dense>\r\n            <div *ngFor=\"let parameter of staticDataParameters\">\r\n                <parameter-result [parameter]=\"parameter\"></parameter-result>\r\n                <mat-divider></mat-divider>\r\n            </div>\r\n        </mat-list>\r\n    </div>\r\n\r\n    <div class=\"mt-2\">\r\n        <div *ngFor=\"let parameter of notGroupedParameters\"\r\n             class=\"list-inline-item ml-5 d-inline-flex\">\r\n            <parameter-form [parameter]=\"parameter\"\r\n                            (valueChanged)=\"onValueChanged($event)\"></parameter-form>\r\n        </div>\r\n\r\n\r\n        <mat-accordion>\r\n            <mat-expansion-panel *ngFor=\"let group of groups\">\r\n                <mat-expansion-panel-header>\r\n                    <mat-panel-title>\r\n                        {{group.name}}\r\n                    </mat-panel-title>\r\n                </mat-expansion-panel-header>\r\n\r\n                <ul class=\"list-inline m-0\">\r\n                    <li *ngFor=\"let parameter of group.parameters\"\r\n                        class=\"list-inline-item ml-5 d-inline-flex\">\r\n                        <parameter-form [parameter]=\"parameter\"\r\n                                        (valueChanged)=\"onValueChanged($event)\"></parameter-form>\r\n                    </li>\r\n                </ul>\r\n\r\n            </mat-expansion-panel>\r\n        </mat-accordion>\r\n    </div>\r\n\r\n\r\n    <div class=\"text-center\"\r\n         *ngIf=\"visibleParameters\">\r\n        <button mat-stroked-button\r\n                color=\"accent\"\r\n                class=\"calculate\"\r\n                type=\"button\"\r\n                [disabled]=\"!isValid()\"\r\n                (click)=\"calculate()\">\r\n            <span class=\"fa fa-calculator\"></span> Calculate\r\n        </button>\r\n    </div>\r\n\r\n    <div *ngIf=\"isCalculating\"\r\n         class=\"mt-2\">\r\n        <mat-progress-bar mode=\"query\"></mat-progress-bar>\r\n    </div>\r\n\r\n    <div *ngIf=\"resultParameters && !valueChanged\">\r\n        <h3 class=\"ml-2\">Results</h3>\r\n        <mat-list dense>\r\n            <div *ngFor=\"let parameter of resultParameters\">\r\n                <parameter-result [parameter]=\"parameter\"></parameter-result>\r\n                <mat-divider></mat-divider>\r\n            </div>\r\n        </mat-list>\r\n    </div>\r\n</div>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-card/script-card.component.html":
/*!*********************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-card/script-card.component.html ***!
  \*********************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<mat-card class=\"flex-grow-1\">\r\n    <mat-card-header>\r\n        <div mat-card-avatar class=\"script-header-image\"></div>\r\n        <mat-card-title>{{ script.name }}</mat-card-title>\r\n        <mat-card-subtitle>{{ script.accordingTo }}</mat-card-subtitle>\r\n    </mat-card-header>\r\n    <div mat-card-image>\r\n        <ul>\r\n            <li class=\"small\"\r\n                *ngFor=\"let tag of script.tags\">{{tag.name}}</li>\r\n        </ul>\r\n    </div>\r\n    <!--<img mat-card-image\r\n         src=\"https://lorempixel.com/300/300/?random={{script.id}}\"\r\n         title=\"{{script.name}}\"\r\n         alt=\"{{script.name}}\">-->\r\n    <mat-card-content>\r\n        <p class=\"mb-4\">\r\n            {{script.description }}\r\n        </p>\r\n    </mat-card-content>\r\n    <mat-card-actions class=\"footer\">\r\n        <div class=\"actions\">\r\n            <button mat-stroked-button\r\n                    [routerLink]=\"['/scripts/calculator', script.id]\">\r\n                <span class=\"fa fa-calculator\"></span> Calculate\r\n            </button>\r\n            <button mat-stroked-button\r\n                    [routerLink]=\"['/scripts/edit', script.id]\">\r\n                <span class=\"fa fa-edit\"></span> Edit\r\n            </button>\r\n        </div>\r\n            <button mat-stroked-button \r\n                    color=\"warn\"\r\n                    class=\"float-right\"\r\n                    (click)=\"delete(script)\">\r\n                <span class=\"fa fa-remove\"></span> Delete\r\n            </button>\r\n    </mat-card-actions>\r\n</mat-card>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-cards/script-cards.component.html":
/*!***********************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-cards/script-cards.component.html ***!
  \***********************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"row mt-5 m-2\">\r\n        <app-script-card *ngFor=\"let script of scripts\"\r\n                         class=\"flex-column d-none d-flex col col-xl-3 col-lg-4 col-md-6 col-sm-12 col-auto mb-4\"\r\n                         [script]=\"script\"\r\n                         (deleted)=\"onDeleted($event)\"></app-script-card>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.html":
/*!*****************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.html ***!
  \*****************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n\r\n<form (ngSubmit)=\"onSubmit($event)\"\r\n      [formGroup]=\"parameterForm\">\r\n\r\n    <h3>\r\n        <span innerHTML=\"{{parameterName.value | html }}\"></span> - {{parameterDescription.value}}\r\n    </h3>\r\n\r\n    <div class=\"full-width\">\r\n        <label id=\"parameter-type\">Pick parameter type</label>\r\n        <mat-radio-group aria-labelledby=\"parameter-type\"\r\n                         (change)=\"parameterTypeChanged()\">\r\n            <mat-radio-button class=\"ml-2\"\r\n                              #editable\r\n                              [value]=\"context.editable\">Editable</mat-radio-button>\r\n            <mat-radio-button class=\"ml-2\"\r\n                              #static\r\n                              [value]=\"context.staticData\">Static</mat-radio-button>\r\n            <mat-radio-button class=\"ml-2\"\r\n                              #calculable\r\n                              [value]=\"context.calculation\">Calculable</mat-radio-button>\r\n        </mat-radio-group>\r\n\r\n        <mat-checkbox (change)=\"parameterTypeChanged()\"\r\n                      [value]=\"context.visible\"\r\n                      class=\"ml-2\"\r\n                      #visible>Visible</mat-checkbox>\r\n        <mat-checkbox (change)=\"parameterTypeChanged()\"\r\n                      [value]=\"context.important\"\r\n                      class=\"ml-2\"\r\n                      #important>Important</mat-checkbox>\r\n        <mat-checkbox (change)=\"parameterTypeChanged()\"\r\n                      [value]=\"context.optional\"\r\n                      class=\"ml-2\"\r\n                      #optional>Optional</mat-checkbox>\r\n\r\n    </div>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <input matInput\r\n               required\r\n               placeholder=\"Name\"\r\n               formControlName=\"name\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>Parameter name</mat-hint>\r\n        <mat-error *ngIf=\"parameterName && parameterName.hasError('maxlength') && !parameterName.hasError('required')\">\r\n            Name should be maximum {{parameterName.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n        <mat-error *ngIf=\"parameterName && parameterName.hasError('required')\">\r\n            Name is <strong>required</strong>\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <input matInput\r\n               placeholder=\"Unit\"\r\n               formControlName=\"unit\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>Unit</mat-hint>\r\n        <mat-error *ngIf=\"parameterUnit && parameterUnit.hasError('maxlength')\">\r\n            Unit should be maximum {{parameterUnit.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <input matInput\r\n               placeholder=\"Document\"\r\n               formControlName=\"accordingTo\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>Document</mat-hint>\r\n        <mat-error *ngIf=\"parameterDocument && parameterDocument.hasError('maxlength')\">\r\n            Document should be maximum {{parameterDocument.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <mat-label>Value Type</mat-label>\r\n        <mat-select matNativeControl\r\n                    formControlName=\"valueType\"\r\n                    required>\r\n            <mat-option *ngFor=\"let valueType of valueTypes; let i = index\"\r\n                        [value]=\"i\">\r\n                {{valueType}}\r\n            </mat-option>\r\n        </mat-select>\r\n        <mat-hint>Value Type</mat-hint>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <mat-label>Group name</mat-label>\r\n        <input matInput\r\n               placeholder=\"Group name\"\r\n               formControlName=\"groupName\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>Group name</mat-hint>\r\n        <mat-error *ngIf=\"parameterGroupName && parameterGroupName.hasError('maxlength')\">\r\n            Group namme should be maximum {{parameterGroupName.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 full-width\">\r\n        <textarea matInput\r\n                  #value\r\n                  placeholder=\"Value\"\r\n                  formControlName=\"value\"\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\"></textarea>\r\n        <mat-hint>Value for parameter</mat-hint>\r\n        <mat-error *ngIf=\"parameterValue && parameterValue.hasError('maxlength')\">\r\n            Value should be maximum {{parameterValue.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <div>\r\n        <button mat-stroked-button \r\n                *ngFor=\"let parameter of previousParameters\"\r\n                matTooltip=\"{{parameter.description}}\"\r\n                matTooltipPosition=\"below\" \r\n                innerHtml=\"{{parameter.name | html}} [{{parameter.unit | html}}]\"\r\n                 type=\"button\"\r\n                (click)=\"select(parameter)\"></button>\r\n    </div>\r\n\r\n    <div class=\"value-options-border p-2\">\r\n        <app-value-options-form [parameterForm]=\"parameterForm\"></app-value-options-form>\r\n    </div>\r\n\r\n    <mat-form-field class=\"m-2 full-width\">\r\n        <textarea matInput\r\n                  placeholder=\"Description\"\r\n                  formControlName=\"description\"\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\"></textarea>\r\n        <mat-hint>Description for parameter</mat-hint>\r\n        <mat-error *ngIf=\"parameterDescription && parameterDescription.hasError('maxlength')\">\r\n            Description should be maximum {{parameterDescription.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 form-medium\">\r\n        <input matInput\r\n               placeholder=\"Visibility validator\"\r\n               formControlName=\"visibilityValidator\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>Visibility validator</mat-hint>\r\n        <mat-error *ngIf=\"parameterVisibilityValidator && parameterVisibilityValidator.hasError('maxlength')\">\r\n            Visibility validator should be maximum {{parameterVisibilityValidator.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 form-medium\">\r\n        <input matInput\r\n               placeholder=\"Data validator\"\r\n               formControlName=\"dataValidator\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>Data validator</mat-hint>\r\n        <mat-error *ngIf=\"parameterDataValidator && parameterDataValidator.hasError('maxlength')\">\r\n            Data validator should be maximum {{parameterDataValidator.errors.maxlength.requiredLength}} characters long.\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <div class=\"value-options-border p-2 mb-3\"\r\n         *ngIf=\"parameterId.value > 0\">\r\n        <app-figure-parameter-form [parameterForm]=\"parameterForm\"></app-figure-parameter-form>\r\n    </div>\r\n\r\n    <div class=\"full-width\">\r\n        <button mat-stroked-button\r\n                color=\"accent\"\r\n                type=\"submit\">\r\n            {{ newlyAddedParameter ? 'Add' : 'Update'}}\r\n        </button>\r\n    </div>\r\n</form>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.html":
/*!*********************************************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.html ***!
  \*********************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1 mat-dialog-title>Pictures</h1>\r\n<div mat-dialog-content>\r\n    <p>Select proper picture:</p>\r\n    <mat-form-field>\r\n        <img *ngFor=\"let figure of figures\"\r\n             src=\"clientapp/uploads/{{parameterId.value}}/{{figure.fileName}}\"\r\n             alt=\"Parameter picture\" />\r\n    </mat-form-field>\r\n</div>\r\n<div mat-dialog-actions>\r\n    <button mat-button \r\n            type=\"button\"\r\n            (click)=\"onNoClick()\">No Thanks</button>\r\n    <button mat-button \r\n            type=\"button\"\r\n            [mat-dialog-close]=\"data\" \r\n            cdkFocusInitial>Ok</button>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.html":
/*!*****************************************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.html ***!
  \*****************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<mat-accordion>\r\n    <mat-expansion-panel>\r\n        <mat-expansion-panel-header>\r\n            <mat-panel-title>\r\n                Pictures\r\n            </mat-panel-title>\r\n            <mat-panel-description>\r\n                Provide additional pictures for parameter\r\n            </mat-panel-description>\r\n        </mat-expansion-panel-header>\r\n        <input type=\"file\"\r\n               (change)=\"uploadFigure()\"\r\n               #fileInput />\r\n\r\n        <div class=\"mt-1\">\r\n            <!--<button mat-raised-button (click)=\"pickExistingDialog()\">Pick existing</button>-->\r\n            <div *ngFor=\"let figure of figures\">\r\n                <img src=\"clientapp/uploads/parameters/{{figure.fileName}}\"\r\n                     alt=\"Parameter picture\" />\r\n                <button mat-stroked-button\r\n                        color=\"warn\"\r\n                        type=\"button\"\r\n                        (click)=\"remove(figure)\">\r\n                    Remove\r\n                </button>\r\n                <p>Test</p>\r\n            </div>\r\n        </div>\r\n\r\n    </mat-expansion-panel>\r\n</mat-accordion>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.html":
/*!***********************************************************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.html ***!
  \***********************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<mat-accordion>\r\n    <mat-expansion-panel>\r\n        <mat-expansion-panel-header>\r\n            <mat-panel-title>\r\n                Value Options\r\n            </mat-panel-title>\r\n            <mat-panel-description>\r\n                Provide some selectable data\r\n            </mat-panel-description>\r\n        </mat-expansion-panel-header>\r\n\r\n        <form [formGroup]=\"parameterForm\">\r\n\r\n            <div>\r\n                <mat-radio-group formControlName=\"valueOptionSetting\">\r\n                    <mat-radio-button [value]=\"valueOptionSettings.None\"\r\n                                      class=\"ml-2\">None</mat-radio-button>\r\n                    <mat-radio-button [value]=\"valueOptionSettings.UserInput\"\r\n                                      class=\"ml-2\">Allow any values</mat-radio-button>\r\n                    <mat-radio-button [value]=\"valueOptionSettings.Boolean\"\r\n                                      (change)=\"booleanSettingChecked($event)\"\r\n                                      class=\"ml-2\">Is boolean</mat-radio-button>\r\n                </mat-radio-group>\r\n            </div>\r\n\r\n            <div *ngIf=\"parameterValueOptionSetting.value != valueOptionSettings.Boolean\">\r\n                <ul *ngFor=\"let valueOption of parameterValueOptions.controls; let i = index\">\r\n                    <li>\r\n                        <div [formGroup]=\"valueOption\">\r\n                            <mat-form-field class=\"m-2\">\r\n                                <input matInput\r\n                                       placeholder=\"Name\"\r\n                                       formControlName=\"name\"\r\n                                       [errorStateMatcher]=\"matcher\"\r\n                                       autocomplete=\"off\" />\r\n                                <mat-hint>Name</mat-hint>\r\n                                <!--<mat-error *ngIf=\"parameterDocument && parameterDocument.hasError('maxlength')\">\r\n                        Document should be maximum {{parameterDocument.errors.maxlength.requiredLength}} characters long.\r\n                    </mat-error>-->\r\n                            </mat-form-field>\r\n                            <mat-form-field class=\"m-2\">\r\n                                <input matInput\r\n                                       placeholder=\"Value\"\r\n                                       formControlName=\"value\"\r\n                                       [errorStateMatcher]=\"matcher\"\r\n                                       autocomplete=\"off\" />\r\n                                <mat-hint>Value</mat-hint>\r\n                            </mat-form-field>\r\n\r\n                            <mat-form-field class=\"m-2 form-medium\">\r\n                                <textarea matInput\r\n                                          placeholder=\"Description\"\r\n                                          formControlName=\"description\"\r\n                                          [errorStateMatcher]=\"matcher\"\r\n                                          autocomplete=\"off\"></textarea>\r\n                                <mat-hint>Description for value option</mat-hint>\r\n                            </mat-form-field>\r\n\r\n                            <button mat-stroked-button\r\n                                    color=\"warn\"\r\n                                    type=\"button\"\r\n                                    (click)=\"remove(valueOption)\">\r\n                                Remove\r\n                            </button>\r\n                        </div>\r\n                    </li>\r\n                </ul>\r\n                <button mat-stroked-button\r\n                        color=\"accent\"\r\n                        type=\"button\"\r\n                        (click)=\"addValueOption()\">\r\n                    Add\r\n                </button>\r\n            </div>\r\n        </form>\r\n\r\n    </mat-expansion-panel>\r\n</mat-accordion>\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.html":
/*!*****************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.html ***!
  \*****************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"!editMode\">\r\n    <div class=\"m-4\">\r\n        <label id=\"parameters-type-filter\">Select parameters:</label>\r\n        <mat-radio-group aria-labelledby=\"parameters-type-filter\"\r\n                         [(ngModel)]=\"parametersToShow\"\r\n                         (change)=\"onParametersToShowChange()\">\r\n            <mat-radio-button value=\"all\"\r\n                              class=\"ml-2\">All parameters</mat-radio-button>\r\n            <mat-radio-button value=\"data\"\r\n                              class=\"ml-2\">Data parameters</mat-radio-button>\r\n            <mat-radio-button value=\"static\"\r\n                              class=\"ml-2\">Static parameters</mat-radio-button>\r\n            <mat-radio-button value=\"calculation\"\r\n                              class=\"ml-2\">Calculation parameters</mat-radio-button>\r\n        </mat-radio-group>\r\n    </div>\r\n\r\n    <div cdkDropList\r\n         class=\"parameters-list\"\r\n         (cdkDropListDropped)=\"drop($event)\">\r\n        <div class=\"parameter-in-list\"\r\n             *ngFor=\"let parameter of sortParameters(filteredParameters, 'number')\"\r\n             cdkDrag>\r\n            <div class=\"parameter-placeholder\"\r\n                 *cdkDragPlaceholder></div>\r\n            <div class=\"parameter-container\"\r\n                 [ngClass]=\"{'selected-parameter' : parameter == newParameter}\">\r\n                <div class=\"ml-3 parameter-data\">\r\n                    <b class=\"parameter-name\"\r\n                       [innerHTML]=\"parameter.name | html\"></b> - {{parameter.description}}\r\n                </div>\r\n\r\n                <div class=\"parameter-options\">\r\n                    <button mat-stroked-button\r\n                            class=\"ml-2\"\r\n                            (click)=\"editParameter(parameter)\">\r\n                        Edit\r\n                    </button>\r\n                    <button mat-stroked-button\r\n                            class=\"ml-2\"\r\n                            (click)=\"remove(parameter.id)\"\r\n                            color=\"warn\">\r\n                        Remove\r\n                    </button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <button mat-stroked-button\r\n            color=\"accent\"\r\n            class=\"m-3\"\r\n            (click)=\"addNewParameter()\">\r\n        New parameter\r\n    </button>\r\n</div>\r\n\r\n<div class=\"m-3\"\r\n     *ngIf=\"editMode\">\r\n    <button mat-fab\r\n            color=\"primary\"\r\n            (click)=\"changeEditMode()\">\r\n        <span class=\"fa fa-backward\"></span>\r\n    </button>\r\n\r\n    <div class=\"container\"\r\n         *ngIf=\"editMode\">\r\n        <app-data-parameter-form [newlyAddedParameter]=\"newlyAddedParameter\"\r\n                                 [scriptId]=\"scriptId\"\r\n                                 [newParameter]=\"newParameter\"\r\n                                 [parameters]=\"parameters\"\r\n                                 (created)=\"onCreated($event)\"\r\n                                 (updated)=\"onUpdated($event)\"></app-data-parameter-form>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.html":
/*!*******************************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.html ***!
  \*******************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n    <div [formGroup]=\"scriptForm\">\r\n        <mat-form-field class=\"m-2 form-medium\">\r\n            <input matInput\r\n                   required\r\n                   placeholder=\"Name\"\r\n                   formControlName=\"name\"\r\n                   [errorStateMatcher]=\"matcher\"\r\n                   autocomplete=\"off\" />\r\n            <mat-hint>Script name</mat-hint>\r\n            <mat-error *ngIf=\"scriptName && scriptName.hasError('minlength') && !scriptName.hasError('required')\">\r\n                Name should be minimum {{scriptName.errors.minlength.requiredLength}} characters long.\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptName && scriptName.hasError('maxlength') && !scriptName.hasError('required')\">\r\n                Name should be maximum {{scriptName.errors.maxlength.requiredLength}} characters long.\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptName && scriptName.hasError('required')\">\r\n                Name is <strong>required</strong>\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2\">\r\n            <input matInput\r\n                   placeholder=\"Author\"\r\n                   formControlName=\"author\"\r\n                   [errorStateMatcher]=\"matcher\"\r\n                   autocomplete=\"off\" />\r\n            <mat-hint>Script author</mat-hint>\r\n            <mat-error *ngIf=\"scriptAuthor && scriptAuthor.hasError('maxlength')\">\r\n                Author name should be maximum {{scriptAuthor.errors.maxlength.requiredLength}} characters long.\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2 form-medium\">\r\n            <input matInput\r\n                   placeholder=\"Document\"\r\n                   formControlName=\"accordingTo\"\r\n                   [errorStateMatcher]=\"matcher\"\r\n                   autocomplete=\"off\" />\r\n            <mat-hint>Accoording to</mat-hint>\r\n            <mat-error *ngIf=\"scriptDocument && scriptDocument.hasError('maxlength')\">\r\n                Document name should be maximum {{scriptDocument.errors.maxlength.requiredLength}} characters long.\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2\">\r\n            <mat-label>Group</mat-label>\r\n            <mat-select formControlName=\"groupName\"\r\n                        [errorStateMatcher]=\"matcher\"\r\n                        required>\r\n                <mat-option value=\"Statica\"><span class=\"fa fa-minus\"></span> Statica</mat-option>\r\n                <mat-option value=\"Loads\"><span class=\"fa fa-arrow-down\"></span> Loads</mat-option>\r\n                <mat-option value=\"Concrete\">Concrete</mat-option>\r\n                <mat-option value=\"Steel\">Steel</mat-option>\r\n                <mat-option value=\"Timber\"><span class=\"fa fa-tree\"></span> Timber</mat-option>\r\n                <mat-option value=\"Soils\">Soils</mat-option>\r\n                <mat-divider></mat-divider>\r\n                <mat-option value=\"Other\">Other</mat-option>\r\n            </mat-select>\r\n            <mat-hint>Category for a script</mat-hint>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2 full-width\">\r\n            <textarea matInput\r\n                      placeholder=\"Description\"\r\n                      formControlName=\"description\"\r\n                      required\r\n                      [errorStateMatcher]=\"matcher\"\r\n                      autocomplete=\"off\"></textarea>\r\n            <mat-hint>Description for script</mat-hint>\r\n            <mat-error *ngIf=\"scriptDescription && scriptDescription.hasError('minlength') && !scriptDescription.hasError('required')\">\r\n                Description should be minimum {{scriptDescription.errors.minlength.requiredLength}} characters long.\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptDescription && scriptDescription.hasError('maxlength') && !scriptDescription.hasError('required')\">\r\n                Description should be maximum {{scriptDescription.errors.maxlength.requiredLength}} characters long.\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptDescription && scriptDescription.hasError('required')\">\r\n                Description is <strong>required</strong>\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <div class=\"m-2\">\r\n            <mat-checkbox [checked]=\"includeNote\"\r\n                          (change)=\"includeNote = !includeNote\">\r\n                Include note\r\n            </mat-checkbox>\r\n\r\n            <mat-form-field class=\"full-width\"\r\n                            *ngIf=\"includeNote\">\r\n                <textarea matInput\r\n                          placeholder=\"Notes\"\r\n                          formControlName=\"notes\"\r\n                          [errorStateMatcher]=\"matcher\"\r\n                          autocomplete=\"off\"></textarea>\r\n                <mat-hint>Additional notes for script</mat-hint>\r\n                <mat-error *ngIf=\"scriptNotes && scriptNotes.hasError('maxlength')\">\r\n                    Note should be maximum {{scriptNotes.errors.maxlength.requiredLength}} characters long.\r\n                </mat-error>\r\n            </mat-form-field>\r\n        </div>\r\n    </div>"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/script-form.component.html":
/*!*********************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/script-form.component.html ***!
  \*********************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h2 class=\"mt-4 text-center\"\r\n    *ngIf=\"!editMode\">\r\n    Script\r\n</h2>\r\n<h2 class=\"mt-4 text-center\"\r\n    *ngIf=\"editMode\">\r\n    {{scriptName.value}}\r\n</h2>\r\n\r\n<form (ngSubmit)=\"onSubmit()\"\r\n      [formGroup]=\"scriptForm\">\r\n    <mat-tab-group dynamicHeight>\r\n\r\n        <mat-tab label=\"Script data\">\r\n            <div class=\"mat-elevation-z4\">\r\n                <script-data-form [scriptForm]=\"scriptForm\"\r\n                                  [includeNote]=\"includeNote\"></script-data-form>\r\n            </div>\r\n        </mat-tab>\r\n\r\n        <mat-tab label=\"Tags\">\r\n            <div class=\"mat-elevation-z4\">\r\n                <tag-form [scriptForm]=\"scriptForm\"></tag-form>\r\n            </div>\r\n        </mat-tab>\r\n\r\n        <mat-tab label=\"Parameters\">\r\n            <div class=\"mat-elevation-z4\">\r\n                <app-parameters-form *ngIf=\"editMode\"></app-parameters-form>\r\n            </div>\r\n        </mat-tab>\r\n\r\n    </mat-tab-group>\r\n    \r\n    <button mat-stroked-button\r\n            color=\"accent\"\r\n            *ngIf=\"!editMode\"\r\n            type=\"submit\"\r\n            [disabled]=\"!scriptForm.valid\"\r\n            class=\"mt-3 ml-3\">\r\n        Add Script\r\n    </button>\r\n    <button mat-stroked-button\r\n            color=\"accent\"\r\n            *ngIf=\"editMode\"\r\n            type=\"submit\"\r\n            [disabled]=\"!scriptForm.valid\"\r\n            class=\"mt-3 ml-3\">\r\n        Update Script\r\n    </button>\r\n</form>\r\n\r\n"

/***/ }),

/***/ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.html":
/*!***************************************************************************************************************************!*\
  !*** ../node_modules/raw-loader!./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.html ***!
  \***************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field class=\"w-75 m-2\">\r\n    <mat-chip-list #chipList>\r\n        <mat-chip *ngFor=\"let tagForm of scriptTags.controls\"\r\n                  [selectable]=\"selectable\"\r\n                  [removable]=\"removable\"\r\n                  (removed)=\"remove(tagForm)\">\r\n            {{tagForm.value.name}}\r\n            <span matChipRemove\r\n                  *ngIf=\"removable\"\r\n                  class=\"fa fa-remove\"></span>\r\n        </mat-chip>\r\n        <input placeholder=\"Add new tags\"\r\n               #tagInput\r\n               [attr.disabled]=\"scriptTags.controls.length > 5 || null\"\r\n               [formControl]=\"tagCtrl\"\r\n               [matAutocomplete]=\"auto\"\r\n               [matChipInputFor]=\"chipList\"\r\n               [matChipInputSeparatorKeyCodes]=\"separatorKeysCodes\"\r\n               [matChipInputAddOnBlur]=\"addOnBlur\"\r\n               (matChipInputTokenEnd)=\"add($event)\">\r\n    </mat-chip-list>\r\n    <mat-autocomplete #auto=\"matAutocomplete\" \r\n                      (optionSelected)=\"selected($event)\">\r\n        <mat-option *ngFor=\"let tag of filteredTags | async\"\r\n                    [value]=\"tag.name\">\r\n            {{tag.name}}\r\n        </mat-option>\r\n    </mat-autocomplete>\r\n</mat-form-field>"

/***/ }),

/***/ "./$$_lazy_route_resource lazy recursive":
/*!******************************************************!*\
  !*** ./$$_lazy_route_resource lazy namespace object ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./app/app-routing.module.ts":
/*!***********************************!*\
  !*** ./app/app-routing.module.ts ***!
  \***********************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_home_home_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/home/home.component */ "./app/components/home/home.component.ts");
/* harmony import */ var _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/about-me/about-me.component */ "./app/components/about-me/about-me.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var routes = [
    { path: 'home', component: _components_home_home_component__WEBPACK_IMPORTED_MODULE_2__["HomeComponent"] },
    { path: 'about', component: _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_3__["AboutMeComponent"] },
    { path: '**', component: _components_home_home_component__WEBPACK_IMPORTED_MODULE_2__["HomeComponent"] }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]],
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "./app/app.component.css":
/*!*******************************!*\
  !*** ./app/app.component.css ***!
  \*******************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvYXBwLmNvbXBvbmVudC5jc3MifQ== */"

/***/ }),

/***/ "./app/app.component.ts":
/*!******************************!*\
  !*** ./app/app.component.ts ***!
  \******************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'Build IT';
        this.subtitle = 'Site with civil engineering calculators';
    }
    AppComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! raw-loader!./app.component.html */ "../node_modules/raw-loader/index.js!./app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./app/app.module.ts":
/*!***************************!*\
  !*** ./app/app.module.ts ***!
  \***************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "../node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/platform-browser/animations */ "../node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./app-routing.module */ "./app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./app.component */ "./app/app.component.ts");
/* harmony import */ var _components_nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/nav-menu/nav-menu.component */ "./app/components/nav-menu/nav-menu.component.ts");
/* harmony import */ var _components_home_home_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/home/home.component */ "./app/components/home/home.component.ts");
/* harmony import */ var _components_carousel_carousel_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./components/carousel/carousel.component */ "./app/components/carousel/carousel.component.ts");
/* harmony import */ var _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./components/about-me/about-me.component */ "./app/components/about-me/about-me.component.ts");
/* harmony import */ var _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./common/errors/app-error-handler */ "./app/common/errors/app-error-handler.ts");
/* harmony import */ var _modules_loads_loads_routing_module__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./modules/loads/loads-routing.module */ "./app/modules/loads/loads-routing.module.ts");
/* harmony import */ var _modules_loads_loads_module__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./modules/loads/loads.module */ "./app/modules/loads/loads.module.ts");
/* harmony import */ var _modules_script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./modules/script-interpreter/script-interpreter.module */ "./app/modules/script-interpreter/script-interpreter.module.ts");
/* harmony import */ var _modules_script_interpreter_script_interpreter_routing_module__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./modules/script-interpreter/script-interpreter-routing.module */ "./app/modules/script-interpreter/script-interpreter-routing.module.ts");
/* harmony import */ var _modules_md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./modules/md-components-module/md-components.module */ "./app/modules/md-components-module/md-components.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

















var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_6__["AppComponent"],
                _components_nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_7__["NavMenuComponent"],
                _components_home_home_component__WEBPACK_IMPORTED_MODULE_8__["HomeComponent"],
                _components_carousel_carousel_component__WEBPACK_IMPORTED_MODULE_9__["CarouselComponent"],
                _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_10__["AboutMeComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"].withServerTransition({ appId: 'ng-cli-universal' }),
                _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                _modules_script_interpreter_script_interpreter_routing_module__WEBPACK_IMPORTED_MODULE_15__["ScriptInterpreterRoutingModule"],
                _modules_loads_loads_routing_module__WEBPACK_IMPORTED_MODULE_12__["LoadsRoutingModule"],
                _app_routing_module__WEBPACK_IMPORTED_MODULE_5__["AppRoutingModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__["BrowserAnimationsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
                _modules_script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_14__["ScriptInterpreterModule"],
                _modules_loads_loads_module__WEBPACK_IMPORTED_MODULE_13__["LoadsModule"],
                _modules_md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_16__["MdComponentsModule"]
            ],
            providers: [
                { provide: _angular_core__WEBPACK_IMPORTED_MODULE_1__["ErrorHandler"], useClass: _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_11__["AppErrorHandler"] }
            ],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_6__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./app/common/errors/app-error-handler.ts":
/*!************************************************!*\
  !*** ./app/common/errors/app-error-handler.ts ***!
  \************************************************/
/*! exports provided: AppErrorHandler */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppErrorHandler", function() { return AppErrorHandler; });
var AppErrorHandler = /** @class */ (function () {
    function AppErrorHandler() {
    }
    AppErrorHandler.prototype.handleError = function (error) {
        // alert("An unexpected error occurred.");
        console.log(error);
    };
    return AppErrorHandler;
}());



/***/ }),

/***/ "./app/common/errors/app-error-state-matcher.ts":
/*!******************************************************!*\
  !*** ./app/common/errors/app-error-state-matcher.ts ***!
  \******************************************************/
/*! exports provided: AppErrorStateMatcher */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppErrorStateMatcher", function() { return AppErrorStateMatcher; });
var AppErrorStateMatcher = /** @class */ (function () {
    function AppErrorStateMatcher() {
    }
    AppErrorStateMatcher.prototype.isErrorState = function (control, form) {
        var isSubmitted = form && form.submitted;
        return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
    };
    return AppErrorStateMatcher;
}());



/***/ }),

/***/ "./app/common/errors/app-error.ts":
/*!****************************************!*\
  !*** ./app/common/errors/app-error.ts ***!
  \****************************************/
/*! exports provided: AppError */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppError", function() { return AppError; });
var AppError = /** @class */ (function () {
    function AppError(originalError) {
        this.originalError = originalError;
    }
    return AppError;
}());



/***/ }),

/***/ "./app/common/errors/bad-input-error.ts":
/*!**********************************************!*\
  !*** ./app/common/errors/bad-input-error.ts ***!
  \**********************************************/
/*! exports provided: BadInputError */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BadInputError", function() { return BadInputError; });
/* harmony import */ var _app_error__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-error */ "./app/common/errors/app-error.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var BadInputError = /** @class */ (function (_super) {
    __extends(BadInputError, _super);
    function BadInputError(originalError) {
        var _this = _super.call(this, originalError) || this;
        _this.originalError = originalError;
        return _this;
    }
    return BadInputError;
}(_app_error__WEBPACK_IMPORTED_MODULE_0__["AppError"]));



/***/ }),

/***/ "./app/common/errors/not-found-error.ts":
/*!**********************************************!*\
  !*** ./app/common/errors/not-found-error.ts ***!
  \**********************************************/
/*! exports provided: NotFoundError */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NotFoundError", function() { return NotFoundError; });
/* harmony import */ var _app_error__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-error */ "./app/common/errors/app-error.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var NotFoundError = /** @class */ (function (_super) {
    __extends(NotFoundError, _super);
    function NotFoundError(originalError) {
        var _this = _super.call(this, originalError) || this;
        _this.originalError = originalError;
        return _this;
    }
    return NotFoundError;
}(_app_error__WEBPACK_IMPORTED_MODULE_0__["AppError"]));



/***/ }),

/***/ "./app/components/about-me/about-me.component.scss":
/*!*********************************************************!*\
  !*** ./app/components/about-me/about-me.component.scss ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".carousel-caption {\n  background-color: #45454590;\n  padding: 1em;\n  padding-bottom: 1.5em;\n  border-radius: 30px;\n}\n\nimg {\n  box-shadow: 10px 5px 5px black;\n  border: 1px solid black;\n  margin-bottom: 5px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9jb21wb25lbnRzL2Fib3V0LW1lL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL2FwcFxcY29tcG9uZW50c1xcYWJvdXQtbWVcXGFib3V0LW1lLmNvbXBvbmVudC5zY3NzIiwiYXBwL2NvbXBvbmVudHMvYWJvdXQtbWUvYWJvdXQtbWUuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0E7RUFDSSwyQkFBQTtFQUNBLFlBQUE7RUFDQSxxQkFBQTtFQUNBLG1CQUFBO0FDQUo7O0FER0E7RUFDSSw4QkFBQTtFQUNBLHVCQUFBO0VBQ0Esa0JBQUE7QUNBSiIsImZpbGUiOiJhcHAvY29tcG9uZW50cy9hYm91dC1tZS9hYm91dC1tZS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxyXG4uY2Fyb3VzZWwtY2FwdGlvbiB7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiAjNDU0NTQ1OTA7XHJcbiAgICBwYWRkaW5nOiAxZW07XHJcbiAgICBwYWRkaW5nLWJvdHRvbTogMS41ZW07XHJcbiAgICBib3JkZXItcmFkaXVzOiAzMHB4O1xyXG59XHJcblxyXG5pbWcge1xyXG4gICAgYm94LXNoYWRvdzogMTBweCA1cHggNXB4IGJsYWNrO1xyXG4gICAgYm9yZGVyOiAxcHggc29saWQgYmxhY2s7XHJcbiAgICBtYXJnaW4tYm90dG9tOjVweDtcclxufSIsIi5jYXJvdXNlbC1jYXB0aW9uIHtcbiAgYmFja2dyb3VuZC1jb2xvcjogIzQ1NDU0NTkwO1xuICBwYWRkaW5nOiAxZW07XG4gIHBhZGRpbmctYm90dG9tOiAxLjVlbTtcbiAgYm9yZGVyLXJhZGl1czogMzBweDtcbn1cblxuaW1nIHtcbiAgYm94LXNoYWRvdzogMTBweCA1cHggNXB4IGJsYWNrO1xuICBib3JkZXI6IDFweCBzb2xpZCBibGFjaztcbiAgbWFyZ2luLWJvdHRvbTogNXB4O1xufSJdfQ== */"

/***/ }),

/***/ "./app/components/about-me/about-me.component.ts":
/*!*******************************************************!*\
  !*** ./app/components/about-me/about-me.component.ts ***!
  \*******************************************************/
/*! exports provided: AboutMeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AboutMeComponent", function() { return AboutMeComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var AboutMeComponent = /** @class */ (function () {
    function AboutMeComponent() {
    }
    AboutMeComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-about-me',
            template: __webpack_require__(/*! raw-loader!./about-me.component.html */ "../node_modules/raw-loader/index.js!./app/components/about-me/about-me.component.html"),
            styles: [__webpack_require__(/*! ./about-me.component.scss */ "./app/components/about-me/about-me.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], AboutMeComponent);
    return AboutMeComponent;
}());



/***/ }),

/***/ "./app/components/carousel/carousel.component.css":
/*!********************************************************!*\
  !*** ./app/components/carousel/carousel.component.css ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n.carousel-caption {\r\n    background-color: #45454590;\r\n    padding: 1em;\r\n    padding-bottom: 1.5em;\r\n    border-radius: 30px;\r\n}\r\n\r\nimg {\r\n    box-shadow: 10px 5px 5px black;\r\n    border: 1px solid black;\r\n    margin-bottom: 5px;\r\n}\r\n\r\n.link {\r\n    cursor: pointer;\r\n}\r\n\r\n.link:hover > img {\r\n        box-shadow: 10px 5px 5px gray;\r\n        border: 1px solid gray;\r\n    }\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9jb21wb25lbnRzL2Nhcm91c2VsL2Nhcm91c2VsLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IjtBQUNBO0lBQ0ksMkJBQTJCO0lBQzNCLFlBQVk7SUFDWixxQkFBcUI7SUFDckIsbUJBQW1CO0FBQ3ZCOztBQUVBO0lBQ0ksOEJBQThCO0lBQzlCLHVCQUF1QjtJQUN2QixrQkFBa0I7QUFDdEI7O0FBRUE7SUFDSSxlQUFlO0FBQ25COztBQUVJO1FBQ0ksNkJBQTZCO1FBQzdCLHNCQUFzQjtJQUMxQiIsImZpbGUiOiJhcHAvY29tcG9uZW50cy9jYXJvdXNlbC9jYXJvdXNlbC5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiXHJcbi5jYXJvdXNlbC1jYXB0aW9uIHtcclxuICAgIGJhY2tncm91bmQtY29sb3I6ICM0NTQ1NDU5MDtcclxuICAgIHBhZGRpbmc6IDFlbTtcclxuICAgIHBhZGRpbmctYm90dG9tOiAxLjVlbTtcclxuICAgIGJvcmRlci1yYWRpdXM6IDMwcHg7XHJcbn1cclxuXHJcbmltZyB7XHJcbiAgICBib3gtc2hhZG93OiAxMHB4IDVweCA1cHggYmxhY2s7XHJcbiAgICBib3JkZXI6IDFweCBzb2xpZCBibGFjaztcclxuICAgIG1hcmdpbi1ib3R0b206IDVweDtcclxufVxyXG5cclxuLmxpbmsge1xyXG4gICAgY3Vyc29yOiBwb2ludGVyO1xyXG59XHJcblxyXG4gICAgLmxpbms6aG92ZXIgPiBpbWcge1xyXG4gICAgICAgIGJveC1zaGFkb3c6IDEwcHggNXB4IDVweCBncmF5O1xyXG4gICAgICAgIGJvcmRlcjogMXB4IHNvbGlkIGdyYXk7XHJcbiAgICB9XHJcbiJdfQ== */"

/***/ }),

/***/ "./app/components/carousel/carousel.component.ts":
/*!*******************************************************!*\
  !*** ./app/components/carousel/carousel.component.ts ***!
  \*******************************************************/
/*! exports provided: CarouselComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CarouselComponent", function() { return CarouselComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var CarouselComponent = /** @class */ (function () {
    function CarouselComponent() {
    }
    CarouselComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-carousel',
            template: __webpack_require__(/*! raw-loader!./carousel.component.html */ "../node_modules/raw-loader/index.js!./app/components/carousel/carousel.component.html"),
            styles: [__webpack_require__(/*! ./carousel.component.css */ "./app/components/carousel/carousel.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], CarouselComponent);
    return CarouselComponent;
}());



/***/ }),

/***/ "./app/components/home/home.component.css":
/*!************************************************!*\
  !*** ./app/components/home/home.component.css ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvY29tcG9uZW50cy9ob21lL2hvbWUuY29tcG9uZW50LmNzcyJ9 */"

/***/ }),

/***/ "./app/components/home/home.component.ts":
/*!***********************************************!*\
  !*** ./app/components/home/home.component.ts ***!
  \***********************************************/
/*! exports provided: HomeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeComponent", function() { return HomeComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var HomeComponent = /** @class */ (function () {
    function HomeComponent() {
    }
    HomeComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-home',
            template: __webpack_require__(/*! raw-loader!./home.component.html */ "../node_modules/raw-loader/index.js!./app/components/home/home.component.html"),
            styles: [__webpack_require__(/*! ./home.component.css */ "./app/components/home/home.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], HomeComponent);
    return HomeComponent;
}());



/***/ }),

/***/ "./app/components/nav-menu/nav-menu.component.css":
/*!********************************************************!*\
  !*** ./app/components/nav-menu/nav-menu.component.css ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvY29tcG9uZW50cy9uYXYtbWVudS9uYXYtbWVudS5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./app/components/nav-menu/nav-menu.component.ts":
/*!*******************************************************!*\
  !*** ./app/components/nav-menu/nav-menu.component.ts ***!
  \*******************************************************/
/*! exports provided: NavMenuComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavMenuComponent", function() { return NavMenuComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var NavMenuComponent = /** @class */ (function () {
    function NavMenuComponent() {
    }
    NavMenuComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-nav-menu',
            template: __webpack_require__(/*! raw-loader!./nav-menu.component.html */ "../node_modules/raw-loader/index.js!./app/components/nav-menu/nav-menu.component.html"),
            styles: [__webpack_require__(/*! ./nav-menu.component.css */ "./app/components/nav-menu/nav-menu.component.css")]
        })
    ], NavMenuComponent);
    return NavMenuComponent;
}());



/***/ }),

/***/ "./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.scss":
/*!***********************************************************************************************************************!*\
  !*** ./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.scss ***!
  \***********************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto;\n}\n\ntr.additions-hidden {\n  height: 0;\n}\n\ntr.summary-hidden {\n  display: none;\n}\n\ntr.fa-reorder {\n  cursor: -webkit-grab;\n  cursor: grab;\n}\n\n.scroll-horizontal {\n  overflow-x: auto;\n}\n\n/*.cdk-drag-preview {\n    box-sizing: border-box;\n    border-radius: 4px;\n    box-shadow: 0 5px 5px -3px rgba(0, 0, 0, 0.2), 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12);\n}\n\n.cdk-drag-animating {\n    transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n}\n\n.example-box:last-child {\n    border: none;\n}\n\n.example-list.cdk-drop-list-dragging .example-box:not(.cdk-drag-placeholder) {\n    transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n}\n\n.example-custom-placeholder {\n    background: #ccc;\n    border: dotted 3px #999;\n    transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n}*/\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvZGVhZC1sb2Fkcy1jb21wb25lbnRzL2RlYWQtbG9hZHMtY2FsY3VsYXRvci9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9hcHBcXG1vZHVsZXNcXGxvYWRzXFxjb21wb25lbnRzXFxkZWFkLWxvYWRzLWNvbXBvbmVudHNcXGRlYWQtbG9hZHMtY2FsY3VsYXRvclxcZGVhZC1sb2Fkcy1jYWxjdWxhdG9yLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvbG9hZHMvY29tcG9uZW50cy9kZWFkLWxvYWRzLWNvbXBvbmVudHMvZGVhZC1sb2Fkcy1jYWxjdWxhdG9yL2RlYWQtbG9hZHMtY2FsY3VsYXRvci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGlCQUFBO0VBQ0Esa0JBQUE7QUNDSjs7QURFQTtFQUNJLFNBQUE7QUNDSjs7QURFQTtFQUNJLGFBQUE7QUNDSjs7QURFQTtFQUNJLG9CQUFBO0VBQUEsWUFBQTtBQ0NKOztBREVBO0VBQ0ksZ0JBQUE7QUNDSjs7QURFQTs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztFQUFBIiwiZmlsZSI6ImFwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvZGVhZC1sb2Fkcy1jb21wb25lbnRzL2RlYWQtbG9hZHMtY2FsY3VsYXRvci9kZWFkLWxvYWRzLWNhbGN1bGF0b3IuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJ0YWJsZS5jZW50ZXIge1xyXG4gICAgbWFyZ2luLWxlZnQ6IGF1dG87XHJcbiAgICBtYXJnaW4tcmlnaHQ6IGF1dG87XHJcbn1cclxuXHJcbnRyLmFkZGl0aW9ucy1oaWRkZW4ge1xyXG4gICAgaGVpZ2h0OiAwO1xyXG59XHJcblxyXG50ci5zdW1tYXJ5LWhpZGRlbiB7XHJcbiAgICBkaXNwbGF5OiBub25lO1xyXG59XHJcblxyXG50ci5mYS1yZW9yZGVye1xyXG4gICAgY3Vyc29yOiBncmFiO1xyXG59XHJcblxyXG4uc2Nyb2xsLWhvcml6b250YWwge1xyXG4gICAgb3ZlcmZsb3cteDogYXV0bztcclxufVxyXG5cclxuLyouY2RrLWRyYWctcHJldmlldyB7XHJcbiAgICBib3gtc2l6aW5nOiBib3JkZXItYm94O1xyXG4gICAgYm9yZGVyLXJhZGl1czogNHB4O1xyXG4gICAgYm94LXNoYWRvdzogMCA1cHggNXB4IC0zcHggcmdiYSgwLCAwLCAwLCAwLjIpLCAwIDhweCAxMHB4IDFweCByZ2JhKDAsIDAsIDAsIDAuMTQpLCAwIDNweCAxNHB4IDJweCByZ2JhKDAsIDAsIDAsIDAuMTIpO1xyXG59XHJcblxyXG4uY2RrLWRyYWctYW5pbWF0aW5nIHtcclxuICAgIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcclxufVxyXG5cclxuLmV4YW1wbGUtYm94Omxhc3QtY2hpbGQge1xyXG4gICAgYm9yZGVyOiBub25lO1xyXG59XHJcblxyXG4uZXhhbXBsZS1saXN0LmNkay1kcm9wLWxpc3QtZHJhZ2dpbmcgLmV4YW1wbGUtYm94Om5vdCguY2RrLWRyYWctcGxhY2Vob2xkZXIpIHtcclxuICAgIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcclxufVxyXG5cclxuLmV4YW1wbGUtY3VzdG9tLXBsYWNlaG9sZGVyIHtcclxuICAgIGJhY2tncm91bmQ6ICNjY2M7XHJcbiAgICBib3JkZXI6IGRvdHRlZCAzcHggIzk5OTtcclxuICAgIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcclxufSovXHJcbiIsInRhYmxlLmNlbnRlciB7XG4gIG1hcmdpbi1sZWZ0OiBhdXRvO1xuICBtYXJnaW4tcmlnaHQ6IGF1dG87XG59XG5cbnRyLmFkZGl0aW9ucy1oaWRkZW4ge1xuICBoZWlnaHQ6IDA7XG59XG5cbnRyLnN1bW1hcnktaGlkZGVuIHtcbiAgZGlzcGxheTogbm9uZTtcbn1cblxudHIuZmEtcmVvcmRlciB7XG4gIGN1cnNvcjogZ3JhYjtcbn1cblxuLnNjcm9sbC1ob3Jpem9udGFsIHtcbiAgb3ZlcmZsb3cteDogYXV0bztcbn1cblxuLyouY2RrLWRyYWctcHJldmlldyB7XG4gICAgYm94LXNpemluZzogYm9yZGVyLWJveDtcbiAgICBib3JkZXItcmFkaXVzOiA0cHg7XG4gICAgYm94LXNoYWRvdzogMCA1cHggNXB4IC0zcHggcmdiYSgwLCAwLCAwLCAwLjIpLCAwIDhweCAxMHB4IDFweCByZ2JhKDAsIDAsIDAsIDAuMTQpLCAwIDNweCAxNHB4IDJweCByZ2JhKDAsIDAsIDAsIDAuMTIpO1xufVxuXG4uY2RrLWRyYWctYW5pbWF0aW5nIHtcbiAgICB0cmFuc2l0aW9uOiB0cmFuc2Zvcm0gMjUwbXMgY3ViaWMtYmV6aWVyKDAsIDAsIDAuMiwgMSk7XG59XG5cbi5leGFtcGxlLWJveDpsYXN0LWNoaWxkIHtcbiAgICBib3JkZXI6IG5vbmU7XG59XG5cbi5leGFtcGxlLWxpc3QuY2RrLWRyb3AtbGlzdC1kcmFnZ2luZyAuZXhhbXBsZS1ib3g6bm90KC5jZGstZHJhZy1wbGFjZWhvbGRlcikge1xuICAgIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcbn1cblxuLmV4YW1wbGUtY3VzdG9tLXBsYWNlaG9sZGVyIHtcbiAgICBiYWNrZ3JvdW5kOiAjY2NjO1xuICAgIGJvcmRlcjogZG90dGVkIDNweCAjOTk5O1xuICAgIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcbn0qLyJdfQ== */"

/***/ }),

/***/ "./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.ts":
/*!*********************************************************************************************************************!*\
  !*** ./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.ts ***!
  \*********************************************************************************************************************/
/*! exports provided: DeadLoadsCalculatorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsCalculatorComponent", function() { return DeadLoadsCalculatorComponent; });
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "../node_modules/@angular/cdk/esm5/drag-drop.es5.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material_table__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/table */ "../node_modules/@angular/material/esm5/table.es5.js");
/* harmony import */ var _models_dead_loads_material_for_calculations__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../models/dead-loads/material-for-calculations */ "./app/modules/loads/models/dead-loads/material-for-calculations.ts");
/* harmony import */ var _models_dead_loads_units__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../models/dead-loads/units */ "./app/modules/loads/models/dead-loads/units.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var DeadLoadsCalculatorComponent = /** @class */ (function () {
    function DeadLoadsCalculatorComponent() {
        this.selectedMaterials = [];
        this.materialsForCalculationsDisplayedColumns = ['position', 'category', 'name', 'length', 'width', 'thickness', 'minDensity', 'maxDensity', 'unit', 'remove'];
        this.selectedMaterialDataSource = new _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTableDataSource"](this.selectedMaterials);
    }
    ;
    Object.defineProperty(DeadLoadsCalculatorComponent.prototype, "units", {
        get: function () {
            return _models_dead_loads_units__WEBPACK_IMPORTED_MODULE_4__["Units"].loadUnit;
        },
        enumerable: true,
        configurable: true
    });
    DeadLoadsCalculatorComponent.prototype.ngOnInit = function () {
    };
    Object.defineProperty(DeadLoadsCalculatorComponent.prototype, "newMaterial", {
        set: function (material) {
            var _this = this;
            if (material != null)
                this.selectedMaterials.push(material);
            if (this.selectedMaterialTable)
                this.selectedMaterialTable.renderRows();
            this.selectedMaterials.forEach(function (m) { return _this.calculate(m); });
        },
        enumerable: true,
        configurable: true
    });
    DeadLoadsCalculatorComponent.prototype.dropTable = function (event) {
        var prevIndex = this.selectedMaterials.findIndex(function (d) { return d === event.item.data; });
        Object(_angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_0__["moveItemInArray"])(this.selectedMaterials, prevIndex, event.currentIndex);
        this.selectedMaterialTable.renderRows();
    };
    DeadLoadsCalculatorComponent.prototype.ondrag = function () {
        console.log("4");
    };
    DeadLoadsCalculatorComponent.prototype.removeMaterial = function (material) {
        var _this = this;
        var index = this.selectedMaterials.indexOf(material, 0);
        if (index > -1)
            this.selectedMaterials.splice(index, 1);
        this.selectedMaterialTable.renderRows();
        this.selectedMaterials.forEach(function (m) { return _this.calculate(m); });
    };
    DeadLoadsCalculatorComponent.prototype.calculate = function (materialForCalculation) {
        materialForCalculation.calculate();
        this.setSums();
    };
    DeadLoadsCalculatorComponent.prototype.setSums = function () {
        var _this = this;
        this.sumMinimumDeadLoads = 0;
        this.sumMaximumDeadLoads = 0;
        if (this.isUnitsProper()) {
            this.selectedMaterials.forEach(function (m) { return _this.sumMinimumDeadLoads += m.calculatedMinimumLoad; });
            this.selectedMaterials.forEach(function (m) { return _this.sumMaximumDeadLoads += m.calculatedMaximumLoad; });
        }
        else {
            this.sumMinimumDeadLoads = undefined;
            this.sumMaximumDeadLoads = undefined;
        }
    };
    DeadLoadsCalculatorComponent.prototype.isUnitsProper = function () {
        var _this = this;
        return this.selectedMaterials.every(function (m) { return m.unit == _this.selectedMaterials[0].unit; });
    };
    DeadLoadsCalculatorComponent.prototype.additionChecked = function (materialForCalculation, addition) {
        addition.isChecked = !addition.isChecked;
        this.calculate(materialForCalculation);
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewChild"])(_angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTable"], { static: false }),
        __metadata("design:type", _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTable"])
    ], DeadLoadsCalculatorComponent.prototype, "selectedMaterialTable", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        __metadata("design:type", _models_dead_loads_material_for_calculations__WEBPACK_IMPORTED_MODULE_3__["MaterialForCalculations"]),
        __metadata("design:paramtypes", [_models_dead_loads_material_for_calculations__WEBPACK_IMPORTED_MODULE_3__["MaterialForCalculations"]])
    ], DeadLoadsCalculatorComponent.prototype, "newMaterial", null);
    DeadLoadsCalculatorComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-dead-loads-calculator',
            template: __webpack_require__(/*! raw-loader!./dead-loads-calculator.component.html */ "../node_modules/raw-loader/index.js!./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.html"),
            styles: [__webpack_require__(/*! ./dead-loads-calculator.component.scss */ "./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], DeadLoadsCalculatorComponent);
    return DeadLoadsCalculatorComponent;
}());



/***/ }),

/***/ "./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.scss":
/*!***********************************************************************************************************!*\
  !*** ./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.scss ***!
  \***********************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto;\n}\n\ntr.additions-hidden {\n  height: 0;\n}\n\ntr.summary-hidden {\n  display: none;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvZGVhZC1sb2Fkcy1jb21wb25lbnRzL2RlYWQtbG9hZHMtZGF0YS9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9hcHBcXG1vZHVsZXNcXGxvYWRzXFxjb21wb25lbnRzXFxkZWFkLWxvYWRzLWNvbXBvbmVudHNcXGRlYWQtbG9hZHMtZGF0YVxcZGVhZC1sb2Fkcy1kYXRhLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvbG9hZHMvY29tcG9uZW50cy9kZWFkLWxvYWRzLWNvbXBvbmVudHMvZGVhZC1sb2Fkcy1kYXRhL2RlYWQtbG9hZHMtZGF0YS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGlCQUFBO0VBQ0Esa0JBQUE7QUNDSjs7QURFQTtFQUNJLFNBQUE7QUNDSjs7QURFQTtFQUNJLGFBQUE7QUNDSiIsImZpbGUiOiJhcHAvbW9kdWxlcy9sb2Fkcy9jb21wb25lbnRzL2RlYWQtbG9hZHMtY29tcG9uZW50cy9kZWFkLWxvYWRzLWRhdGEvZGVhZC1sb2Fkcy1kYXRhLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsidGFibGUuY2VudGVyIHtcclxuICAgIG1hcmdpbi1sZWZ0OiBhdXRvO1xyXG4gICAgbWFyZ2luLXJpZ2h0OiBhdXRvO1xyXG59XHJcblxyXG50ci5hZGRpdGlvbnMtaGlkZGVuIHtcclxuICAgIGhlaWdodDogMDtcclxufVxyXG5cclxudHIuc3VtbWFyeS1oaWRkZW4ge1xyXG4gICAgZGlzcGxheTogbm9uZTtcclxufSIsInRhYmxlLmNlbnRlciB7XG4gIG1hcmdpbi1sZWZ0OiBhdXRvO1xuICBtYXJnaW4tcmlnaHQ6IGF1dG87XG59XG5cbnRyLmFkZGl0aW9ucy1oaWRkZW4ge1xuICBoZWlnaHQ6IDA7XG59XG5cbnRyLnN1bW1hcnktaGlkZGVuIHtcbiAgZGlzcGxheTogbm9uZTtcbn0iXX0= */"

/***/ }),

/***/ "./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.ts":
/*!*********************************************************************************************************!*\
  !*** ./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.ts ***!
  \*********************************************************************************************************/
/*! exports provided: DeadLoadsDataComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsDataComponent", function() { return DeadLoadsDataComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_dead_loads_material_for_calculations__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../models/dead-loads/material-for-calculations */ "./app/modules/loads/models/dead-loads/material-for-calculations.ts");
/* harmony import */ var _models_dead_loads_units__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../models/dead-loads/units */ "./app/modules/loads/models/dead-loads/units.ts");
/* harmony import */ var _services_dead_loads_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../services/dead-loads.service */ "./app/modules/loads/services/dead-loads.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var DeadLoadsDataComponent = /** @class */ (function () {
    // Constructor
    function DeadLoadsDataComponent(deadLoadsService) {
        this.deadLoadsService = deadLoadsService;
        this.materialsDisplayedColumns = ['name', 'minDensity', 'maxDensity', 'unit', 'add'];
        this.materialAdded = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
    }
    Object.defineProperty(DeadLoadsDataComponent.prototype, "units", {
        get: function () {
            return _models_dead_loads_units__WEBPACK_IMPORTED_MODULE_2__["Units"].loadUnit;
        },
        enumerable: true,
        configurable: true
    });
    DeadLoadsDataComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.deadLoadsService.getCategories().subscribe(function (categories) {
            _this.categories = categories;
            console.log("Categories", _this.categories);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsDataComponent.prototype.onCategoryChange = function () {
        var _this = this;
        this.deadLoadsService.getSubcategories(this.selectedCategory.id)
            .subscribe(function (subcategories) {
            _this.subcategories = subcategories.sort(function (subcategory, nextSubcategory) {
                return nextSubcategory.documentName.localeCompare(subcategory.documentName);
            });
            _this.materials = null;
            console.log("Subcategories", _this.subcategories);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsDataComponent.prototype.onSubcategoryChange = function () {
        var _this = this;
        this.deadLoadsService.getMaterials(this.selectedSubcategory.id)
            .subscribe(function (materials) {
            _this.materials = materials;
            console.log("Materials", _this.materials);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsDataComponent.prototype.addMaterial = function (material) {
        var categoryName = this.selectedCategory.name + ' ' + this.selectedSubcategory.name;
        this.materialAdded.emit(new _models_dead_loads_material_for_calculations__WEBPACK_IMPORTED_MODULE_1__["MaterialForCalculations"](categoryName, material));
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], DeadLoadsDataComponent.prototype, "materialAdded", void 0);
    DeadLoadsDataComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-dead-loads-data',
            template: __webpack_require__(/*! raw-loader!./dead-loads-data.component.html */ "../node_modules/raw-loader/index.js!./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.html"),
            styles: [__webpack_require__(/*! ./dead-loads-data.component.scss */ "./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_dead_loads_service__WEBPACK_IMPORTED_MODULE_3__["DeadLoadsService"]])
    ], DeadLoadsDataComponent);
    return DeadLoadsDataComponent;
}());



/***/ }),

/***/ "./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.scss":
/*!*************************************************************************************************!*\
  !*** ./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.scss ***!
  \*************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto;\n}\n\ntr.additions-hidden {\n  height: 0;\n}\n\ntr.summary-hidden {\n  display: none;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvZGVhZC1sb2Fkcy1jb21wb25lbnRzL2RlYWQtbG9hZHMvQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvYXBwXFxtb2R1bGVzXFxsb2Fkc1xcY29tcG9uZW50c1xcZGVhZC1sb2Fkcy1jb21wb25lbnRzXFxkZWFkLWxvYWRzXFxkZWFkLWxvYWRzLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvbG9hZHMvY29tcG9uZW50cy9kZWFkLWxvYWRzLWNvbXBvbmVudHMvZGVhZC1sb2Fkcy9kZWFkLWxvYWRzLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksaUJBQUE7RUFDQSxrQkFBQTtBQ0NKOztBREVBO0VBQ0ksU0FBQTtBQ0NKOztBREVBO0VBQ0ksYUFBQTtBQ0NKIiwiZmlsZSI6ImFwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvZGVhZC1sb2Fkcy1jb21wb25lbnRzL2RlYWQtbG9hZHMvZGVhZC1sb2Fkcy5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbInRhYmxlLmNlbnRlciB7XHJcbiAgICBtYXJnaW4tbGVmdDogYXV0bztcclxuICAgIG1hcmdpbi1yaWdodDogYXV0bztcclxufVxyXG5cclxudHIuYWRkaXRpb25zLWhpZGRlbiB7XHJcbiAgICBoZWlnaHQ6IDA7XHJcbn1cclxuXHJcbnRyLnN1bW1hcnktaGlkZGVuIHtcclxuICAgIGRpc3BsYXk6IG5vbmU7XHJcbn0iLCJ0YWJsZS5jZW50ZXIge1xuICBtYXJnaW4tbGVmdDogYXV0bztcbiAgbWFyZ2luLXJpZ2h0OiBhdXRvO1xufVxuXG50ci5hZGRpdGlvbnMtaGlkZGVuIHtcbiAgaGVpZ2h0OiAwO1xufVxuXG50ci5zdW1tYXJ5LWhpZGRlbiB7XG4gIGRpc3BsYXk6IG5vbmU7XG59Il19 */"

/***/ }),

/***/ "./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts":
/*!***********************************************************************************************!*\
  !*** ./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts ***!
  \***********************************************************************************************/
/*! exports provided: DeadLoadsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsComponent", function() { return DeadLoadsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var DeadLoadsComponent = /** @class */ (function () {
    function DeadLoadsComponent() {
    }
    DeadLoadsComponent.prototype.onMaterialAdded = function (material) {
        this.newMaterial = material;
    };
    DeadLoadsComponent.prototype.ngOnInit = function () {
    };
    DeadLoadsComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-dead-loads',
            template: __webpack_require__(/*! raw-loader!./dead-loads.component.html */ "../node_modules/raw-loader/index.js!./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.html"),
            styles: [__webpack_require__(/*! ./dead-loads.component.scss */ "./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], DeadLoadsComponent);
    return DeadLoadsComponent;
}());



/***/ }),

/***/ "./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.scss":
/*!*************************************************************************************************!*\
  !*** ./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.scss ***!
  \*************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto;\n}\n\ntr.additions-hidden {\n  height: 0;\n}\n\ntr.summary-hidden {\n  display: none;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvc25vdy1sb2Fkcy1jb21wb25lbnRzL3Nub3ctbG9hZHMvQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvYXBwXFxtb2R1bGVzXFxsb2Fkc1xcY29tcG9uZW50c1xcc25vdy1sb2Fkcy1jb21wb25lbnRzXFxzbm93LWxvYWRzXFxzbm93LWxvYWRzLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvbG9hZHMvY29tcG9uZW50cy9zbm93LWxvYWRzLWNvbXBvbmVudHMvc25vdy1sb2Fkcy9zbm93LWxvYWRzLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksaUJBQUE7RUFDQSxrQkFBQTtBQ0NKOztBREVBO0VBQ0ksU0FBQTtBQ0NKOztBREVBO0VBQ0ksYUFBQTtBQ0NKIiwiZmlsZSI6ImFwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvc25vdy1sb2Fkcy1jb21wb25lbnRzL3Nub3ctbG9hZHMvc25vdy1sb2Fkcy5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbInRhYmxlLmNlbnRlciB7XHJcbiAgICBtYXJnaW4tbGVmdDogYXV0bztcclxuICAgIG1hcmdpbi1yaWdodDogYXV0bztcclxufVxyXG5cclxudHIuYWRkaXRpb25zLWhpZGRlbiB7XHJcbiAgICBoZWlnaHQ6IDA7XHJcbn1cclxuXHJcbnRyLnN1bW1hcnktaGlkZGVuIHtcclxuICAgIGRpc3BsYXk6IG5vbmU7XHJcbn0iLCJ0YWJsZS5jZW50ZXIge1xuICBtYXJnaW4tbGVmdDogYXV0bztcbiAgbWFyZ2luLXJpZ2h0OiBhdXRvO1xufVxuXG50ci5hZGRpdGlvbnMtaGlkZGVuIHtcbiAgaGVpZ2h0OiAwO1xufVxuXG50ci5zdW1tYXJ5LWhpZGRlbiB7XG4gIGRpc3BsYXk6IG5vbmU7XG59Il19 */"

/***/ }),

/***/ "./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts":
/*!***********************************************************************************************!*\
  !*** ./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts ***!
  \***********************************************************************************************/
/*! exports provided: SnowLoadsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SnowLoadsComponent", function() { return SnowLoadsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var SnowLoadsComponent = /** @class */ (function () {
    function SnowLoadsComponent() {
        this.loadsGroupFilter = ['Loads'];
        this.loadsTagFilter = ['Snow', 'Load'];
    }
    SnowLoadsComponent.prototype.ngOnInit = function () {
    };
    SnowLoadsComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-snow-loads',
            template: __webpack_require__(/*! raw-loader!./snow-loads.component.html */ "../node_modules/raw-loader/index.js!./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.html"),
            styles: [__webpack_require__(/*! ./snow-loads.component.scss */ "./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], SnowLoadsComponent);
    return SnowLoadsComponent;
}());



/***/ }),

/***/ "./app/modules/loads/loads-routing.module.ts":
/*!***************************************************!*\
  !*** ./app/modules/loads/loads-routing.module.ts ***!
  \***************************************************/
/*! exports provided: LoadsRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoadsRoutingModule", function() { return LoadsRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_dead_loads_components_dead_loads_dead_loads_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads/dead-loads.component */ "./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts");
/* harmony import */ var _components_snow_loads_components_snow_loads_snow_loads_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/snow-loads-components/snow-loads/snow-loads.component */ "./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var routes = [
    { path: 'deadloads', component: _components_dead_loads_components_dead_loads_dead_loads_component__WEBPACK_IMPORTED_MODULE_2__["DeadLoadsComponent"] },
    { path: 'snowloads', component: _components_snow_loads_components_snow_loads_snow_loads_component__WEBPACK_IMPORTED_MODULE_3__["SnowLoadsComponent"] }
];
var LoadsRoutingModule = /** @class */ (function () {
    function LoadsRoutingModule() {
    }
    LoadsRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]],
        })
    ], LoadsRoutingModule);
    return LoadsRoutingModule;
}());



/***/ }),

/***/ "./app/modules/loads/loads.module.ts":
/*!*******************************************!*\
  !*** ./app/modules/loads/loads.module.ts ***!
  \*******************************************/
/*! exports provided: LoadsModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoadsModule", function() { return LoadsModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "../node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _loads_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./loads-routing.module */ "./app/modules/loads/loads-routing.module.ts");
/* harmony import */ var _components_dead_loads_components_dead_loads_calculator_dead_loads_calculator_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component */ "./app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "../node_modules/@angular/cdk/esm5/drag-drop.es5.js");
/* harmony import */ var _components_dead_loads_components_dead_loads_data_dead_loads_data_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads-data/dead-loads-data.component */ "./app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.ts");
/* harmony import */ var _components_dead_loads_components_dead_loads_dead_loads_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads/dead-loads.component */ "./app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/platform-browser/animations */ "../node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../md-components-module/md-components.module */ "./app/modules/md-components-module/md-components.module.ts");
/* harmony import */ var _script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../script-interpreter/script-interpreter.module */ "./app/modules/script-interpreter/script-interpreter.module.ts");
/* harmony import */ var _components_snow_loads_components_snow_loads_snow_loads_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./components/snow-loads-components/snow-loads/snow-loads.component */ "./app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












var LoadsModule = /** @class */ (function () {
    function LoadsModule() {
    }
    LoadsModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _components_dead_loads_components_dead_loads_dead_loads_component__WEBPACK_IMPORTED_MODULE_7__["DeadLoadsComponent"],
                _components_dead_loads_components_dead_loads_calculator_dead_loads_calculator_component__WEBPACK_IMPORTED_MODULE_3__["DeadLoadsCalculatorComponent"],
                _components_dead_loads_components_dead_loads_data_dead_loads_data_component__WEBPACK_IMPORTED_MODULE_6__["DeadLoadsDataComponent"],
                _components_snow_loads_components_snow_loads_snow_loads_component__WEBPACK_IMPORTED_MODULE_11__["SnowLoadsComponent"]
            ],
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _loads_routing_module__WEBPACK_IMPORTED_MODULE_2__["LoadsRoutingModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_4__["FormsModule"],
                _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_9__["MdComponentsModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__["BrowserAnimationsModule"],
                _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_5__["DragDropModule"],
                _script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_10__["ScriptInterpreterModule"]
            ]
        })
    ], LoadsModule);
    return LoadsModule;
}());



/***/ }),

/***/ "./app/modules/loads/models/dead-loads/addition-for-calculations.ts":
/*!**************************************************************************!*\
  !*** ./app/modules/loads/models/dead-loads/addition-for-calculations.ts ***!
  \**************************************************************************/
/*! exports provided: AdditionForCalculations */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdditionForCalculations", function() { return AdditionForCalculations; });
var AdditionForCalculations = /** @class */ (function () {
    function AdditionForCalculations(addition) {
        this.origin = addition;
    }
    return AdditionForCalculations;
}());



/***/ }),

/***/ "./app/modules/loads/models/dead-loads/enums/loadUnit.ts":
/*!***************************************************************!*\
  !*** ./app/modules/loads/models/dead-loads/enums/loadUnit.ts ***!
  \***************************************************************/
/*! exports provided: LoadUnit */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoadUnit", function() { return LoadUnit; });
var LoadUnit;
(function (LoadUnit) {
    LoadUnit[LoadUnit["kilonewton"] = 0] = "kilonewton";
    LoadUnit[LoadUnit["kilonewton_per_meter"] = 1] = "kilonewton_per_meter";
    LoadUnit[LoadUnit["kilonewton_per_square_meter"] = 2] = "kilonewton_per_square_meter";
    LoadUnit[LoadUnit["kilonewton_per_cubic_meter"] = 3] = "kilonewton_per_cubic_meter";
})(LoadUnit || (LoadUnit = {}));


/***/ }),

/***/ "./app/modules/loads/models/dead-loads/material-for-calculations.ts":
/*!**************************************************************************!*\
  !*** ./app/modules/loads/models/dead-loads/material-for-calculations.ts ***!
  \**************************************************************************/
/*! exports provided: MaterialForCalculations */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MaterialForCalculations", function() { return MaterialForCalculations; });
/* harmony import */ var _addition_for_calculations__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./addition-for-calculations */ "./app/modules/loads/models/dead-loads/addition-for-calculations.ts");

var MaterialForCalculations = /** @class */ (function () {
    function MaterialForCalculations(categoryName, material) {
        var _this = this;
        this.additions = [];
        this.categoryName = categoryName;
        this.material = material;
        this.unit = this.material.unit;
        this.material.additions.forEach(function (a) { return _this.additions.push(new _addition_for_calculations__WEBPACK_IMPORTED_MODULE_0__["AdditionForCalculations"](a)); });
    }
    MaterialForCalculations.prototype.calculate = function () {
        var length = 1;
        var width = 1;
        var thickness = 1;
        this.unit = this.material.unit;
        if (this.length != undefined) {
            length = this.length / 100;
            this.unit -= 1;
        }
        if (this.width != undefined) {
            width = this.width / 100;
            this.unit -= 1;
        }
        if (this.thickness != undefined) {
            thickness = this.thickness / 100;
            this.unit -= 1;
        }
        var addition = 0;
        this.additions.filter(function (a) { return a.isChecked; })
            .forEach(function (a) { return addition += a.origin.value; });
        this.calculatedMinimumLoad =
            (this.material.minimumDensity + addition)
                * length * width * thickness;
        this.calculatedMaximumLoad =
            (this.material.maximumDensity + addition)
                * length * width * thickness;
    };
    return MaterialForCalculations;
}());



/***/ }),

/***/ "./app/modules/loads/models/dead-loads/units.ts":
/*!******************************************************!*\
  !*** ./app/modules/loads/models/dead-loads/units.ts ***!
  \******************************************************/
/*! exports provided: Units */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Units", function() { return Units; });
/* harmony import */ var _enums_loadUnit__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./enums/loadUnit */ "./app/modules/loads/models/dead-loads/enums/loadUnit.ts");

var Units = /** @class */ (function () {
    function Units() {
    }
    Units.loadUnit = [
        { key: _enums_loadUnit__WEBPACK_IMPORTED_MODULE_0__["LoadUnit"].kilonewton, value: 'kN' },
        { key: _enums_loadUnit__WEBPACK_IMPORTED_MODULE_0__["LoadUnit"].kilonewton_per_meter, value: 'kN/m' },
        { key: _enums_loadUnit__WEBPACK_IMPORTED_MODULE_0__["LoadUnit"].kilonewton_per_square_meter, value: 'kN/m<sup>2</sup>' },
        { key: _enums_loadUnit__WEBPACK_IMPORTED_MODULE_0__["LoadUnit"].kilonewton_per_cubic_meter, value: 'kN/m<sup>3</sup>' },
    ];
    return Units;
}());



/***/ }),

/***/ "./app/modules/loads/services/dead-loads.service.ts":
/*!**********************************************************!*\
  !*** ./app/modules/loads/services/dead-loads.service.ts ***!
  \**********************************************************/
/*! exports provided: DeadLoadsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsService", function() { return DeadLoadsService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var DeadLoadsService = /** @class */ (function () {
    function DeadLoadsService(http) {
        this.http = http;
    }
    DeadLoadsService.prototype.getCategories = function () {
        return this.http.get('/api/deadloads');
    };
    DeadLoadsService.prototype.getSubcategories = function (categoryId) {
        return this.http.get('/api/deadloads/' + categoryId + '/subcategories');
    };
    DeadLoadsService.prototype.getMaterials = function (subcategoryId) {
        return this.http.get('/api/deadloads/' + subcategoryId + '/materials');
    };
    DeadLoadsService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], DeadLoadsService);
    return DeadLoadsService;
}());



/***/ }),

/***/ "./app/modules/md-components-module/md-components.module.ts":
/*!******************************************************************!*\
  !*** ./app/modules/md-components-module/md-components.module.ts ***!
  \******************************************************************/
/*! exports provided: MdComponentsModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MdComponentsModule", function() { return MdComponentsModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "../node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_material_select__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/select */ "../node_modules/@angular/material/esm5/select.es5.js");
/* harmony import */ var _angular_material_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/table */ "../node_modules/@angular/material/esm5/table.es5.js");
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/button */ "../node_modules/@angular/material/esm5/button.es5.js");
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/input */ "../node_modules/@angular/material/esm5/input.es5.js");
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/material/checkbox */ "../node_modules/@angular/material/esm5/checkbox.es5.js");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "../node_modules/@angular/cdk/esm5/drag-drop.es5.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/platform-browser/animations */ "../node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _angular_material_card__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/card */ "../node_modules/@angular/material/esm5/card.es5.js");
/* harmony import */ var _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/material/autocomplete */ "../node_modules/@angular/material/esm5/autocomplete.es5.js");
/* harmony import */ var _angular_material_progress_bar__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/material/progress-bar */ "../node_modules/@angular/material/esm5/progress-bar.es5.js");
/* harmony import */ var _angular_material_radio__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/material/radio */ "../node_modules/@angular/material/esm5/radio.es5.js");
/* harmony import */ var _angular_material_expansion__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @angular/material/expansion */ "../node_modules/@angular/material/esm5/expansion.es5.js");
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/material/list */ "../node_modules/@angular/material/esm5/list.es5.js");
/* harmony import */ var _angular_material_tabs__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/material/tabs */ "../node_modules/@angular/material/esm5/tabs.es5.js");
/* harmony import */ var _angular_material_chips__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/material/chips */ "../node_modules/@angular/material/esm5/chips.es5.js");
/* harmony import */ var _angular_material_toolbar__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! @angular/material/toolbar */ "../node_modules/@angular/material/esm5/toolbar.es5.js");
/* harmony import */ var _angular_material_paginator__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @angular/material/paginator */ "../node_modules/@angular/material/esm5/paginator.es5.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! @angular/platform-browser */ "../node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! @angular/material/dialog */ "../node_modules/@angular/material/esm5/dialog.es5.js");
/* harmony import */ var _angular_material_tooltip__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! @angular/material/tooltip */ "../node_modules/@angular/material/esm5/tooltip.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






















var MdComponentsModule = /** @class */ (function () {
    function MdComponentsModule() {
    }
    MdComponentsModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [],
            exports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _angular_material_select__WEBPACK_IMPORTED_MODULE_2__["MatSelectModule"],
                _angular_material_table__WEBPACK_IMPORTED_MODULE_3__["MatTableModule"],
                _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButtonModule"],
                _angular_material_input__WEBPACK_IMPORTED_MODULE_5__["MatInputModule"],
                _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_6__["MatCheckboxModule"],
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_19__["BrowserModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__["BrowserAnimationsModule"],
                _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_7__["DragDropModule"],
                _angular_material_card__WEBPACK_IMPORTED_MODULE_9__["MatCardModule"],
                _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_10__["MatAutocompleteModule"],
                _angular_material_progress_bar__WEBPACK_IMPORTED_MODULE_11__["MatProgressBarModule"],
                _angular_material_radio__WEBPACK_IMPORTED_MODULE_12__["MatRadioModule"],
                _angular_material_expansion__WEBPACK_IMPORTED_MODULE_13__["MatExpansionModule"],
                _angular_material_list__WEBPACK_IMPORTED_MODULE_14__["MatListModule"],
                _angular_material_tabs__WEBPACK_IMPORTED_MODULE_15__["MatTabsModule"],
                _angular_material_chips__WEBPACK_IMPORTED_MODULE_16__["MatChipsModule"],
                _angular_material_toolbar__WEBPACK_IMPORTED_MODULE_17__["MatToolbarModule"],
                _angular_material_paginator__WEBPACK_IMPORTED_MODULE_18__["MatPaginatorModule"],
                _angular_material_dialog__WEBPACK_IMPORTED_MODULE_20__["MatDialogModule"],
                _angular_material_tooltip__WEBPACK_IMPORTED_MODULE_21__["MatTooltipModule"]
            ]
        })
    ], MdComponentsModule);
    return MdComponentsModule;
}());



/***/ }),

/***/ "./app/modules/pipes-module/pipes.module.ts":
/*!**************************************************!*\
  !*** ./app/modules/pipes-module/pipes.module.ts ***!
  \**************************************************/
/*! exports provided: PipesModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PipesModule", function() { return PipesModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _text_pipes_html_pipe__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./text-pipes/html-pipe */ "./app/modules/pipes-module/text-pipes/html-pipe.ts");
/* harmony import */ var _text_pipes_toNumber_pipe__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./text-pipes/toNumber-pipe */ "./app/modules/pipes-module/text-pipes/toNumber-pipe.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var PipesModule = /** @class */ (function () {
    function PipesModule() {
    }
    PipesModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _text_pipes_html_pipe__WEBPACK_IMPORTED_MODULE_1__["HtmlPipe"],
                _text_pipes_toNumber_pipe__WEBPACK_IMPORTED_MODULE_2__["ToNumberPipe"]
            ],
            imports: [],
            exports: [
                _text_pipes_html_pipe__WEBPACK_IMPORTED_MODULE_1__["HtmlPipe"],
                _text_pipes_toNumber_pipe__WEBPACK_IMPORTED_MODULE_2__["ToNumberPipe"]
            ]
        })
    ], PipesModule);
    return PipesModule;
}());



/***/ }),

/***/ "./app/modules/pipes-module/text-pipes/html-pipe.ts":
/*!**********************************************************!*\
  !*** ./app/modules/pipes-module/text-pipes/html-pipe.ts ***!
  \**********************************************************/
/*! exports provided: HtmlPipe */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HtmlPipe", function() { return HtmlPipe; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

//@NgModule({})
var HtmlPipe = /** @class */ (function () {
    function HtmlPipe() {
    }
    HtmlPipe.prototype.transform = function (html) {
        if (!html)
            return "";
        var finalHtml = "";
        var inSubScript = false;
        var inSupScript = false;
        for (var i = 0; i < html.length; i++) {
            if (html[i] == "_" && !inSubScript) {
                finalHtml += "<sub>";
                inSubScript = true;
            }
            else if (html[i] == "_" && inSubScript) {
                finalHtml += "</sub>";
                inSubScript = false;
            }
            else if (html[i] == "^" && !inSupScript) {
                finalHtml += "<sup>";
                inSupScript = true;
            }
            else if (html[i] == "^" && inSupScript) {
                finalHtml += "</sup>";
                inSupScript = false;
            }
            else
                finalHtml += html[i];
        }
        return finalHtml;
    };
    HtmlPipe = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Pipe"])({ name: 'html' })
    ], HtmlPipe);
    return HtmlPipe;
}());



/***/ }),

/***/ "./app/modules/pipes-module/text-pipes/toNumber-pipe.ts":
/*!**************************************************************!*\
  !*** ./app/modules/pipes-module/text-pipes/toNumber-pipe.ts ***!
  \**************************************************************/
/*! exports provided: ToNumberPipe */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ToNumberPipe", function() { return ToNumberPipe; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var ToNumberPipe = /** @class */ (function () {
    function ToNumberPipe() {
    }
    ToNumberPipe.prototype.transform = function (value) {
        return parseFloat(value.replace(',', '.'));
    };
    ToNumberPipe = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Pipe"])({ name: 'toNumber' })
    ], ToNumberPipe);
    return ToNumberPipe;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.scss":
/*!*****************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.scss ***!
  \*****************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n  position: relative;\n  top: -1.4em;\n  max-width: 205px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvYXV0b2NvbXBsZXRlL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL2FwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FsY3VsYXRvclxccGFyYW1ldGVyLWlucHV0c1xcYXV0b2NvbXBsZXRlXFxwYXJhbWV0ZXItYXV0b2NvbXBsZXRlLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9hdXRvY29tcGxldGUvcGFyYW1ldGVyLWF1dG9jb21wbGV0ZS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLCtCQUFBO0VBQ0EsZ0JBQUE7RUFDQSxrQkFBQTtFQUNBLFdBQUE7RUFDQSxnQkFBQTtBQ0NKIiwiZmlsZSI6ImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvYXV0b2NvbXBsZXRlL3BhcmFtZXRlci1hdXRvY29tcGxldGUuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJwLnBhcmFtZXRlci1kZXNjcmlwdGlvbiB7XHJcbiAgICBjb2xvcjogcmdiYSgyNTUsMjU1LDI1NSwuNyk7XHJcbiAgICBmb250LXNpemU6IDg3LjUlO1xyXG4gICAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG4gICAgdG9wOiAtMS40ZW07XHJcbiAgICBtYXgtd2lkdGg6IDIwNXB4O1xyXG59XHJcbiIsInAucGFyYW1ldGVyLWRlc2NyaXB0aW9uIHtcbiAgY29sb3I6IHJnYmEoMjU1LCAyNTUsIDI1NSwgMC43KTtcbiAgZm9udC1zaXplOiA4Ny41JTtcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xuICB0b3A6IC0xLjRlbTtcbiAgbWF4LXdpZHRoOiAyMDVweDtcbn0iXX0= */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.ts":
/*!***************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.ts ***!
  \***************************************************************************************************************************************/
/*! exports provided: ParameterAutocompleteComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterAutocompleteComponent", function() { return ParameterAutocompleteComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "../node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var ParameterAutocompleteComponent = /** @class */ (function () {
    function ParameterAutocompleteComponent() {
        this.valueOptionsForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]();
        this.parameter = null;
        this.valueChanged = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.parameterOptions = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"];
    }
    ParameterAutocompleteComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.filteredValueOptions = this.valueOptionsForm.valueChanges.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["startWith"])(''), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["map"])(function (value) { return _this._filter(value); }));
    };
    ParameterAutocompleteComponent.prototype._filter = function (value) {
        var filterValue = value.toLowerCase();
        return this.parameter.valueOptions.filter(function (option) {
            return option.value.toLowerCase().indexOf(filterValue) === 0;
        });
    };
    ParameterAutocompleteComponent.prototype.changeValue = function () {
        this.valueChanged.emit(this.parameter);
    };
    ParameterAutocompleteComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], ParameterAutocompleteComponent.prototype, "parameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ParameterAutocompleteComponent.prototype, "valueChanged", void 0);
    ParameterAutocompleteComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-autocomplete',
            template: __webpack_require__(/*! raw-loader!./parameter-autocomplete.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.html"),
            styles: [__webpack_require__(/*! ./parameter-autocomplete.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterAutocompleteComponent);
    return ParameterAutocompleteComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.scss":
/*!*********************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.scss ***!
  \*********************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  max-width: 205px;\n}\n\ndiv.parameter-radio {\n  position: relative;\n  top: -2em;\n}\n\ndiv.parameter-radio label {\n  font-size: 75%;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvY2hlY2tib3gvQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItaW5wdXRzXFxjaGVja2JveFxccGFyYW1ldGVyLWNoZWNrYm94LmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9jaGVja2JveC9wYXJhbWV0ZXItY2hlY2tib3guY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSwrQkFBQTtFQUNBLGdCQUFBO0FDQ0o7O0FERUE7RUFDSSxrQkFBQTtFQUNBLFNBQUE7QUNDSjs7QURFQTtFQUNJLGNBQUE7QUNDSiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2NoZWNrYm94L3BhcmFtZXRlci1jaGVja2JveC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbInAucGFyYW1ldGVyLWRlc2NyaXB0aW9uIHtcclxuICAgIGNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LC43KTtcclxuICAgIG1heC13aWR0aDoyMDVweDtcclxufVxyXG5cclxuZGl2LnBhcmFtZXRlci1yYWRpb3tcclxuICAgIHBvc2l0aW9uOnJlbGF0aXZlO1xyXG4gICAgdG9wOiAtMmVtO1xyXG59XHJcblxyXG5kaXYucGFyYW1ldGVyLXJhZGlvIGxhYmVse1xyXG4gICAgZm9udC1zaXplOiA3NSU7XHJcbn0iLCJwLnBhcmFtZXRlci1kZXNjcmlwdGlvbiB7XG4gIGNvbG9yOiByZ2JhKDI1NSwgMjU1LCAyNTUsIDAuNyk7XG4gIG1heC13aWR0aDogMjA1cHg7XG59XG5cbmRpdi5wYXJhbWV0ZXItcmFkaW8ge1xuICBwb3NpdGlvbjogcmVsYXRpdmU7XG4gIHRvcDogLTJlbTtcbn1cblxuZGl2LnBhcmFtZXRlci1yYWRpbyBsYWJlbCB7XG4gIGZvbnQtc2l6ZTogNzUlO1xufSJdfQ== */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.ts":
/*!*******************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.ts ***!
  \*******************************************************************************************************************************/
/*! exports provided: ParameterCheckboxComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterCheckboxComponent", function() { return ParameterCheckboxComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/checkbox */ "../node_modules/@angular/material/esm5/checkbox.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ParameterCheckboxComponent = /** @class */ (function () {
    function ParameterCheckboxComponent() {
        this.parameter = null;
        this.valueChanged = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.parameterOptions = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__["ParameterOptions"];
    }
    ParameterCheckboxComponent.prototype.ngOnInit = function () {
        if (this.isRequired() && this.parameter.value != 'true')
            this.parameter.value = 'false';
    };
    ParameterCheckboxComponent.prototype.ngAfterViewInit = function () {
        if (!this.isRequired())
            this.defaultField.checked = this.parameter.value == '';
        else
            this.checkboxField.checked = this.parameter.value == 'true';
        if (this.defaultField)
            this.isDefault = this.defaultField.checked;
    };
    ParameterCheckboxComponent.prototype.changeValue = function (event) {
        this.parameter.value = event.checked ? 'true' : 'false';
        this.valueChanged.emit(this.parameter);
    };
    ParameterCheckboxComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    ParameterCheckboxComponent.prototype.defaultChecked = function (event) {
        if (event.checked) {
            this.parameter.value = null;
            this.isDefault = true;
        }
        else
            this.isDefault = false;
        this.valueChanged.emit(this.parameter);
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], ParameterCheckboxComponent.prototype, "parameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ParameterCheckboxComponent.prototype, "valueChanged", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('defaultField', { static: false }),
        __metadata("design:type", _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__["MatCheckbox"])
    ], ParameterCheckboxComponent.prototype, "defaultField", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('checkboxField', { static: false }),
        __metadata("design:type", _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__["MatCheckbox"])
    ], ParameterCheckboxComponent.prototype, "checkboxField", void 0);
    ParameterCheckboxComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-checkbox',
            template: __webpack_require__(/*! raw-loader!./parameter-checkbox.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.html"),
            styles: [__webpack_require__(/*! ./parameter-checkbox.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterCheckboxComponent);
    return ParameterCheckboxComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.scss":
/*!*******************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.scss ***!
  \*******************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2ZpZ3VyZXMvcGFyYW1ldGVyLWZpZ3VyZXMuY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.ts":
/*!*****************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.ts ***!
  \*****************************************************************************************************************************/
/*! exports provided: ParameterFiguresComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterFiguresComponent", function() { return ParameterFiguresComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_figure_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../services/figure.service */ "./app/modules/script-interpreter/services/figure.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ParameterFiguresComponent = /** @class */ (function () {
    function ParameterFiguresComponent(figureService) {
        this.figureService = figureService;
    }
    ParameterFiguresComponent.prototype.ngOnInit = function () {
        this.figures = this.parameter.figures;
    };
    ParameterFiguresComponent.prototype.expanded = function () {
        this.isExpanded = true;
    };
    ParameterFiguresComponent.prototype.collapsed = function () {
        this.isExpanded = false;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], ParameterFiguresComponent.prototype, "parameter", void 0);
    ParameterFiguresComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-figures',
            template: __webpack_require__(/*! raw-loader!./parameter-figures.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.html"),
            styles: [__webpack_require__(/*! ./parameter-figures.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_figure_service__WEBPACK_IMPORTED_MODULE_1__["FigureService"]])
    ], ParameterFiguresComponent);
    return ParameterFiguresComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.scss":
/*!***************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.scss ***!
  \***************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n  position: relative;\n  top: -1.4em;\n  max-width: 205px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvaW5wdXQvQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItaW5wdXRzXFxpbnB1dFxccGFyYW1ldGVyLWlucHV0LmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9pbnB1dC9wYXJhbWV0ZXItaW5wdXQuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSwrQkFBQTtFQUNBLGdCQUFBO0VBQ0Esa0JBQUE7RUFDQSxXQUFBO0VBQ0EsZ0JBQUE7QUNDSiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2lucHV0L3BhcmFtZXRlci1pbnB1dC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbInAucGFyYW1ldGVyLWRlc2NyaXB0aW9uIHtcclxuICAgIGNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LC43KTtcclxuICAgIGZvbnQtc2l6ZTogODcuNSU7XHJcbiAgICBwb3NpdGlvbjpyZWxhdGl2ZTtcclxuICAgIHRvcDotMS40ZW07XHJcbiAgICBtYXgtd2lkdGg6MjA1cHg7XHJcbn1cclxuIiwicC5wYXJhbWV0ZXItZGVzY3JpcHRpb24ge1xuICBjb2xvcjogcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjcpO1xuICBmb250LXNpemU6IDg3LjUlO1xuICBwb3NpdGlvbjogcmVsYXRpdmU7XG4gIHRvcDogLTEuNGVtO1xuICBtYXgtd2lkdGg6IDIwNXB4O1xufSJdfQ== */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.ts":
/*!*************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.ts ***!
  \*************************************************************************************************************************/
/*! exports provided: ParameterInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterInputComponent", function() { return ParameterInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../models/enums/valueType */ "./app/modules/script-interpreter/models/enums/valueType.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ParameterInputComponent = /** @class */ (function () {
    function ParameterInputComponent() {
        this.parameter = null;
        this.valueChanged = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.parameterOptions = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__["ParameterOptions"];
        this.valueTypes = _models_enums_valueType__WEBPACK_IMPORTED_MODULE_2__["ValueType"];
    }
    ParameterInputComponent.prototype.ngOnInit = function () {
    };
    ParameterInputComponent.prototype.changeValue = function () {
        this.valueChanged.emit(this.parameter);
    };
    ParameterInputComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], ParameterInputComponent.prototype, "parameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ParameterInputComponent.prototype, "valueChanged", void 0);
    ParameterInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-input',
            template: __webpack_require__(/*! raw-loader!./parameter-input.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.html"),
            styles: [__webpack_require__(/*! ./parameter-input.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterInputComponent);
    return ParameterInputComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.scss":
/*!************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.scss ***!
  \************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL3BhcmFtZXRlcnMtZm9ybS9wYXJhbWV0ZXItZm9ybS5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.ts":
/*!**********************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.ts ***!
  \**********************************************************************************************************************************/
/*! exports provided: ParameterFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterFormComponent", function() { return ParameterFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/valueOptionSettings */ "./app/modules/script-interpreter/models/enums/valueOptionSettings.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ParameterFormComponent = /** @class */ (function () {
    function ParameterFormComponent() {
        this.valueOptionSetting = _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_1__["ValueOptionSettings"];
        this.parameter = null;
        this.valueChanged = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
    }
    ParameterFormComponent.prototype.ngOnInit = function () {
    };
    ParameterFormComponent.prototype.onValueChanged = function (parameter) {
        this.valueChanged.emit(parameter);
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], ParameterFormComponent.prototype, "parameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ParameterFormComponent.prototype, "valueChanged", void 0);
    ParameterFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-form',
            template: __webpack_require__(/*! raw-loader!./parameter-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.html"),
            styles: [__webpack_require__(/*! ./parameter-form.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterFormComponent);
    return ParameterFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.scss":
/*!***************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.scss ***!
  \***************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  max-width: 205px;\n}\n\ndiv.parameter-radio {\n  position: relative;\n  top: -2em;\n}\n\ndiv.parameter-radio label {\n  font-size: 75%;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvcmFkaW8vQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItaW5wdXRzXFxyYWRpb1xccGFyYW1ldGVyLXJhZGlvLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9yYWRpby9wYXJhbWV0ZXItcmFkaW8uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSwrQkFBQTtFQUNBLGdCQUFBO0FDQ0o7O0FERUE7RUFDSSxrQkFBQTtFQUNBLFNBQUE7QUNDSjs7QURFQTtFQUNJLGNBQUE7QUNDSiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL3JhZGlvL3BhcmFtZXRlci1yYWRpby5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbInAucGFyYW1ldGVyLWRlc2NyaXB0aW9uIHtcclxuICAgIGNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LC43KTtcclxuICAgIG1heC13aWR0aDoyMDVweDtcclxufVxyXG5cclxuZGl2LnBhcmFtZXRlci1yYWRpb3tcclxuICAgIHBvc2l0aW9uOnJlbGF0aXZlO1xyXG4gICAgdG9wOiAtMmVtO1xyXG59XHJcblxyXG5kaXYucGFyYW1ldGVyLXJhZGlvIGxhYmVse1xyXG4gICAgZm9udC1zaXplOiA3NSU7XHJcbn0iLCJwLnBhcmFtZXRlci1kZXNjcmlwdGlvbiB7XG4gIGNvbG9yOiByZ2JhKDI1NSwgMjU1LCAyNTUsIDAuNyk7XG4gIG1heC13aWR0aDogMjA1cHg7XG59XG5cbmRpdi5wYXJhbWV0ZXItcmFkaW8ge1xuICBwb3NpdGlvbjogcmVsYXRpdmU7XG4gIHRvcDogLTJlbTtcbn1cblxuZGl2LnBhcmFtZXRlci1yYWRpbyBsYWJlbCB7XG4gIGZvbnQtc2l6ZTogNzUlO1xufSJdfQ== */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.ts":
/*!*************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.ts ***!
  \*************************************************************************************************************************/
/*! exports provided: ParameterRadioComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterRadioComponent", function() { return ParameterRadioComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ParameterRadioComponent = /** @class */ (function () {
    function ParameterRadioComponent() {
        this.parameter = null;
        this.valueChanged = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.parameterOptions = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__["ParameterOptions"];
    }
    ParameterRadioComponent.prototype.ngOnInit = function () {
    };
    ParameterRadioComponent.prototype.changeValue = function (event) {
        this.parameter.value = event.value;
        this.valueChanged.emit(this.parameter);
    };
    ParameterRadioComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], ParameterRadioComponent.prototype, "parameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ParameterRadioComponent.prototype, "valueChanged", void 0);
    ParameterRadioComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-radio',
            template: __webpack_require__(/*! raw-loader!./parameter-radio.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.html"),
            styles: [__webpack_require__(/*! ./parameter-radio.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterRadioComponent);
    return ParameterRadioComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.scss":
/*!*****************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.scss ***!
  \*****************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n  position: relative;\n  top: -1.4em;\n  max-width: 205px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvc2VsZWN0L0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL2FwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FsY3VsYXRvclxccGFyYW1ldGVyLWlucHV0c1xcc2VsZWN0XFxwYXJhbWV0ZXItc2VsZWN0LmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9zZWxlY3QvcGFyYW1ldGVyLXNlbGVjdC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLCtCQUFBO0VBQ0EsZ0JBQUE7RUFDQSxrQkFBQTtFQUNBLFdBQUE7RUFDQSxnQkFBQTtBQ0NKIiwiZmlsZSI6ImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvc2VsZWN0L3BhcmFtZXRlci1zZWxlY3QuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJwLnBhcmFtZXRlci1kZXNjcmlwdGlvbiB7XHJcbiAgICBjb2xvcjogcmdiYSgyNTUsMjU1LDI1NSwuNyk7XHJcbiAgICBmb250LXNpemU6IDg3LjUlO1xyXG4gICAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG4gICAgdG9wOiAtMS40ZW07XHJcbiAgICBtYXgtd2lkdGg6IDIwNXB4O1xyXG59XHJcbiIsInAucGFyYW1ldGVyLWRlc2NyaXB0aW9uIHtcbiAgY29sb3I6IHJnYmEoMjU1LCAyNTUsIDI1NSwgMC43KTtcbiAgZm9udC1zaXplOiA4Ny41JTtcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xuICB0b3A6IC0xLjRlbTtcbiAgbWF4LXdpZHRoOiAyMDVweDtcbn0iXX0= */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.ts":
/*!***************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.ts ***!
  \***************************************************************************************************************************/
/*! exports provided: ParameterSelectComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterSelectComponent", function() { return ParameterSelectComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ParameterSelectComponent = /** @class */ (function () {
    function ParameterSelectComponent() {
        this.parameter = null;
        this.valueChanged = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.parameterOptions = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__["ParameterOptions"];
    }
    ParameterSelectComponent.prototype.ngOnInit = function () {
    };
    ParameterSelectComponent.prototype.changeValue = function () {
        this.valueChanged.emit(this.parameter);
    };
    ParameterSelectComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], ParameterSelectComponent.prototype, "parameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ParameterSelectComponent.prototype, "valueChanged", void 0);
    ParameterSelectComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-select',
            template: __webpack_require__(/*! raw-loader!./parameter-select.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.html"),
            styles: [__webpack_require__(/*! ./parameter-select.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterSelectComponent);
    return ParameterSelectComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.scss":
/*!****************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.scss ***!
  \****************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".parameter-result-header {\n  position: relative;\n  top: 0.4em;\n}\n\n.parameter-result-value {\n  font-size: 120%;\n}\n\n.parameter-result-important {\n  border-bottom-style: dotted;\n  border-top-style: dotted;\n  border-color: #9c27b0;\n  border-width: 3px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1yZXN1bHRzL3BhcmFtZXRlci1yZXN1bHQvQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItcmVzdWx0c1xccGFyYW1ldGVyLXJlc3VsdFxccGFyYW1ldGVyLXJlc3VsdC5jb21wb25lbnQuc2NzcyIsImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1yZXN1bHRzL3BhcmFtZXRlci1yZXN1bHQvcGFyYW1ldGVyLXJlc3VsdC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGtCQUFBO0VBQ0EsVUFBQTtBQ0NKOztBREVBO0VBQ0ksZUFBQTtBQ0NKOztBREVBO0VBQ0ksMkJBQUE7RUFDQSx3QkFBQTtFQUNBLHFCQUFBO0VBQ0EsaUJBQUE7QUNDSiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItcmVzdWx0cy9wYXJhbWV0ZXItcmVzdWx0L3BhcmFtZXRlci1yZXN1bHQuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIucGFyYW1ldGVyLXJlc3VsdC1oZWFkZXJ7XHJcbiAgICBwb3NpdGlvbjpyZWxhdGl2ZTtcclxuICAgIHRvcDowLjRlbTtcclxufVxyXG5cclxuLnBhcmFtZXRlci1yZXN1bHQtdmFsdWV7XHJcbiAgICBmb250LXNpemU6IDEyMCU7XHJcbn1cclxuXHJcbi5wYXJhbWV0ZXItcmVzdWx0LWltcG9ydGFudCB7XHJcbiAgICBib3JkZXItYm90dG9tLXN0eWxlOiBkb3R0ZWQ7XHJcbiAgICBib3JkZXItdG9wLXN0eWxlOiBkb3R0ZWQ7XHJcbiAgICBib3JkZXItY29sb3I6IHJnYigxNTYsMzksMTc2KTtcclxuICAgIGJvcmRlci13aWR0aDogM3B4O1xyXG59IiwiLnBhcmFtZXRlci1yZXN1bHQtaGVhZGVyIHtcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xuICB0b3A6IDAuNGVtO1xufVxuXG4ucGFyYW1ldGVyLXJlc3VsdC12YWx1ZSB7XG4gIGZvbnQtc2l6ZTogMTIwJTtcbn1cblxuLnBhcmFtZXRlci1yZXN1bHQtaW1wb3J0YW50IHtcbiAgYm9yZGVyLWJvdHRvbS1zdHlsZTogZG90dGVkO1xuICBib3JkZXItdG9wLXN0eWxlOiBkb3R0ZWQ7XG4gIGJvcmRlci1jb2xvcjogIzljMjdiMDtcbiAgYm9yZGVyLXdpZHRoOiAzcHg7XG59Il19 */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.ts":
/*!**************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.ts ***!
  \**************************************************************************************************************************************/
/*! exports provided: ParameterResultComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterResultComponent", function() { return ParameterResultComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/valueType */ "./app/modules/script-interpreter/models/enums/valueType.ts");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ParameterResultComponent = /** @class */ (function () {
    function ParameterResultComponent() {
        this.parameter = null;
        this.forbiddenSigns = ['(', ')', ',', '.', '^'];
        this.valueTypes = _models_enums_valueType__WEBPACK_IMPORTED_MODULE_1__["ValueType"];
        this.valueTypesMapping = { 'number': 0, 'text': 1 };
    }
    ParameterResultComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.forbiddenSigns.forEach(function (fs) { return _this.valueClass = _this.parameter.name.replace(fs, ''); });
    };
    ParameterResultComponent.prototype.isImportant = function () {
        return (this.parameter.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_2__["ParameterOptions"].important) != 0;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('parameter'),
        __metadata("design:type", Object)
    ], ParameterResultComponent.prototype, "parameter", void 0);
    ParameterResultComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-result',
            template: __webpack_require__(/*! raw-loader!./parameter-result.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.html"),
            styles: [__webpack_require__(/*! ./parameter-result.component.scss */ "./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterResultComponent);
    return ParameterResultComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/script-calculator.component.scss":
/*!******************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/script-calculator.component.scss ***!
  \******************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table {\n  width: 100%;\n}\n\n.mat-hint {\n  margin-bottom: 10px;\n  display: inline-block;\n  align-content: flex-start;\n}\n\n.form-inline {\n  -webkit-transform: scale(0.9);\n          transform: scale(0.9);\n  -webkit-transform-origin: left;\n          transform-origin: left;\n}\n\n.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n}\n\n.mat-form-field-paddings {\n  padding-bottom: 0px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL2FwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FsY3VsYXRvclxcc2NyaXB0LWNhbGN1bGF0b3IuY29tcG9uZW50LnNjc3MiLCJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9zY3JpcHQtY2FsY3VsYXRvci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLFdBQUE7QUNDSjs7QURFQTtFQUNJLG1CQUFBO0VBQ0EscUJBQUE7RUFDQSx5QkFBQTtBQ0NKOztBREVBO0VBQ0ksNkJBQUE7VUFBQSxxQkFBQTtFQUNBLDhCQUFBO1VBQUEsc0JBQUE7QUNDSjs7QURFQTtFQUNJLCtCQUFBO0VBQ0EsZ0JBQUE7QUNDSjs7QURFQTtFQUNJLG1CQUFBO0FDQ0oiLCJmaWxlIjoiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3Ivc2NyaXB0LWNhbGN1bGF0b3IuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJ0YWJsZXtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59XHJcblxyXG4ubWF0LWhpbnQge1xyXG4gICAgbWFyZ2luLWJvdHRvbToxMHB4O1xyXG4gICAgZGlzcGxheTppbmxpbmUtYmxvY2s7XHJcbiAgICBhbGlnbi1jb250ZW50OmZsZXgtc3RhcnQ7XHJcbn1cclxuXHJcbi5mb3JtLWlubGluZSB7XHJcbiAgICB0cmFuc2Zvcm06IHNjYWxlKDAuOSk7XHJcbiAgICB0cmFuc2Zvcm0tb3JpZ2luOiBsZWZ0O1xyXG59XHJcblxyXG4ucGFyYW1ldGVyLWRlc2NyaXB0aW9uIHtcclxuICAgIGNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LC43KTtcclxuICAgIGZvbnQtc2l6ZTogODcuNSU7XHJcbn1cclxuXHJcbi5tYXQtZm9ybS1maWVsZC1wYWRkaW5ncyB7XHJcbiAgICBwYWRkaW5nLWJvdHRvbTogMHB4O1xyXG59IiwidGFibGUge1xuICB3aWR0aDogMTAwJTtcbn1cblxuLm1hdC1oaW50IHtcbiAgbWFyZ2luLWJvdHRvbTogMTBweDtcbiAgZGlzcGxheTogaW5saW5lLWJsb2NrO1xuICBhbGlnbi1jb250ZW50OiBmbGV4LXN0YXJ0O1xufVxuXG4uZm9ybS1pbmxpbmUge1xuICB0cmFuc2Zvcm06IHNjYWxlKDAuOSk7XG4gIHRyYW5zZm9ybS1vcmlnaW46IGxlZnQ7XG59XG5cbi5wYXJhbWV0ZXItZGVzY3JpcHRpb24ge1xuICBjb2xvcjogcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjcpO1xuICBmb250LXNpemU6IDg3LjUlO1xufVxuXG4ubWF0LWZvcm0tZmllbGQtcGFkZGluZ3Mge1xuICBwYWRkaW5nLWJvdHRvbTogMHB4O1xufSJdfQ== */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts":
/*!****************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts ***!
  \****************************************************************************************************/
/*! exports provided: ScriptCalculatorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptCalculatorComponent", function() { return ScriptCalculatorComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../models/enums/valueType */ "./app/modules/script-interpreter/models/enums/valueType.ts");
/* harmony import */ var _models_parametersGroup__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../models/parametersGroup */ "./app/modules/script-interpreter/models/parametersGroup.ts");
/* harmony import */ var _services_calculation_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../services/calculation.service */ "./app/modules/script-interpreter/services/calculation.service.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../services/parameter.service */ "./app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../services/script.service */ "./app/modules/script-interpreter/services/script.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









var ScriptCalculatorComponent = /** @class */ (function () {
    function ScriptCalculatorComponent(route, scriptService, parameterService, calculationService) {
        this.route = route;
        this.scriptService = scriptService;
        this.parameterService = parameterService;
        this.calculationService = calculationService;
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]();
        this.parameterOptions = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"];
    }
    ScriptCalculatorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id;
        var sub = this.route.params.subscribe(function (params) {
            id = +params['id'];
        });
        if (id != undefined) {
            this.scriptService.getScript(id).subscribe(function (script) {
                _this.script = script;
                console.log("Script", _this.script);
                _this.setParameters();
            }, function (error) { return console.error(error); });
        }
        sub.unsubscribe();
    };
    ScriptCalculatorComponent.prototype.setParameters = function () {
        var _this = this;
        this.parameterService.getParameters(this.script.id).subscribe(function (parameters) {
            _this.parameters = parameters.filter(function (p) { return (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].editable) != 0; }),
                _this.staticDataParameters = parameters.filter(function (p) {
                    return (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].staticData) != 0 &&
                        (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].visible) != 0;
                }),
                _this.parameters.forEach(function (p) { return _this.prepareParameter(p); }),
                _this.filterParameters(),
                console.log("Parameters", _this.parameters);
        }, function (error) { return console.error(error); });
    };
    ScriptCalculatorComponent.prototype.prepareParameter = function (parameter) {
        parameter.equation = parameter.value;
    };
    ScriptCalculatorComponent.prototype.sortParameters = function (parameters, prop) {
        if (parameters)
            return parameters.sort(function (a, b) { return a[prop] > b[prop] ? 1 :
                a[prop] === b[prop] ? 0 :
                    -1; });
    };
    ScriptCalculatorComponent.prototype.onValueChanged = function (parameter) {
        this.valueChanged = true;
        this.filterParameters();
    };
    ScriptCalculatorComponent.prototype.filterParameters = function () {
        var _this = this;
        this.visibleParameters = this.parameters.filter(function (p) {
            return (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].visible) != 0 &&
                _this.validateVisibility(p);
        });
        if (this.groups == undefined)
            this.createGroups();
        this.populateGroups();
    };
    ScriptCalculatorComponent.prototype.createGroups = function () {
        var groupNames = this.visibleParameters.map(function (vp) { return vp.groupName; })
            .filter(function (value, index, self) { return self.indexOf(value) === index &&
            value != "" && value != undefined; });
        this.groups = groupNames.map(function (gn) { return new _models_parametersGroup__WEBPACK_IMPORTED_MODULE_5__["ParametersGroup"](gn); });
    };
    ScriptCalculatorComponent.prototype.populateGroups = function () {
        var _this = this;
        this.groups.forEach(function (g) { return g.clear(); });
        this.notGroupedParameters = [];
        this.visibleParameters.forEach(function (vp) {
            if (vp.groupName == "" || vp.groupName == undefined)
                _this.notGroupedParameters.push(vp);
            else {
                var group = _this.groups.find(function (g) { return g.name === vp.groupName; });
                group.addParameter(vp);
            }
        });
    };
    ScriptCalculatorComponent.prototype.isValid = function () {
        var _this = this;
        return this.parameters
            .filter(function (p) { return (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].editable) != 0 &&
            (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].optional) == 0 &&
            _this.validateVisibility(p); })
            .every(function (p) { return p.value != undefined && p.value != ""; });
    };
    ScriptCalculatorComponent.prototype.calculate = function () {
        var _this = this;
        this.isCalculating = true;
        this.calculationService.calculate(this.script.id, this.parameters)
            .subscribe(function (params) {
            _this.resultParameters = params.filter(function (p) { return (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].visible) != 0; });
            _this.resultParameters.forEach(function (p) { return p.equation = _this.setEquation(p); });
        }, function (error) {
            console.error(error);
            _this.isCalculating = false;
        }, function () {
            _this.isCalculating = false;
            _this.valueChanged = false;
        });
    };
    ScriptCalculatorComponent.prototype.setEquation = function (parameter) {
        var firstPartOfEquation = parameter.equation.replace(/\[/g, '').replace(/\]/g, '');
        var secondPartOfEquation = parameter.equation;
        this.parameters.concat(this.staticDataParameters).concat(this.resultParameters).forEach(function (p) {
            secondPartOfEquation = secondPartOfEquation.replace("[" + p.name + "]", " " + p.value + p.unit + " ");
        });
        return firstPartOfEquation + ' = ' + secondPartOfEquation;
    };
    ScriptCalculatorComponent.prototype.validateVisibility = function (parameter) {
        if (!parameter.visibilityValidator)
            return true;
        var visibilityValidatorEquation = parameter.visibilityValidator.slice(parameter.visibilityValidator.indexOf('(') + 1, parameter.visibilityValidator.lastIndexOf(')'));
        this.parameters.forEach(function (p) {
            var value = p.valueType == _models_enums_valueType__WEBPACK_IMPORTED_MODULE_4__["ValueType"].number ? p.value : "'" + p.value + "'";
            visibilityValidatorEquation = visibilityValidatorEquation.split("[" + p.name + "]").join(value);
        });
        try {
            var result = eval(visibilityValidatorEquation);
            if (result != null && !result && parameter.value != parameter.equation)
                parameter.value = parameter.equation;
            if (result != null)
                return result;
            else
                return true;
        }
        catch (e) {
            return true;
        }
    };
    ScriptCalculatorComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'script-calculator',
            template: __webpack_require__(/*! raw-loader!./script-calculator.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-calculator/script-calculator.component.html"),
            styles: [__webpack_require__(/*! ./script-calculator.component.scss */ "./app/modules/script-interpreter/components/script-calculator/script-calculator.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _services_script_service__WEBPACK_IMPORTED_MODULE_8__["ScriptService"],
            _services_parameter_service__WEBPACK_IMPORTED_MODULE_7__["ParameterService"],
            _services_calculation_service__WEBPACK_IMPORTED_MODULE_6__["CalculationService"]])
    ], ScriptCalculatorComponent);
    return ScriptCalculatorComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-card/script-card.component.scss":
/*!******************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-card/script-card.component.scss ***!
  \******************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".script-card {\n  max-width: 400px;\n}\n\n.script-header-image {\n  background-image: url(\"https://lorempixel.com/100/100/?random=12\");\n  background-size: cover;\n}\n\n.actions {\n  position: absolute;\n  left: 0;\n  bottom: 0;\n}\n\n.footer > button:not(.actions) {\n  position: absolute;\n  right: 0;\n  bottom: 0;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYXJkL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL2FwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FyZFxcc2NyaXB0LWNhcmQuY29tcG9uZW50LnNjc3MiLCJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FyZC9zY3JpcHQtY2FyZC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGdCQUFBO0FDQ0o7O0FEQ0E7RUFDSSxrRUFBQTtFQUNBLHNCQUFBO0FDRUo7O0FEQ0E7RUFDSSxrQkFBQTtFQUNBLE9BQUE7RUFDQSxTQUFBO0FDRUo7O0FEQ0E7RUFDSSxrQkFBQTtFQUNBLFFBQUE7RUFDQSxTQUFBO0FDRUoiLCJmaWxlIjoiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhcmQvc2NyaXB0LWNhcmQuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuc2NyaXB0LWNhcmQge1xyXG4gICAgbWF4LXdpZHRoOiA0MDBweDtcclxufVxyXG4uc2NyaXB0LWhlYWRlci1pbWFnZSB7XHJcbiAgICBiYWNrZ3JvdW5kLWltYWdlOiB1cmwoJ2h0dHBzOi8vbG9yZW1waXhlbC5jb20vMTAwLzEwMC8/cmFuZG9tPTEyJyk7XHJcbiAgICBiYWNrZ3JvdW5kLXNpemU6IGNvdmVyO1xyXG59XHJcblxyXG4uYWN0aW9ucyB7XHJcbiAgICBwb3NpdGlvbjogYWJzb2x1dGU7XHJcbiAgICBsZWZ0OiAwO1xyXG4gICAgYm90dG9tOiAwO1xyXG59XHJcblxyXG4uZm9vdGVyID4gYnV0dG9uOm5vdCguYWN0aW9ucykge1xyXG4gICAgcG9zaXRpb246IGFic29sdXRlO1xyXG4gICAgcmlnaHQ6IDA7XHJcbiAgICBib3R0b206IDA7XHJcbn0iLCIuc2NyaXB0LWNhcmQge1xuICBtYXgtd2lkdGg6IDQwMHB4O1xufVxuXG4uc2NyaXB0LWhlYWRlci1pbWFnZSB7XG4gIGJhY2tncm91bmQtaW1hZ2U6IHVybChcImh0dHBzOi8vbG9yZW1waXhlbC5jb20vMTAwLzEwMC8/cmFuZG9tPTEyXCIpO1xuICBiYWNrZ3JvdW5kLXNpemU6IGNvdmVyO1xufVxuXG4uYWN0aW9ucyB7XG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgbGVmdDogMDtcbiAgYm90dG9tOiAwO1xufVxuXG4uZm9vdGVyID4gYnV0dG9uOm5vdCguYWN0aW9ucykge1xuICBwb3NpdGlvbjogYWJzb2x1dGU7XG4gIHJpZ2h0OiAwO1xuICBib3R0b206IDA7XG59Il19 */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-card/script-card.component.ts":
/*!****************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-card/script-card.component.ts ***!
  \****************************************************************************************/
/*! exports provided: ScriptCardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptCardComponent", function() { return ScriptCardComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../services/script.service */ "./app/modules/script-interpreter/services/script.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ScriptCardComponent = /** @class */ (function () {
    function ScriptCardComponent(scriptService) {
        this.scriptService = scriptService;
        this.deleted = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
    }
    ScriptCardComponent.prototype.delete = function (script) {
        var _this = this;
        if (confirm("Are you sure that you want to remove \"" + script.name + "\"?")) {
            this.scriptService.delete(script.id).subscribe(function (s) {
                console.log("Scripts", s);
                _this.deleted.emit(script);
            });
        }
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('script'),
        __metadata("design:type", Object)
    ], ScriptCardComponent.prototype, "script", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])('deleted'),
        __metadata("design:type", Object)
    ], ScriptCardComponent.prototype, "deleted", void 0);
    ScriptCardComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-script-card',
            template: __webpack_require__(/*! raw-loader!./script-card.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-card/script-card.component.html"),
            styles: [__webpack_require__(/*! ./script-card.component.scss */ "./app/modules/script-interpreter/components/script-card/script-card.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_script_service__WEBPACK_IMPORTED_MODULE_1__["ScriptService"]])
    ], ScriptCardComponent);
    return ScriptCardComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-cards/script-cards.component.scss":
/*!********************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-cards/script-cards.component.scss ***!
  \********************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FyZHMvc2NyaXB0LWNhcmRzLmNvbXBvbmVudC5zY3NzIn0= */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-cards/script-cards.component.ts":
/*!******************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-cards/script-cards.component.ts ***!
  \******************************************************************************************/
/*! exports provided: ScriptCardsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptCardsComponent", function() { return ScriptCardsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../services/script.service */ "./app/modules/script-interpreter/services/script.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ScriptCardsComponent = /** @class */ (function () {
    function ScriptCardsComponent(scriptService) {
        this.scriptService = scriptService;
    }
    ScriptCardsComponent.prototype.ngOnInit = function () {
        this.setScript();
    };
    ScriptCardsComponent.prototype.setScript = function () {
        var _this = this;
        this.scriptService.getScripts().subscribe(function (scripts) {
            _this.scripts = scripts;
            if (_this.groupFilters != undefined)
                _this.scripts = _this.scripts.filter(function (s) { return _this.groupFilters.indexOf(s.groupName) != -1; });
            if (_this.tagFilters != undefined)
                _this.scripts = _this.scripts.filter(function (s) { return _this.tagFilters.every(function (tf) { return s.tags.map(function (t) { return t.name; }).indexOf(tf) != -1; }); });
            console.log("Scripts", _this.scripts);
        }, function (error) { return console.error(error); });
    };
    ScriptCardsComponent.prototype.onDeleted = function (script) {
        this.scripts = this.scripts.filter(function (s) { return s.id != script.id; });
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('groupFilters'),
        __metadata("design:type", Array)
    ], ScriptCardsComponent.prototype, "groupFilters", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('tagFilters'),
        __metadata("design:type", Array)
    ], ScriptCardsComponent.prototype, "tagFilters", void 0);
    ScriptCardsComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-script-cards',
            template: __webpack_require__(/*! raw-loader!./script-cards.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-cards/script-cards.component.html"),
            styles: [__webpack_require__(/*! ./script-cards.component.scss */ "./app/modules/script-interpreter/components/script-cards/script-cards.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_script_service__WEBPACK_IMPORTED_MODULE_1__["ScriptService"]])
    ], ScriptCardsComponent);
    return ScriptCardsComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.scss":
/*!**************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.scss ***!
  \**************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".full-width {\n  width: 98%;\n}\n\n.form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%;\n}\n\n.value-options-border {\n  box-shadow: 10px 5px 5px black;\n  border: 1px solid black;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL3BhcmFtZXRlcnMtZm9ybS9kYXRhLXBhcmFtZXRlci1mb3JtL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL2FwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtZm9ybVxccGFyYW1ldGVycy1mb3JtXFxkYXRhLXBhcmFtZXRlci1mb3JtXFxkYXRhLXBhcmFtZXRlci1mb3JtLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL2RhdGEtcGFyYW1ldGVyLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDQTtFQUNJLFVBQUE7QUNBSjs7QURHQTtFQUNJLGdCQUFBO0VBQ0EsZ0JBQUE7RUFDQSxXQUFBO0FDQUo7O0FER0E7RUFDSSw4QkFBQTtFQUNBLHVCQUFBO0FDQUoiLCJmaWxlIjoiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL2RhdGEtcGFyYW1ldGVyLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxyXG4uZnVsbC13aWR0aCB7XHJcbiAgICB3aWR0aDogOTglO1xyXG59XHJcblxyXG4uZm9ybS1tZWRpdW0ge1xyXG4gICAgbWluLXdpZHRoOiAxNTBweDtcclxuICAgIG1heC13aWR0aDogMzQwcHg7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufVxyXG5cclxuLnZhbHVlLW9wdGlvbnMtYm9yZGVyIHtcclxuICAgIGJveC1zaGFkb3c6IDEwcHggNXB4IDVweCBibGFjaztcclxuICAgIGJvcmRlcjogMXB4IHNvbGlkIGJsYWNrO1xyXG59IiwiLmZ1bGwtd2lkdGgge1xuICB3aWR0aDogOTglO1xufVxuXG4uZm9ybS1tZWRpdW0ge1xuICBtaW4td2lkdGg6IDE1MHB4O1xuICBtYXgtd2lkdGg6IDM0MHB4O1xuICB3aWR0aDogMTAwJTtcbn1cblxuLnZhbHVlLW9wdGlvbnMtYm9yZGVyIHtcbiAgYm94LXNoYWRvdzogMTBweCA1cHggNXB4IGJsYWNrO1xuICBib3JkZXI6IDFweCBzb2xpZCBibGFjaztcbn0iXX0= */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.ts":
/*!************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.ts ***!
  \************************************************************************************************************************************/
/*! exports provided: DataParameterFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DataParameterFormComponent", function() { return DataParameterFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/checkbox */ "../node_modules/@angular/material/esm5/checkbox.es5.js");
/* harmony import */ var _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/radio */ "../node_modules/@angular/material/esm5/radio.es5.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../../../common/errors/app-error-state-matcher */ "./app/common/errors/app-error-state-matcher.ts");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../models/enums/valueOptionSettings */ "./app/modules/script-interpreter/models/enums/valueOptionSettings.ts");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../../models/enums/valueType */ "./app/modules/script-interpreter/models/enums/valueType.ts");
/* harmony import */ var _models_parameterImpl__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../../../models/parameterImpl */ "./app/modules/script-interpreter/models/parameterImpl.ts");
/* harmony import */ var _models_valueOptionImpl__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../../../models/valueOptionImpl */ "./app/modules/script-interpreter/models/valueOptionImpl.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../../../../services/parameter.service */ "./app/modules/script-interpreter/services/parameter.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};











var DataParameterFormComponent = /** @class */ (function () {
    function DataParameterFormComponent(parameterService) {
        this.parameterService = parameterService;
        this.parameterForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
            id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0'),
            name: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(20)]),
            number: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required),
            description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(1000)),
            valueType: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required),
            value: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(1000)),
            visibilityValidator: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(1000)),
            dataValidator: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(1000)),
            unit: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(50)),
            context: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('3', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required),
            groupName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(200)),
            accordingTo: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(200)),
            notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(1000)),
            valueOptionSetting: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](0),
            valueOptions: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormArray"]([]),
            figures: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormArray"]([]),
        });
        this.matcher = new _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_4__["AppErrorStateMatcher"]();
        this.newParameter = new _models_parameterImpl__WEBPACK_IMPORTED_MODULE_8__["ParameterImpl"]();
        this.created = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.updated = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.valueTypes = this.getEnumValues(_models_enums_valueType__WEBPACK_IMPORTED_MODULE_7__["ValueType"]);
        this.context = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_5__["ParameterOptions"];
        this.allowUserValues = false;
    }
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterId", {
        get: function () {
            return this.parameterForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterName", {
        get: function () {
            return this.parameterForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterNumber", {
        get: function () {
            return this.parameterForm.get('number');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterUnit", {
        get: function () {
            return this.parameterForm.get('unit');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterDocument", {
        get: function () {
            return this.parameterForm.get('accordingTo');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterValueType", {
        get: function () {
            return this.parameterForm.get('valueType');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterValue", {
        get: function () {
            return this.parameterForm.get('value');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterDescription", {
        get: function () {
            return this.parameterForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterVisibilityValidator", {
        get: function () {
            return this.parameterForm.get('visibilityValidator');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterDataValidator", {
        get: function () {
            return this.parameterForm.get('dataValidator');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterContext", {
        get: function () {
            return this.parameterForm.get('context');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterValueOptions", {
        get: function () {
            return this.parameterForm.get('valueOptions');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterGroupName", {
        get: function () {
            return this.parameterForm.get('groupName');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterFigures", {
        get: function () {
            return this.parameterForm.get('figures');
        },
        enumerable: true,
        configurable: true
    });
    DataParameterFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.previousParameters = this.parameters.filter(function (p) { return p.number < _this.parameterNumber.value; });
    };
    DataParameterFormComponent.prototype.ngOnChanges = function (changes) {
        var _this = this;
        if (changes.newParameter) {
            var parameter = changes.newParameter.currentValue;
            this.parameterForm.patchValue(parameter);
            parameter.valueOptions.forEach(function (vo) { return _this.parameterValueOptions.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](vo.id),
                name: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](vo.name),
                value: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](vo.value),
                description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](vo.description)
            })); });
            parameter.figures.forEach(function (f) { return _this.parameterFigures.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](f.id),
                fileName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](f.fileName),
            })); });
            this.setNewParameterChanges(changes.newParameter);
        }
        if (changes.editMode)
            this.newlyAddedParameter = changes.editMode.currentValue;
    };
    DataParameterFormComponent.prototype.setNewParameterChanges = function (newParameter) {
        console.log('Previous parameter: ', newParameter.previousValue);
        console.log('New parameter: ', newParameter.currentValue);
        this.newParameter = newParameter.currentValue;
        // this.setDataType();
        this.setValueOptionsSettings();
        this.setParameterType();
    };
    DataParameterFormComponent.prototype.getEnumValues = function (e) {
        return Object.keys(e).map(function (i) { return e[i]; });
    };
    DataParameterFormComponent.prototype.parameterTypeChanged = function () {
        var value = 0;
        if (this.editable.checked)
            value += this.editable.value;
        if (this.static.checked)
            value += this.static.value;
        if (this.calculable.checked)
            value += this.calculable.value;
        if (this.visible.checked)
            value += +this.visible.value;
        if (this.important.checked)
            value += +this.important.value;
        if (this.optional.checked)
            value += +this.optional.value;
        this.parameterContext.setValue(value);
        console.log(this.parameterContext.value);
    };
    DataParameterFormComponent.prototype.setParameterType = function () {
        var value = this.parameterContext.value;
        if (value >= this.context.optional) {
            value -= this.context.optional;
            this.optional.checked = true;
        }
        if (value >= this.context.important) {
            value -= this.context.important;
            this.important.checked = true;
        }
        if (value >= this.context.staticData) {
            value -= this.context.staticData;
            this.static.checked = true;
        }
        if (value >= this.context.calculation) {
            value -= this.context.calculation;
            this.calculable.checked = true;
        }
        if (value >= this.context.editable) {
            value -= this.context.editable;
            this.editable.checked = true;
        }
        if (value >= this.context.visible) {
            value -= this.context.visible;
            this.visible.checked = true;
        }
    };
    DataParameterFormComponent.prototype.addValueOption = function () {
        var valueOption = new _models_valueOptionImpl__WEBPACK_IMPORTED_MODULE_9__["ValueOptionImpl"]();
        if (this.newParameter.valueOptions.length > 0)
            valueOption.id = Math.max.apply(Math, this.newParameter.valueOptions.map(function (vo) { return vo.id; })) + 1;
        else
            valueOption.id = 0;
        this.newParameter.valueOptions.push(valueOption);
    };
    DataParameterFormComponent.prototype.removeValueOption = function (valueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(function (vo) { return vo !== valueOption; });
        if (this.newParameter.valueOptions.length == 0) {
            this.allowUserValues = false;
            this.onAllowUserValues();
        }
    };
    DataParameterFormComponent.prototype.select = function (parameter) {
        this.parameterValue.setValue(this.parameterValue.value + "[" + parameter.name + "]");
        this.value.nativeElement.focus();
        this.value.nativeElement.selectionEnd = this.parameterValue.value.length;
    };
    DataParameterFormComponent.prototype.onAllowUserValues = function () {
        this.newParameter.valueOptionSetting =
            this.allowUserValues ? _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_6__["ValueOptionSettings"].UserInput : _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_6__["ValueOptionSettings"].None;
    };
    DataParameterFormComponent.prototype.onSubmit = function ($event) {
        if (this.newlyAddedParameter)
            this.create();
        else
            this.update();
    };
    DataParameterFormComponent.prototype.create = function () {
        this.created.emit(this.parameterForm.value);
    };
    DataParameterFormComponent.prototype.update = function () {
        var _this = this;
        this.parameterService.update(this.scriptId, this.parameterForm.value)
            .subscribe(function (p) {
            _this.updated.emit(p);
        }, function (error) { return console.error(error); });
    };
    DataParameterFormComponent.prototype.setValueOptionsSettings = function () {
        this.allowUserValues = this.newParameter.valueOptionSetting == _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_6__["ValueOptionSettings"].UserInput;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('newlyAddedParameter'),
        __metadata("design:type", Boolean)
    ], DataParameterFormComponent.prototype, "newlyAddedParameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('scriptId'),
        __metadata("design:type", Number)
    ], DataParameterFormComponent.prototype, "scriptId", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('newParameter'),
        __metadata("design:type", Object)
    ], DataParameterFormComponent.prototype, "newParameter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('parameters'),
        __metadata("design:type", Array)
    ], DataParameterFormComponent.prototype, "parameters", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])('created'),
        __metadata("design:type", Object)
    ], DataParameterFormComponent.prototype, "created", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])('updated'),
        __metadata("design:type", Object)
    ], DataParameterFormComponent.prototype, "updated", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('editable', { static: true }),
        __metadata("design:type", _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__["MatRadioButton"])
    ], DataParameterFormComponent.prototype, "editable", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('static', { static: true }),
        __metadata("design:type", _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__["MatRadioButton"])
    ], DataParameterFormComponent.prototype, "static", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('calculable', { static: true }),
        __metadata("design:type", _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__["MatRadioButton"])
    ], DataParameterFormComponent.prototype, "calculable", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('visible', { static: true }),
        __metadata("design:type", _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__["MatCheckbox"])
    ], DataParameterFormComponent.prototype, "visible", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('important', { static: true }),
        __metadata("design:type", _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__["MatCheckbox"])
    ], DataParameterFormComponent.prototype, "important", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('optional', { static: true }),
        __metadata("design:type", _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__["MatCheckbox"])
    ], DataParameterFormComponent.prototype, "optional", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('value', { static: false }),
        __metadata("design:type", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ElementRef"])
    ], DataParameterFormComponent.prototype, "value", void 0);
    DataParameterFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-data-parameter-form',
            template: __webpack_require__(/*! raw-loader!./data-parameter-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.html"),
            styles: [__webpack_require__(/*! ./data-parameter-form.component.scss */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_parameter_service__WEBPACK_IMPORTED_MODULE_10__["ParameterService"]])
    ], DataParameterFormComponent);
    return DataParameterFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.scss":
/*!******************************************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.scss ***!
  \******************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9wYXJhbWV0ZXJzLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS9leGlzdGluZy1maWd1cmVzLWRpYWxvZy9leGlzdGluZy1maWd1cmVzLWRpYWxvZy5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.ts":
/*!****************************************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.ts ***!
  \****************************************************************************************************************************************************************/
/*! exports provided: ExistingFiguresDialogComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ExistingFiguresDialogComponent", function() { return ExistingFiguresDialogComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/material/dialog */ "../node_modules/@angular/material/esm5/dialog.es5.js");
/* harmony import */ var _services_figure_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../services/figure.service */ "./app/modules/script-interpreter/services/figure.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (undefined && undefined.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};



var ExistingFiguresDialogComponent = /** @class */ (function () {
    function ExistingFiguresDialogComponent(dialogRef, figure, figureService) {
        this.dialogRef = dialogRef;
        this.figure = figure;
        this.figureService = figureService;
    }
    ExistingFiguresDialogComponent.prototype.ngOnInit = function () {
        //this.figureService.getAllFigures()
        //    .subscribe(f => this.figures = f);
    };
    ExistingFiguresDialogComponent.prototype.onNoClick = function () {
        this.dialogRef.close();
    };
    ExistingFiguresDialogComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-existing-figures-dialog',
            template: __webpack_require__(/*! raw-loader!./existing-figures-dialog.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.html"),
            styles: [__webpack_require__(/*! ./existing-figures-dialog.component.scss */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.scss")]
        }),
        __param(1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])(_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MAT_DIALOG_DATA"])),
        __metadata("design:paramtypes", [_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialogRef"], Object, _services_figure_service__WEBPACK_IMPORTED_MODULE_2__["FigureService"]])
    ], ExistingFiguresDialogComponent);
    return ExistingFiguresDialogComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.scss":
/*!**************************************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.scss ***!
  \**************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9wYXJhbWV0ZXJzLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS9maWd1cmUtcGFyYW1ldGVyLWZvcm0vZmlndXJlLXBhcmFtZXRlci1mb3JtLmNvbXBvbmVudC5zY3NzIn0= */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.ts":
/*!************************************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.ts ***!
  \************************************************************************************************************************************************************/
/*! exports provided: FigureParameterFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FigureParameterFormComponent", function() { return FigureParameterFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_figure_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../../services/figure.service */ "./app/modules/script-interpreter/services/figure.service.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/dialog */ "../node_modules/@angular/material/esm5/dialog.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var FigureParameterFormComponent = /** @class */ (function () {
    function FigureParameterFormComponent(figureService, dialog) {
        this.figureService = figureService;
        this.dialog = dialog;
    }
    Object.defineProperty(FigureParameterFormComponent.prototype, "parameterId", {
        get: function () {
            return this.parameterForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(FigureParameterFormComponent.prototype, "parameterFigures", {
        get: function () {
            return this.parameterForm.get('figures');
        },
        enumerable: true,
        configurable: true
    });
    FigureParameterFormComponent.prototype.ngOnInit = function () {
        this.figures = this.parameterFigures.value;
    };
    FigureParameterFormComponent.prototype.uploadFigure = function () {
        var _this = this;
        var nativeELement = this.fileInput.nativeElement;
        this.figureService.upload(this.parameterId.value, nativeELement.files[0])
            .subscribe(function (figure) {
            _this.figures.push(figure);
        });
    };
    FigureParameterFormComponent.prototype.remove = function (figure) {
        var _this = this;
        this.figureService.detach(this.parameterId.value, figure.id)
            .subscribe(function (figure) { return _this.figures = _this.figures.filter(function (f) { return f != figure; }); });
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('parameterForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormGroup"])
    ], FigureParameterFormComponent.prototype, "parameterForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('fileInput', { static: false }),
        __metadata("design:type", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ElementRef"])
    ], FigureParameterFormComponent.prototype, "fileInput", void 0);
    FigureParameterFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-figure-parameter-form',
            template: __webpack_require__(/*! raw-loader!./figure-parameter-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.html"),
            styles: [__webpack_require__(/*! ./figure-parameter-form.component.scss */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_figure_service__WEBPACK_IMPORTED_MODULE_1__["FigureService"],
            _angular_material_dialog__WEBPACK_IMPORTED_MODULE_3__["MatDialog"]])
    ], FigureParameterFormComponent);
    return FigureParameterFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.scss":
/*!********************************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.scss ***!
  \********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".full-width {\n  width: 98%;\n}\n\n.form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL3BhcmFtZXRlcnMtZm9ybS9kYXRhLXBhcmFtZXRlci1mb3JtL3ZhbHVlLW9wdGlvbnMtZm9ybS9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9hcHBcXG1vZHVsZXNcXHNjcmlwdC1pbnRlcnByZXRlclxcY29tcG9uZW50c1xcc2NyaXB0LWZvcm1cXHBhcmFtZXRlcnMtZm9ybVxcZGF0YS1wYXJhbWV0ZXItZm9ybVxcdmFsdWUtb3B0aW9ucy1mb3JtXFx2YWx1ZS1vcHRpb25zLWZvcm0uY29tcG9uZW50LnNjc3MiLCJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9wYXJhbWV0ZXJzLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS92YWx1ZS1vcHRpb25zLWZvcm0vdmFsdWUtb3B0aW9ucy1mb3JtLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUNBO0VBQ0ksVUFBQTtBQ0FKOztBREdBO0VBQ0ksZ0JBQUE7RUFDQSxnQkFBQTtFQUNBLFdBQUE7QUNBSiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9wYXJhbWV0ZXJzLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS92YWx1ZS1vcHRpb25zLWZvcm0vdmFsdWUtb3B0aW9ucy1mb3JtLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiXHJcbi5mdWxsLXdpZHRoIHtcclxuICAgIHdpZHRoOiA5OCU7XHJcbn1cclxuXHJcbi5mb3JtLW1lZGl1bSB7XHJcbiAgICBtaW4td2lkdGg6IDE1MHB4O1xyXG4gICAgbWF4LXdpZHRoOiAzNDBweDtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59IiwiLmZ1bGwtd2lkdGgge1xuICB3aWR0aDogOTglO1xufVxuXG4uZm9ybS1tZWRpdW0ge1xuICBtaW4td2lkdGg6IDE1MHB4O1xuICBtYXgtd2lkdGg6IDM0MHB4O1xuICB3aWR0aDogMTAwJTtcbn0iXX0= */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.ts":
/*!******************************************************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.ts ***!
  \******************************************************************************************************************************************************/
/*! exports provided: ValueOptionsFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValueOptionsFormComponent", function() { return ValueOptionsFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../../../common/errors/app-error-state-matcher */ "./app/common/errors/app-error-state-matcher.ts");
/* harmony import */ var _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../models/enums/valueOptionSettings */ "./app/modules/script-interpreter/models/enums/valueOptionSettings.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var ValueOptionsFormComponent = /** @class */ (function () {
    function ValueOptionsFormComponent() {
        this.valueOptionSettings = _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_3__["ValueOptionSettings"];
        this.matcher = new _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_2__["AppErrorStateMatcher"]();
    }
    Object.defineProperty(ValueOptionsFormComponent.prototype, "parameterValueOptionSetting", {
        get: function () {
            return this.parameterForm.get('valueOptionSetting');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ValueOptionsFormComponent.prototype, "parameterValueOptions", {
        get: function () {
            return this.parameterForm.get('valueOptions');
        },
        enumerable: true,
        configurable: true
    });
    ValueOptionsFormComponent.prototype.addValueOption = function () {
        this.parameterValueOptions.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
            id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](0),
            name: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
            value: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
            description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('')
        }));
    };
    ValueOptionsFormComponent.prototype.remove = function (valueOption) {
        var index = this.parameterValueOptions.controls.indexOf(valueOption);
        if (index >= 0) {
            this.parameterValueOptions.removeAt(index);
        }
    };
    ValueOptionsFormComponent.prototype.booleanSettingChecked = function (checkbox) {
        if (checkbox.value == this.valueOptionSettings.Boolean)
            while (this.parameterValueOptions.length !== 0) {
                this.parameterValueOptions.removeAt(0);
            }
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('parameterForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], ValueOptionsFormComponent.prototype, "parameterForm", void 0);
    ValueOptionsFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-value-options-form',
            template: __webpack_require__(/*! raw-loader!./value-options-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.html"),
            styles: [__webpack_require__(/*! ./value-options-form.component.scss */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ValueOptionsFormComponent);
    return ValueOptionsFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.scss":
/*!**************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.scss ***!
  \**************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".parameters-list {\n  width: 800px;\n  max-width: 100%;\n  border-top: solid 1px gray;\n  border-left: solid 1px gray;\n  border-right: solid 1px gray;\n  display: block;\n  border-radius: 4px;\n  overflow: hidden;\n  background: #424242;\n  position: center;\n  margin-left: 20px;\n}\n\n.parameter-in-list {\n  border-bottom: solid 1px gray;\n  color: white;\n  display: flex;\n  flex-direction: row;\n  align-items: baseline;\n  justify-content: flex-start;\n  box-sizing: border-box;\n  cursor: move;\n  font-size: 14px;\n  background: #424242;\n}\n\n.selected-parameter {\n  border: dashed 3px #9c27b0;\n}\n\n.cdk-drag-preview {\n  box-sizing: border-box;\n  border-radius: 4px;\n  box-shadow: 0 5px 5px -3px rgba(0, 0, 0, 0.2), 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12);\n}\n\n.cdk-drag-animating {\n  transition: -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1), -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n}\n\n.parameter-in-list.cdk-drop-list-dragging .parameter-in-list:not(.cdk-drag-placeholder) {\n  transition: -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1), -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n}\n\n.parameter-placeholder {\n  background: #ccc;\n  border: dotted 3px #999;\n  min-height: 35px;\n  transition: -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1), -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n}\n\n.parameter-name {\n  font-size: 18px;\n}\n\n.parameter-container {\n  width: 100%;\n  display: flex;\n  align-items: center;\n}\n\n.parameter-data {\n  float: left;\n  width: 75%;\n}\n\n.parameter-options {\n  float: right;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL3BhcmFtZXRlcnMtZm9ybS9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9hcHBcXG1vZHVsZXNcXHNjcmlwdC1pbnRlcnByZXRlclxcY29tcG9uZW50c1xcc2NyaXB0LWZvcm1cXHBhcmFtZXRlcnMtZm9ybVxccGFyYW1ldGVycy1mb3JtLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL3BhcmFtZXRlcnMtZm9ybS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLFlBQUE7RUFDQSxlQUFBO0VBQ0EsMEJBQUE7RUFDQSwyQkFBQTtFQUNBLDRCQUFBO0VBQ0EsY0FBQTtFQUNBLGtCQUFBO0VBQ0EsZ0JBQUE7RUFDQSxtQkFBQTtFQUNBLGdCQUFBO0VBQ0EsaUJBQUE7QUNDSjs7QURFQTtFQUNJLDZCQUFBO0VBQ0EsWUFBQTtFQUNBLGFBQUE7RUFDQSxtQkFBQTtFQUNBLHFCQUFBO0VBQ0EsMkJBQUE7RUFDQSxzQkFBQTtFQUNBLFlBQUE7RUFDQSxlQUFBO0VBQ0EsbUJBQUE7QUNDSjs7QURFQTtFQUNJLDBCQUFBO0FDQ0o7O0FERUE7RUFDSSxzQkFBQTtFQUNBLGtCQUFBO0VBQ0EscUhBQUE7QUNDSjs7QURFQTtFQUNJLDhEQUFBO0VBQUEsc0RBQUE7RUFBQSwwR0FBQTtBQ0NKOztBREtBO0VBQ0ksOERBQUE7RUFBQSxzREFBQTtFQUFBLDBHQUFBO0FDRko7O0FES0E7RUFDSSxnQkFBQTtFQUNBLHVCQUFBO0VBQ0EsZ0JBQUE7RUFDQSw4REFBQTtFQUFBLHNEQUFBO0VBQUEsMEdBQUE7QUNGSjs7QURNQTtFQUNJLGVBQUE7QUNISjs7QURNQTtFQUNJLFdBQUE7RUFDQSxhQUFBO0VBQ0EsbUJBQUE7QUNISjs7QURNQTtFQUNJLFdBQUE7RUFDQSxVQUFBO0FDSEo7O0FETUE7RUFDSSxZQUFBO0FDSEoiLCJmaWxlIjoiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL3BhcmFtZXRlcnMtZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5wYXJhbWV0ZXJzLWxpc3Qge1xyXG4gICAgd2lkdGg6IDgwMHB4O1xyXG4gICAgbWF4LXdpZHRoOiAxMDAlO1xyXG4gICAgYm9yZGVyLXRvcDogc29saWQgMXB4IGdyYXk7XHJcbiAgICBib3JkZXItbGVmdDogc29saWQgMXB4IGdyYXk7XHJcbiAgICBib3JkZXItcmlnaHQ6IHNvbGlkIDFweCBncmF5O1xyXG4gICAgZGlzcGxheTogYmxvY2s7XHJcbiAgICBib3JkZXItcmFkaXVzOiA0cHg7XHJcbiAgICBvdmVyZmxvdzogaGlkZGVuO1xyXG4gICAgYmFja2dyb3VuZDogcmdiYSg2Niw2Niw2NiwxKTtcclxuICAgIHBvc2l0aW9uOiBjZW50ZXI7XHJcbiAgICBtYXJnaW4tbGVmdDogMjBweDtcclxufVxyXG5cclxuLnBhcmFtZXRlci1pbi1saXN0IHtcclxuICAgIGJvcmRlci1ib3R0b206IHNvbGlkIDFweCBncmF5O1xyXG4gICAgY29sb3I6IHdoaXRlO1xyXG4gICAgZGlzcGxheTogZmxleDtcclxuICAgIGZsZXgtZGlyZWN0aW9uOiByb3c7XHJcbiAgICBhbGlnbi1pdGVtczogYmFzZWxpbmU7XHJcbiAgICBqdXN0aWZ5LWNvbnRlbnQ6IGZsZXgtc3RhcnQ7XHJcbiAgICBib3gtc2l6aW5nOiBib3JkZXItYm94O1xyXG4gICAgY3Vyc29yOiBtb3ZlO1xyXG4gICAgZm9udC1zaXplOiAxNHB4O1xyXG4gICAgYmFja2dyb3VuZDogcmdiYSg2Niw2Niw2NiwxKTtcclxufVxyXG5cclxuLnNlbGVjdGVkLXBhcmFtZXRlciB7XHJcbiAgICBib3JkZXI6IGRhc2hlZCAzcHggcmdiKDE1NiwzOSwxNzYpO1xyXG59XHJcblxyXG4uY2RrLWRyYWctcHJldmlldyB7XHJcbiAgICBib3gtc2l6aW5nOiBib3JkZXItYm94O1xyXG4gICAgYm9yZGVyLXJhZGl1czogNHB4O1xyXG4gICAgYm94LXNoYWRvdzogMCA1cHggNXB4IC0zcHggcmdiYSgwLCAwLCAwLCAwLjIpLCAwIDhweCAxMHB4IDFweCByZ2JhKDAsIDAsIDAsIDAuMTQpLCAwIDNweCAxNHB4IDJweCByZ2JhKDAsIDAsIDAsIDAuMTIpO1xyXG59XHJcblxyXG4uY2RrLWRyYWctYW5pbWF0aW5nIHtcclxuICAgIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcclxufVxyXG5cclxuLnBhcmFtZXRlci1pbi1saXN0Omxhc3QtY2hpbGQge1xyXG59XHJcblxyXG4ucGFyYW1ldGVyLWluLWxpc3QuY2RrLWRyb3AtbGlzdC1kcmFnZ2luZyAucGFyYW1ldGVyLWluLWxpc3Q6bm90KC5jZGstZHJhZy1wbGFjZWhvbGRlcikge1xyXG4gICAgdHJhbnNpdGlvbjogdHJhbnNmb3JtIDI1MG1zIGN1YmljLWJlemllcigwLCAwLCAwLjIsIDEpO1xyXG59XHJcblxyXG4ucGFyYW1ldGVyLXBsYWNlaG9sZGVyIHtcclxuICAgIGJhY2tncm91bmQ6ICNjY2M7XHJcbiAgICBib3JkZXI6IGRvdHRlZCAzcHggIzk5OTtcclxuICAgIG1pbi1oZWlnaHQ6IDM1cHg7XHJcbiAgICB0cmFuc2l0aW9uOiB0cmFuc2Zvcm0gMjUwbXMgY3ViaWMtYmV6aWVyKDAsIDAsIDAuMiwgMSk7XHJcbn1cclxuXHJcbi8vIFBhcmFtZXRlciByb3dcclxuLnBhcmFtZXRlci1uYW1lIHtcclxuICAgIGZvbnQtc2l6ZTogMThweDtcclxufVxyXG5cclxuLnBhcmFtZXRlci1jb250YWluZXIge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAgYWxpZ24taXRlbXM6IGNlbnRlcjtcclxufVxyXG5cclxuLnBhcmFtZXRlci1kYXRhIHtcclxuICAgIGZsb2F0OiBsZWZ0O1xyXG4gICAgd2lkdGg6IDc1JTtcclxufVxyXG5cclxuLnBhcmFtZXRlci1vcHRpb25zIHtcclxuICAgIGZsb2F0OiByaWdodDtcclxufVxyXG4iLCIucGFyYW1ldGVycy1saXN0IHtcbiAgd2lkdGg6IDgwMHB4O1xuICBtYXgtd2lkdGg6IDEwMCU7XG4gIGJvcmRlci10b3A6IHNvbGlkIDFweCBncmF5O1xuICBib3JkZXItbGVmdDogc29saWQgMXB4IGdyYXk7XG4gIGJvcmRlci1yaWdodDogc29saWQgMXB4IGdyYXk7XG4gIGRpc3BsYXk6IGJsb2NrO1xuICBib3JkZXItcmFkaXVzOiA0cHg7XG4gIG92ZXJmbG93OiBoaWRkZW47XG4gIGJhY2tncm91bmQ6ICM0MjQyNDI7XG4gIHBvc2l0aW9uOiBjZW50ZXI7XG4gIG1hcmdpbi1sZWZ0OiAyMHB4O1xufVxuXG4ucGFyYW1ldGVyLWluLWxpc3Qge1xuICBib3JkZXItYm90dG9tOiBzb2xpZCAxcHggZ3JheTtcbiAgY29sb3I6IHdoaXRlO1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LWRpcmVjdGlvbjogcm93O1xuICBhbGlnbi1pdGVtczogYmFzZWxpbmU7XG4gIGp1c3RpZnktY29udGVudDogZmxleC1zdGFydDtcbiAgYm94LXNpemluZzogYm9yZGVyLWJveDtcbiAgY3Vyc29yOiBtb3ZlO1xuICBmb250LXNpemU6IDE0cHg7XG4gIGJhY2tncm91bmQ6ICM0MjQyNDI7XG59XG5cbi5zZWxlY3RlZC1wYXJhbWV0ZXIge1xuICBib3JkZXI6IGRhc2hlZCAzcHggIzljMjdiMDtcbn1cblxuLmNkay1kcmFnLXByZXZpZXcge1xuICBib3gtc2l6aW5nOiBib3JkZXItYm94O1xuICBib3JkZXItcmFkaXVzOiA0cHg7XG4gIGJveC1zaGFkb3c6IDAgNXB4IDVweCAtM3B4IHJnYmEoMCwgMCwgMCwgMC4yKSwgMCA4cHggMTBweCAxcHggcmdiYSgwLCAwLCAwLCAwLjE0KSwgMCAzcHggMTRweCAycHggcmdiYSgwLCAwLCAwLCAwLjEyKTtcbn1cblxuLmNkay1kcmFnLWFuaW1hdGluZyB7XG4gIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcbn1cblxuLnBhcmFtZXRlci1pbi1saXN0LmNkay1kcm9wLWxpc3QtZHJhZ2dpbmcgLnBhcmFtZXRlci1pbi1saXN0Om5vdCguY2RrLWRyYWctcGxhY2Vob2xkZXIpIHtcbiAgdHJhbnNpdGlvbjogdHJhbnNmb3JtIDI1MG1zIGN1YmljLWJlemllcigwLCAwLCAwLjIsIDEpO1xufVxuXG4ucGFyYW1ldGVyLXBsYWNlaG9sZGVyIHtcbiAgYmFja2dyb3VuZDogI2NjYztcbiAgYm9yZGVyOiBkb3R0ZWQgM3B4ICM5OTk7XG4gIG1pbi1oZWlnaHQ6IDM1cHg7XG4gIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcbn1cblxuLnBhcmFtZXRlci1uYW1lIHtcbiAgZm9udC1zaXplOiAxOHB4O1xufVxuXG4ucGFyYW1ldGVyLWNvbnRhaW5lciB7XG4gIHdpZHRoOiAxMDAlO1xuICBkaXNwbGF5OiBmbGV4O1xuICBhbGlnbi1pdGVtczogY2VudGVyO1xufVxuXG4ucGFyYW1ldGVyLWRhdGEge1xuICBmbG9hdDogbGVmdDtcbiAgd2lkdGg6IDc1JTtcbn1cblxuLnBhcmFtZXRlci1vcHRpb25zIHtcbiAgZmxvYXQ6IHJpZ2h0O1xufSJdfQ== */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts":
/*!************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts ***!
  \************************************************************************************************************/
/*! exports provided: ParametersFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParametersFormComponent", function() { return ParametersFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _models_enums_parameter_filter__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../models/enums/parameter-filter */ "./app/modules/script-interpreter/models/enums/parameter-filter.ts");
/* harmony import */ var _models_parameterImpl__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../models/parameterImpl */ "./app/modules/script-interpreter/models/parameterImpl.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../services/parameter.service */ "./app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "../node_modules/@angular/cdk/esm5/drag-drop.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var ParametersFormComponent = /** @class */ (function () {
    function ParametersFormComponent(parameterService, route) {
        this.parameterService = parameterService;
        this.route = route;
        this.newParameter = new _models_parameterImpl__WEBPACK_IMPORTED_MODULE_3__["ParameterImpl"]();
        this.editMode = false;
        this.newlyAddedParameter = false;
        this.parametersToShow = "all";
    }
    ParametersFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.scriptId = +params['id'];
        });
        if (isNaN(this.scriptId))
            return;
        this.getParameters(this.scriptId);
    };
    ParametersFormComponent.prototype.drop = function (event) {
        Object(_angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_5__["moveItemInArray"])(this.filteredParameters, event.previousIndex, event.currentIndex);
        this.setNumbers(event);
        this.saveParameters();
    };
    ParametersFormComponent.prototype.setNumbers = function (event) {
        var sortedParameters = this.sortParameters(this.filteredParameters, 'number');
        var addition = this.getAddition();
        sortedParameters[event.previousIndex].number = event.currentIndex + addition;
        if (event.currentIndex < event.previousIndex) {
            var i = event.previousIndex - 1;
            for (i; i >= event.currentIndex; i--)
                sortedParameters[i].number = sortedParameters[i].number + 1;
        }
        else if (event.currentIndex > event.previousIndex) {
            var i = event.currentIndex;
            for (i; i > event.previousIndex; i--)
                sortedParameters[i].number = sortedParameters[i].number - 1;
        }
    };
    ParametersFormComponent.prototype.getAddition = function () {
        var addition = 0;
        if (this.parametersToShow == 'data')
            addition = 0;
        if (this.parametersToShow == 'static' || this.parametersToShow == 'calculation') {
            var parametersFilterCriteria_1 = _models_enums_parameter_filter__WEBPACK_IMPORTED_MODULE_2__["ParameterFilter"]['data'];
            addition += this.parameters.filter(function (p) { return (p.context & parametersFilterCriteria_1) != 0; }).length;
        }
        if (this.parametersToShow == 'calculation') {
            var parametersFilterCriteria_2 = _models_enums_parameter_filter__WEBPACK_IMPORTED_MODULE_2__["ParameterFilter"]['static'];
            addition += this.parameters.filter(function (p) { return (p.context & parametersFilterCriteria_2) != 0; }).length;
        }
        return addition;
    };
    ParametersFormComponent.prototype.getParameters = function (id) {
        var _this = this;
        this.parameterService.getParameters(id).subscribe(function (parameters) {
            _this.parameters = parameters;
            _this.onParametersToShowChange();
            console.log("Parameters", _this.parameters);
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.onParametersToShowChange = function () {
        var parametersFilterCriteria = _models_enums_parameter_filter__WEBPACK_IMPORTED_MODULE_2__["ParameterFilter"][this.parametersToShow];
        switch (parametersFilterCriteria) {
            case _models_enums_parameter_filter__WEBPACK_IMPORTED_MODULE_2__["ParameterFilter"].all:
                this.filteredParameters = this.parameters;
                break;
            default:
                this.filteredParameters = this.parameters.filter(function (p) { return (p.context & parametersFilterCriteria) != 0; });
                break;
        }
    };
    ParametersFormComponent.prototype.editParameter = function (parameter) {
        this.editMode = true;
        this.newlyAddedParameter = false;
        this.newParameter = parameter;
    };
    ParametersFormComponent.prototype.remove = function (parameterId) {
        var _this = this;
        if (confirm("Are you sure?")) {
            this.parameterService.delete(this.scriptId, parameterId)
                .subscribe(function (p) {
                _this.onParametersToShowChange();
                _this.refreshNumbering(p.number);
                _this.saveParameters();
            }, function (error) { return console.error(error); });
            this.parameters = this.parameters.filter(function (p) { return p.id != parameterId; });
        }
    };
    ParametersFormComponent.prototype.refreshNumbering = function (number) {
        var index = 0;
        for (var _i = 0, _a = this.sortParameters(this.parameters, 'number'); _i < _a.length; _i++) {
            var parameter = _a[_i];
            parameter.number = index++;
        }
    };
    ParametersFormComponent.prototype.onCreated = function (parameter) {
        var _this = this;
        if (this.parameters.length > 0)
            parameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number; })) + 1;
        else
            parameter.number = 0;
        this.parameterService.create(this.scriptId, parameter)
            .subscribe(function (p) {
            _this.parameters.push(p);
        });
        this.editMode = false;
    };
    ParametersFormComponent.prototype.onUpdated = function (parameter) {
        var index = this.parameters.findIndex(function (p) { return p.id == parameter.id; });
        this.parameters[index] = parameter;
        this.editMode = false;
    };
    ParametersFormComponent.prototype.changeEditMode = function () {
        if (this.editMode) {
            this.editMode = false;
            this.newlyAddedParameter = false;
            this.newParameter = null;
        }
    };
    ParametersFormComponent.prototype.sortParameters = function (parameters, prop) {
        if (parameters)
            return parameters.sort(function (a, b) { return a[prop] > b[prop] ? 1 :
                a[prop] === b[prop] ? 0 :
                    -1; });
    };
    ParametersFormComponent.prototype.addNewParameter = function () {
        this.editMode = true;
        this.newlyAddedParameter = true;
        this.newParameter = new _models_parameterImpl__WEBPACK_IMPORTED_MODULE_3__["ParameterImpl"]();
        this.newParameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number; })) + 1;
    };
    ParametersFormComponent.prototype.saveParameters = function () {
        var _this = this;
        this.parameters.forEach(function (p) {
            _this.parameterService.update(_this.scriptId, p)
                .subscribe(function (p) {
                console.log(p);
            }, function (error) { return console.error(error); });
        });
    };
    ParametersFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-parameters-form',
            template: __webpack_require__(/*! raw-loader!./parameters-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.html"),
            styles: [__webpack_require__(/*! ./parameters-form.component.scss */ "./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_parameter_service__WEBPACK_IMPORTED_MODULE_4__["ParameterService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], ParametersFormComponent);
    return ParametersFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.scss":
/*!****************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.scss ***!
  \****************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%;\n}\n\n.full-width {\n  width: 98%;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL3NjcmlwdC1kYXRhLWZvcm0vQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1mb3JtXFxzY3JpcHQtZGF0YS1mb3JtXFxzY3JpcHQtZGF0YS1mb3JtLmNvbXBvbmVudC5zY3NzIiwiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vc2NyaXB0LWRhdGEtZm9ybS9zY3JpcHQtZGF0YS1mb3JtLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksZ0JBQUE7RUFDQSxnQkFBQTtFQUNBLFdBQUE7QUNDSjs7QURFQTtFQUNJLFVBQUE7QUNDSiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9zY3JpcHQtZGF0YS1mb3JtL3NjcmlwdC1kYXRhLWZvcm0uY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuZm9ybS1tZWRpdW0ge1xyXG4gICAgbWluLXdpZHRoOiAxNTBweDtcclxuICAgIG1heC13aWR0aDogMzQwcHg7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufVxyXG5cclxuLmZ1bGwtd2lkdGgge1xyXG4gICAgd2lkdGg6IDk4JTtcclxufVxyXG4iLCIuZm9ybS1tZWRpdW0ge1xuICBtaW4td2lkdGg6IDE1MHB4O1xuICBtYXgtd2lkdGg6IDM0MHB4O1xuICB3aWR0aDogMTAwJTtcbn1cblxuLmZ1bGwtd2lkdGgge1xuICB3aWR0aDogOTglO1xufSJdfQ== */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.ts":
/*!**************************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.ts ***!
  \**************************************************************************************************************/
/*! exports provided: ScriptDataFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptDataFormComponent", function() { return ScriptDataFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../common/errors/app-error-state-matcher */ "./app/common/errors/app-error-state-matcher.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ScriptDataFormComponent = /** @class */ (function () {
    function ScriptDataFormComponent() {
        this.matcher = new _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_2__["AppErrorStateMatcher"]();
    }
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptAuthor", {
        get: function () {
            return this.scriptForm.get('author');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptDocument", {
        get: function () {
            return this.scriptForm.get('accordingTo');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptGroup", {
        get: function () {
            return this.scriptForm.get('groupName');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptDescription", {
        get: function () {
            return this.scriptForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptNotes", {
        get: function () {
            return this.scriptForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('scriptForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], ScriptDataFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('includeNote'),
        __metadata("design:type", Boolean)
    ], ScriptDataFormComponent.prototype, "includeNote", void 0);
    ScriptDataFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'script-data-form',
            template: __webpack_require__(/*! raw-loader!./script-data-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.html"),
            styles: [__webpack_require__(/*! ./script-data-form.component.scss */ "./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.scss")]
        })
    ], ScriptDataFormComponent);
    return ScriptDataFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/script-form.component.scss":
/*!******************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/script-form.component.scss ***!
  \******************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%;\n}\n\n.full-width {\n  width: 100%;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL2FwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtZm9ybVxcc2NyaXB0LWZvcm0uY29tcG9uZW50LnNjc3MiLCJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9zY3JpcHQtZm9ybS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDQTtFQUNJLGdCQUFBO0VBQ0EsZ0JBQUE7RUFDQSxXQUFBO0FDQUo7O0FER0E7RUFDSSxXQUFBO0FDQUoiLCJmaWxlIjoiYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vc2NyaXB0LWZvcm0uY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJcclxuLmZvcm0tbWVkaXVtIHtcclxuICAgIG1pbi13aWR0aDogMTUwcHg7XHJcbiAgICBtYXgtd2lkdGg6IDM0MHB4O1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbi5mdWxsLXdpZHRoIHtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59IiwiLmZvcm0tbWVkaXVtIHtcbiAgbWluLXdpZHRoOiAxNTBweDtcbiAgbWF4LXdpZHRoOiAzNDBweDtcbiAgd2lkdGg6IDEwMCU7XG59XG5cbi5mdWxsLXdpZHRoIHtcbiAgd2lkdGg6IDEwMCU7XG59Il19 */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/script-form.component.ts":
/*!****************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/script-form.component.ts ***!
  \****************************************************************************************/
/*! exports provided: ScriptFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptFormComponent", function() { return ScriptFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/script.service */ "./app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _services_tag_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../services/tag.service */ "./app/modules/script-interpreter/services/tag.service.ts");
/* harmony import */ var _parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./parameters-form/parameters-form.component */ "./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __awaiter = (undefined && undefined.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (undefined && undefined.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};






var ScriptFormComponent = /** @class */ (function () {
    function ScriptFormComponent(scriptService, tagService, route, router) {
        this.scriptService = scriptService;
        this.tagService = tagService;
        this.route = route;
        this.router = router;
        this.scriptForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
            id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0'),
            name: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].minLength(5), _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(100)]),
            author: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(40)),
            accordingTo: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(50)),
            groupName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('Other'),
            description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].minLength(25), _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(500)]),
            notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(1000)),
            tags: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormArray"]([])
        });
        this.parametersToShow = 'dataParameters';
        this.editMode = true;
    }
    Object.defineProperty(ScriptFormComponent.prototype, "scriptId", {
        get: function () {
            return this.scriptForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptFormComponent.prototype, "scriptName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptFormComponent.prototype, "scriptTags", {
        get: function () {
            return this.scriptForm.get('tags');
        },
        enumerable: true,
        configurable: true
    });
    ScriptFormComponent.prototype.ngOnInit = function () {
        var id;
        var sub = this.route.params.subscribe(function (params) {
            id = +params['id'];
        });
        if (isNaN(id)) {
            this.editMode = false;
            return;
        }
        this.getScript(id);
    };
    ScriptFormComponent.prototype.getScript = function (id) {
        var _this = this;
        this.scriptService.getScript(id).subscribe(function (script) {
            console.log("Script", script);
            _this.includeNote = script.notes != null && script.notes != '';
            _this.scriptForm.patchValue(script);
            script.tags.forEach(function (t) { return _this.scriptTags.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](t.id),
                name: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](t.name)
            })); });
        }, function (error) { throw error; });
    };
    ScriptFormComponent.prototype.onSubmit = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this._setTags()];
                    case 1:
                        _a.sent();
                        if (!this.editMode)
                            this.scriptService.create(this.scriptForm.value)
                                .subscribe(function (script) {
                                console.log(script);
                                _this.router.navigateByUrl('/scripts/edit/' + script.id);
                            }, function (error) { throw error; });
                        else
                            this.scriptService.update(this.scriptForm.value)
                                .subscribe(function (script) { return console.log(script); });
                        this.parametersForm.saveParameters();
                        return [2 /*return*/];
                }
            });
        });
    };
    ScriptFormComponent.prototype._setTags = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _i, _a, tag, newTag;
            return __generator(this, function (_b) {
                switch (_b.label) {
                    case 0:
                        _i = 0, _a = this.scriptTags.value;
                        _b.label = 1;
                    case 1:
                        if (!(_i < _a.length)) return [3 /*break*/, 4];
                        tag = _a[_i];
                        if (!(tag.id == 0)) return [3 /*break*/, 3];
                        return [4 /*yield*/, this._setTag(tag)];
                    case 2:
                        newTag = _b.sent();
                        tag.id = newTag.id;
                        console.log(newTag);
                        _b.label = 3;
                    case 3:
                        _i++;
                        return [3 /*break*/, 1];
                    case 4: return [2 /*return*/];
                }
            });
        });
    };
    ScriptFormComponent.prototype._setTag = function (tag) {
        return __awaiter(this, void 0, void 0, function () {
            var newTag;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.tagService.create(tag).toPromise()];
                    case 1:
                        newTag = _a.sent();
                        return [2 /*return*/, newTag];
                }
            });
        });
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])(_parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_5__["ParametersFormComponent"], { static: false }),
        __metadata("design:type", _parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_5__["ParametersFormComponent"])
    ], ScriptFormComponent.prototype, "parametersForm", void 0);
    ScriptFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'script-form',
            template: __webpack_require__(/*! raw-loader!./script-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/script-form.component.html"),
            styles: [__webpack_require__(/*! ./script-form.component.scss */ "./app/modules/script-interpreter/components/script-form/script-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_script_service__WEBPACK_IMPORTED_MODULE_3__["ScriptService"],
            _services_tag_service__WEBPACK_IMPORTED_MODULE_4__["TagService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], ScriptFormComponent);
    return ScriptFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.scss":
/*!************************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.scss ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS90YWctZm9ybS90YWctZm9ybS5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.ts":
/*!**********************************************************************************************!*\
  !*** ./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.ts ***!
  \**********************************************************************************************/
/*! exports provided: TagFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TagFormComponent", function() { return TagFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_tag_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../services/tag.service */ "./app/modules/script-interpreter/services/tag.service.ts");
/* harmony import */ var _angular_cdk_keycodes__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/cdk/keycodes */ "../node_modules/@angular/cdk/esm5/keycodes.es5.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/autocomplete */ "../node_modules/@angular/material/esm5/autocomplete.es5.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/operators */ "../node_modules/rxjs/_esm5/operators/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var TagFormComponent = /** @class */ (function () {
    function TagFormComponent(tagService) {
        this.tagService = tagService;
        this.visible = true;
        this.selectable = true;
        this.removable = true;
        this.addOnBlur = true;
        this.separatorKeysCodes = [_angular_cdk_keycodes__WEBPACK_IMPORTED_MODULE_2__["ENTER"], _angular_cdk_keycodes__WEBPACK_IMPORTED_MODULE_2__["COMMA"]];
        this.tagCtrl = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]();
    }
    Object.defineProperty(TagFormComponent.prototype, "scriptId", {
        get: function () {
            return this.scriptForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TagFormComponent.prototype, "scriptTags", {
        get: function () {
            return this.scriptForm.get('tags');
        },
        enumerable: true,
        configurable: true
    });
    TagFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.filteredTags = this.tagCtrl.valueChanges.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_5__["startWith"])(null), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_5__["map"])(function (tagName) { return tagName ? _this._filter(tagName) : _this.tags; }));
        this.getTags();
    };
    TagFormComponent.prototype.getTags = function () {
        var _this = this;
        this.tagService.getTags().subscribe(function (tags) {
            _this.tags = tags;
            _this.tagCtrl.setValue(null);
        }, function (error) { return console.error(error); });
    };
    TagFormComponent.prototype.add = function (event) {
        if (!this.matAutocomplete.isOpen) {
            var input = event.input;
            var value_1 = event.value;
            if ((value_1 || '').trim() && !this.scriptTags.controls.some(function (c) { return c.value.name == value_1.trim(); })) {
                this.scriptTags.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormGroup"]({
                    id: new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](0),
                    name: new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](value_1.trim())
                }));
            }
            if (input) {
                input.value = '';
            }
            if (this.scriptTags.controls.length > 5)
                this.tagCtrl.setValue('###Not supposed to be on the list###');
            else
                this.tagCtrl.setValue(null);
        }
    };
    TagFormComponent.prototype.remove = function (tagForm) {
        var index = this.scriptTags.controls.indexOf(tagForm);
        if (index >= 0) {
            this.scriptTags.removeAt(index);
        }
    };
    TagFormComponent.prototype.selected = function (event) {
        var tag = this.tags.find(function (t) { return t.name == event.option.viewValue; });
        if (tag == null) {
            this.tagInput.nativeElement.value = '';
            this.tagCtrl.setValue(null);
            return;
        }
        this.scriptTags.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormGroup"]({
            id: new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](tag.id),
            name: new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](tag.name)
        }));
        this.tagInput.nativeElement.value = '';
        this.tagCtrl.setValue(null);
    };
    TagFormComponent.prototype._filter = function (value) {
        var filterValue = value.toLowerCase();
        return this.tags.filter(function (t) { return t.name.toLowerCase().indexOf(filterValue) === 0; });
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('scriptForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormGroup"])
    ], TagFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('tagInput', { static: false }),
        __metadata("design:type", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ElementRef"])
    ], TagFormComponent.prototype, "tagInput", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('auto', { static: false }),
        __metadata("design:type", _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_4__["MatAutocomplete"])
    ], TagFormComponent.prototype, "matAutocomplete", void 0);
    TagFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'tag-form',
            template: __webpack_require__(/*! raw-loader!./tag-form.component.html */ "../node_modules/raw-loader/index.js!./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.html"),
            styles: [__webpack_require__(/*! ./tag-form.component.scss */ "./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_tag_service__WEBPACK_IMPORTED_MODULE_1__["TagService"]])
    ], TagFormComponent);
    return TagFormComponent;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/models/enums/parameter-filter.ts":
/*!*************************************************************************!*\
  !*** ./app/modules/script-interpreter/models/enums/parameter-filter.ts ***!
  \*************************************************************************/
/*! exports provided: ParameterFilter */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterFilter", function() { return ParameterFilter; });
var ParameterFilter;
(function (ParameterFilter) {
    ParameterFilter[ParameterFilter["all"] = 0] = "all";
    ParameterFilter[ParameterFilter["data"] = 2] = "data";
    ParameterFilter[ParameterFilter["static"] = 8] = "static";
    ParameterFilter[ParameterFilter["calculation"] = 4] = "calculation";
})(ParameterFilter || (ParameterFilter = {}));


/***/ }),

/***/ "./app/modules/script-interpreter/models/enums/parameterOptions.ts":
/*!*************************************************************************!*\
  !*** ./app/modules/script-interpreter/models/enums/parameterOptions.ts ***!
  \*************************************************************************/
/*! exports provided: ParameterOptions */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterOptions", function() { return ParameterOptions; });
var ParameterOptions;
(function (ParameterOptions) {
    ParameterOptions[ParameterOptions["none"] = 0] = "none";
    ParameterOptions[ParameterOptions["visible"] = 1] = "visible";
    ParameterOptions[ParameterOptions["editable"] = 2] = "editable";
    ParameterOptions[ParameterOptions["calculation"] = 4] = "calculation";
    ParameterOptions[ParameterOptions["staticData"] = 8] = "staticData";
    ParameterOptions[ParameterOptions["important"] = 16] = "important";
    ParameterOptions[ParameterOptions["optional"] = 32] = "optional";
})(ParameterOptions || (ParameterOptions = {}));


/***/ }),

/***/ "./app/modules/script-interpreter/models/enums/valueOptionSettings.ts":
/*!****************************************************************************!*\
  !*** ./app/modules/script-interpreter/models/enums/valueOptionSettings.ts ***!
  \****************************************************************************/
/*! exports provided: ValueOptionSettings */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValueOptionSettings", function() { return ValueOptionSettings; });
var ValueOptionSettings;
(function (ValueOptionSettings) {
    ValueOptionSettings[ValueOptionSettings["None"] = 0] = "None";
    ValueOptionSettings[ValueOptionSettings["UserInput"] = 1] = "UserInput";
    ValueOptionSettings[ValueOptionSettings["Boolean"] = 2] = "Boolean";
})(ValueOptionSettings || (ValueOptionSettings = {}));


/***/ }),

/***/ "./app/modules/script-interpreter/models/enums/valueType.ts":
/*!******************************************************************!*\
  !*** ./app/modules/script-interpreter/models/enums/valueType.ts ***!
  \******************************************************************/
/*! exports provided: ValueType */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValueType", function() { return ValueType; });
var ValueType;
(function (ValueType) {
    ValueType["number"] = "Number";
    ValueType["text"] = "Text";
})(ValueType || (ValueType = {}));


/***/ }),

/***/ "./app/modules/script-interpreter/models/parameterImpl.ts":
/*!****************************************************************!*\
  !*** ./app/modules/script-interpreter/models/parameterImpl.ts ***!
  \****************************************************************/
/*! exports provided: ParameterImpl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterImpl", function() { return ParameterImpl; });
/* harmony import */ var _enums_valueType__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./enums/valueType */ "./app/modules/script-interpreter/models/enums/valueType.ts");

var ParameterImpl = /** @class */ (function () {
    function ParameterImpl() {
        this.valueType = _enums_valueType__WEBPACK_IMPORTED_MODULE_0__["ValueType"].number;
        this.valueOptions = [];
        this.figures = [];
    }
    return ParameterImpl;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/models/parametersGroup.ts":
/*!******************************************************************!*\
  !*** ./app/modules/script-interpreter/models/parametersGroup.ts ***!
  \******************************************************************/
/*! exports provided: ParametersGroup */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParametersGroup", function() { return ParametersGroup; });
var ParametersGroup = /** @class */ (function () {
    function ParametersGroup(name) {
        this.parameters = [];
        this.name = name;
    }
    ParametersGroup.prototype.addParameter = function (parameter) {
        this.parameters.push(parameter);
    };
    ParametersGroup.prototype.clear = function () {
        this.parameters = [];
    };
    return ParametersGroup;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/models/valueOptionImpl.ts":
/*!******************************************************************!*\
  !*** ./app/modules/script-interpreter/models/valueOptionImpl.ts ***!
  \******************************************************************/
/*! exports provided: ValueOptionImpl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValueOptionImpl", function() { return ValueOptionImpl; });
var ValueOptionImpl = /** @class */ (function () {
    function ValueOptionImpl() {
    }
    return ValueOptionImpl;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/script-interpreter-routing.module.ts":
/*!*****************************************************************************!*\
  !*** ./app/modules/script-interpreter/script-interpreter-routing.module.ts ***!
  \*****************************************************************************/
/*! exports provided: ScriptInterpreterRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptInterpreterRoutingModule", function() { return ScriptInterpreterRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_script_form_script_form_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/script-form/script-form.component */ "./app/modules/script-interpreter/components/script-form/script-form.component.ts");
/* harmony import */ var _components_script_calculator_script_calculator_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/script-calculator/script-calculator.component */ "./app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var routes = [
    { path: 'scripts/new', component: _components_script_form_script_form_component__WEBPACK_IMPORTED_MODULE_2__["ScriptFormComponent"] },
    { path: 'scripts/edit/:id', component: _components_script_form_script_form_component__WEBPACK_IMPORTED_MODULE_2__["ScriptFormComponent"] },
    { path: 'scripts/calculator/:id', component: _components_script_calculator_script_calculator_component__WEBPACK_IMPORTED_MODULE_3__["ScriptCalculatorComponent"] },
    { path: 'scripts/calculator', component: _components_script_calculator_script_calculator_component__WEBPACK_IMPORTED_MODULE_3__["ScriptCalculatorComponent"] },
];
var ScriptInterpreterRoutingModule = /** @class */ (function () {
    function ScriptInterpreterRoutingModule() {
    }
    ScriptInterpreterRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]],
        })
    ], ScriptInterpreterRoutingModule);
    return ScriptInterpreterRoutingModule;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/script-interpreter.module.ts":
/*!*********************************************************************!*\
  !*** ./app/modules/script-interpreter/script-interpreter.module.ts ***!
  \*********************************************************************/
/*! exports provided: ScriptInterpreterModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptInterpreterModule", function() { return ScriptInterpreterModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "../node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser/animations */ "../node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _components_script_form_script_form_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/script-form/script-form.component */ "./app/modules/script-interpreter/components/script-form/script-form.component.ts");
/* harmony import */ var _components_script_form_parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/script-form/parameters-form/parameters-form.component */ "./app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts");
/* harmony import */ var _components_script_calculator_script_calculator_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/script-calculator/script-calculator.component */ "./app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_data_parameter_form_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/data-parameter-form.component */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.ts");
/* harmony import */ var _components_script_card_script_card_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./components/script-card/script-card.component */ "./app/modules/script-interpreter/components/script-card/script-card.component.ts");
/* harmony import */ var _components_script_cards_script_cards_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./components/script-cards/script-cards.component */ "./app/modules/script-interpreter/components/script-cards/script-cards.component.ts");
/* harmony import */ var _components_script_form_tag_form_tag_form_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./components/script-form/tag-form/tag-form.component */ "./app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_input_parameter_input_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/input/parameter-input.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_select_parameter_select_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/select/parameter-select.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_autocomplete_parameter_autocomplete_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_radio_parameter_radio_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/radio/parameter-radio.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_parameters_form_parameter_form_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/parameters-form/parameter-form.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_results_parameter_result_parameter_result_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./components/script-calculator/parameter-results/parameter-result/parameter-result.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_value_options_form_value_options_form_component__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.ts");
/* harmony import */ var _components_script_form_script_data_form_script_data_form_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./components/script-form/script-data-form/script-data-form.component */ "./app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_checkbox_parameter_checkbox_component__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_figure_parameter_form_figure_parameter_form_component__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_figures_parameter_figures_component__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/figures/parameter-figures.component */ "./app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_existing_figures_dialog_existing_figures_dialog_component__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component */ "./app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.ts");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./services/script.service */ "./app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _services_tag_service__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./services/tag.service */ "./app/modules/script-interpreter/services/tag.service.ts");
/* harmony import */ var _services_calculation_service__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./services/calculation.service */ "./app/modules/script-interpreter/services/calculation.service.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! ./services/parameter.service */ "./app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! ./../../common/errors/app-error-handler */ "./app/common/errors/app-error-handler.ts");
/* harmony import */ var _pipes_module_pipes_module__WEBPACK_IMPORTED_MODULE_30__ = __webpack_require__(/*! ../pipes-module/pipes.module */ "./app/modules/pipes-module/pipes.module.ts");
/* harmony import */ var _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_31__ = __webpack_require__(/*! ../md-components-module/md-components.module */ "./app/modules/md-components-module/md-components.module.ts");
/* harmony import */ var _services_figure_service__WEBPACK_IMPORTED_MODULE_32__ = __webpack_require__(/*! ./services/figure.service */ "./app/modules/script-interpreter/services/figure.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

































var ScriptInterpreterModule = /** @class */ (function () {
    function ScriptInterpreterModule() {
    }
    ScriptInterpreterModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _components_script_form_script_form_component__WEBPACK_IMPORTED_MODULE_6__["ScriptFormComponent"],
                _components_script_form_parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_7__["ParametersFormComponent"],
                _components_script_form_parameters_form_data_parameter_form_data_parameter_form_component__WEBPACK_IMPORTED_MODULE_9__["DataParameterFormComponent"],
                _components_script_form_parameters_form_data_parameter_form_value_options_form_value_options_form_component__WEBPACK_IMPORTED_MODULE_19__["ValueOptionsFormComponent"],
                _components_script_calculator_script_calculator_component__WEBPACK_IMPORTED_MODULE_8__["ScriptCalculatorComponent"],
                _components_script_card_script_card_component__WEBPACK_IMPORTED_MODULE_10__["ScriptCardComponent"],
                _components_script_cards_script_cards_component__WEBPACK_IMPORTED_MODULE_11__["ScriptCardsComponent"],
                _components_script_form_script_data_form_script_data_form_component__WEBPACK_IMPORTED_MODULE_20__["ScriptDataFormComponent"],
                _components_script_form_tag_form_tag_form_component__WEBPACK_IMPORTED_MODULE_12__["TagFormComponent"],
                _components_script_calculator_parameter_inputs_input_parameter_input_component__WEBPACK_IMPORTED_MODULE_13__["ParameterInputComponent"],
                _components_script_calculator_parameter_inputs_select_parameter_select_component__WEBPACK_IMPORTED_MODULE_14__["ParameterSelectComponent"],
                _components_script_calculator_parameter_inputs_autocomplete_parameter_autocomplete_component__WEBPACK_IMPORTED_MODULE_15__["ParameterAutocompleteComponent"],
                _components_script_calculator_parameter_inputs_radio_parameter_radio_component__WEBPACK_IMPORTED_MODULE_16__["ParameterRadioComponent"],
                _components_script_calculator_parameter_inputs_parameters_form_parameter_form_component__WEBPACK_IMPORTED_MODULE_17__["ParameterFormComponent"],
                _components_script_calculator_parameter_results_parameter_result_parameter_result_component__WEBPACK_IMPORTED_MODULE_18__["ParameterResultComponent"],
                _components_script_calculator_parameter_inputs_checkbox_parameter_checkbox_component__WEBPACK_IMPORTED_MODULE_21__["ParameterCheckboxComponent"],
                _components_script_form_parameters_form_data_parameter_form_figure_parameter_form_figure_parameter_form_component__WEBPACK_IMPORTED_MODULE_22__["FigureParameterFormComponent"],
                _components_script_calculator_parameter_inputs_figures_parameter_figures_component__WEBPACK_IMPORTED_MODULE_23__["ParameterFiguresComponent"],
                _components_script_form_parameters_form_data_parameter_form_existing_figures_dialog_existing_figures_dialog_component__WEBPACK_IMPORTED_MODULE_24__["ExistingFiguresDialogComponent"]
            ],
            imports: [
                _pipes_module_pipes_module__WEBPACK_IMPORTED_MODULE_30__["PipesModule"],
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__["BrowserAnimationsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
                _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_31__["MdComponentsModule"]
            ],
            entryComponents: [
                _components_script_form_parameters_form_data_parameter_form_existing_figures_dialog_existing_figures_dialog_component__WEBPACK_IMPORTED_MODULE_24__["ExistingFiguresDialogComponent"]
            ],
            exports: [
                _components_script_cards_script_cards_component__WEBPACK_IMPORTED_MODULE_11__["ScriptCardsComponent"]
            ],
            providers: [
                _services_script_service__WEBPACK_IMPORTED_MODULE_25__["ScriptService"],
                _services_tag_service__WEBPACK_IMPORTED_MODULE_26__["TagService"],
                _services_calculation_service__WEBPACK_IMPORTED_MODULE_27__["CalculationService"],
                _services_parameter_service__WEBPACK_IMPORTED_MODULE_28__["ParameterService"],
                _services_figure_service__WEBPACK_IMPORTED_MODULE_32__["FigureService"],
                { provide: _angular_core__WEBPACK_IMPORTED_MODULE_0__["ErrorHandler"], useClass: _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_29__["AppErrorHandler"] }
            ]
        })
    ], ScriptInterpreterModule);
    return ScriptInterpreterModule;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/services/calculation.service.ts":
/*!************************************************************************!*\
  !*** ./app/modules/script-interpreter/services/calculation.service.ts ***!
  \************************************************************************/
/*! exports provided: CalculationService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CalculationService", function() { return CalculationService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var CalculationService = /** @class */ (function () {
    function CalculationService(http) {
        this.http = http;
    }
    CalculationService.prototype.calculate = function (scriptId, parameters) {
        return this.http.put('/api/scripts/' + scriptId + '/calculate', parameters);
    };
    CalculationService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], CalculationService);
    return CalculationService;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/services/figure.service.ts":
/*!*******************************************************************!*\
  !*** ./app/modules/script-interpreter/services/figure.service.ts ***!
  \*******************************************************************/
/*! exports provided: FigureService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FigureService", function() { return FigureService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var FigureService = /** @class */ (function () {
    function FigureService(http) {
        this.http = http;
    }
    FigureService.prototype.getFigures = function (parameterId) {
        return this.http.get("/api/parameters/" + parameterId + "/figures");
    };
    FigureService.prototype.upload = function (parameterId, photo) {
        var formData = new FormData();
        formData.append('file', photo);
        return this.http.post("/api/parameters/" + parameterId + "/figures", formData);
    };
    FigureService.prototype.detach = function (parameterId, figureId) {
        return this.http.delete('/api/parameters/' + parameterId + '/figures/' + figureId);
    };
    FigureService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
    ], FigureService);
    return FigureService;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/services/parameter.service.ts":
/*!**********************************************************************!*\
  !*** ./app/modules/script-interpreter/services/parameter.service.ts ***!
  \**********************************************************************/
/*! exports provided: ParameterService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterService", function() { return ParameterService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ParameterService = /** @class */ (function () {
    function ParameterService(http) {
        this.http = http;
    }
    ParameterService.prototype.delete = function (scriptId, parameterId) {
        return this.http.delete('/api/scripts/' + scriptId + '/parameters/' + parameterId);
    };
    ParameterService.prototype.getParameters = function (scriptId) {
        return this.http.get('/api/scripts/' + scriptId + '/parameters');
    };
    ParameterService.prototype.create = function (scriptId, parameter) {
        return this.http.post('/api/scripts/' + scriptId + '/parameters', parameter);
    };
    ParameterService.prototype.update = function (scriptId, parameter) {
        return this.http.put('/api/scripts/' + scriptId + '/parameters/' + parameter.id, parameter);
    };
    ParameterService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], ParameterService);
    return ParameterService;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/services/script.service.ts":
/*!*******************************************************************!*\
  !*** ./app/modules/script-interpreter/services/script.service.ts ***!
  \*******************************************************************/
/*! exports provided: ScriptService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptService", function() { return ScriptService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "../node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "../node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../common/errors/app-error */ "./app/common/errors/app-error.ts");
/* harmony import */ var _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../common/errors/not-found-error */ "./app/common/errors/not-found-error.ts");
/* harmony import */ var _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../common/errors/bad-input-error */ "./app/common/errors/bad-input-error.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ScriptService = /** @class */ (function () {
    function ScriptService(http) {
        this.http = http;
    }
    ScriptService.prototype.getScripts = function () {
        return this.http.get('/api/scripts')
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.getScript = function (id) {
        return this.http.get('/api/scripts/' + id)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.delete = function (id) {
        return this.http.delete('/api/scripts/' + id)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.create = function (script) {
        return this.http.post('/api/scripts', script)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.update = function (script) {
        return this.http.put('/api/scripts/' + script.id, script)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], ScriptService);
    return ScriptService;
}());



/***/ }),

/***/ "./app/modules/script-interpreter/services/tag.service.ts":
/*!****************************************************************!*\
  !*** ./app/modules/script-interpreter/services/tag.service.ts ***!
  \****************************************************************/
/*! exports provided: TagService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TagService", function() { return TagService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var TagService = /** @class */ (function () {
    function TagService(http) {
        this.http = http;
    }
    TagService.prototype.getTags = function () {
        return this.http.get('/api/tags');
    };
    TagService.prototype.getTagsForScript = function (scriptId) {
        return this.http.get('/api/tags/' + scriptId);
    };
    TagService.prototype.create = function (newTag) {
        return this.http.post('/api/tags', newTag);
    };
    TagService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], TagService);
    return TagService;
}());



/***/ }),

/***/ "./environments/environment.ts":
/*!*************************************!*\
  !*** ./environments/environment.ts ***!
  \*************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * In development mode, for easier debugging, you can ignore zone related error
 * stack frames such as `zone.run`/`zoneDelegate.invokeTask` by importing the
 * below file. Don't forget to comment it out in production mode
 * because it will have a performance impact when errors are thrown
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./main.ts":
/*!*****************!*\
  !*** ./main.ts ***!
  \*****************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "../node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***********************!*\
  !*** multi ./main.ts ***!
  \***********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\KPK_Calcs\Build_IT_Web\ClientApp\main.ts */"./main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map