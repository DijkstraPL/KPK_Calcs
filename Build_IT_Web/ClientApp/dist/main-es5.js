(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./node_modules/raw-loader/index.js!./src/app/app.component.html":
/*!**************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/app.component.html ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <app-nav-menu></app-nav-menu>\r\n    <router-outlet></router-outlet>\r\n</div>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/components/about-me/about-me.component.html":
/*!***************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/about-me/about-me.component.html ***!
  \***************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"mt-2 ml-5 mr-5\">\r\n    <h3>{{'about.Overall.Header' | translate}}</h3>\r\n    <p>\r\n        {{'about.Overall.Description' | translate}}\r\n    </p>\r\n</div>\r\n<div class=\"m-5\">\r\n    <div>\r\n        <h3>{{'about.SnowLoad.Header' | translate}}</h3>\r\n        <p [innerHtml]=\"'about.SnowLoad.Description' | translate\"></p>\r\n        <ul>\r\n            <li *ngFor=\"let position of 'about.SnowLoad.List'| translate\">{{position}}</li>\r\n        </ul>\r\n    </div>\r\n    <div>\r\n        <h3>{{'about.DeadLoad.Header' | translate}}</h3>\r\n        <p [innerHtml]=\"'about.DeadLoad.Description' | translate\"></p>\r\n    </div>\r\n    <hr />\r\n    <div>\r\n        <h3>{{'about.Author.Header' | translate}}</h3>\r\n        <p [innerHtml]=\"'about.Author.Description' | translate\"></p>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/components/carousel/carousel.component.html":
/*!***************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/carousel/carousel.component.html ***!
  \***************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n    <div class=\"d-flex justify-content-center\">\r\n        <div id=\"carouselExampleIndicators\"\r\n             class=\"carousel slide w-100\"\r\n             data-ride=\"carousel\">\r\n            <ol class=\"carousel-indicators\">\r\n                <li data-target=\"#carouselExampleIndicators\"\r\n                    data-slide-to=\"0\"\r\n                    class=\"active\"></li>\r\n                <li data-target=\"#carouselExampleIndicators\"\r\n                    data-slide-to=\"1\"></li>\r\n                <li data-target=\"#carouselExampleIndicators\"\r\n                    data-slide-to=\"2\"></li>\r\n            </ol>\r\n            <div class=\"carousel-inner\">\r\n\r\n                <div class=\"carousel-item active\"\r\n                     [routerLinkActive]='[\"link-active\"]'\r\n                     [routerLinkActiveOptions]='{ exact: true }'>\r\n                    <div class=\"d-flex justify-content-center nav-item link\"\r\n                         [routerLink]=\"['/snowloads']\">\r\n                        <img src=\"../../../assets/images/snow_load_carousel.jpg\"\r\n                             alt=\"Snow load\">\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>{{'carousel.SnowLoads.Header' | translate}}</h5>\r\n                            <p>{{'carousel.SnowLoads.Description' | translate}}</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"carousel-item\"\r\n                     [routerLinkActive]='[\"link-active\"]'\r\n                     [routerLinkActiveOptions]='{ exact: true }'>\r\n                    <div class=\"d-flex justify-content-center link\"\r\n                         [routerLink]=\"['/deadloads']\">\r\n                        <img src=\"../../../assets/images/dead_load_carousel.jpg\"\r\n                             alt=\"Lorem ipsum\">\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>{{'carousel.DeadLoads.Header' | translate}}</h5>\r\n                            <p>{{'carousel.DeadLoads.Description' | translate}}</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"carousel-item\"\r\n                     [routerLinkActive]='[\"link-active\"]'\r\n                     [routerLinkActiveOptions]='{ exact: true }'>\r\n                    <div class=\"d-flex justify-content-center link\"\r\n                         [routerLink]=\"['/about']\">\r\n                        <img src=\"../../../assets/images/about_me_carousel.jpg\"\r\n                             alt=\"Lorem ipsum\">\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>{{'carousel.About.Header' | translate}}</h5>\r\n                            <p>{{'carousel.About.Description' | translate}}</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <a class=\"carousel-control-prev\"\r\n               href=\"#carouselExampleIndicators\"\r\n               role=\"button\"\r\n               data-slide=\"prev\">\r\n                <span class=\"carousel-control-prev-icon\"\r\n                      aria-hidden=\"true\"></span>\r\n                <span class=\"sr-only\">{{'carousel.Previous' | translate}}</span>\r\n            </a>\r\n            <a class=\"carousel-control-next\"\r\n               href=\"#carouselExampleIndicators\"\r\n               role=\"button\"\r\n               data-slide=\"next\">\r\n                <span class=\"carousel-control-next-icon\"\r\n                      aria-hidden=\"true\"></span>\r\n                <span class=\"sr-only\">{{'carousel.Next' | translate}}</span>\r\n            </a>\r\n        </div>\r\n    </div>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/components/home/home.component.html":
/*!*******************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/home/home.component.html ***!
  \*******************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<app-carousel class=\"mt-2\"></app-carousel>\r\n\r\n<app-script-cards></app-script-cards>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/components/login/login.component.html":
/*!*********************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/login/login.component.html ***!
  \*********************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"login-container\">\r\n    <h2 class=\"login-title\">{{'login.Title' | translate}}</h2>\r\n    <form [formGroup]=\"form\"\r\n          (ngSubmit)=\"onSubmit()\"\r\n          class=\"login-form\">\r\n        <div *ngIf=\"form.errors?.auth\"\r\n             class=\"error-panel help-block\">\r\n            {{form.errors.auth}}\r\n        </div>\r\n        <div class=\"form-group\"\r\n             [ngClass]=\"{ 'has-error has-feedback' : hasError('username') }\">\r\n\r\n            <mat-form-field class=\"form-medium\">\r\n                <input matInput\r\n                       type=\"text\"\r\n                       placeholder=\"{{'login.UsernameOrEmail' | translate}}\"\r\n                       [formControl]=\"username\">\r\n                <mat-error *ngIf=\"username && username.hasError('email') && !username.hasError('required')\">\r\n                    {{'login.WriteProperUsernameOrPassword' | translate}}\r\n                </mat-error>\r\n                <mat-error *ngIf=\"username && username.hasError('required')\">\r\n                    {{'login.WriteProperUsernameOrPassword' | translate}}\r\n                </mat-error>\r\n            </mat-form-field>\r\n        </div>\r\n        <div class=\"form-group\"\r\n             [ngClass]=\"{ 'has-error has-feedback' : hasError('password') }\">\r\n\r\n            <mat-form-field class=\"form-medium\">\r\n                <input matInput\r\n                       type=\"password\"\r\n                       placeholder=\"{{'login.Password' | translate}}\"\r\n                       [formControl]=\"password\">\r\n                <mat-error *ngIf=\"password && password.hasError('email') && !password.hasError('required')\">\r\n                    {{'login.WritePassword' | translate}}\r\n                </mat-error>\r\n                <mat-error *ngIf=\"password && password.hasError('required')\">\r\n                    {{'login.WritePassword' | translate}}\r\n                </mat-error>\r\n            </mat-form-field>\r\n        </div>\r\n        <div>\r\n            <mat-checkbox class=\"example-margin\"\r\n                          name=\"remember\"\r\n                          value=\"remember\">\r\n                {{'login.RememberMe' | translate}}\r\n            </mat-checkbox>\r\n        </div>\r\n        <button mat-raised-button\r\n                color=\"accent\"\r\n                type=\"submit\"\r\n                [disabled]=\"form.invalid\">\r\n            {{'login.LogIn' | translate}}\r\n        </button>\r\n    </form>\r\n    <div class=\"login-link\">\r\n        <a href=\"#\">\r\n            {{'login.ForgotPassword' | translate}}\r\n        </a>\r\n    </div>\r\n    <div class=\"login-link\">\r\n        <a [routerLink]=\"['/register']\"\r\n           (click)=\"dismiss()\">\r\n            {{'login.DontHaveAccount' | translate}}\r\n        </a>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/components/nav-menu/nav-menu.component.html":
/*!***************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/nav-menu/nav-menu.component.html ***!
  \***************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<nav class=\"navbar navbar-expand-lg navbar-dark bg-secondary\">\r\n    <a class=\"navbar-brand font-weight-bold\"\r\n       [routerLink]='[\"/\"]'><span class=\"fa fa-building-o\"></span>BUILD IT</a>\r\n    <button class=\"navbar-toggler\"\r\n            type=\"button\"\r\n            data-toggle=\"collapse\"\r\n            data-target=\"#navbarSupportedContent\"\r\n            aria-controls=\"navbarSupportedContent\"\r\n            aria-expanded=\"false\"\r\n            aria-label=\"Toggle navigation\">\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n    </button>\r\n\r\n    <div class=\"collapse navbar-collapse\" id=\"navbarSupportedContent\">\r\n        <ul class=\"navbar-nav mr-auto\">\r\n            <li class=\"nav-item\"\r\n                [routerLinkActive]='[\"active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   [routerLink]='[\"/home\"]'>\r\n                    <span class=\"fa fa-home\"></span> {{'app.Home' | translate}} <span class=\"sr-only\">(current)</span>\r\n                </a>\r\n            </li>\r\n            <li *ngIf=\"this.auth.isLoggedIn()\"\r\n                class=\"nav-item\"\r\n                [routerLinkActive]='[\"active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   [routerLink]=\"['/scripts/new']\">\r\n                    <span class=\"fa fa-file-code\"></span> {{'app.NewScript' | translate}}\r\n                </a>\r\n            </li>\r\n            <li class=\"nav-item dropdown\"\r\n                [routerLinkActive]='[\"active\"]'>\r\n                <a class=\"nav-link dropdown-toggle\"\r\n                   href=\"#\"\r\n                   id=\"navbarDropdown\"\r\n                   role=\"button\"\r\n                   data-toggle=\"dropdown\"\r\n                   aria-haspopup=\"true\"\r\n                   aria-expanded=\"false\">\r\n                    <span class=\"fa fa-arrow-down\"></span> {{'app.Loads.Header' | translate}}\r\n                </a>\r\n                <div class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">\r\n                    <a class=\"dropdown-item\"\r\n                       [routerLink]=\"['/deadloads']\">\r\n                        <span class=\"fa fa-building\"></span> {{'app.Loads.DeadLoads' | translate}}\r\n                    </a>\r\n                    <a class=\"dropdown-item\"\r\n                       [routerLink]=\"['/snowloads']\">\r\n                        <span class=\"fa fa-snowman\"></span> {{'app.Loads.SnowLoads' | translate}}\r\n                    </a>\r\n                    <!--<div class=\"dropdown-divider\"></div>-->\r\n                </div>\r\n            </li>\r\n\r\n            <li class=\"nav-item\"\r\n                [routerLinkActive]='[\"active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   [routerLink]=\"['/about']\">\r\n                    <span class=\"fa fa-user-circle\"></span> {{'app.About' | translate}}\r\n                </a>\r\n            </li>\r\n            <li *ngIf=\"!this.auth.isLoggedIn()\"\r\n                class=\"nav-item\"\r\n                [routerLinkActive]='[\"active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   (click)=\"openLoginSheet()\">\r\n                    <!--[routerLink]=\"['/login']\"-->\r\n                    <span class=\"fa fa-sign-in-alt\"></span> {{'app.LogIn' | translate }} / {{'app.Register' | translate }}\r\n                </a>\r\n            </li>\r\n            <li *ngIf=\"this.auth.isLoggedIn()\"\r\n                class=\"nav-item\"\r\n                [routerLinkActive]='[\"active\"]'\r\n                [routerLinkActiveOptions]='{ exact: true }'>\r\n                <a class=\"nav-link\"\r\n                   (click)=\"logout()\">\r\n                    <span class='fa fa-sign-out-alt'></span> {{'app.LogOut' | translate }}\r\n                </a>\r\n            </li>\r\n            <!--<li class=\"nav-item\">\r\n        <a class=\"nav-link disabled\" href=\"#\">Disabled</a>\r\n    </li>-->\r\n        </ul>\r\n        <form class=\"form-inline my-2 my-lg-0\"\r\n              (ngSubmit)=\"onSearch()\"\r\n              [formGroup]=\"searchForm\">\r\n            <input class=\"form-control mr-sm-2\"\r\n                   type=\"search\"\r\n                   formControlName=\"search\"\r\n                   placeholder=\"{{'app.Search' | translate}}\"\r\n                   aria-label=\"Search\">\r\n            <button mat-stroked-button\r\n                    color=\"accent\"\r\n                    type=\"submit\">\r\n                {{'app.Search' | translate}}\r\n            </button>           \r\n        </form>\r\n\r\n\r\n        <select id=\"language\"\r\n                [(ngModel)]=\"configurations.language\"\r\n                #languageSelector=\"element-select\"\r\n                elementSelect\r\n                class=\"selectpicker form-control smaller ml-3\">\r\n            <option data-subtext=\"(Default)\"\r\n                    value=\"en\">\r\n                {{'app.Languages.English' | translate}}\r\n            </option>\r\n            <option value=\"pl\">{{'app.Languages.Polish' | translate}}</option>\r\n            <option value=\"de\">{{'app.Languages.German' | translate}}</option>\r\n        </select>\r\n    </div>\r\n</nav>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/components/register/register.component.html":
/*!***************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/register/register.component.html ***!
  \***************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Work in progress</h1>\r\n\r\n<!--<div class=\"login-container\">\r\n    <h2 class=\"login-title\">{{'register.RegisterNewUser' | translate}}</h2>\r\n    <form [formGroup]=\"form\"\r\n          (ngSubmit)=\"onSubmit()\"\r\n          class=\"login-form\">\r\n        <div *ngIf=\"form.errors?.auth\"\r\n             class=\"error-panel help-block\">\r\n            {{form.errors.register}}\r\n        </div>\r\n        <div class=\"form-group\"\r\n             [ngClass]=\"{ 'has-error has-feedback' : hasError('Username') }\">\r\n            <input type=\"text\" required autofocus\r\n                   formControlName=\"Username\"\r\n                   class=\"form-control\"\r\n                   placeholder=\"{{'register.WriteUsername' | translate}}\" />\r\n            <span *ngIf=\"hasError('Username')\"\r\n                  class=\"glyphicon glyphicon-remove form-control-feedback\"\r\n                  aria-hidden=\"true\"></span>\r\n            <div *ngIf=\"hasError('Username')\"\r\n                 class=\"help-block\">\r\n                {{'register.WriteProperUsername' | translate}}\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\"\r\n             [ngClass]=\"{ 'has-error has-feedback' : hasError('Email') }\">\r\n            <input type=\"text\" required autofocus\r\n                   formControlName=\"Email\"\r\n                   class=\"form-control\"\r\n                   placeholder=\"{{'register.WriteEmail' | translate}}\" />\r\n            <span *ngIf=\"hasError('Email')\"\r\n                  class=\"glyphicon glyphicon-remove form-control-feedback\"\r\n                  aria-hidden=\"true\"></span>\r\n            <div *ngIf=\"hasError('Email')\"\r\n                 class=\"help-block\">\r\n                {{'register.WriteProperEmail' | translate}}\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\"\r\n             [ngClass]=\"{ 'has-error has-feedback' : hasError('Password') }\">\r\n            <input type=\"password\" required\r\n                   formControlName=\"Password\"\r\n                   class=\"form-control\"\r\n                   placeholder=\"{{'register.WritePassword' | translate}}\" />\r\n            <span *ngIf=\"hasError('Password')\"\r\n                  class=\"glyphicon glyphicon-remove form-control-feedback\"\r\n                  aria-hidden=\"true\"></span>\r\n            <div *ngIf=\"hasError('Password')\"\r\n                 class=\"help-block\">\r\n                {{'register.WriteProperPassword' | translate}}\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\"\r\n             [ngClass]=\"{ 'has-error has-feedback' : hasError('PasswordConfirm') }\">\r\n            <input type=\"password\" required\r\n                   formControlName=\"PasswordConfirm\"\r\n                   class=\"form-control\"\r\n                   placeholder=\"{{'register.RepeatPassword' | translate}}\" />\r\n            <span *ngIf=\"hasError('PasswordConfirm')\"\r\n                  class=\"glyphicon glyphicon-remove form-control-feedback\"\r\n                  aria-hidden=\"true\"></span>\r\n            <div *ngIf=\"hasError('PasswordConfirm')\"\r\n                 class=\"help-block\">\r\n                {{'register.WrongPasswordConfirmation' | translate}}\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\"\r\n             [ngClass]=\"{ 'has-error has-feedback' : hasError('DisplayName') }\">\r\n            <input type=\"text\" required autofocus\r\n                   formControlName=\"DisplayName\"\r\n                   class=\"form-control\"\r\n                   placeholder=\"{{'register.WriteDisplayedName' | translate}}\" />\r\n            <span *ngIf=\"hasError('DisplayName')\"\r\n                  class=\"glyphicon glyphicon-remove form-control-feedback\"\r\n                  aria-hidden=\"true\"></span>\r\n            <div *ngIf=\"hasError('DisplayName')\"\r\n                 class=\"help-block\">\r\n                {{'register.WriteProperDisplayedName' | translate}}\r\n            </div>\r\n        </div>\r\n        <div class=\"text-center\">\r\n            <button type=\"submit\"\r\n                    [disabled]=\"form.invalid\"\r\n                    class=\"btn btn-md btn-success btn-signin\">\r\n                {{'register.Register' | translate}}\r\n            </button>\r\n            <button type=\"submit\"\r\n                    (click)=\"onBack()\"\r\n                    class=\"btn btn-md btn-default\">\r\n                {{'register.Cancel' | translate}}\r\n            </button>\r\n        </div>\r\n    </form>\r\n</div>-->\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.html":
/*!***************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.html ***!
  \***************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>{{script.name}}</h1>\r\n\r\n<div class=\"container\">\r\n    <div class=\"figure\">\r\n        <svg width=\"400\" height=\"300\" xmlns=\"http://www.w3.org/2000/svg\">\r\n            <g>\r\n                <title>Background</title>\r\n                <rect fill=\"none\" id=\"canvas_background\" height=\"220\" width=\"400\" y=\"-1\" x=\"-1\" />\r\n                <g display=\"none\" overflow=\"visible\" y=\"0\" x=\"0\" height=\"100%\" width=\"100%\" id=\"canvasGrid\">\r\n                    <rect fill=\"url(#gridpattern)\" stroke-width=\"0\" y=\"0\" x=\"0\" height=\"100%\" width=\"100%\" />\r\n                </g>\r\n            </g>\r\n            <g>\r\n                <title>Snow load</title>\r\n                <rect width=\"300\" height=\"50\"\r\n                      x=\"50\" y=\"0\"\r\n                      stroke-width=\"3\" stroke=\"#ffffff\" fill=\"none\" />\r\n                <text xml:space=\"preserve\"\r\n                      text-anchor=\"start\"\r\n                      font-family=\"Helvetica, Arial, sans-serif\"\r\n                      font-size=\"24\"\r\n                      id=\"snow-load\"\r\n                      [attr.y]=\"30\"\r\n                      x=\"100\"\r\n                      stroke-width=\"0\"\r\n                      stroke=\"#0f0f00\"\r\n                      fill=\"#ffffff\"\r\n                      *ngIf=\"snowLoad\">{{snowLoad.name}} = {{snowLoad.value}}<xhtml:span [innerHtml]=\"snowLoad.unit | html\"></xhtml:span></text>\r\n            </g>\r\n            <g>\r\n                <title>Building</title>\r\n                <line id=\"left\"\r\n                      x1=\"50\" [attr.y1]=\"200+offset\"\r\n                      x2=\"50\" [attr.y2]=\"addition+offset\"\r\n                      stroke-width=\"3\" stroke=\"#ffffff\" fill=\"none\" />\r\n                <line id=\"top\"\r\n                      x1=\"50\" [attr.y1]=\"addition+offset\"\r\n                      x2=\"350\" [attr.y2]=\"offset\"\r\n                      stroke-width=\"3\" stroke=\"#ffffff\" fill=\"none\" />\r\n                <line id=\"right\"\r\n                      x1=\"350\" [attr.y1]=\"offset\"\r\n                      x2=\"350\" [attr.y2]=\"200+offset\"\r\n                      stroke-width=\"3\" stroke=\"#ffffff\" fill=\"none\" />\r\n                <line id=\"bottom\"\r\n                      x1=\"0\" [attr.y1]=\"200+offset\"\r\n                      x2=\"400\" [attr.y2]=\"200+offset\"\r\n                      stroke-width=\"3\" stroke=\"#ffffff\" fill=\"none\" />\r\n                <line id=\"angle\"\r\n                      x1=\"50\" [attr.y1]=\"addition+offset\"\r\n                      x2=\"225\" [attr.y2]=\"addition+offset\"\r\n                      stroke-width=\"0.5\" stroke=\"#ffffff\" fill=\"none\" />\r\n                <line *ngIf=\"snowFences.value == true\"\r\n                      id=\"snow-fence\"\r\n                      x1=\"55\" [attr.y1]=\"addition+offset\"\r\n                      x2=\"55\" [attr.y2]=\"addition+offset-20\"\r\n                      stroke-width=\"2\" stroke=\"#ffffff\" fill=\"none\" />\r\n                <foreignObject class=\"node\"\r\n                               x=\"209.5\"\r\n                               [attr.y]=\"addition > 30 ? addition-5+offset-22 : offset+30-22\"\r\n                               width=\"100%\" height=\"100%\">\r\n                    <xhtml:div>\r\n                        <p>\r\n                            {{slope.name}} = <span>\r\n                                <input class=\"svg-input\"\r\n                                       [required]=\"isRequired(slope)\"\r\n                                       autocomplete=\"off\"\r\n                                       [attr.type]=\"slope.valueType == 0 ? 'number' : 'text'\"\r\n                                       [(ngModel)]=\"slope.value\"\r\n                                       (change)=\"onSlopeChange()\" />\r\n                            </span>{{slope.unit}}\r\n                        </p>\r\n                    </xhtml:div>\r\n                </foreignObject>\r\n            </g>\r\n        </svg>\r\n\r\n        <button (click)=\"calculate()\">Calculate</button>\r\n    </div>\r\n\r\n    <div class=\"form ml-2\">\r\n        <mat-form-field>\r\n            <input matInput\r\n                   [required]=\"isRequired(altitude)\"\r\n                   autocomplete=\"off\"\r\n                   [attr.type]=\"altitude.valueType == 0 ? 'number' : 'text'\"\r\n                   [(ngModel)]=\"altitude.value\"\r\n                   (change)=\"onSlopeChange()\">\r\n            <mat-placeholder>\r\n                <span [innerHtml]=\"altitude.name | html\"></span>\r\n            </mat-placeholder>\r\n            <span matSuffix [innerHtml]=\"altitude.unit | html\"></span>\r\n        </mat-form-field>\r\n        <p class=\"parameter-description\">{{altitude.description}}</p>\r\n\r\n        <mat-form-field>\r\n            <input matInput\r\n                   [required]=\"isRequired(slope)\"\r\n                   autocomplete=\"off\"\r\n                   [attr.type]=\"slope.valueType == 0 ? 'number' : 'text'\"\r\n                   [(ngModel)]=\"slope.value\"\r\n                   (change)=\"onSlopeChange()\">\r\n            <mat-placeholder>\r\n                <span [innerHtml]=\"slope.name | html\"></span>\r\n            </mat-placeholder>\r\n            <span matSuffix [innerHtml]=\"slope.unit | html\"></span>\r\n        </mat-form-field>\r\n        <p class=\"parameter-description\">{{slope.description}}</p>\r\n\r\n        <div class=\"justify-content-start parameter-radio\">\r\n            <label class=\"align-self-start mb-2\">\r\n                <span [innerHtml]=\"topography.name | html\"></span>{{isRequired(topography) ? '*' : ''}}\r\n            </label>\r\n            <mat-radio-group [(ngModel)]=\"topography.value\">\r\n                <mat-radio-button *ngFor=\"let valueOption of topography.valueOptions; index as i\"\r\n                                  [value]=\"valueOption.value\"\r\n                                  [required]=\"isRequired(topography)\"\r\n                                  class=\"mr-3\"\r\n                                  (change)=\"changeValue($event)\">\r\n                    {{valueOption.name }}\r\n                </mat-radio-button>\r\n                {{topography.unit | html}}\r\n            </mat-radio-group>\r\n            <p class=\"parameter-description-radio\">{{topography.description}}</p>\r\n        </div>\r\n\r\n        <div class=\"align-self-start parameter-checkbox\">\r\n            <label class=\"align-self-start mb-2\">\r\n                {{snowFences.name | html}}{{isRequired(snowFences) ? '*' : ''}}\r\n            </label>\r\n\r\n            <div class=\"d-inline-flex\">\r\n                <mat-checkbox [required]=\"isRequired(snowFences)\"\r\n                              class=\"true\"\r\n                              [(ngModel)]=\"snowFences.value\"\r\n                              (change)=\"calculate()\">\r\n                    {{'scriptCalculator.Controls.True' | translate}}\r\n                </mat-checkbox>\r\n            </div>\r\n            <p class=\"parameter-description-normal\">{{snowFences.description}}</p>\r\n        </div>\r\n\r\n        <div class=\"map-container\">\r\n            <img src=\"../../../../../assets/images/custom-views/snow-zones.jpg\" />\r\n            <svg height=\"617\" width=\"617\" xmlns=\"http://www.w3.org/2000/svg\"\r\n                 class=\"zone-container\"\r\n                 fill-rule=\"evenodd\">\r\n                <path id=\"firstZone\"\r\n                      d=\"m48,368c-17,22 -10,17 -10,17c0,0 -11,1 -11,1c0,0 1,-11 1,-11c0,0 17,-30 17,-30c0,0 0,-11\r\n                      0,-11c0,0 -15,-13 -15,-13c0,0 -4,-19 -4,-19c0,0 0,-16 0,-16c0,0 8,-19 8,-19c0,0 0,-20 0,-20c0,0\r\n                      -3,-16 -3,-16c0,0 -7,-12 -7,-12c0,0 22,1 22,1c0,0 30,19 30,19c0,0 28,16 28,16c0,0 18,6 18,6c0,0\r\n                      18,6 18,6c0,0 20,2 20,2c0,0 20,10 20,10c0,0 12,14 12,14c0,0 12,21 13,21c1,0 14,21 14,21c0,0 11,27\r\n                      11,27c0,0 6,27 6,27c0,0 -4,21 -4,21c0,0 -5,21 -5,21c0,0 -8,18 -8,18c0,0 -7,4 -7,4c0,0 -9,0 -9,0c0,0\r\n                      -9,-1 -10,-1c-1,0 -13,-8 -13,-8c0,0 -13,-2 -13,-2c0,0 -8,4 -8,4c0,0 5,10 5,10c0,0 -13,4 -13,4c0,0\r\n                      -4,9 -4,9c0,0 -11,-5 -11,-5c0,0 -8,-24 -8,-24c0,0 -12,-2 -12,-2c0,0 3,-10 3,-10c0,0 10,-10 10,-10c0,0\r\n                      -7,-2 -8,-2c-1,0 -12,2 -13,1c-1,-1 -11,-6 -11,-6c0,0 -13,-7 -13,-7c0,0 -11,-3 -11,-3\"\r\n                      class=\"zone\"\r\n                      [class.selected]=\"zone.value == 'FirstZone'\"\r\n                      (click)=\"selectZone(1)\" />\r\n                <path id=\"secondZone_I\"\r\n                      d=\"m23,219c0,0 -17,-26 -17,-26c0,0 13,-17 13,-17c0,0 7,-21 6,-21c-1,0 -5,-32 -5,-32c0,0 -3,-24\r\n                      -3,-24c0,0 -3,-10 -3,-10c0,0 19,-8 19,-8c0,0 42,-7 42,-7c0,0 28,-11 28,-11c0,0 27,-9 27,-9c0,0\r\n                      24,-25 24,-25c0,0 -5,41 -5,41c0,0 8,45 8,45c0,0 22,30 22,30c0,0 33,16 33,16c0,0 29,1 29,1c0,0\r\n                      45,-7 45,-7c0,0 33,1 33,1c0,0 30,17 30,17c0,0 111,45 111,45c0,0 5,24 5,24c0,0 -3,8 -3,8c0,0 7,15\r\n                      7,15c0,0 18,45 18,45c0,0 -9,24 -9,24c0,0 -51,33 -51,33c0,0 -57,22 -57,22c0,0 -41,16 -41,16c0,0 -9,13\r\n                      -9,13c0,0 4,26 4,26c0,0 -2,17 -2,17c0,0 -8,15 -8,15c0,0 -24,18 -24,18c0,0 -23,13 -23,13c0,0 -5,-12\r\n                      -5,-12c0,0 -22,-14 -22,-14c0,0 -19,1 -19,1c0,0 -11,-15 -11,-15c0,0 8,-12 8,-12c0,0 -3,-7 -3,-7c0,0\r\n                      21,-49 21,-49c0,0 -3,-28 -3,-28c0,0 -12,-33 -12,-33c0,0 -17,-28 -17,-28c0,0 -16,-27 -16,-27c0,0\r\n                      -28,-12 -28,-12c0,0 -34,-10 -34,-10c0,0 -16,-5 -16,-5c0,0 -14,-4 -14,-4c0,0 -28,-18 -28,-18c0,0\r\n                      -21,-16 -21,-16c0,0 -13,-1 -13,-1\"\r\n                      class=\"zone\"\r\n                      [class.selected]=\"zone.value == 'SecondZone'\"\r\n                      (click)=\"selectZone(2)\" />\r\n                <path id=\"thirdZone\"\r\n                      d=\"M 154.26892,31.42254c0,0 30.00006,-7.69232 29.5776,-8.34557c0.42246,0.65325 28.88406,-12.4237\r\n                      28.4616,-13.07695c0.42246,0.65325 41.961,-3.96214 41.53854,-4.61539c0.42246,0.65325 31.19175,19.11482\r\n                      30.76929,18.46157c0.42246,0.65325 3.49939,6.03788 3.49939,6.03788c0,0 -6.92309,1.53846\r\n                      -7.34555,0.88521c0.42246,0.65325 -21.88527,-14.73139 -22.30774,-15.38464c0.42247,0.65325 6.57632,22.19175\r\n                      6.15386,21.5385c0.42246,0.65325 18.11481,12.96097 18.11481,12.96097c0,0 18.46157,2.3077\r\n                      18.03911,1.65444c0.42246,0.65326 30.42252,-9.34676 30.00006,-10.00002c0.42246,0.65326 35.80715,-0.11598\r\n                      35.38469,-0.76923c0.42246,0.65325 2.73016,9.11481 2.73016,9.11481c0,0 -10.00002,33.84622\r\n                      -10.42249,33.19297c0.42247,0.65325 1.96093,23.73022 1.96093,23.73022c0,0 14.61542,26.92313\r\n                      14.19295,26.26988c0.42247,0.65325 17.34558,13.7302 16.92311,13.07695c0.42247,0.65325 31.96099,3.73018\r\n                      31.96099,3.73018c0,0 37.69239,0 37.69239,0c0,0 40.76931,6.92309 40.76931,6.92309c0,0 22.30774,11.53849\r\n                      21.88527,10.88523c0.42247,0.65326 19.65328,37.57641 19.2308,36.92315c0.42248,0.65326 9.65326,33.73025\r\n                      9.23079,33.07699c0.42247,0.65326 3.4994,16.03791 3.4994,16.03791c0,0 18.46158,13.84618 18.46158,13.84618c0,0\r\n                      0,13.84618 0,14.61541c0,0.76923 2.3077,12.30772 1.88522,11.65446c0.42248,0.65326 -4.96215,6.80712\r\n                      -5.38462,6.15386c0.42247,0.65326 8.11479,26.03792 7.69232,25.38466c0.42247,0.65326 3.4994,16.03791\r\n                      3.07693,15.38465c0.42247,0.65326 30.42253,39.88411 30.00006,39.23085c0.42247,0.65326 -4.96215,8.34558\r\n                      -4.96215,8.34558c0,0 6.15385,21.53851 6.15385,21.53851c0,0 -3.07692,12.30771 -3.07692,12.30771c0,0\r\n                      -15.38465,8.46156 -15.80712,7.8083c0.42247,0.65326 -58.80842,79.11496 -58.80842,79.11496c0,0 -1.53846,10.00002\r\n                      -1.96094,9.34675c0.42248,0.65327 -7.26985,6.03789 -7.69232,5.38463c0.42247,0.65326 -1.11599,18.34561\r\n                      -0.34676,19.11484c0.76923,0.76923 13.07695,22.30774 13.84618,22.30774c0.76923,0 -2.3077,10.76925\r\n                      -2.73017,10.11598c0.42247,0.65327 -21.88526,-16.26984 -21.88526,-16.26984c0,0 -14.61542,0.76923\r\n                      -15.03789,0.11596c0.42247,0.65327 -33.42375,-22.4237 -33.84622,-23.07697c0.42247,0.65327 -29.57759,-1.65443\r\n                      -30.00006,-2.30769c0.42247,0.65326 -11.11602,9.11482 -11.11602,9.11482c0,0 -33.84622,-6.92309\r\n                      -34.26868,-7.57636c0.42246,0.65327 -12.65449,-3.19289 -13.07695,-3.84616c0.42246,0.65327 -21.88527,2.96096\r\n                      -22.30774,2.3077c0.42247,0.65326 -13.42372,5.26866 -13.42372,5.26866c0,0 -7.69232,-9.23079\r\n                      -8.11478,-9.88406c0.42246,0.65327 -1.88524,-11.65445 -2.3077,-12.30771c0.42246,0.65326 -12.65449,5.26866\r\n                      -12.65449,5.26866c0,0 -8.46155,13.84618 -8.46155,13.84618c0,0 -5.38463,0 -6.15386,0c-0.76923,0 -6.15386,5.38462\r\n                      -6.57632,4.73136c0.42246,0.65326 -10.34679,1.4225 -10.76925,0.76923c0.42246,0.65327 -2.65447,-7.80829\r\n                      -3.07693,-8.46156c0.42246,0.65327 -5.7314,-5.50059 -5.7314,-5.50059c0,0 -5.38463,-10.00002 -5.38463,-10.00002c0,0\r\n                      -6.92309,-6.92309 -7.34555,-7.57635c0.42246,0.65326 54.26873,-36.26989 54.26873,-36.26989c0,0 4.61539,-25.38467\r\n                      4.61539,-25.38467c0,0 -2.3077,-30.00006 -2.73016,-30.65332c0.42246,0.65326 7.34555,-12.42369\r\n                      6.92309,-13.07695c0.42246,0.65326 105.80729,-40.11605 105.80729,-40.11605c0,0 44.61548,-30.00006\r\n                      44.61548,-30.00006c0,0 8.46155,-22.30774 8.46155,-22.30774c0,0 -23.07697,-66.15398 -23.07697,-66.15398c0,0\r\n                      1.53847,-6.92309 1.53847,-6.92309c0,0 -5.38463,-23.07697 -5.38463,-23.07697c0,0 -111.53869,-43.07701\r\n                      -111.53869,-43.07701c0,0 -26.15389,-16.15388 -26.15389,-16.15388c0,0 -20.76928,-2.30769 -20.76928,-2.30769c0,0\r\n                      -18.46157,-0.76924 -18.88404,-1.42249c0.42247,0.65325 -37.26992,8.34558 -37.26992,8.34558c0,0 -29.23083,-0.76924\r\n                      -29.23083,-0.76924c0,0 -37.69238,-16.92311 -38.11484,-17.57636c0.42246,0.65325 -19.57758,-27.80834\r\n                      -19.57758,-27.80834c0,0 -8.46156,-49.23087 -8.46156,-49.23087c0,0 4.6154,-34.61546 4.6154,-34.61546z\r\n                      M 375.0386,459.88495c0,0 0,12.30772 -0.42247,11.65445c0.42247,0.65327 29.65329,15.26868\r\n                      29.23083,14.61541c0.42246,0.65327 30.42253,2.19173 30.42253,2.19173c0,0 33.84622,-6.15385\r\n                      33.84622,-6.15385c0,0 29.23083,-12.30772 28.80836,-12.96099c0.42247,0.65327 5.03786,-7.03905\r\n                      4.61539,-7.69232c0.42247,0.65327 5.8071,-16.26985 5.38463,-16.92311c0.42247,0.65326 -2.65446,-10.88522\r\n                      -2.65446,-10.88522c0,0 -13.84619,-6.15386 -14.26865,-6.80712c0.42246,0.65326 -16.50065,-0.8852\r\n                      -16.92311,-1.53847c0.42246,0.65327 -38.80838,8.34559 -39.23085,7.69233c0.42247,0.65326 -33.42376,12.96098\r\n                      -33.84622,12.30771c0.42246,0.65327 -9.57756,4.49943 -9.57756,4.49943\"\r\n                      class=\"zone\"\r\n                      [class.selected]=\"zone.value == 'ThirdZone'\"\r\n                      (click)=\"selectZone(3)\" />\r\n                <path id=\"secondZone_II\"\r\n                      d=\"m375.0386,459.88495c0,0 0,12.30772 -0.42247,11.65445c0.42247,0.65327 29.65329,15.26868\r\n                      29.23083,14.61541c0.42246,0.65327 30.42253,2.19173 30.42253,2.19173c0,0 33.84622,-6.15385\r\n                      33.84622,-6.15385c0,0 29.23083,-12.30772 28.80836,-12.96099c0.42247,0.65327 5.03786,-7.03905\r\n                      4.61539,-7.69232c0.42247,0.65327 5.8071,-16.26985 5.38463,-16.92311c0.42247,0.65326 -2.65446,-10.88522\r\n                      -2.65446,-10.88522c0,0 -13.84619,-6.15386 -14.26865,-6.80712c0.42246,0.65326 -16.50065,-0.8852\r\n                      -16.92311,-1.53847c0.42246,0.65327 -38.80838,8.34559 -39.23085,7.69233c0.42247,0.65326 -33.42376,12.96098\r\n                      -33.84622,12.30771c0.42246,0.65327 -9.57756,4.49943 -9.57756,4.49943\"\r\n                      class=\"zone\"\r\n                      [class.selected]=\"zone.value == 'SecondZone'\"\r\n                      (click)=\"selectZone(2)\" />\r\n                <path id=\"fourthZone\"\r\n                      d=\"m555.80819,236.80757c0,0 10.76925,-10.76925 10.76925,-10.76925c0,0 11.53848,0.76923\r\n                      11.11601,0.11597c0.42247,0.65326 12.73019,-7.03907 12.73019,-7.03907c0,0 -0.76923,-26.1539\r\n                      -1.1917,-26.80716c0.42247,0.65326 -4.19292,-5.5006 -4.61539,-6.15386c0.42247,0.65326 1.96094,-20.88525\r\n                      1.96094,-20.88525c0,0 -10.00002,-21.53851 -10.42249,-22.19176c0.42247,0.65326 -13.42371,-21.65448\r\n                      -13.84618,-22.30774c0.42247,0.65325 -7.26985,-24.73141 -7.26985,-24.73141c0,0 -0.76923,-23.8462\r\n                      -0.76923,-23.8462c0,0 -3.84616,-16.92311 -3.84616,-16.92311c0,0 -20.00004,-9.23079 -20.00004,-10.00002c0,-0.76923\r\n                      -23.07697,0 -23.07697,0c0,0 -56.92319,5.38463 -56.92319,5.38463c0,0 -80.76939,-6.15386 -80.76939,-6.15386c0,0\r\n                      -7.69232,35.38469 -7.69232,35.38469c0,0 0,23.8462 -0.42247,23.19295c0.42247,0.65325 10.42249,22.96099\r\n                      10.00002,22.30774c0.42247,0.65325 18.88404,18.3456 18.46158,17.69234c0.42247,0.65326 34.26869,5.26865\r\n                      34.26869,5.26865c0,0 35.38469,0 35.38469,0c0,0 41.53855,8.46156 41.11608,7.8083c0.42247,0.65326 22.73021,9.88404\r\n                      22.30774,9.23079c0.42247,0.65326 20.42251,35.26871 20.00004,34.61545c0.42247,0.65326 8.11479,30.65332\r\n                      7.69232,30.00006c0.42247,0.65326 5.03786,6.80712 5.03786,6.80712z\"\r\n                      class=\"zone\"\r\n                      [class.selected]=\"zone.value == 'FourthZone'\"\r\n                      (click)=\"selectZone(4)\" />\r\n                <path id=\"fifthZone\"\r\n                      d=\"m345.35709,539.42758c0,0 6.2857,7.99999 6.07083,7.99998c0.21488,0.00001 -0.92798,7.42857\r\n                      -1.14286,7.42856c0.21488,0.00001 14.50057,2.28572 14.28569,2.28571c0.21488,0.00001 4.7863,5.71429\r\n                      4.57142,5.71428c0.21488,0.00001 3.64344,-11.99997 3.42857,-11.99998c0.21488,0.00001 15.07199,-13.14282\r\n                      14.85712,-13.14283c0.21488,0.00001 -9.49939,-4.57141 -9.49939,-4.57141c0,0 -22.28567,1.71428 -22.28567,1.71428\"\r\n                      class=\"zone\"\r\n                      [class.selected]=\"zone.value == 'FifthZone'\"\r\n                      (click)=\"selectZone(5)\" />\r\n            </svg>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.html":
/*!*****************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.html ***!
  \*****************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"scroll-horizontal mb-4\">\r\n    <table mat-table\r\n           multiTemplateDataRows\r\n           [dataSource]=\"selectedMaterialDataSource\"\r\n           class=\"mat-elevation-z8 mt-4 center\"\r\n           cdkDropList\r\n           [cdkDropListData]=\"selectedMaterialDataSource\"\r\n           (cdkDropListDropped)=\"dropTable($event)\"\r\n           *ngIf=\"selectedMaterials.length > 0\">\r\n\r\n        <ng-container matColumnDef=\"position\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                \r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\">\r\n                <div cdkDragHandle class=\"fa fa-reorder\"></div>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"category\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-left\">\r\n                    {{'deadLoadsModule.Category' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-left\">\r\n                <div class=\"mr-3\">\r\n                    {{materialForCalculation.categoryName}}\r\n                </div>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"name\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Name' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                <div class=\"mr-1\">\r\n                    {{materialForCalculation.material.name}}\r\n                </div>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"length\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Length' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                <mat-form-field *ngIf=\"materialForCalculation.material.unit > 0; else noLengthBlock\"\r\n                                class=\"ml-3 smaller-input\">\r\n                    <input matInput\r\n                           type=\"number\"\r\n                           class=\"text-center\"\r\n                           min=\"0\"\r\n                           (change)=\"calculate(materialForCalculation)\"\r\n                           [(ngModel)]=\"materialForCalculation.length\">\r\n                </mat-form-field>\r\n                <ng-template #noLengthBlock>-</ng-template>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"width\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Width' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n\r\n                <mat-form-field *ngIf=\"materialForCalculation.material.unit > 1; else noLengthBlock\"\r\n                                class=\"ml-3 smaller-input\">\r\n                    <input matInput\r\n                           type=\"number\"\r\n                           class=\"text-center\"\r\n                           min=\"0\"\r\n                           (change)=\"calculate(materialForCalculation)\"\r\n                           [(ngModel)]=\"materialForCalculation.width\">\r\n                </mat-form-field>\r\n                <ng-template #noLengthBlock>-</ng-template>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"thickness\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Thickness' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n\r\n                <mat-form-field *ngIf=\"materialForCalculation.material.unit > 2; else noLengthBlock\"\r\n                                class=\"ml-3 smaller-input\">\r\n                    <input matInput\r\n                           type=\"number\"\r\n                           class=\"text-center\"\r\n                           min=\"0\"\r\n                           (change)=\"calculate(materialForCalculation)\"\r\n                           [(ngModel)]=\"materialForCalculation.thickness\">\r\n                </mat-form-field>\r\n                <ng-template #noLengthBlock>-</ng-template>\r\n            </td>\r\n            <td mat-footer-cell\r\n                *matFooterCellDef\r\n                class=\"text-right\">\r\n                {{'deadLoadsModule.Total' | translate}}\r\n            </td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"minDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\"\r\n                     [innerHtml]=\"'deadLoadsModule.MinimumDensity' | translate\">\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                {{materialForCalculation.calculatedMinimumLoad | number:'1.0-3'}}\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef>{{sumMinimumDeadLoads | number:'1.0-3'}}</td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"maxDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\"\r\n                     [innerHtml]=\"'deadLoadsModule.MaximumDensity' | translate\">\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                {{materialForCalculation.calculatedMaximumLoad | number:'1.0-3'}}\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef>{{sumMaximumDeadLoads | number:'1.0-3'}}</td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"unit\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Unit' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\"\r\n                [innerHTML]=\"units[materialForCalculation.unit].value\"></td>\r\n            <td mat-footer-cell *matFooterCellDef>\r\n                <div [innerHTML]=\"units[selectedMaterials[0].unit].value\"></div>\r\n            </td>\r\n        </ng-container>\r\n        <ng-container matColumnDef=\"remove\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Remove' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-center\">\r\n                <button mat-stroked-button color=\"warn\"\r\n                        (click)=\"removeMaterial(materialForCalculation)\">\r\n                    <span class=\"fa fa-minus\"></span>\r\n                </button>\r\n            </td>\r\n            <td mat-footer-cell *matFooterCellDef></td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"additions\">\r\n            <td mat-cell\r\n                colspan=\"10\"\r\n                *matCellDef=\"let materialForCalculation\"\r\n                class=\"text-left\">\r\n                <div *ngFor=\"let addition of materialForCalculation.additions\">\r\n                    <mat-checkbox class=\"ml-1\"\r\n                                  [checked]=\"addition.isChecked\"\r\n                                  (change)=\"additionChecked(materialForCalculation, addition)\">\r\n                        {{addition.origin.name}}\r\n                        <span *ngIf=\"addition.origin.description\">\r\n                            - {{addition.origin.description}}\r\n                        </span>\r\n                    </mat-checkbox>\r\n                </div>\r\n            </td>\r\n        </ng-container>\r\n\r\n        <tr mat-header-row\r\n            *matHeaderRowDef=\"materialsForCalculationsDisplayedColumns\"></tr>\r\n        <tr mat-row\r\n            *matRowDef=\"let row; columns: materialsForCalculationsDisplayedColumns;\"\r\n            cdkDrag\r\n            [cdkDragData]=\"row\"></tr>\r\n        <!--<tr mat-row\r\n            class=\"example-custom-placeholder\"\r\n            *cdkDragPlaceholder>\r\n        </tr>-->\r\n        <tr mat-row\r\n            *matRowDef=\"let row; columns: ['additions'];\"\r\n            [class.additions-hidden]=\"row\"></tr>\r\n        <tr mat-footer-row\r\n            [class.summary-hidden]=\"!isUnitsProper()\"\r\n            *matFooterRowDef=\"materialsForCalculationsDisplayedColumns\"></tr>\r\n    </table>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.html":
/*!*****************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.html ***!
  \*****************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "    <mat-form-field class=\"m-2\">\r\n        <mat-label>{{'deadLoadsModule.Categories' | translate}}</mat-label>\r\n        <mat-select [(ngModel)]=\"selectedCategory\"\r\n                    name=\"category\"\r\n                    (selectionChange)=\"onCategoryChange()\">\r\n            <mat-option *ngFor=\"let category of categories\"\r\n                        [value]=\"category\">\r\n                {{category.name}}\r\n            </mat-option>\r\n        </mat-select>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\"\r\n                    *ngIf=\"subcategories\">\r\n        <mat-label>{{'deadLoadsModule.Subcategories' | translate}}</mat-label>\r\n        <mat-select [(ngModel)]=\"selectedSubcategory\"\r\n                    name=\"subcategory\"\r\n                    (selectionChange)=\"onSubcategoryChange()\">\r\n            <mat-option *ngFor=\"let subcategory of subcategories\"\r\n                        [value]=\"subcategory\">\r\n                {{subcategory.name}} - {{subcategory.documentName}}\r\n            </mat-option>\r\n        </mat-select>\r\n    </mat-form-field>\r\n\r\n    <table mat-table\r\n           [dataSource]=\"materials\"\r\n           class=\"mat-elevation-z8 center mt-4\"\r\n           *ngIf=\"materials\">\r\n        <ng-container matColumnDef=\"name\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                {{'deadLoadsModule.Name' | translate}}\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\"\r\n                class=\"text-left\">\r\n                {{material.name}}\r\n            </td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"minDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\"\r\n                     [innerHtml]=\"'deadLoadsModule.MinimumDensity' | translate\">\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\">\r\n                {{material.minimumDensity}}\r\n            </td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"maxDensity\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\"\r\n                     [innerHtml]=\"'deadLoadsModule.MaximumDensity' | translate\">\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\">\r\n                {{material.maximumDensity}}\r\n            </td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"unit\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Unit' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\"\r\n                [innerHTML]=\"units[material.unit].value\"></td>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"add\">\r\n            <th mat-header-cell\r\n                *matHeaderCellDef>\r\n                <div class=\"ml-3 mr-3 text-center\">\r\n                    {{'deadLoadsModule.Add' | translate}}\r\n                </div>\r\n            </th>\r\n            <td mat-cell\r\n                *matCellDef=\"let material\">\r\n                <button mat-stroked-button color=\"accent\"\r\n                        (click)=\"addMaterial(material)\">\r\n                    <span class=\"fa fa-plus\"></span>\r\n                </button>\r\n            </td>\r\n        </ng-container>\r\n\r\n        <tr mat-header-row *matHeaderRowDef=\"materialsDisplayedColumns\"></tr>\r\n        <tr mat-row *matRowDef=\"let row; columns: materialsDisplayedColumns;\"></tr>\r\n    </table>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.html":
/*!*******************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.html ***!
  \*******************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"text-center\">\r\n\r\n    <h1>{{'deadLoadsModule.Header' | translate}}</h1>\r\n\r\n    <app-dead-loads-calculator [newMaterial]=\"newMaterial\"></app-dead-loads-calculator>\r\n    <app-dead-loads-data (materialAdded)=\"onMaterialAdded($event)\"></app-dead-loads-data>\r\n   \r\n</div>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.html":
/*!*******************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.html ***!
  \*******************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n    <h1 class=\"text-center\">{{'snowLoadsModule.Header' | translate}}</h1>\r\n\r\n<app-script-cards [groupFilters]=\"loadsGroupFilter\"\r\n                  [tagFilters]=\"loadsTagFilter\"></app-script-cards>\r\n\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.html":
/*!***********************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.html ***!
  \***********************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field>\r\n    <span *ngIf=\"parameter.figures && parameter.figures.length > 0\"\r\n          matPrefix><figures-button [parameter]=\"parameter\"></figures-button></span>\r\n    <input type=\"text\"\r\n           aria-label=\"Number\"\r\n           matInput\r\n           [required]=\"isRequired()\"\r\n           [formControl]=\"valueOptionsForm\"\r\n           [attr.type]=\"parameter.valueType == 0 ? 'number' : 'text'\"\r\n           name=\"parameterInput\"\r\n           [ngClass]=\"parameter.name\"\r\n           [matAutocomplete]=\"auto\"\r\n           [(ngModel)]=\"parameter.value\"\r\n           (change)=\"changeValue()\">\r\n    <mat-placeholder>\r\n        <span [innerHtml]=\"parameter.name | html\"></span>\r\n    </mat-placeholder>\r\n    <span matSuffix\r\n          [innerHtml]=\"parameter.unit | html\"></span>\r\n</mat-form-field>\r\n\r\n<mat-autocomplete #auto=\"matAutocomplete\"\r\n                  autoActiveFirstOption>\r\n    <mat-option *ngIf=\"!isRequired()\"\r\n                class=\"default\"> </mat-option>\r\n    <mat-option *ngFor=\"let valueOption of filteredValueOptions | async\"\r\n                [value]=\"valueOption.value\"\r\n                [ngClass]=\"valueOption.name\">\r\n        {{valueOption.name }}\r\n    </mat-option>\r\n</mat-autocomplete>\r\n\r\n<p class=\"parameter-description\">{{parameter.description}}</p>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.html":
/*!***************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.html ***!
  \***************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"align-self-start parameter-radio\">\r\n    <label class=\"align-self-start mb-2\">\r\n        <span *ngIf=\"parameter.figures && parameter.figures.length > 0\"\r\n              matPrefix><figures-button [parameter]=\"parameter\"></figures-button></span>\r\n        <span [innerHtml]=\"parameter.name | html\"></span>{{isRequired() ? '*' : ''}}\r\n    </label>\r\n\r\n    <div class=\"d-inline-flex\"\r\n         [ngClass]=\"parameter.name\">\r\n        <mat-checkbox *ngIf=\"!isRequired()\"\r\n                      class=\"mr-3 default\"\r\n                      #defaultField\r\n                      (change)=\"defaultChecked($event)\">\r\n            {{'scriptCalculator.Controls.Default' | translate}}\r\n        </mat-checkbox>\r\n\r\n        <mat-checkbox *ngIf=\"!isDefault\"\r\n                      [required]=\"isRequired()\"\r\n                      #checkboxField\r\n                      class=\"true\"\r\n                      (change)=\"changeValue($event)\">\r\n            {{'scriptCalculator.Controls.True' | translate}}\r\n        </mat-checkbox>\r\n    </div>\r\n    <p class=\"parameter-description-normal\">{{parameter.description}}</p>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.html":
/*!*****************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.html ***!
  \*****************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<span *ngIf=\"parameter && parameter.figures && parameter.figures.length > 0\"\r\n      class=\"fa fa-images figures-button\"\r\n      (click)=\"openFigures()\"></span>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.html":
/*!*************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.html ***!
  \*************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<!--<mat-accordion *ngIf=\"figures.length > 0\">\r\n    <mat-expansion-panel (closed)=\"collapsed()\"\r\n                         (opened)=\"expanded()\">\r\n        <mat-expansion-panel-header>\r\n            <mat-panel-title>\r\n                {{'scriptCalculator.Controls.Figures' | translate}}\r\n            </mat-panel-title>\r\n        </mat-expansion-panel-header>-->\r\n<h1 mat-dialog-title>Figures</h1>\r\n<div mat-dialog-content\r\n     *ngIf=\"parameter && parameter.figures\">\r\n    <img *ngFor=\"let figure of parameter.figures\"\r\n         src=\"clientapp/uploads/parameters/{{figure.fileName}}\"\r\n         alt=\"Parameter picture\" />\r\n</div>\r\n<div mat-dialog-actions>\r\n    <button mat-button \r\n            (click)=\"onCloseClick()\"\r\n            cdkFocusInitial>Close</button>\r\n    <!--<button mat-button [mat-dialog-close]=\"data.figures\" cdkFocusInitial>Ok</button>-->\r\n</div>\r\n<!--    </mat-expansion-panel>\r\n</mat-accordion>-->\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.html":
/*!*********************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.html ***!
  \*********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field>\r\n    <span *ngIf=\"parameter.figures && parameter.figures.length > 0\"\r\n          matPrefix><figures-button [parameter]=\"parameter\"></figures-button></span>\r\n    <input matInput\r\n           [required]=\"isRequired()\"\r\n           autocomplete=\"off\"\r\n           [ngClass]=\"parameter.name\"\r\n           [attr.type]=\"parameter.valueType == 0 ? 'number' : 'text'\"\r\n           [(ngModel)]=\"parameter.value\"\r\n           (change)=\"changeValue()\">\r\n    <mat-placeholder>\r\n        <span [innerHtml]=\"parameter.name | html\"></span>\r\n    </mat-placeholder>\r\n    <span matSuffix [innerHtml]=\"parameter.unit | html\"></span>\r\n</mat-form-field>\r\n<p class=\"parameter-description\">{{parameter.description}}</p>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.html":
/*!******************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.html ***!
  \******************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"parameter.valueOptionSetting != valueOptionSetting.Boolean && parameter.valueOptions.length == 0; else valueOptions\">\r\n    <parameter-input [parameter]=\"parameter\"\r\n                     (valueChanged)=\"onValueChanged($event)\"></parameter-input>\r\n</div>\r\n\r\n<ng-template #valueOptions>\r\n\r\n    <div *ngIf=\"parameter.valueOptionSetting == valueOptionSetting.UserInput; else fixedValueOptions\">\r\n        <parameter-autocomplete [parameter]=\"parameter\"\r\n                                (valueChanged)=\"onValueChanged($event)\"></parameter-autocomplete>\r\n    </div>\r\n\r\n    <ng-template #fixedValueOptions>\r\n\r\n        <div class=\"form-inline\"\r\n             *ngIf=\"parameter.valueOptionSetting == valueOptionSetting.Boolean; else severalValueOptions\">\r\n            <parameter-checkbox [parameter]=\"parameter\"\r\n                                (valueChanged)=\"onValueChanged($event)\"></parameter-checkbox>\r\n        </div>\r\n\r\n        <ng-template #severalValueOptions>\r\n            <div class=\"form-inline\"\r\n                 *ngIf=\"parameter.valueOptions.length > 0 && parameter.valueOptions.length <= 3\">\r\n                <parameter-radio [parameter]=\"parameter\"\r\n                                 (valueChanged)=\"onValueChanged($event)\"></parameter-radio>\r\n            </div>\r\n\r\n            <div *ngIf=\"parameter.valueOptions.length > 3\">\r\n                <parameter-select [parameter]=\"parameter\"\r\n                                  (valueChanged)=\"onValueChanged($event)\"></parameter-select>\r\n            </div>\r\n        </ng-template>\r\n    </ng-template>\r\n\r\n</ng-template>\r\n\r\n<!--<parameter-figures [parameter]=\"parameter\"></parameter-figures>-->"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.html":
/*!*********************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.html ***!
  \*********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"justify-content-start parameter-radio\">\r\n    <label class=\"align-self-start mb-2\">\r\n        <span *ngIf=\"parameter.figures && parameter.figures.length > 0\"\r\n              matPrefix><figures-button [parameter]=\"parameter\"></figures-button></span>\r\n        <span [innerHtml]=\"parameter.name | html\"></span>{{isRequired() ? '*' : ''}}\r\n    </label>\r\n    <mat-radio-group [(ngModel)]=\"parameter.value\"\r\n                     [ngClass]=\"parameter.name\">\r\n        <mat-radio-button value=\"\"\r\n                          *ngIf=\"!isRequired()\"\r\n                          selected\r\n                          class=\"mr-3 default\"\r\n                          (change)=\"changeValue($event)\">\r\n            {{'scriptCalculator.Controls.Default' | translate}}\r\n        </mat-radio-button>\r\n        <mat-radio-button *ngFor=\"let valueOption of parameter.valueOptions; index as i\"\r\n                          [value]=\"valueOption.value\"\r\n                          [required]=\"isRequired()\"\r\n                          class=\"mr-3\"\r\n                          [ngClass]=\"valueOption.name\"\r\n                          (change)=\"changeValue($event)\">\r\n            {{valueOption.name }}\r\n        </mat-radio-button>\r\n        {{parameter.unit | html}}\r\n    </mat-radio-group>\r\n    <p class=\"parameter-description\">{{parameter.description}}</p>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.html":
/*!***********************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.html ***!
  \***********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field>\r\n    <span *ngIf=\"parameter.figures && parameter.figures.length > 0\"\r\n          matPrefix><figures-button [parameter]=\"parameter\"></figures-button></span>\r\n    <mat-label [innerHtml]=\"parameter.name | html\"></mat-label>\r\n    <mat-select [(ngModel)]=\"parameter.value\"\r\n                [required]=\"isRequired()\"\r\n                [ngClass]=\"parameter.name\"\r\n                (selectionChange)=\"changeValue()\">\r\n        <mat-option *ngIf=\"!isRequired()\"\r\n                    class=\"default\"></mat-option>\r\n        <mat-option *ngFor=\"let valueOption of parameter.valueOptions\"\r\n                    [value]=\"valueOption.value\"\r\n                    [ngClass]=\"valueOption.name\">\r\n            {{valueOption.name }}\r\n        </mat-option>\r\n    </mat-select>\r\n    <span matSuffix\r\n          [innerHtml]=\"parameter.unit | html\"></span>\r\n</mat-form-field>\r\n<p class=\"parameter-description\">{{parameter.description}}</p>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.html":
/*!**********************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.html ***!
  \**********************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [ngClass]=\"{'parameter-result-important': isImportant()}\">\r\n    <mat-list-item class=\"mt-3\">\r\n        <div class=\"d-inline-flex m-2\">\r\n            <h3 class=\"blockquote d-inline-block mr-2 parameter-result-header\"\r\n                [innerHtml]=\"parameter.name | html\"></h3>\r\n            <div class=\"d-inline-block\">\r\n                <p class=\"font-weight-bold mb-0 parameter-result-value\">\r\n                    <span *ngIf=\"parameter.valueType == valueTypesMapping['number']; else textValue\"\r\n                          [ngClass]=\"parameter.name\">\r\n                        {{parameter.value | toNumber | number:'1.0-3'}}\r\n                    </span>\r\n                    <ng-template #textValue>\r\n                        <span [ngClass]=\"parameter.name\">{{parameter.value}}</span>\r\n                    </ng-template>\r\n                    <span [innerHtml]=\"parameter.unit | html\"></span>\r\n                </p>\r\n                <p class=\"d-inline-block\"> {{ parameter.description }} </p>\r\n            </div>\r\n            <!--<p innerHtml=\"{{parameter.equation | html}}\"></p>-->\r\n        </div>\r\n    </mat-list-item>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.html":
/*!************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.html ***!
  \************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div *ngIf=\"script\">\r\n    <div class=\"text-center\">\r\n        <h1>{{script.name}}</h1>\r\n    </div>\r\n\r\n    <p class=\"ml-2\">{{script.description}}</p>\r\n    <ul>\r\n        <li *ngFor=\"let tag of script.tags\">\r\n            {{tag.name}}\r\n        </li>\r\n    </ul>\r\n    <div *ngIf=\"!visibleParameters\">\r\n        <mat-progress-bar mode=\"indeterminate\"></mat-progress-bar>\r\n    </div>\r\n\r\n    <div *ngIf=\"staticDataParameters && staticDataParameters.length > 0\">\r\n        <h5 class=\"ml-2\">{{'scriptCalculator.StaticData' | translate}}</h5>\r\n        <mat-list dense>\r\n            <div *ngFor=\"let parameter of staticDataParameters\">\r\n                <parameter-result [parameter]=\"parameter\"></parameter-result>\r\n                <mat-divider></mat-divider>\r\n            </div>\r\n        </mat-list>\r\n    </div>\r\n\r\n    <div class=\"mt-2\">\r\n        <div *ngFor=\"let parameter of notGroupedParameters\"\r\n             class=\"list-inline-item ml-5 d-inline-flex\">\r\n            <parameter-form [parameter]=\"parameter\"\r\n                            (valueChanged)=\"onValueChanged($event)\"></parameter-form>\r\n        </div>\r\n\r\n\r\n        <mat-accordion>\r\n            <mat-expansion-panel *ngFor=\"let group of groups\">\r\n                <mat-expansion-panel-header>\r\n                    <mat-panel-title>\r\n                        {{group.name}}\r\n                    </mat-panel-title>\r\n                </mat-expansion-panel-header>\r\n\r\n                <ul class=\"list-inline m-0\">\r\n                    <li *ngFor=\"let parameter of group.parameters\"\r\n                        class=\"list-inline-item ml-5 d-inline-flex\">\r\n                        <parameter-form [parameter]=\"parameter\"\r\n                                        (valueChanged)=\"onValueChanged($event)\"></parameter-form>\r\n                    </li>\r\n                </ul>\r\n\r\n            </mat-expansion-panel>\r\n        </mat-accordion>\r\n    </div>\r\n\r\n\r\n    <div class=\"text-center\"\r\n         *ngIf=\"visibleParameters\">\r\n\r\n            <mat-chip-list aria-label=\"Error list\"\r\n                           class=\"list-horizontal\"\r\n                           *ngIf=\"errorMessages\">\r\n                <mat-chip *ngFor=\"let errorMessage of errorMessages\"\r\n                          [innerHtml]=\"errorMessage | html\"\r\n                          color=\"warn\"\r\n                          selected></mat-chip>\r\n            </mat-chip-list>\r\n\r\n        <button mat-stroked-button\r\n                color=\"accent\"\r\n                class=\"calculate\"\r\n                type=\"button\"\r\n                [disabled]=\"!isValid()\"\r\n                (click)=\"calculate()\">\r\n            <span class=\"fa fa-calculator\"></span> {{'scriptCalculator.Calculate' | translate}}\r\n        </button>\r\n    </div>\r\n\r\n    <div *ngIf=\"isCalculating\"\r\n         class=\"mt-2\">\r\n        <mat-progress-bar mode=\"query\"></mat-progress-bar>\r\n    </div>\r\n\r\n    <div *ngIf=\"resultParameters && !valueChanged\">\r\n        <h3 class=\"ml-2\">{{'scriptCalculator.Results' | translate}}</h3>\r\n        <mat-list dense>\r\n            <div *ngFor=\"let parameter of resultParameters\">\r\n                <parameter-result [parameter]=\"parameter\"></parameter-result>\r\n                <mat-divider></mat-divider>\r\n            </div>\r\n        </mat-list>\r\n    </div>\r\n</div>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-card/script-card.component.html":
/*!************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-card/script-card.component.html ***!
  \************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<mat-card class=\"flex-grow-1\">\r\n    <mat-card-header>\r\n        <div mat-card-avatar class=\"script-header-image\"></div>\r\n        <mat-card-title>{{ script.name }}</mat-card-title>\r\n        <mat-card-subtitle>{{ script.accordingTo }}</mat-card-subtitle>\r\n    </mat-card-header>\r\n    <div mat-card-image>\r\n        <ul>\r\n            <li class=\"small\"\r\n                *ngFor=\"let tag of script.tags\">{{tag.name}}</li>\r\n        </ul>\r\n    </div>\r\n    <!--<img mat-card-image\r\n         src=\"https://lorempixel.com/300/300/?random={{script.id}}\"\r\n         title=\"{{script.name}}\"\r\n         alt=\"{{script.name}}\">-->\r\n    <mat-card-content>\r\n        <p class=\"mb-4\">\r\n            {{script.description }}\r\n        </p>\r\n    </mat-card-content>\r\n    <mat-card-actions class=\"footer\">\r\n        <div class=\"actions\">\r\n            <button mat-stroked-button\r\n                    [routerLink]=\"['/scripts/calculator', script.id]\">\r\n                <span class=\"fa fa-calculator\"></span> {{'scriptCard.Calculate' | translate}}\r\n            </button>\r\n            <button *ngIf=\"this.auth.isLoggedIn()\"\r\n                    mat-stroked-button\r\n                    [routerLink]=\"['/scripts/edit', script.id]\">\r\n                <span class=\"fa fa-edit\"></span> {{'scriptCard.Edit' | translate}}\r\n            </button>\r\n        </div>\r\n        <button *ngIf=\"this.auth.isLoggedIn()\"\r\n                mat-stroked-button\r\n                color=\"warn\"\r\n                class=\"float-right\"\r\n                (click)=\"delete(script)\">\r\n            <span class=\"fa fa-remove\"></span> {{'scriptCard.Delete' | translate}}\r\n        </button>\r\n    </mat-card-actions>\r\n</mat-card>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-cards/script-cards.component.html":
/*!**************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-cards/script-cards.component.html ***!
  \**************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"row mt-5 m-2\">\r\n    <app-script-card *ngFor=\"let script of activeScripts\"\r\n                     class=\"flex-column d-none d-flex col col-xl-3 col-lg-4 col-md-6 col-sm-12 col-auto mb-4\"\r\n                     [script]=\"script\"\r\n                     (deleted)=\"onDeleted($event)\"></app-script-card>\r\n</div>\r\n<mat-paginator [length]=\"filteredScripts.length\"\r\n               [pageSize]=\"pageSize\"\r\n               [pageSizeOptions]=\"pageSizeOptions\"\r\n               [pageIndex]=\"pageIndex\"\r\n               (page)=\"onPageChanged($event)\">\r\n</mat-paginator>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.html":
/*!********************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.html ***!
  \********************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n\r\n<form (ngSubmit)=\"onSubmit($event)\"\r\n      [formGroup]=\"parameterForm\">\r\n\r\n    <h3>\r\n        <span innerHTML=\"{{parameterName.value | html }}\"></span> - {{parameterDescription.value}}\r\n    </h3>\r\n\r\n    <div class=\"full-width\">\r\n        <label id=\"parameter-type\">{{'scriptsForm.Parameters.EditMode.ParameterTypePicker' | translate}}</label>\r\n        <mat-radio-group aria-labelledby=\"parameter-type\"\r\n                         (change)=\"parameterTypeChanged()\">\r\n            <mat-radio-button class=\"ml-2\"\r\n                              #editable\r\n                              [value]=\"context.editable\">\r\n                {{'scriptsForm.Parameters.EditMode.ParameterTypes.Editable' | translate}}\r\n            </mat-radio-button>\r\n            <mat-radio-button class=\"ml-2\"\r\n                              #static\r\n                              [value]=\"context.staticData\">\r\n                {{'scriptsForm.Parameters.EditMode.ParameterTypes.Static' | translate}}\r\n            </mat-radio-button>\r\n            <mat-radio-button class=\"ml-2\"\r\n                              #calculable\r\n                              [value]=\"context.calculation\">\r\n                {{'scriptsForm.Parameters.EditMode.ParameterTypes.Calculable' | translate}}\r\n            </mat-radio-button>\r\n        </mat-radio-group>\r\n\r\n        <mat-checkbox (change)=\"parameterTypeChanged()\"\r\n                      [value]=\"context.visible\"\r\n                      class=\"ml-2\"\r\n                      #visible>\r\n            {{'scriptsForm.Parameters.EditMode.ParameterTypes.Visible' | translate}}\r\n        </mat-checkbox>\r\n        <mat-checkbox (change)=\"parameterTypeChanged()\"\r\n                      [value]=\"context.important\"\r\n                      class=\"ml-2\"\r\n                      #important>\r\n            {{'scriptsForm.Parameters.EditMode.ParameterTypes.Important' | translate}}\r\n        </mat-checkbox>\r\n        <mat-checkbox (change)=\"parameterTypeChanged()\"\r\n                      [value]=\"context.optional\"\r\n                      class=\"ml-2\"\r\n                      #optional>\r\n            {{'scriptsForm.Parameters.EditMode.ParameterTypes.Optional' | translate}}\r\n        </mat-checkbox>\r\n\r\n    </div>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <input matInput\r\n               required\r\n               placeholder=\"{{'scriptsForm.Parameters.EditMode.Name.Header' | translate}}\"\r\n               formControlName=\"name\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.Name.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterName && parameterName.hasError('maxlength') && !parameterName.hasError('required')\">\r\n            {{'scriptsForm.Parameters.EditMode.Name.MaxLengthError' | translate:parameterName.errors.maxlength}}\r\n        </mat-error>\r\n        <mat-error *ngIf=\"parameterName && parameterName.hasError('required')\"\r\n                   [innerHtml]=\"'scriptsForm.Parameters.EditMode.Name.RequiredError' | translate\">\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <input matInput\r\n               placeholder=\"{{'scriptsForm.Parameters.EditMode.Unit.Header' | translate}}\"\r\n               formControlName=\"unit\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.Unit.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterUnit && parameterUnit.hasError('maxlength')\">\r\n            {{'scriptsForm.Parameters.EditMode.Unit.MaxLengthError' | translate:parameterUnit.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <input matInput\r\n               placeholder=\"{{'scriptsForm.Parameters.EditMode.Document.Header' | translate}}\"\r\n               formControlName=\"accordingTo\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.Document.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterDocument && parameterDocument.hasError('maxlength')\">\r\n            {{'scriptsForm.Parameters.EditMode.Document.MaxLengthError' | translate:parameterDocument.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <mat-label>{{'scriptsForm.Parameters.EditMode.ValueType.Header' | translate}}</mat-label>\r\n        <mat-select matNativeControl\r\n                    formControlName=\"valueType\"\r\n                    required>\r\n            <mat-option [value]=\"0\">\r\n                {{'scriptsForm.Parameters.EditMode.ValueType.Number'| translate}}\r\n            </mat-option>\r\n            <mat-option [value]=\"1\">\r\n                {{'scriptsForm.Parameters.EditMode.ValueType.Text'| translate}}\r\n            </mat-option>\r\n        </mat-select>\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.ValueType.Hint' | translate}}</mat-hint>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2\">\r\n        <mat-label>{{'scriptsForm.Parameters.EditMode.GroupName.Header' | translate}}</mat-label>\r\n        <input matInput\r\n               placeholder=\"{{'scriptsForm.Parameters.EditMode.GroupName.Header' | translate}}\"\r\n               formControlName=\"groupName\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.GroupName.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterGroupName && parameterGroupName.hasError('maxlength')\">\r\n            {{'scriptsForm.Parameters.EditMode.GroupName.MaxLengthError' | translate:parameterGroupName.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <!--<div contenteditable=\"true\"\r\n         [innerHtml]=\"parameterValue.value | html\"></div>-->\r\n\r\n    <mat-form-field class=\"m-2 full-width\">\r\n        <textarea matInput\r\n                  #value\r\n                  placeholder=\"{{'scriptsForm.Parameters.EditMode.Value.Header' | translate}}\"\r\n                  formControlName=\"value\"\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\"></textarea>\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.Value.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterValue && parameterValue.hasError('maxlength')\">\r\n            {{'scriptsForm.Parameters.EditMode.Value.MaxLengthError' | translate:parameterValue.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <div>\r\n        <button mat-stroked-button\r\n                *ngFor=\"let parameter of previousParameters\"\r\n                matTooltip=\"{{parameter.description}}\"\r\n                matTooltipPosition=\"below\"\r\n                innerHtml=\"{{parameter.name | html}} [{{parameter.unit | html}}]\"\r\n                type=\"button\"\r\n                (click)=\"select(parameter)\"></button>\r\n    </div>\r\n\r\n    <div class=\"value-options-border p-2\">\r\n        <app-value-options-form [parameterForm]=\"parameterForm\"></app-value-options-form>\r\n    </div>\r\n\r\n    <mat-form-field class=\"m-2 full-width\">\r\n        <textarea matInput\r\n                  placeholder=\"{{'scriptsForm.Parameters.EditMode.Description.Header' | translate}}\"\r\n                  formControlName=\"description\"\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\"></textarea>\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.Description.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterDescription && parameterDescription.hasError('maxlength')\">\r\n            {{'scriptsForm.Parameters.EditMode.Description.MaxLengthError' | translate:parameterDescription.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 form-medium\">\r\n        <textarea matInput\r\n                  placeholder=\"{{'scriptsForm.Parameters.EditMode.VisibilityValidator.Header' | translate}}\"\r\n                  formControlName=\"visibilityValidator\"\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\" ></textarea>\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.VisibilityValidator.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterVisibilityValidator && parameterVisibilityValidator.hasError('maxlength')\">\r\n            {{'scriptsForm.Parameters.EditMode.VisibilityValidator.MaxLengthError' | translate:parameterVisibilityValidator.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 form-medium\">\r\n        <textarea matInput\r\n                  placeholder=\"{{'scriptsForm.Parameters.EditMode.DataValidator.Header' | translate}}\"\r\n                  formControlName=\"dataValidator\"\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\" ></textarea>\r\n        <mat-hint>{{'scriptsForm.Parameters.EditMode.DataValidator.Hint' | translate}}</mat-hint>\r\n        <mat-error *ngIf=\"parameterDataValidator && parameterDataValidator.hasError('maxlength')\">\r\n            {{'scriptsForm.Parameters.EditMode.DataValidator.MaxLengthError' | translate:parameterDataValidator.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <div class=\"value-options-border p-2 mb-3\"\r\n         *ngIf=\"parameterId.value > 0\">\r\n        <app-figure-parameter-form [parameterForm]=\"parameterForm\"></app-figure-parameter-form>\r\n    </div>\r\n\r\n    <div class=\"full-width\">\r\n        <button mat-stroked-button\r\n                color=\"accent\"\r\n                type=\"submit\">\r\n            {{ newlyAddedParameter ? ('scriptsForm.Parameters.Add' | translate) : ('scriptsForm.Parameters.EditMode.Update' | translate)}}\r\n        </button>\r\n    </div>\r\n</form>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.html":
/*!************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.html ***!
  \************************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1 mat-dialog-title>Pictures</h1>\r\n<div mat-dialog-content>\r\n    <p>Select proper picture:</p>\r\n    <mat-form-field>\r\n        <img *ngFor=\"let figure of figures\"\r\n             src=\"clientapp/uploads/{{parameterId.value}}/{{figure.fileName}}\"\r\n             alt=\"Parameter picture\" />\r\n    </mat-form-field>\r\n</div>\r\n<div mat-dialog-actions>\r\n    <button mat-button \r\n            type=\"button\"\r\n            (click)=\"onNoClick()\">No Thanks</button>\r\n    <button mat-button \r\n            type=\"button\"\r\n            [mat-dialog-close]=\"data\" \r\n            cdkFocusInitial>Ok</button>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.html":
/*!********************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.html ***!
  \********************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<mat-accordion>\r\n    <mat-expansion-panel>\r\n        <mat-expansion-panel-header>\r\n            <mat-panel-title>\r\n                {{'scriptsForm.Parameters.Figures.Header' | translate}}\r\n            </mat-panel-title>\r\n            <mat-panel-description>\r\n                {{'scriptsForm.Parameters.Figures.Hint' | translate}}\r\n            </mat-panel-description>\r\n        </mat-expansion-panel-header>\r\n        <input type=\"file\"\r\n               (change)=\"uploadFigure()\"\r\n               #fileInput />\r\n\r\n        <div class=\"mt-1\">\r\n            <!--<button mat-raised-button (click)=\"pickExistingDialog()\">Pick existing</button>-->\r\n            <div *ngFor=\"let figure of figures\">\r\n                <img src=\"clientapp/uploads/parameters/{{figure.fileName}}\"\r\n                     alt=\"Parameter picture\" />\r\n                <button mat-stroked-button\r\n                        color=\"warn\"\r\n                        type=\"button\"\r\n                        (click)=\"remove(figure)\">\r\n                    {{'scriptsForm.Parameters.Figures.Remove' | translate}}\r\n                </button>\r\n                <p>Test</p>\r\n            </div>\r\n        </div>\r\n\r\n    </mat-expansion-panel>\r\n</mat-accordion>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.html":
/*!**************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.html ***!
  \**************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<mat-accordion>\r\n    <mat-expansion-panel>\r\n        <mat-expansion-panel-header>\r\n            <mat-panel-title>\r\n                {{'scriptsForm.Parameters.ValueOptions.Header' | translate}}\r\n            </mat-panel-title>\r\n            <mat-panel-description>\r\n                {{'scriptsForm.Parameters.ValueOptions.Hint' | translate}}\r\n            </mat-panel-description>\r\n        </mat-expansion-panel-header>\r\n\r\n        <form [formGroup]=\"parameterForm\">\r\n\r\n            <div>\r\n                <mat-radio-group formControlName=\"valueOptionSetting\">\r\n                    <mat-radio-button [value]=\"valueOptionSettings.None\"\r\n                                      class=\"ml-2\">\r\n                        {{'scriptsForm.Parameters.ValueOptions.None' | translate}}\r\n                    </mat-radio-button>\r\n                    <mat-radio-button [value]=\"valueOptionSettings.UserInput\"\r\n                                      class=\"ml-2\">\r\n                        {{'scriptsForm.Parameters.ValueOptions.AllowAny' | translate}}\r\n                    </mat-radio-button>\r\n                    <mat-radio-button [value]=\"valueOptionSettings.Boolean\"\r\n                                      (change)=\"booleanSettingChecked($event)\"\r\n                                      class=\"ml-2\">\r\n                        {{'scriptsForm.Parameters.ValueOptions.Boolean' | translate}}\r\n                    </mat-radio-button>\r\n                </mat-radio-group>\r\n            </div>\r\n\r\n            <div *ngIf=\"parameterValueOptionSetting.value != valueOptionSettings.Boolean\">\r\n                <ul *ngFor=\"let valueOption of parameterValueOptions.controls; let i = index\">\r\n                    <li>\r\n                        <div [formGroup]=\"valueOption\">\r\n                            <mat-form-field class=\"m-2\">\r\n                                <input matInput\r\n                                       placeholder=\"{{'scriptsForm.Parameters.ValueOptions.Name.Header' | translate}}\"\r\n                                       formControlName=\"name\"\r\n                                       [errorStateMatcher]=\"matcher\"\r\n                                       autocomplete=\"off\" />\r\n                                <mat-hint>{{'scriptsForm.Parameters.ValueOptions.Name.Hint' | translate}}</mat-hint>\r\n                                <!--<mat-error *ngIf=\"parameterDocument && parameterDocument.hasError('maxlength')\">\r\n                        Document should be maximum {{parameterDocument.errors.maxlength.requiredLength}} characters long.\r\n                    </mat-error>-->\r\n                            </mat-form-field>\r\n                            <mat-form-field class=\"m-2\">\r\n                                <input matInput\r\n                                       placeholder=\"{{'scriptsForm.Parameters.ValueOptions.Value.Header' | translate}}\"\r\n                                       formControlName=\"value\"\r\n                                       [errorStateMatcher]=\"matcher\"\r\n                                       autocomplete=\"off\" />\r\n                                <mat-hint>{{'scriptsForm.Parameters.ValueOptions.Value.Hint' | translate}}</mat-hint>\r\n                            </mat-form-field>\r\n\r\n                            <mat-form-field class=\"m-2 form-medium\">\r\n                                <textarea matInput\r\n                                          placeholder=\"{{'scriptsForm.Parameters.ValueOptions.Description.Header' | translate}}\"\r\n                                          formControlName=\"description\"\r\n                                          [errorStateMatcher]=\"matcher\"\r\n                                          autocomplete=\"off\"></textarea>\r\n                                <mat-hint>{{'scriptsForm.Parameters.ValueOptions.Description.Hint' | translate}}</mat-hint>\r\n                            </mat-form-field>\r\n\r\n                            <button mat-stroked-button\r\n                                    color=\"warn\"\r\n                                    type=\"button\"\r\n                                    (click)=\"remove(valueOption)\">\r\n                                {{'scriptsForm.Parameters.ValueOptions.Remove' | translate}}\r\n                            </button>\r\n                        </div>\r\n                    </li>\r\n                </ul>\r\n                <button mat-stroked-button\r\n                        color=\"accent\"\r\n                        type=\"button\"\r\n                        (click)=\"addValueOption()\">\r\n                    {{'scriptsForm.Parameters.ValueOptions.Add' | translate}}\r\n                </button>\r\n            </div>\r\n        </form>\r\n\r\n    </mat-expansion-panel>\r\n</mat-accordion>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.html":
/*!********************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.html ***!
  \********************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"!editMode\">\r\n    <div class=\"m-4\">\r\n        <label id=\"parameters-type-filter\">{{'scriptsForm.Parameters.ParametersFilterLabel' | translate}}:</label>\r\n        <mat-radio-group aria-labelledby=\"parameters-type-filter\"\r\n                         [(ngModel)]=\"parametersToShow\"\r\n                         (change)=\"onParametersToShowChange()\">\r\n            <mat-radio-button value=\"all\"\r\n                              class=\"ml-2\">{{'scriptsForm.Parameters.AllParameters' | translate}}</mat-radio-button>\r\n            <mat-radio-button value=\"data\"\r\n                              class=\"ml-2\">{{'scriptsForm.Parameters.DataParameters' | translate}}</mat-radio-button>\r\n            <mat-radio-button value=\"static\"\r\n                              class=\"ml-2\">{{'scriptsForm.Parameters.StaticParameters' | translate}}</mat-radio-button>\r\n            <mat-radio-button value=\"calculation\"\r\n                              class=\"ml-2\">{{'scriptsForm.Parameters.CalculationParameters' | translate}}</mat-radio-button>\r\n        </mat-radio-group>\r\n    </div>\r\n\r\n    <div cdkDropList\r\n         class=\"parameters-list\"\r\n         (cdkDropListDropped)=\"drop($event)\">\r\n        <div class=\"parameter-in-list\"\r\n             *ngFor=\"let parameter of sortParameters(filteredParameters, 'number')\"\r\n             cdkDrag>\r\n            <div class=\"parameter-placeholder\"\r\n                 *cdkDragPlaceholder></div>\r\n            <div class=\"parameter-container\"\r\n                 [ngClass]=\"{'selected-parameter' : parameter == newParameter}\">\r\n                <div class=\"ml-3 parameter-data\">\r\n                    <b class=\"parameter-name\"\r\n                       [innerHTML]=\"parameter.name | html\"></b> - {{parameter.description}}\r\n                </div>\r\n\r\n                <div class=\"parameter-options\">\r\n                    <button mat-stroked-button\r\n                            class=\"ml-2\"\r\n                            (click)=\"editParameter(parameter)\">\r\n                        {{'scriptsForm.Parameters.Edit' | translate}}\r\n                    </button>\r\n                    <button mat-stroked-button\r\n                            class=\"ml-2\"\r\n                            (click)=\"remove(parameter.id)\"\r\n                            color=\"warn\">\r\n                        {{'scriptsForm.Parameters.Remove' | translate}}\r\n                    </button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <button mat-stroked-button\r\n            color=\"accent\"\r\n            class=\"m-3\"\r\n            (click)=\"addNewParameter()\">\r\n        {{'scriptsForm.Parameters.NewParameter' | translate}}\r\n    </button>\r\n</div>\r\n\r\n<div class=\"m-3\"\r\n     *ngIf=\"editMode\">\r\n    <button mat-fab\r\n            color=\"primary\"\r\n            (click)=\"changeEditMode()\">\r\n        <span class=\"fa fa-backward\"></span>\r\n    </button>\r\n\r\n    <div class=\"container\"\r\n         *ngIf=\"editMode\">\r\n        <app-data-parameter-form [newlyAddedParameter]=\"newlyAddedParameter\"\r\n                                 [scriptId]=\"scriptId\"\r\n                                 [newParameter]=\"newParameter\"\r\n                                 [parameters]=\"parameters\"\r\n                                 (created)=\"onCreated($event)\"\r\n                                 (updated)=\"onUpdated($event)\"></app-data-parameter-form>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.html":
/*!**********************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.html ***!
  \**********************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n    <div [formGroup]=\"scriptForm\">\r\n        <mat-form-field class=\"m-2 form-medium\">\r\n            <input matInput\r\n                   required\r\n                   placeholder=\"{{'scriptsForm.ScriptData.Name.Header' | translate}}\"\r\n                   formControlName=\"name\"\r\n                   [errorStateMatcher]=\"matcher\"\r\n                   autocomplete=\"off\" />\r\n            <mat-hint>{{'scriptsForm.ScriptData.Name.Hint' | translate}}</mat-hint>\r\n            <mat-error *ngIf=\"scriptName && scriptName.hasError('minlength') && !scriptName.hasError('required')\">\r\n                {{'scriptsForm.ScriptData.Name.MinLengthError' | translate:scriptName.errors.minlength}}\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptName && scriptName.hasError('maxlength') && !scriptName.hasError('required')\">\r\n                {{'scriptsForm.ScriptData.Name.MaxLengthError' | translate:scriptName.errors.maxlength}}\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptName && scriptName.hasError('required')\"\r\n                       [innerHtml]=\"'scriptsForm.ScriptData.Name.RequiredError' | translate\">\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2\">\r\n            <input matInput\r\n                   placeholder=\"{{'scriptsForm.ScriptData.Author.Header' | translate}}\"\r\n                   formControlName=\"author\"\r\n                   [errorStateMatcher]=\"matcher\"\r\n                   autocomplete=\"off\" />\r\n            <mat-hint>{{'scriptsForm.ScriptData.Author.Hint' | translate}}</mat-hint>\r\n            <mat-error *ngIf=\"scriptAuthor && scriptAuthor.hasError('maxlength')\">\r\n                {{'scriptsForm.ScriptData.Author.MaxLengthError' | translate:scriptAuthor.errors.maxlength}}\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2 form-medium\">\r\n            <input matInput\r\n                   placeholder=\"{{'scriptsForm.ScriptData.Document.Header' | translate}}\"\r\n                   formControlName=\"accordingTo\"\r\n                   [errorStateMatcher]=\"matcher\"\r\n                   autocomplete=\"off\" />\r\n            <mat-hint>{{'scriptsForm.ScriptData.Document.Hint' | translate}}</mat-hint>\r\n            <mat-error *ngIf=\"scriptDocument && scriptDocument.hasError('maxlength')\">\r\n                {{'scriptsForm.ScriptData.Document.MaxLengthError' | translate:scriptDocument.errors.maxlength}}\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2\">\r\n            <mat-label>{{'scriptsForm.ScriptData.Group.Header' | translate}}</mat-label>\r\n            <mat-select formControlName=\"groupName\"\r\n                        [errorStateMatcher]=\"matcher\"\r\n                        required>\r\n                <mat-option value=\"Statica\">\r\n                    <span class=\"fa fa-minus\"></span> {{'scriptsForm.ScriptData.Group.Statica' | translate}}\r\n                </mat-option>\r\n                <mat-option value=\"Loads\">\r\n                    <span class=\"fa fa-arrow-down\"></span> {{'scriptsForm.ScriptData.Group.Loads' | translate}}\r\n                </mat-option>\r\n                <mat-option value=\"Concrete\">{{'scriptsForm.ScriptData.Group.Concrete' | translate}}</mat-option>\r\n                <mat-option value=\"Steel\">{{'scriptsForm.ScriptData.Group.Steel' | translate}}</mat-option>\r\n                <mat-option value=\"Timber\">\r\n                    <span class=\"fa fa-tree\"></span> {{'scriptsForm.ScriptData.Group.Timber' | translate}}\r\n                </mat-option>\r\n                <mat-option value=\"Soils\">\r\n                    {{'scriptsForm.ScriptData.Group.Soils' | translate}}\r\n                </mat-option>\r\n                <mat-divider></mat-divider>\r\n                <mat-option value=\"Other\">\r\n                    {{'scriptsForm.ScriptData.Group.Other' | translate}}\r\n                </mat-option>\r\n            </mat-select>\r\n            <mat-hint>{{'scriptsForm.ScriptData.Group.Hint' | translate}}</mat-hint>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2\">\r\n            <mat-label>{{'app.Languages.Language' | translate}}</mat-label>\r\n            <mat-select formControlName=\"defaultLanguage\"\r\n                        [errorStateMatcher]=\"matcher\"\r\n                        required>\r\n                <mat-option [value]=\"languages.english\">\r\n                    {{'app.Languages.English' | translate}}\r\n                </mat-option>\r\n                <mat-option [value]=\"languages.polish\">\r\n                    {{'app.Languages.Polish' | translate}}\r\n                </mat-option>\r\n            </mat-select>\r\n            <mat-hint>{{'scriptsForm.ScriptData.Group.Hint' | translate}}</mat-hint>\r\n            <mat-error *ngIf=\"scriptDefaultLanguage && scriptDefaultLanguage.hasError('required')\"\r\n                       [innerHtml]=\"'scriptsForm.ScriptData.Description.RequiredError' | translate\">\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2 full-width\">\r\n            <textarea matInput\r\n                      placeholder=\"{{'scriptsForm.ScriptData.Description.Header' | translate}}\"\r\n                      formControlName=\"description\"\r\n                      required\r\n                      [errorStateMatcher]=\"matcher\"\r\n                      autocomplete=\"off\"></textarea>\r\n            <mat-hint>{{'scriptsForm.ScriptData.Description.Hint' | translate}}</mat-hint>\r\n            <mat-error *ngIf=\"scriptDescription && scriptDescription.hasError('minlength') && !scriptDescription.hasError('required')\">\r\n                {{'scriptsForm.ScriptData.Description.MinLengthError' | translate:scriptDescription.errors.minlength}}\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptDescription && scriptDescription.hasError('maxlength') && !scriptDescription.hasError('required')\">\r\n                {{'scriptsForm.ScriptData.Description.MaxLengthError' | translate:scriptDescription.errors.maxlength}}\r\n            </mat-error>\r\n            <mat-error *ngIf=\"scriptDescription && scriptDescription.hasError('required')\"\r\n                       [innerHtml]=\"'scriptsForm.ScriptData.Description.RequiredError' | translate\">\r\n            </mat-error>\r\n        </mat-form-field>\r\n\r\n        <div class=\"m-2\">\r\n            <mat-checkbox [checked]=\"includeNote\"\r\n                          (change)=\"includeNote = !includeNote\">\r\n                {{'scriptsForm.ScriptData.IncludeNote' | translate}}\r\n            </mat-checkbox>\r\n\r\n            <mat-form-field class=\"full-width\"\r\n                            *ngIf=\"includeNote\">\r\n                <textarea matInput\r\n                          placeholder=\"{{'scriptsForm.ScriptData.Note.Header' | translate}}\"\r\n                          formControlName=\"notes\"\r\n                          [errorStateMatcher]=\"matcher\"\r\n                          autocomplete=\"off\"></textarea>\r\n                <mat-hint>{{'scriptsForm.ScriptData.Note.Hint' | translate}}</mat-hint>\r\n                <mat-error *ngIf=\"scriptNotes && scriptNotes.hasError('maxlength')\">\r\n                    {{'scriptsForm.ScriptData.Note.MaxLengthError' | translate:scriptNotes.errors.maxlength}}\r\n                </mat-error>\r\n            </mat-form-field>\r\n        </div>\r\n    </div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/script-form.component.html":
/*!************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/script-form.component.html ***!
  \************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h2 class=\"mt-4 text-center\"\r\n    *ngIf=\"!editMode\">\r\n    {{'scriptsForm.Header' | translate}}\r\n</h2>\r\n<h2 class=\"mt-4 text-center\"\r\n    *ngIf=\"editMode\">\r\n    {{scriptName.value}}\r\n</h2>\r\n\r\n<form (ngSubmit)=\"onSubmit()\"\r\n      [formGroup]=\"scriptForm\">\r\n    <mat-tab-group dynamicHeight>\r\n\r\n        <mat-tab label=\"{{'scriptsForm.ScriptData.Header' | translate}}\">\r\n            <div class=\"mat-elevation-z4\">\r\n                <script-data-form [scriptForm]=\"scriptForm\"\r\n                                  [includeNote]=\"includeNote\"></script-data-form>\r\n            </div>\r\n        </mat-tab>\r\n\r\n        <mat-tab label=\"{{'scriptsForm.Tags.Header' | translate}}\">\r\n            <div class=\"mat-elevation-z4\">\r\n                <tag-form [scriptForm]=\"scriptForm\"></tag-form>\r\n            </div>\r\n        </mat-tab>\r\n\r\n        <mat-tab label=\"{{'scriptsForm.Parameters.Header' | translate}}\"\r\n                 *ngIf=\"editMode\">\r\n            <div class=\"mat-elevation-z4\">\r\n                <app-parameters-form *ngIf=\"editMode\"></app-parameters-form>\r\n            </div>\r\n        </mat-tab>\r\n\r\n        <mat-tab label=\"{{'scriptsForm.Translations.Header' | translate}}\">\r\n            <div class=\"mat-elevation-z4\">\r\n                <app-translation-form [defaultLanguage]=\"scriptDefaultLanguage.value\" \r\n                                      [scriptForm]=\"scriptForm\"></app-translation-form>\r\n            </div>\r\n        </mat-tab>\r\n    </mat-tab-group>\r\n    \r\n    <button mat-stroked-button\r\n            color=\"accent\"\r\n            type=\"submit\"\r\n            [disabled]=\"!scriptForm.valid\"\r\n            class=\"mt-3 ml-3\">\r\n        {{editMode ? ('scriptsForm.UpdateScript' | translate) : ('scriptsForm.AddScript' | translate)}}\r\n    </button>\r\n</form>\r\n\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.html":
/*!******************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.html ***!
  \******************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-form-field class=\"w-75 m-2\">\r\n    <mat-chip-list #chipList>\r\n        <mat-chip *ngFor=\"let tagForm of scriptTags.controls\"\r\n                  [selectable]=\"selectable\"\r\n                  [removable]=\"removable\"\r\n                  (removed)=\"remove(tagForm)\">\r\n            {{tagForm.value.name}}\r\n            <span matChipRemove\r\n                  *ngIf=\"removable\"\r\n                  class=\"fa fa-times\"></span>\r\n        </mat-chip>\r\n        <input placeholder=\"{{'scriptsForm.Tags.AddNewTags' | translate}}\"\r\n               #tagInput\r\n               [attr.disabled]=\"scriptTags.controls.length > 5 || null\"\r\n               [formControl]=\"tagCtrl\"\r\n               [matAutocomplete]=\"auto\"\r\n               [matChipInputFor]=\"chipList\"\r\n               [matChipInputSeparatorKeyCodes]=\"separatorKeysCodes\"\r\n               [matChipInputAddOnBlur]=\"addOnBlur\"\r\n               (matChipInputTokenEnd)=\"add($event)\">\r\n    </mat-chip-list>\r\n    <mat-autocomplete #auto=\"matAutocomplete\" \r\n                      (optionSelected)=\"selected($event)\">\r\n        <mat-option *ngFor=\"let tag of filteredTags | async\"\r\n                    [value]=\"tag.name\">\r\n            {{tag.name}}\r\n        </mat-option>\r\n    </mat-autocomplete>\r\n</mat-form-field>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.html":
/*!***********************************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.html ***!
  \***********************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-accordion>\r\n    <mat-expansion-panel *ngFor=\"let mappedParameter of mappedParameters\">\r\n        <mat-expansion-panel-header>\r\n            <mat-panel-title>\r\n                <span [innerHtml]=\"mappedParameter.parameter.name | html\"></span>&nbsp;- {{mappedParameter.parameter.description}}\r\n            </mat-panel-title>\r\n        </mat-expansion-panel-header>\r\n\r\n        <mat-form-field class=\"m-2\"\r\n                        *ngIf=\"mappedParameter.parameter.groupName\">\r\n            <mat-label>{{'scriptsForm.Parameters.EditMode.GroupName.Header' | translate}}</mat-label>\r\n            <input matInput\r\n                   placeholder=\"{{'scriptsForm.Parameters.EditMode.GroupName.Header' | translate}}\"\r\n                   [(ngModel)]=\"mappedParameter.translation.groupName\"\r\n                   [errorStateMatcher]=\"matcher\"\r\n                   autocomplete=\"off\" />\r\n            <mat-hint>{{mappedParameter.parameter.groupName}}</mat-hint>\r\n            <!--<mat-error *ngIf=\"parameterGroupName && parameterGroupName.hasError('maxlength')\">\r\n                {{'scriptsForm.Parameters.EditMode.GroupName.MaxLengthError' | translate:parameterGroupName.errors.maxlength}}\r\n            </mat-error>-->\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2 full-width\">\r\n            <textarea matInput\r\n                      placeholder=\"{{'scriptsForm.Parameters.EditMode.Description.Header' | translate}}\"\r\n                       [(ngModel)]=\"mappedParameter.translation.description\"\r\n                      [errorStateMatcher]=\"matcher\"\r\n                      autocomplete=\"off\"></textarea>\r\n            <mat-hint>{{mappedParameter.parameter.description}}</mat-hint>\r\n            <!--<mat-error *ngIf=\"parameterDescription && parameterDescription.hasError('maxlength')\">\r\n                {{'scriptsForm.Parameters.EditMode.Description.MaxLengthError' | translate:parameterDescription.errors.maxlength}}\r\n            </mat-error>-->\r\n        </mat-form-field>\r\n\r\n        <mat-form-field class=\"m-2 full-width\"\r\n                        *ngIf=\"mappedParameter.parameter.notes\">\r\n            <textarea matInput\r\n                      placeholder=\"{{'scriptsForm.Parameters.EditMode.Note.Header' | translate}}\"\r\n                       [(ngModel)]=\"mappedParameter.translation.notes\"\r\n                      [errorStateMatcher]=\"matcher\"\r\n                      autocomplete=\"off\"></textarea>\r\n            <mat-hint>{{mappedParameter.parameter.notes}}</mat-hint>\r\n            <!--<mat-error *ngIf=\"parameterNotes && parameterNotes.hasError('maxlength')\">\r\n                {{'scriptsForm.Parameters.EditMode.Note.MaxLengthError' | translate:parameterNotes.errors.maxlength}}\r\n            </mat-error>-->\r\n        </mat-form-field>\r\n\r\n        <div *ngFor=\"let valueOption of mappedParameter.valueOptions\">\r\n\r\n            <mat-form-field class=\"m-2\"\r\n                            *ngIf=\"valueOption.origin.name\">\r\n                <mat-label>{{'scriptsForm.Parameters.ValueOptions.Name.Header' | translate}}</mat-label>\r\n                <input matInput\r\n                       placeholder=\"{{'scriptsForm.Parameters.ValueOptions.Name.Header' | translate}}\"\r\n                       [(ngModel)]=\"valueOption.translation.name\"\r\n                       [errorStateMatcher]=\"matcher\"\r\n                       autocomplete=\"off\" />\r\n                <mat-hint>{{valueOption.origin.name}}</mat-hint>\r\n            </mat-form-field>\r\n\r\n            <mat-form-field class=\"m-2\"\r\n                            *ngIf=\"valueOption.origin.description\">\r\n                <mat-label>{{'scriptsForm.Parameters.ValueOptions.Description.Header' | translate}}</mat-label>\r\n                <input matInput\r\n                       placeholder=\"{{'scriptsForm.Parameters.ValueOptions.Description.Header' | translate}}\"\r\n                       [(ngModel)]=\"valueOption.translation.description\"\r\n                       [errorStateMatcher]=\"matcher\"\r\n                       autocomplete=\"off\" />\r\n                <mat-hint>{{valueOption.origin.description}}</mat-hint>\r\n            </mat-form-field>\r\n\r\n        </div>\r\n\r\n    </mat-expansion-panel>\r\n\r\n</mat-accordion>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.html":
/*!*****************************************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.html ***!
  \*****************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [formGroup]=\"translationForm\">\r\n    <mat-form-field class=\"m-2\">\r\n        <mat-label>{{'app.Languages.Language' | translate}}</mat-label>\r\n        <mat-select matNativeControl\r\n                    formControlName=\"language\"\r\n                    required\r\n                    #languagesSelector\r\n                    (selectionChange)=\"onLanguageChange($event)\">\r\n            <mat-option [value]=\"languages.english\"\r\n                        *ngIf=\"defaultLanguage != languages.english\">\r\n                {{'app.Languages.English'| translate}}\r\n            </mat-option>\r\n            <mat-option [value]=\"languages.polish\"\r\n                        *ngIf=\"defaultLanguage != languages.polish\">\r\n                {{'app.Languages.Polish'| translate}}\r\n            </mat-option>\r\n            <mat-option [value]=\"languages.german\"\r\n                        *ngIf=\"defaultLanguage != languages.german\">\r\n                {{'app.Languages.German'| translate}}\r\n            </mat-option>\r\n        </mat-select>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 form-medium\">\r\n        <input matInput\r\n               required\r\n               placeholder=\"{{'scriptsForm.ScriptData.Name.Header' | translate}}\"\r\n               formControlName=\"name\"\r\n               [errorStateMatcher]=\"matcher\"\r\n               autocomplete=\"off\" />\r\n        <mat-hint>{{originalName.value}}</mat-hint>\r\n        <mat-error *ngIf=\"translationName && translationName.hasError('minlength') && !translationName.hasError('required')\">\r\n            {{'scriptsForm.ScriptData.Name.MinLengthError' | translate:scriptName.errors.minlength}}\r\n        </mat-error>\r\n        <mat-error *ngIf=\"translationName && translationName.hasError('maxlength') && !translationName.hasError('required')\">\r\n            {{'scriptsForm.ScriptData.Name.MaxLengthError' | translate:scriptName.errors.maxlength}}\r\n        </mat-error>\r\n        <mat-error *ngIf=\"translationName && translationName.hasError('required')\"\r\n                   [innerHtml]=\"'scriptsForm.ScriptData.Name.RequiredError' | translate\">\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 full-width\">\r\n        <textarea matInput\r\n                  placeholder=\"{{'scriptsForm.ScriptData.Description.Header' | translate}}\"\r\n                  formControlName=\"description\"\r\n                  required\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\"></textarea>\r\n        <mat-hint>{{originalDescription.value}}</mat-hint>\r\n        <mat-error *ngIf=\"translationDescription && translationDescription.hasError('minlength') && !translationDescription.hasError('required')\">\r\n            {{'scriptsForm.ScriptData.Description.MinLengthError' | translate:scriptDescription.errors.minlength}}\r\n        </mat-error>\r\n        <mat-error *ngIf=\"translationDescription && translationDescription.hasError('maxlength') && !translationDescription.hasError('required')\">\r\n            {{'scriptsForm.ScriptData.Description.MaxLengthError' | translate:scriptDescription.errors.maxlength}}\r\n        </mat-error>\r\n        <mat-error *ngIf=\"translationDescription && translationDescription.hasError('required')\"\r\n                   [innerHtml]=\"'scriptsForm.ScriptData.Description.RequiredError' | translate\">\r\n        </mat-error>\r\n    </mat-form-field>\r\n\r\n    <mat-form-field class=\"m-2 full-width\">\r\n        <textarea matInput\r\n                  placeholder=\"{{'scriptsForm.ScriptData.Note.Header' | translate}}\"\r\n                  formControlName=\"notes\"\r\n                  [errorStateMatcher]=\"matcher\"\r\n                  autocomplete=\"off\"></textarea>\r\n        <mat-hint>{{originalNotes.value}}</mat-hint>\r\n        <mat-error *ngIf=\"translationNotes && translationNotes.hasError('maxlength')\">\r\n            {{'scriptsForm.ScriptData.Note.MaxLengthError' | translate:scriptNotes.errors.maxlength}}\r\n        </mat-error>\r\n    </mat-form-field>\r\n</div>"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.html":
/*!**********************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.html ***!
  \**********************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [formGroup]=\"translationForm\">\r\n\r\n    <app-script-translation-form [scriptForm]=\"scriptForm\"\r\n                                 [defaultLanguage]=\"defaultLanguage\"\r\n                                 [translationForm]=\"translationForm\"\r\n                                 [translationData]=\"translationData\"></app-script-translation-form>\r\n    <app-parameter-translation-form [scriptForm]=\"scriptForm\"\r\n                                    [defaultLanguage]=\"defaultLanguage\"\r\n                                    [translationForm]=\"translationForm\"\r\n                                    [translationData]=\"translationData\"\r\n                                    #parameterTranslationForm></app-parameter-translation-form>\r\n\r\n    <div class=\"flex-column\">\r\n        <button mat-stroked-button\r\n                color=\"accent\"\r\n                type=\"button\"\r\n                (click)=\"onScriptTranslationSubmit()\"\r\n                [disabled]=\"!translationForm.valid\"\r\n                class=\"mt-3 ml-3\">\r\n            {{translationData.editMode ? ('scriptsForm.Translations.Update' | translate) : ('scriptsForm.Translations.Add' | translate)}}\r\n        </button>\r\n\r\n        <button mat-stroked-button\r\n                color=\"warn\"\r\n                type=\"button\"\r\n                *ngIf=\"translationData.editMode\"\r\n                (click)=\"removeScriptTranslation()\"\r\n                class=\"mt-3 ml-3\">\r\n            {{'scriptsForm.Translations.Remove' | translate}}\r\n        </button>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
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
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_home_home_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/home/home.component */ "./src/app/components/home/home.component.ts");
/* harmony import */ var _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/about-me/about-me.component */ "./src/app/components/about-me/about-me.component.ts");
/* harmony import */ var _components_login_login_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./components/login/login.component */ "./src/app/components/login/login.component.ts");
/* harmony import */ var _components_register_register_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/register/register.component */ "./src/app/components/register/register.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var routes = [
    { path: 'home', component: _components_home_home_component__WEBPACK_IMPORTED_MODULE_2__["HomeComponent"] },
    { path: 'about', component: _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_3__["AboutMeComponent"] },
    { path: 'login', component: _components_login_login_component__WEBPACK_IMPORTED_MODULE_4__["LoginComponent"] },
    { path: 'register', component: _components_register_register_component__WEBPACK_IMPORTED_MODULE_5__["RegisterComponent"] },
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

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
            template: __webpack_require__(/*! raw-loader!./app.component.html */ "./node_modules/raw-loader/index.js!./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule, getBaseUrl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getBaseUrl", function() { return getBaseUrl; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _ngx_translate_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @ngx-translate/core */ "./node_modules/@ngx-translate/core/fesm5/ngx-translate-core.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _components_nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/nav-menu/nav-menu.component */ "./src/app/components/nav-menu/nav-menu.component.ts");
/* harmony import */ var _components_home_home_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./components/home/home.component */ "./src/app/components/home/home.component.ts");
/* harmony import */ var _components_carousel_carousel_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./components/carousel/carousel.component */ "./src/app/components/carousel/carousel.component.ts");
/* harmony import */ var _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./components/about-me/about-me.component */ "./src/app/components/about-me/about-me.component.ts");
/* harmony import */ var _components_login_login_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./components/login/login.component */ "./src/app/components/login/login.component.ts");
/* harmony import */ var _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./common/errors/app-error-handler */ "./src/app/common/errors/app-error-handler.ts");
/* harmony import */ var _modules_loads_loads_routing_module__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./modules/loads/loads-routing.module */ "./src/app/modules/loads/loads-routing.module.ts");
/* harmony import */ var _modules_loads_loads_module__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./modules/loads/loads.module */ "./src/app/modules/loads/loads.module.ts");
/* harmony import */ var _modules_script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./modules/script-interpreter/script-interpreter.module */ "./src/app/modules/script-interpreter/script-interpreter.module.ts");
/* harmony import */ var _modules_script_interpreter_script_interpreter_routing_module__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./modules/script-interpreter/script-interpreter-routing.module */ "./src/app/modules/script-interpreter/script-interpreter-routing.module.ts");
/* harmony import */ var _modules_custom_views_module_components_custom_views_module__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./modules/custom-views-module/components/custom-views.module */ "./src/app/modules/custom-views-module/components/custom-views.module.ts");
/* harmony import */ var _modules_custom_views_module_components_custom_views_routing_module__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./modules/custom-views-module/components/custom-views-routing.module */ "./src/app/modules/custom-views-module/components/custom-views-routing.module.ts");
/* harmony import */ var _modules_md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./modules/md-components-module/md-components.module */ "./src/app/modules/md-components-module/md-components.module.ts");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./services/translation.service */ "./src/app/services/translation.service.ts");
/* harmony import */ var _directives_element_select_directive__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./directives/element-select.directive */ "./src/app/directives/element-select.directive.ts");
/* harmony import */ var _services_local_store_manager_service__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./services/local-store-manager.service */ "./src/app/services/local-store-manager.service.ts");
/* harmony import */ var _services_configuration_service__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./services/configuration.service */ "./src/app/services/configuration.service.ts");
/* harmony import */ var _services_search_service__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./services/search.service */ "./src/app/services/search.service.ts");
/* harmony import */ var _services_auth_service__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./services/auth.service */ "./src/app/services/auth.service.ts");
/* harmony import */ var _services_auth_interceptor__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./services/auth.interceptor */ "./src/app/services/auth.interceptor.ts");
/* harmony import */ var _services_auth_response_interceptor__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! ./services/auth.response.interceptor */ "./src/app/services/auth.response.interceptor.ts");
/* harmony import */ var _components_register_register_component__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! ./components/register/register.component */ "./src/app/components/register/register.component.ts");
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
                _app_component__WEBPACK_IMPORTED_MODULE_7__["AppComponent"],
                _components_nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_8__["NavMenuComponent"],
                _components_home_home_component__WEBPACK_IMPORTED_MODULE_9__["HomeComponent"],
                _components_carousel_carousel_component__WEBPACK_IMPORTED_MODULE_10__["CarouselComponent"],
                _components_about_me_about_me_component__WEBPACK_IMPORTED_MODULE_11__["AboutMeComponent"],
                _directives_element_select_directive__WEBPACK_IMPORTED_MODULE_22__["ElementSelectDirective"],
                _components_login_login_component__WEBPACK_IMPORTED_MODULE_12__["LoginComponent"],
                _components_register_register_component__WEBPACK_IMPORTED_MODULE_29__["RegisterComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"].withServerTransition({ appId: 'ng-cli-universal' }),
                _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                _modules_custom_views_module_components_custom_views_module__WEBPACK_IMPORTED_MODULE_18__["CustomViewsModule"],
                _modules_custom_views_module_components_custom_views_routing_module__WEBPACK_IMPORTED_MODULE_19__["CustomViewsRoutingModule"],
                _modules_script_interpreter_script_interpreter_routing_module__WEBPACK_IMPORTED_MODULE_17__["ScriptInterpreterRoutingModule"],
                _modules_loads_loads_routing_module__WEBPACK_IMPORTED_MODULE_14__["LoadsRoutingModule"],
                _app_routing_module__WEBPACK_IMPORTED_MODULE_6__["AppRoutingModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__["BrowserAnimationsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
                _modules_script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_16__["ScriptInterpreterModule"],
                _modules_loads_loads_module__WEBPACK_IMPORTED_MODULE_15__["LoadsModule"],
                _modules_md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_20__["MdComponentsModule"],
                _ngx_translate_core__WEBPACK_IMPORTED_MODULE_5__["TranslateModule"].forRoot({
                    loader: {
                        provide: _ngx_translate_core__WEBPACK_IMPORTED_MODULE_5__["TranslateLoader"],
                        useClass: _services_translation_service__WEBPACK_IMPORTED_MODULE_21__["TranslateLanguageLoader"]
                    }
                })
            ],
            providers: [
                { provide: _angular_core__WEBPACK_IMPORTED_MODULE_1__["ErrorHandler"], useClass: _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_13__["AppErrorHandler"] },
                { provide: 'BASE_URL', useFactory: getBaseUrl },
                _services_auth_service__WEBPACK_IMPORTED_MODULE_26__["AuthService"],
                {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HTTP_INTERCEPTORS"],
                    useClass: _services_auth_interceptor__WEBPACK_IMPORTED_MODULE_27__["AuthInterceptor"],
                    multi: true
                },
                {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HTTP_INTERCEPTORS"],
                    useClass: _services_auth_response_interceptor__WEBPACK_IMPORTED_MODULE_28__["AuthResponseInterceptor"],
                    multi: true
                },
                _services_translation_service__WEBPACK_IMPORTED_MODULE_21__["TranslationService"],
                _services_local_store_manager_service__WEBPACK_IMPORTED_MODULE_23__["LocalStoreManager"],
                _services_configuration_service__WEBPACK_IMPORTED_MODULE_24__["ConfigurationService"],
                _services_search_service__WEBPACK_IMPORTED_MODULE_25__["SearchService"]
            ],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_7__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());

function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}


/***/ }),

/***/ "./src/app/common/errors/app-error-handler.ts":
/*!****************************************************!*\
  !*** ./src/app/common/errors/app-error-handler.ts ***!
  \****************************************************/
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

/***/ "./src/app/common/errors/app-error-state-matcher.ts":
/*!**********************************************************!*\
  !*** ./src/app/common/errors/app-error-state-matcher.ts ***!
  \**********************************************************/
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

/***/ "./src/app/common/errors/app-error.ts":
/*!********************************************!*\
  !*** ./src/app/common/errors/app-error.ts ***!
  \********************************************/
/*! exports provided: AppError */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppError", function() { return AppError; });
var AppError = /** @class */ (function () {
    function AppError(originalError) {
        this.originalError = originalError;
    }
    AppError.ctorParameters = function () { return [
        { type: undefined }
    ]; };
    return AppError;
}());



/***/ }),

/***/ "./src/app/common/errors/bad-input-error.ts":
/*!**************************************************!*\
  !*** ./src/app/common/errors/bad-input-error.ts ***!
  \**************************************************/
/*! exports provided: BadInputError */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BadInputError", function() { return BadInputError; });
/* harmony import */ var _app_error__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-error */ "./src/app/common/errors/app-error.ts");
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
    BadInputError.ctorParameters = function () { return [
        { type: undefined }
    ]; };
    return BadInputError;
}(_app_error__WEBPACK_IMPORTED_MODULE_0__["AppError"]));



/***/ }),

/***/ "./src/app/common/errors/not-found-error.ts":
/*!**************************************************!*\
  !*** ./src/app/common/errors/not-found-error.ts ***!
  \**************************************************/
/*! exports provided: NotFoundError */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NotFoundError", function() { return NotFoundError; });
/* harmony import */ var _app_error__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-error */ "./src/app/common/errors/app-error.ts");
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
    NotFoundError.ctorParameters = function () { return [
        { type: undefined }
    ]; };
    return NotFoundError;
}(_app_error__WEBPACK_IMPORTED_MODULE_0__["AppError"]));



/***/ }),

/***/ "./src/app/components/about-me/about-me.component.scss":
/*!*************************************************************!*\
  !*** ./src/app/components/about-me/about-me.component.scss ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".carousel-caption {\n  background-color: #45454590;\n  padding: 1em;\n  padding-bottom: 1.5em;\n  border-radius: 30px; }\n\nimg {\n  box-shadow: 10px 5px 5px black;\n  border: 1px solid black;\n  margin-bottom: 5px; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9hYm91dC1tZS9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcY29tcG9uZW50c1xcYWJvdXQtbWVcXGFib3V0LW1lLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUNBO0VBQ0ksMkJBQTJCO0VBQzNCLFlBQVk7RUFDWixxQkFBcUI7RUFDckIsbUJBQW1CLEVBQUE7O0FBR3ZCO0VBQ0ksOEJBQThCO0VBQzlCLHVCQUF1QjtFQUN2QixrQkFBaUIsRUFBQSIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvYWJvdXQtbWUvYWJvdXQtbWUuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJcclxuLmNhcm91c2VsLWNhcHRpb24ge1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogIzQ1NDU0NTkwO1xyXG4gICAgcGFkZGluZzogMWVtO1xyXG4gICAgcGFkZGluZy1ib3R0b206IDEuNWVtO1xyXG4gICAgYm9yZGVyLXJhZGl1czogMzBweDtcclxufVxyXG5cclxuaW1nIHtcclxuICAgIGJveC1zaGFkb3c6IDEwcHggNXB4IDVweCBibGFjaztcclxuICAgIGJvcmRlcjogMXB4IHNvbGlkIGJsYWNrO1xyXG4gICAgbWFyZ2luLWJvdHRvbTo1cHg7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/components/about-me/about-me.component.ts":
/*!***********************************************************!*\
  !*** ./src/app/components/about-me/about-me.component.ts ***!
  \***********************************************************/
/*! exports provided: AboutMeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AboutMeComponent", function() { return AboutMeComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
            template: __webpack_require__(/*! raw-loader!./about-me.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/about-me/about-me.component.html"),
            styles: [__webpack_require__(/*! ./about-me.component.scss */ "./src/app/components/about-me/about-me.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], AboutMeComponent);
    return AboutMeComponent;
}());



/***/ }),

/***/ "./src/app/components/carousel/carousel.component.scss":
/*!*************************************************************!*\
  !*** ./src/app/components/carousel/carousel.component.scss ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".carousel-caption {\n  background-color: #45454590;\n  padding: 1em;\n  padding-bottom: 1.5em;\n  border-radius: 30px; }\n\nimg {\n  box-shadow: 10px 5px 5px black;\n  border: 1px solid black;\n  margin-bottom: 5px; }\n\n.link {\n  cursor: pointer; }\n\n.link:hover > img {\n  box-shadow: 10px 5px 5px gray;\n  border: 1px solid gray; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9jYXJvdXNlbC9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcY29tcG9uZW50c1xcY2Fyb3VzZWxcXGNhcm91c2VsLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUNBO0VBQ0ksMkJBQTJCO0VBQzNCLFlBQVk7RUFDWixxQkFBcUI7RUFDckIsbUJBQW1CLEVBQUE7O0FBR3ZCO0VBQ0ksOEJBQThCO0VBQzlCLHVCQUF1QjtFQUN2QixrQkFBa0IsRUFBQTs7QUFHdEI7RUFDSSxlQUFlLEVBQUE7O0FBR2Y7RUFDSSw2QkFBNkI7RUFDN0Isc0JBQXNCLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9jb21wb25lbnRzL2Nhcm91c2VsL2Nhcm91c2VsLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiXHJcbi5jYXJvdXNlbC1jYXB0aW9uIHtcclxuICAgIGJhY2tncm91bmQtY29sb3I6ICM0NTQ1NDU5MDtcclxuICAgIHBhZGRpbmc6IDFlbTtcclxuICAgIHBhZGRpbmctYm90dG9tOiAxLjVlbTtcclxuICAgIGJvcmRlci1yYWRpdXM6IDMwcHg7XHJcbn1cclxuXHJcbmltZyB7XHJcbiAgICBib3gtc2hhZG93OiAxMHB4IDVweCA1cHggYmxhY2s7XHJcbiAgICBib3JkZXI6IDFweCBzb2xpZCBibGFjaztcclxuICAgIG1hcmdpbi1ib3R0b206IDVweDtcclxufVxyXG5cclxuLmxpbmsge1xyXG4gICAgY3Vyc29yOiBwb2ludGVyO1xyXG59XHJcblxyXG4gICAgLmxpbms6aG92ZXIgPiBpbWcge1xyXG4gICAgICAgIGJveC1zaGFkb3c6IDEwcHggNXB4IDVweCBncmF5O1xyXG4gICAgICAgIGJvcmRlcjogMXB4IHNvbGlkIGdyYXk7XHJcbiAgICB9XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/components/carousel/carousel.component.ts":
/*!***********************************************************!*\
  !*** ./src/app/components/carousel/carousel.component.ts ***!
  \***********************************************************/
/*! exports provided: CarouselComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CarouselComponent", function() { return CarouselComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
            template: __webpack_require__(/*! raw-loader!./carousel.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/carousel/carousel.component.html"),
            styles: [__webpack_require__(/*! ./carousel.component.scss */ "./src/app/components/carousel/carousel.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], CarouselComponent);
    return CarouselComponent;
}());



/***/ }),

/***/ "./src/app/components/home/home.component.scss":
/*!*****************************************************!*\
  !*** ./src/app/components/home/home.component.scss ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvaG9tZS9ob21lLmNvbXBvbmVudC5zY3NzIn0= */"

/***/ }),

/***/ "./src/app/components/home/home.component.ts":
/*!***************************************************!*\
  !*** ./src/app/components/home/home.component.ts ***!
  \***************************************************/
/*! exports provided: HomeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeComponent", function() { return HomeComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
            template: __webpack_require__(/*! raw-loader!./home.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/home/home.component.html"),
            styles: [__webpack_require__(/*! ./home.component.scss */ "./src/app/components/home/home.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], HomeComponent);
    return HomeComponent;
}());



/***/ }),

/***/ "./src/app/components/login/login.component.scss":
/*!*******************************************************!*\
  !*** ./src/app/components/login/login.component.scss ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".login-container {\n  margin: auto;\n  width: 90%;\n  padding: 10px; }\n\n.form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9sb2dpbi9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcY29tcG9uZW50c1xcbG9naW5cXGxvZ2luLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksWUFBWTtFQUNaLFVBQVU7RUFDVixhQUFhLEVBQUE7O0FBR2pCO0VBQ0ksZ0JBQWdCO0VBQ2hCLGdCQUFnQjtFQUNoQixXQUFXLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9jb21wb25lbnRzL2xvZ2luL2xvZ2luLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmxvZ2luLWNvbnRhaW5lciB7XHJcbiAgICBtYXJnaW46IGF1dG87XHJcbiAgICB3aWR0aDogOTAlO1xyXG4gICAgcGFkZGluZzogMTBweDtcclxufVxyXG5cclxuLmZvcm0tbWVkaXVtIHtcclxuICAgIG1pbi13aWR0aDogMTUwcHg7XHJcbiAgICBtYXgtd2lkdGg6IDM0MHB4O1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/components/login/login.component.ts":
/*!*****************************************************!*\
  !*** ./src/app/components/login/login.component.ts ***!
  \*****************************************************/
/*! exports provided: LoginComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoginComponent", function() { return LoginComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_auth_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/auth.service */ "./src/app/services/auth.service.ts");
/* harmony import */ var _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/bottom-sheet */ "./node_modules/@angular/material/esm5/bottom-sheet.es5.js");
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





var LoginComponent = /** @class */ (function () {
    function LoginComponent(router, fb, authService, bottomSheetRef, baseUrl) {
        this.router = router;
        this.fb = fb;
        this.authService = authService;
        this.bottomSheetRef = bottomSheetRef;
        this.baseUrl = baseUrl;
        this.createForm();
    }
    Object.defineProperty(LoginComponent.prototype, "username", {
        get: function () {
            return this.form.get('Username');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(LoginComponent.prototype, "password", {
        get: function () {
            return this.form.get('Password');
        },
        enumerable: true,
        configurable: true
    });
    LoginComponent.prototype.createForm = function () {
        this.form = this.fb.group({
            Username: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required],
            Password: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]
        });
    };
    LoginComponent.prototype.onSubmit = function () {
        var _this = this;
        var url = this.baseUrl + "api/token/auth";
        var username = this.form.value.Username;
        var password = this.form.value.Password;
        this.authService.login(username, password)
            .subscribe(function (res) {
            // Logowanie udane
            // Wyświetl dane logowania w okienku alert.
            // WAŻNE: usuń po zakończeniu testu
            alert("Logowanie udane! "
                + "NAZWA UŻYTKOWNIKA: "
                + username
                + " TOKEN: "
                + _this.authService.getAuth().token);
            _this.bottomSheetRef.dismiss();
            _this.router.navigate(["home"]);
        }, function (err) {
            // Logowanie nieudane
            console.log(err);
            _this.form.setErrors({
                "auth": "Niepoprawna nazwa użytkownika lub hasło."
            });
        });
    };
    LoginComponent.prototype.dismiss = function () {
        this.bottomSheetRef.dismiss();
    };
    LoginComponent.prototype.onBack = function () {
        this.bottomSheetRef.dismiss();
        this.router.navigate(["home"]);
    };
    LoginComponent.prototype.getFormControl = function (name) {
        return this.form.get(name);
    };
    LoginComponent.prototype.isValid = function (name) {
        var e = this.getFormControl(name);
        return e && e.valid;
    };
    LoginComponent.prototype.isChanged = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched);
    };
    LoginComponent.prototype.hasError = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    };
    LoginComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"] },
        { type: _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"] },
        { type: _services_auth_service__WEBPACK_IMPORTED_MODULE_3__["AuthService"] },
        { type: _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_4__["MatBottomSheetRef"] },
        { type: String, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"], args: ['BASE_URL',] }] }
    ]; };
    LoginComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-login',
            template: __webpack_require__(/*! raw-loader!./login.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/login/login.component.html"),
            styles: [__webpack_require__(/*! ./login.component.scss */ "./src/app/components/login/login.component.scss")]
        }),
        __param(4, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])('BASE_URL')),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"],
            _services_auth_service__WEBPACK_IMPORTED_MODULE_3__["AuthService"],
            _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_4__["MatBottomSheetRef"], String])
    ], LoginComponent);
    return LoginComponent;
}());



/***/ }),

/***/ "./src/app/components/nav-menu/nav-menu.component.css":
/*!************************************************************!*\
  !*** ./src/app/components/nav-menu/nav-menu.component.css ***!
  \************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".smaller{\r\n    width: 100px;\r\n}\r\n\r\nli.nav-item{\r\n    cursor: pointer;\r\n}\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9uYXYtbWVudS9uYXYtbWVudS5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0lBQ0ksWUFBWTtBQUNoQjs7QUFFQTtJQUNJLGVBQWU7QUFDbkIiLCJmaWxlIjoic3JjL2FwcC9jb21wb25lbnRzL25hdi1tZW51L25hdi1tZW51LmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuc21hbGxlcntcclxuICAgIHdpZHRoOiAxMDBweDtcclxufVxyXG5cclxubGkubmF2LWl0ZW17XHJcbiAgICBjdXJzb3I6IHBvaW50ZXI7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/components/nav-menu/nav-menu.component.ts":
/*!***********************************************************!*\
  !*** ./src/app/components/nav-menu/nav-menu.component.ts ***!
  \***********************************************************/
/*! exports provided: NavMenuComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavMenuComponent", function() { return NavMenuComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../services/translation.service */ "./src/app/services/translation.service.ts");
/* harmony import */ var _directives_element_select_directive__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../directives/element-select.directive */ "./src/app/directives/element-select.directive.ts");
/* harmony import */ var _services_configuration_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/configuration.service */ "./src/app/services/configuration.service.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _services_search_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../services/search.service */ "./src/app/services/search.service.ts");
/* harmony import */ var _services_auth_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../services/auth.service */ "./src/app/services/auth.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/material/bottom-sheet */ "./node_modules/@angular/material/esm5/bottom-sheet.es5.js");
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../login/login.component */ "./src/app/components/login/login.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};










var NavMenuComponent = /** @class */ (function () {
    function NavMenuComponent(translationService, auth, configurations, searchService, router, bottomSheet) {
        this.translationService = translationService;
        this.auth = auth;
        this.configurations = configurations;
        this.searchService = searchService;
        this.router = router;
        this.bottomSheet = bottomSheet;
        this.searchForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__["FormGroup"]({
            search: new _angular_forms__WEBPACK_IMPORTED_MODULE_4__["FormControl"]('')
        });
    }
    Object.defineProperty(NavMenuComponent.prototype, "searchValue", {
        get: function () {
            return this.searchForm.get('search');
        },
        enumerable: true,
        configurable: true
    });
    NavMenuComponent.prototype.logout = function () {
        if (this.auth.logout())
            this.router.navigate([""]);
        return false;
    };
    NavMenuComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.languageChangedSubscription = this.translationService.languageChanged$.subscribe(function (data) {
            setTimeout(function () {
                _this.languageSelector.refresh();
            });
        });
    };
    NavMenuComponent.prototype.ngOnDestroy = function () {
        this.languageChangedSubscription.unsubscribe();
    };
    NavMenuComponent.prototype.onSearch = function () {
        this.searchService.search(this.searchValue.value);
    };
    NavMenuComponent.prototype.openLoginSheet = function () {
        this.bottomSheet.open(_login_login_component__WEBPACK_IMPORTED_MODULE_9__["LoginComponent"]);
    };
    NavMenuComponent.ctorParameters = function () { return [
        { type: _services_translation_service__WEBPACK_IMPORTED_MODULE_1__["TranslationService"] },
        { type: _services_auth_service__WEBPACK_IMPORTED_MODULE_6__["AuthService"] },
        { type: _services_configuration_service__WEBPACK_IMPORTED_MODULE_3__["ConfigurationService"] },
        { type: _services_search_service__WEBPACK_IMPORTED_MODULE_5__["SearchService"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__["Router"] },
        { type: _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_8__["MatBottomSheet"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('languageSelector', null),
        __metadata("design:type", _directives_element_select_directive__WEBPACK_IMPORTED_MODULE_2__["ElementSelectDirective"])
    ], NavMenuComponent.prototype, "languageSelector", void 0);
    NavMenuComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-nav-menu',
            template: __webpack_require__(/*! raw-loader!./nav-menu.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/nav-menu/nav-menu.component.html"),
            styles: [__webpack_require__(/*! ./nav-menu.component.css */ "./src/app/components/nav-menu/nav-menu.component.css")]
        }),
        __metadata("design:paramtypes", [_services_translation_service__WEBPACK_IMPORTED_MODULE_1__["TranslationService"],
            _services_auth_service__WEBPACK_IMPORTED_MODULE_6__["AuthService"],
            _services_configuration_service__WEBPACK_IMPORTED_MODULE_3__["ConfigurationService"],
            _services_search_service__WEBPACK_IMPORTED_MODULE_5__["SearchService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_7__["Router"],
            _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_8__["MatBottomSheet"]])
    ], NavMenuComponent);
    return NavMenuComponent;
}());



/***/ }),

/***/ "./src/app/components/register/register.component.scss":
/*!*************************************************************!*\
  !*** ./src/app/components/register/register.component.scss ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvcmVnaXN0ZXIvcmVnaXN0ZXIuY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./src/app/components/register/register.component.ts":
/*!***********************************************************!*\
  !*** ./src/app/components/register/register.component.ts ***!
  \***********************************************************/
/*! exports provided: RegisterComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RegisterComponent", function() { return RegisterComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
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




var RegisterComponent = /** @class */ (function () {
    function RegisterComponent(router, fb, http, baseUrl) {
        this.router = router;
        this.fb = fb;
        this.http = http;
        this.baseUrl = baseUrl;
        // Inicjalizacja formularza
        this.createForm();
    }
    RegisterComponent.prototype.createForm = function () {
        this.form = this.fb.group({
            Username: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required],
            Email: ['',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required,
                    _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].email]
            ],
            Password: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required],
            PasswordConfirm: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required],
            DisplayName: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]
        }, {
            validator: this.passwordConfirmValidator
        });
    };
    RegisterComponent.prototype.onSubmit = function () {
        var _this = this;
        // Zbuduj tymczasowy obiekt z wartości z formularza
        var tempUser = {};
        tempUser.Username = this.form.value.Username;
        tempUser.Email = this.form.value.Email;
        tempUser.Password = this.form.value.Password;
        tempUser.DisplayName = this.form.value.DisplayName;
        var url = this.baseUrl + "api/users";
        this.http
            .put(url, tempUser)
            .subscribe(function (res) {
            if (res) {
                var v = res;
                console.log("Użytkownik " + v.Username + " został utworzony.");
                // Przejdź do strony logowania
                _this.router.navigate(["login"]);
            }
            else {
                // Rejestracja nieudana
                _this.form.setErrors({
                    "register": "Rejestracja nie powiodła się."
                });
            }
        }, function (error) { return console.log(error); });
    };
    RegisterComponent.prototype.onBack = function () {
        this.router.navigate(["home"]);
    };
    // Własny walidator porównujący wartości
    // Password i passwordConfirm
    RegisterComponent.prototype.passwordConfirmValidator = function (control) {
        // Pobierz obie kontrolki Controls
        var p = control.root.get('Password');
        var pc = control.root.get('PasswordConfirm');
        if (p && pc) {
            if (p.value !== pc.value) {
                pc.setErrors({ "PasswordMismatch": true });
            }
            else {
                pc.setErrors(null);
            }
        }
        return null;
    };
    // Pobierz FormControl
    RegisterComponent.prototype.getFormControl = function (name) {
        return this.form.get(name);
    };
    // Zwróć TRUE, jeśli element FormControl jest poprawny
    RegisterComponent.prototype.isValid = function (name) {
        var e = this.getFormControl(name);
        return e && e.valid;
    };
    // Zwróć TRUE, jeśli element FormControl uległ zmianie
    RegisterComponent.prototype.isChanged = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched);
    };
    // Zwróć TRUE, jeśli element FormControl nie jest poprawny po wprowadzeniu zmian
    RegisterComponent.prototype.hasError = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    };
    RegisterComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"] },
        { type: _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"] },
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClient"] },
        { type: String, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"], args: ['BASE_URL',] }] }
    ]; };
    RegisterComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-register',
            template: __webpack_require__(/*! raw-loader!./register.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/register/register.component.html"),
            styles: [__webpack_require__(/*! ./register.component.scss */ "./src/app/components/register/register.component.scss")]
        }),
        __param(3, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])('BASE_URL')),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClient"], String])
    ], RegisterComponent);
    return RegisterComponent;
}());



/***/ }),

/***/ "./src/app/directives/element-select.directive.ts":
/*!********************************************************!*\
  !*** ./src/app/directives/element-select.directive.ts ***!
  \********************************************************/
/*! exports provided: ElementSelectDirective */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ElementSelectDirective", function() { return ElementSelectDirective; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ElementSelectDirective = /** @class */ (function () {
    function ElementSelectDirective(el) {
        var _this = this;
        this.el = el;
        this.oldValues = '';
        this.ngModelChange = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.shown = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.hidden = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.changedSubscription = Object(rxjs__WEBPACK_IMPORTED_MODULE_1__["fromEvent"])($(this.el.nativeElement), 'changed.bs.select').subscribe(function (e) { return setTimeout(function () {
            if (_this.checkIsValuesChanged(_this.selected)) {
                _this.ngModelChange.emit(_this.selected);
            }
        }); });
        this.shownSubscription = Object(rxjs__WEBPACK_IMPORTED_MODULE_1__["fromEvent"])($(this.el.nativeElement), 'shown.bs.select').subscribe(function (e) { return setTimeout(function () { return _this.shown.emit(); }); });
        this.hiddenSubscription = Object(rxjs__WEBPACK_IMPORTED_MODULE_1__["fromEvent"])($(this.el.nativeElement), 'hidden.bs.select').subscribe(function (e) { return setTimeout(function () { return _this.hidden.emit(); }); });
    }
    Object.defineProperty(ElementSelectDirective.prototype, "ngModel", {
        set: function (values) {
            var _this = this;
            setTimeout(function () { return _this.selected = values; });
        },
        enumerable: true,
        configurable: true
    });
    ElementSelectDirective.prototype.ngOnInit = function () {
        //$(this.el.nativeElement).selectpicker();
        var _this = this;
        if (this.requiredAttribute) {
            $(this.el.nativeElement).selectpicker('setStyle', 'required', 'add');
        }
        setTimeout(function () {
            _this.refresh();
            _this.doValidation();
        });
    };
    ElementSelectDirective.prototype.ngOnDestroy = function () {
        if (this.changedSubscription) {
            this.changedSubscription.unsubscribe();
        }
        if (this.shownSubscription) {
            this.shownSubscription.unsubscribe();
        }
        if (this.hiddenSubscription) {
            this.hiddenSubscription.unsubscribe();
        }
        $(this.el.nativeElement).selectpicker('destroy');
    };
    ElementSelectDirective.prototype.checkIsValuesChanged = function (newValue) {
        var _this = this;
        return !(newValue == this.oldValues ||
            (newValue instanceof Array && newValue.length === this.oldValues.length && newValue.every(function (v, i) { return v === _this.oldValues[i]; })));
    };
    ElementSelectDirective.prototype.doValidation = function () {
        //if (this.requiredAttribute) {
        //    $(this.el.nativeElement).selectpicker('setStyle', !this.valid ? 'ng-valid' : 'ng-invalid', 'remove');
        //    $(this.el.nativeElement).selectpicker('setStyle', this.valid ? 'ng-valid' : 'ng-invalid', 'add');
        //}
    };
    Object.defineProperty(ElementSelectDirective.prototype, "requiredAttribute", {
        get: function () {
            return this.required === '' || this.required == 'true';
        },
        enumerable: true,
        configurable: true
    });
    ElementSelectDirective.prototype.refresh = function () {
        //setTimeout(() => {
        //    $(this.el.nativeElement).selectpicker('refresh');
        //});
    };
    ElementSelectDirective.prototype.render = function () {
        //setTimeout(() => {
        //    $(this.el.nativeElement).selectpicker('render');
        //});
    };
    Object.defineProperty(ElementSelectDirective.prototype, "valid", {
        get: function () {
            return this.requiredAttribute ? this.selected && this.selected.length > 0 : true;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ElementSelectDirective.prototype, "selected", {
        get: function () {
            //return $(this.el.nativeElement).selectpicker('val');
            return '';
        },
        set: function (values) {
            if (!this.checkIsValuesChanged(values)) {
                return;
            }
            this.oldValues = this.selected;
            //$(this.el.nativeElement).selectpicker('val', values);
            this.doValidation();
        },
        enumerable: true,
        configurable: true
    });
    ElementSelectDirective.ctorParameters = function () { return [
        { type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["ElementRef"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", String)
    ], ElementSelectDirective.prototype, "required", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object),
        __metadata("design:paramtypes", [Object])
    ], ElementSelectDirective.prototype, "ngModel", null);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ElementSelectDirective.prototype, "ngModelChange", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ElementSelectDirective.prototype, "shown", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ElementSelectDirective.prototype, "hidden", void 0);
    ElementSelectDirective = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Directive"])({
            selector: '[elementSelect]',
            exportAs: 'element-select'
        }),
        __metadata("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ElementRef"]])
    ], ElementSelectDirective);
    return ElementSelectDirective;
}());



/***/ }),

/***/ "./src/app/modules/custom-views-module/components/custom-views-routing.module.ts":
/*!***************************************************************************************!*\
  !*** ./src/app/modules/custom-views-module/components/custom-views-routing.module.ts ***!
  \***************************************************************************************/
/*! exports provided: CustomViewsRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomViewsRoutingModule", function() { return CustomViewsRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _snow_load_monopitch_roof_snow_load_monopitch_roof_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./snow-load-monopitch-roof/snow-load-monopitch-roof.component */ "./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: 'scripts/custom/10/1', component: _snow_load_monopitch_roof_snow_load_monopitch_roof_component__WEBPACK_IMPORTED_MODULE_2__["SnowLoadMonopitchRoofComponent"] }
];
var CustomViewsRoutingModule = /** @class */ (function () {
    function CustomViewsRoutingModule() {
    }
    CustomViewsRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]],
        })
    ], CustomViewsRoutingModule);
    return CustomViewsRoutingModule;
}());



/***/ }),

/***/ "./src/app/modules/custom-views-module/components/custom-views.module.ts":
/*!*******************************************************************************!*\
  !*** ./src/app/modules/custom-views-module/components/custom-views.module.ts ***!
  \*******************************************************************************/
/*! exports provided: CustomViewsModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomViewsModule", function() { return CustomViewsModule; });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _ngx_translate_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @ngx-translate/core */ "./node_modules/@ngx-translate/core/fesm5/ngx-translate-core.js");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../services/translation.service */ "./src/app/services/translation.service.ts");
/* harmony import */ var _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../md-components-module/md-components.module */ "./src/app/modules/md-components-module/md-components.module.ts");
/* harmony import */ var _pipes_module_pipes_module__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../pipes-module/pipes.module */ "./src/app/modules/pipes-module/pipes.module.ts");
/* harmony import */ var _script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../../script-interpreter/script-interpreter.module */ "./src/app/modules/script-interpreter/script-interpreter.module.ts");
/* harmony import */ var _snow_load_monopitch_roof_snow_load_monopitch_roof_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./snow-load-monopitch-roof/snow-load-monopitch-roof.component */ "./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.ts");
/* harmony import */ var _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ../../../common/errors/app-error-handler */ "./src/app/common/errors/app-error-handler.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};













var CustomViewsModule = /** @class */ (function () {
    function CustomViewsModule() {
    }
    CustomViewsModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
            declarations: [
                _snow_load_monopitch_roof_snow_load_monopitch_roof_component__WEBPACK_IMPORTED_MODULE_11__["SnowLoadMonopitchRoofComponent"]
            ],
            imports: [
                _pipes_module_pipes_module__WEBPACK_IMPORTED_MODULE_9__["PipesModule"],
                _angular_common__WEBPACK_IMPORTED_MODULE_0__["CommonModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_5__["RouterModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
                _script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_10__["ScriptInterpreterModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__["BrowserAnimationsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["ReactiveFormsModule"],
                _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_8__["MdComponentsModule"],
                _ngx_translate_core__WEBPACK_IMPORTED_MODULE_6__["TranslateModule"].forRoot({
                    loader: {
                        provide: _ngx_translate_core__WEBPACK_IMPORTED_MODULE_6__["TranslateLoader"],
                        useClass: _services_translation_service__WEBPACK_IMPORTED_MODULE_7__["TranslateLanguageLoader"]
                    }
                })
            ],
            entryComponents: [],
            exports: [],
            providers: [
                { provide: _angular_core__WEBPACK_IMPORTED_MODULE_2__["ErrorHandler"], useClass: _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_12__["AppErrorHandler"] }
            ]
        })
    ], CustomViewsModule);
    return CustomViewsModule;
}());



/***/ }),

/***/ "./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.scss":
/*!*************************************************************************************************************************!*\
  !*** ./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.scss ***!
  \*************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n  position: relative;\n  top: -1.4em;\n  max-width: 205px;\n  margin: 0px; }\n\np.parameter-description-normal {\n  color: rgba(255, 255, 255, 0.7);\n  max-width: 205px;\n  font-size: 87.5%;\n  position: relative;\n  top: -0.7em;\n  margin: 0px; }\n\np.parameter-description-radio {\n  color: rgba(255, 255, 255, 0.7);\n  max-width: 205px; }\n\ndiv.parameter-radio {\n  position: relative; }\n\ndiv.parameter-radio label {\n  font-size: 75%; }\n\ndiv.parameter-checkbox {\n  position: relative; }\n\n.container {\n  overflow: hidden; }\n\n.figure {\n  float: left; }\n\n.form {\n  float: left; }\n\ninput.svg-input {\n  background-color: transparent;\n  color: white;\n  width: 40px;\n  border-left: none;\n  border-top: none;\n  border-right: none;\n  border-bottom-color: gray; }\n\n.map-container {\n  position: relative; }\n\n.zone-container {\n  position: absolute;\n  top: 0px;\n  left: 0px; }\n\n.zone:hover {\n  fill: rgba(255, 255, 255, 0.3);\n  cursor: pointer; }\n\n.zone {\n  z-index: 1;\n  fill: transparent; }\n\n.selected {\n  fill: rgba(255, 255, 255, 0.5); }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9jdXN0b20tdmlld3MtbW9kdWxlL2NvbXBvbmVudHMvc25vdy1sb2FkLW1vbm9waXRjaC1yb29mL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxjdXN0b20tdmlld3MtbW9kdWxlXFxjb21wb25lbnRzXFxzbm93LWxvYWQtbW9ub3BpdGNoLXJvb2ZcXHNub3ctbG9hZC1tb25vcGl0Y2gtcm9vZi5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLCtCQUEyQjtFQUMzQixnQkFBZ0I7RUFDaEIsa0JBQWtCO0VBQ2xCLFdBQVc7RUFDWCxnQkFBZ0I7RUFDaEIsV0FBVSxFQUFBOztBQUdkO0VBQ0ksK0JBQTJCO0VBQzNCLGdCQUFnQjtFQUNoQixnQkFBZ0I7RUFDaEIsa0JBQWtCO0VBQ2xCLFdBQVc7RUFDWCxXQUFXLEVBQUE7O0FBR2Y7RUFDSSwrQkFBMkI7RUFDM0IsZ0JBQWdCLEVBQUE7O0FBR3BCO0VBQ0ksa0JBQWtCLEVBQUE7O0FBR3RCO0VBQ0ksY0FBYyxFQUFBOztBQUdsQjtFQUNJLGtCQUFrQixFQUFBOztBQUd0QjtFQUNJLGdCQUFnQixFQUFBOztBQUdwQjtFQUNJLFdBQVcsRUFBQTs7QUFHZjtFQUNJLFdBQVcsRUFBQTs7QUFHZjtFQUNJLDZCQUE2QjtFQUM3QixZQUFZO0VBQ1osV0FBVztFQUNYLGlCQUFpQjtFQUNqQixnQkFBZ0I7RUFDaEIsa0JBQWtCO0VBQ2xCLHlCQUF5QixFQUFBOztBQUc3QjtFQUNJLGtCQUFpQixFQUFBOztBQUdyQjtFQUNJLGtCQUFrQjtFQUNsQixRQUFRO0VBQ1IsU0FBUyxFQUFBOztBQUdiO0VBQ0ksOEJBQTZCO0VBQzdCLGVBQWMsRUFBQTs7QUFHbEI7RUFDSSxVQUFTO0VBQ1QsaUJBQWdCLEVBQUE7O0FBR3BCO0VBQ0ksOEJBQThCLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9tb2R1bGVzL2N1c3RvbS12aWV3cy1tb2R1bGUvY29tcG9uZW50cy9zbm93LWxvYWQtbW9ub3BpdGNoLXJvb2Yvc25vdy1sb2FkLW1vbm9waXRjaC1yb29mLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsicC5wYXJhbWV0ZXItZGVzY3JpcHRpb24ge1xyXG4gICAgY29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjcpO1xyXG4gICAgZm9udC1zaXplOiA4Ny41JTtcclxuICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcclxuICAgIHRvcDogLTEuNGVtO1xyXG4gICAgbWF4LXdpZHRoOiAyMDVweDtcclxuICAgIG1hcmdpbjowcHg7XHJcbn1cclxuXHJcbnAucGFyYW1ldGVyLWRlc2NyaXB0aW9uLW5vcm1hbCB7XHJcbiAgICBjb2xvcjogcmdiYSgyNTUsMjU1LDI1NSwuNyk7XHJcbiAgICBtYXgtd2lkdGg6IDIwNXB4O1xyXG4gICAgZm9udC1zaXplOiA4Ny41JTtcclxuICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcclxuICAgIHRvcDogLTAuN2VtO1xyXG4gICAgbWFyZ2luOiAwcHg7XHJcbn1cclxuXHJcbnAucGFyYW1ldGVyLWRlc2NyaXB0aW9uLXJhZGlvIHtcclxuICAgIGNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LC43KTtcclxuICAgIG1heC13aWR0aDogMjA1cHg7XHJcbn1cclxuXHJcbmRpdi5wYXJhbWV0ZXItcmFkaW8ge1xyXG4gICAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG59XHJcblxyXG5kaXYucGFyYW1ldGVyLXJhZGlvIGxhYmVsIHtcclxuICAgIGZvbnQtc2l6ZTogNzUlO1xyXG59XHJcblxyXG5kaXYucGFyYW1ldGVyLWNoZWNrYm94IHtcclxuICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcclxufVxyXG5cclxuLmNvbnRhaW5lciB7XHJcbiAgICBvdmVyZmxvdzogaGlkZGVuO1xyXG59XHJcblxyXG4uZmlndXJlIHtcclxuICAgIGZsb2F0OiBsZWZ0O1xyXG59XHJcblxyXG4uZm9ybSB7XHJcbiAgICBmbG9hdDogbGVmdDtcclxufVxyXG5cclxuaW5wdXQuc3ZnLWlucHV0IHtcclxuICAgIGJhY2tncm91bmQtY29sb3I6IHRyYW5zcGFyZW50O1xyXG4gICAgY29sb3I6IHdoaXRlO1xyXG4gICAgd2lkdGg6IDQwcHg7XHJcbiAgICBib3JkZXItbGVmdDogbm9uZTtcclxuICAgIGJvcmRlci10b3A6IG5vbmU7XHJcbiAgICBib3JkZXItcmlnaHQ6IG5vbmU7XHJcbiAgICBib3JkZXItYm90dG9tLWNvbG9yOiBncmF5O1xyXG59XHJcblxyXG4ubWFwLWNvbnRhaW5lcntcclxuICAgIHBvc2l0aW9uOnJlbGF0aXZlO1xyXG59XHJcblxyXG4uem9uZS1jb250YWluZXIge1xyXG4gICAgcG9zaXRpb246IGFic29sdXRlO1xyXG4gICAgdG9wOiAwcHg7XHJcbiAgICBsZWZ0OiAwcHg7XHJcbn1cclxuXHJcbi56b25lOmhvdmVye1xyXG4gICAgZmlsbDpyZ2JhKDI1NSwgMjU1LCAyNTUsIDAuMyk7XHJcbiAgICBjdXJzb3I6cG9pbnRlcjtcclxufVxyXG5cclxuLnpvbmV7XHJcbiAgICB6LWluZGV4OjE7XHJcbiAgICBmaWxsOnRyYW5zcGFyZW50O1xyXG59XHJcblxyXG4uc2VsZWN0ZWQge1xyXG4gICAgZmlsbDogcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjUpO1xyXG5cclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.ts":
/*!***********************************************************************************************************************!*\
  !*** ./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.ts ***!
  \***********************************************************************************************************************/
/*! exports provided: SnowLoadMonopitchRoofComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SnowLoadMonopitchRoofComponent", function() { return SnowLoadMonopitchRoofComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _script_interpreter_services_script_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../script-interpreter/services/script.service */ "./src/app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _script_interpreter_services_parameter_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../script-interpreter/services/parameter.service */ "./src/app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _script_interpreter_services_calculation_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../script-interpreter/services/calculation.service */ "./src/app/modules/script-interpreter/services/calculation.service.ts");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../services/translation.service */ "./src/app/services/translation.service.ts");
/* harmony import */ var _script_interpreter_models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../script-interpreter/models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ScriptId = 10;
var SnowLoadMonopitchRoofComponent = /** @class */ (function () {
    function SnowLoadMonopitchRoofComponent(route, scriptService, parameterService, calculationService, translationService) {
        this.route = route;
        this.scriptService = scriptService;
        this.parameterService = parameterService;
        this.calculationService = calculationService;
        this.translationService = translationService;
        this.addition = 0;
        this.resultParameters = [];
        this.parameterOptions = _script_interpreter_models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_6__["ParameterOptions"];
        this.offset = 80;
    }
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "snowFences", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "SnowFences"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "slope", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "α"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "altitude", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "A"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "zone", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "Zone"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "topography", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "Topography"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "snowLoad", {
        get: function () {
            return this.resultParameters.find(function (p) { return p.name == "s"; });
        },
        enumerable: true,
        configurable: true
    });
    SnowLoadMonopitchRoofComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.getScript();
        this.getParameters();
        this.translationService.languageChanged$.subscribe(function (language) {
            _this.getScript();
            _this.getParameters();
        });
    };
    SnowLoadMonopitchRoofComponent.prototype.getScript = function () {
        var _this = this;
        this.scriptService.getScript(ScriptId).subscribe(function (script) {
            _this.script = script;
        }, function (error) { return console.error(error); });
    };
    SnowLoadMonopitchRoofComponent.prototype.getParameters = function () {
        var _this = this;
        this.parameterService.getParameters(ScriptId, this.translationService.getCurrentLanguage())
            .subscribe(function (parameters) {
            _this.parameters = parameters.filter(function (p) { return (p.context & _script_interpreter_models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_6__["ParameterOptions"].editable) != 0; });
        }, function (error) { return console.error(error); });
    };
    SnowLoadMonopitchRoofComponent.prototype.onSlopeChange = function () {
        this.setAddition();
        this.calculate();
    };
    SnowLoadMonopitchRoofComponent.prototype.setAddition = function () {
        this.addition = Math.min(Math.tan(+this.slope.value * Math.PI / 180) * 300 / 5, 175);
    };
    SnowLoadMonopitchRoofComponent.prototype.isRequired = function (parameter) {
        return (parameter.context & this.parameterOptions.optional) == 0;
    };
    SnowLoadMonopitchRoofComponent.prototype.calculate = function () {
        var _this = this;
        this.calculationService.calculate(ScriptId, this.parameters)
            .subscribe(function (parameters) {
            _this.resultParameters = parameters;
        }, function (error) { return console.error(error); });
    };
    SnowLoadMonopitchRoofComponent.prototype.onMouseOver = function ($event) {
        $event.srcElement.style.fill = "white";
        $event.srcElement.style.backgroundColor = "white";
        $event.srcElement.style.opacity = "0.3";
    };
    SnowLoadMonopitchRoofComponent.prototype.selectZone = function (zoneNumber) {
        if (zoneNumber == 1)
            this.zone.value = "FirstZone";
        else if (zoneNumber == 2)
            this.zone.value = "SecondZone";
        else if (zoneNumber == 3)
            this.zone.value = "ThirdZone";
        else if (zoneNumber == 4)
            this.zone.value = "FourthZone";
        else if (zoneNumber == 5)
            this.zone.value = "FifthZone";
    };
    SnowLoadMonopitchRoofComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"] },
        { type: _script_interpreter_services_script_service__WEBPACK_IMPORTED_MODULE_2__["ScriptService"] },
        { type: _script_interpreter_services_parameter_service__WEBPACK_IMPORTED_MODULE_3__["ParameterService"] },
        { type: _script_interpreter_services_calculation_service__WEBPACK_IMPORTED_MODULE_4__["CalculationService"] },
        { type: _services_translation_service__WEBPACK_IMPORTED_MODULE_5__["TranslationService"] }
    ]; };
    SnowLoadMonopitchRoofComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'snow-load-monopitch-roof',
            template: __webpack_require__(/*! raw-loader!./snow-load-monopitch-roof.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.html"),
            styles: [__webpack_require__(/*! ./snow-load-monopitch-roof.component.scss */ "./src/app/modules/custom-views-module/components/snow-load-monopitch-roof/snow-load-monopitch-roof.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            _script_interpreter_services_script_service__WEBPACK_IMPORTED_MODULE_2__["ScriptService"],
            _script_interpreter_services_parameter_service__WEBPACK_IMPORTED_MODULE_3__["ParameterService"],
            _script_interpreter_services_calculation_service__WEBPACK_IMPORTED_MODULE_4__["CalculationService"],
            _services_translation_service__WEBPACK_IMPORTED_MODULE_5__["TranslationService"]])
    ], SnowLoadMonopitchRoofComponent);
    return SnowLoadMonopitchRoofComponent;
}());



/***/ }),

/***/ "./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.scss":
/*!***************************************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.scss ***!
  \***************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto; }\n\ntr.additions-hidden {\n  height: 0; }\n\ntr.summary-hidden {\n  display: none; }\n\ntr.fa-reorder {\n  cursor: -webkit-grab;\n  cursor: grab; }\n\n.scroll-horizontal {\n  overflow-x: auto; }\n\n.smaller-input {\n  width: 100px; }\n\n/*.cdk-drag-preview {\r\n    box-sizing: border-box;\r\n    border-radius: 4px;\r\n    box-shadow: 0 5px 5px -3px rgba(0, 0, 0, 0.2), 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12);\r\n}\r\n\r\n.cdk-drag-animating {\r\n    transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\r\n}\r\n\r\n.example-box:last-child {\r\n    border: none;\r\n}\r\n\r\n.example-list.cdk-drop-list-dragging .example-box:not(.cdk-drag-placeholder) {\r\n    transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\r\n}\r\n\r\n.example-custom-placeholder {\r\n    background: #ccc;\r\n    border: dotted 3px #999;\r\n    transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\r\n}*/\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9sb2Fkcy9jb21wb25lbnRzL2RlYWQtbG9hZHMtY29tcG9uZW50cy9kZWFkLWxvYWRzLWNhbGN1bGF0b3IvQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvc3JjXFxhcHBcXG1vZHVsZXNcXGxvYWRzXFxjb21wb25lbnRzXFxkZWFkLWxvYWRzLWNvbXBvbmVudHNcXGRlYWQtbG9hZHMtY2FsY3VsYXRvclxcZGVhZC1sb2Fkcy1jYWxjdWxhdG9yLmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvZGVhZC1sb2Fkcy1jb21wb25lbnRzL2RlYWQtbG9hZHMtY2FsY3VsYXRvci9kZWFkLWxvYWRzLWNhbGN1bGF0b3IuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxpQkFBaUI7RUFDakIsa0JBQWtCLEVBQUE7O0FBR3RCO0VBQ0ksU0FBUyxFQUFBOztBQUdiO0VBQ0ksYUFBYSxFQUFBOztBQUdqQjtFQUNJLG9CQUFZO0VBQVosWUFBWSxFQUFBOztBQUdoQjtFQUNJLGdCQUFnQixFQUFBOztBQUdwQjtFQUNJLFlBQVksRUFBQTs7QUFHaEI7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7RUNnQkUiLCJmaWxlIjoic3JjL2FwcC9tb2R1bGVzL2xvYWRzL2NvbXBvbmVudHMvZGVhZC1sb2Fkcy1jb21wb25lbnRzL2RlYWQtbG9hZHMtY2FsY3VsYXRvci9kZWFkLWxvYWRzLWNhbGN1bGF0b3IuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJ0YWJsZS5jZW50ZXIge1xyXG4gICAgbWFyZ2luLWxlZnQ6IGF1dG87XHJcbiAgICBtYXJnaW4tcmlnaHQ6IGF1dG87XHJcbn1cclxuXHJcbnRyLmFkZGl0aW9ucy1oaWRkZW4ge1xyXG4gICAgaGVpZ2h0OiAwO1xyXG59XHJcblxyXG50ci5zdW1tYXJ5LWhpZGRlbiB7XHJcbiAgICBkaXNwbGF5OiBub25lO1xyXG59XHJcblxyXG50ci5mYS1yZW9yZGVye1xyXG4gICAgY3Vyc29yOiBncmFiO1xyXG59XHJcblxyXG4uc2Nyb2xsLWhvcml6b250YWwge1xyXG4gICAgb3ZlcmZsb3cteDogYXV0bztcclxufVxyXG5cclxuLnNtYWxsZXItaW5wdXR7XHJcbiAgICB3aWR0aDogMTAwcHg7XHJcbn1cclxuXHJcbi8qLmNkay1kcmFnLXByZXZpZXcge1xyXG4gICAgYm94LXNpemluZzogYm9yZGVyLWJveDtcclxuICAgIGJvcmRlci1yYWRpdXM6IDRweDtcclxuICAgIGJveC1zaGFkb3c6IDAgNXB4IDVweCAtM3B4IHJnYmEoMCwgMCwgMCwgMC4yKSwgMCA4cHggMTBweCAxcHggcmdiYSgwLCAwLCAwLCAwLjE0KSwgMCAzcHggMTRweCAycHggcmdiYSgwLCAwLCAwLCAwLjEyKTtcclxufVxyXG5cclxuLmNkay1kcmFnLWFuaW1hdGluZyB7XHJcbiAgICB0cmFuc2l0aW9uOiB0cmFuc2Zvcm0gMjUwbXMgY3ViaWMtYmV6aWVyKDAsIDAsIDAuMiwgMSk7XHJcbn1cclxuXHJcbi5leGFtcGxlLWJveDpsYXN0LWNoaWxkIHtcclxuICAgIGJvcmRlcjogbm9uZTtcclxufVxyXG5cclxuLmV4YW1wbGUtbGlzdC5jZGstZHJvcC1saXN0LWRyYWdnaW5nIC5leGFtcGxlLWJveDpub3QoLmNkay1kcmFnLXBsYWNlaG9sZGVyKSB7XHJcbiAgICB0cmFuc2l0aW9uOiB0cmFuc2Zvcm0gMjUwbXMgY3ViaWMtYmV6aWVyKDAsIDAsIDAuMiwgMSk7XHJcbn1cclxuXHJcbi5leGFtcGxlLWN1c3RvbS1wbGFjZWhvbGRlciB7XHJcbiAgICBiYWNrZ3JvdW5kOiAjY2NjO1xyXG4gICAgYm9yZGVyOiBkb3R0ZWQgM3B4ICM5OTk7XHJcbiAgICB0cmFuc2l0aW9uOiB0cmFuc2Zvcm0gMjUwbXMgY3ViaWMtYmV6aWVyKDAsIDAsIDAuMiwgMSk7XHJcbn0qL1xyXG4iLCJ0YWJsZS5jZW50ZXIge1xuICBtYXJnaW4tbGVmdDogYXV0bztcbiAgbWFyZ2luLXJpZ2h0OiBhdXRvOyB9XG5cbnRyLmFkZGl0aW9ucy1oaWRkZW4ge1xuICBoZWlnaHQ6IDA7IH1cblxudHIuc3VtbWFyeS1oaWRkZW4ge1xuICBkaXNwbGF5OiBub25lOyB9XG5cbnRyLmZhLXJlb3JkZXIge1xuICBjdXJzb3I6IGdyYWI7IH1cblxuLnNjcm9sbC1ob3Jpem9udGFsIHtcbiAgb3ZlcmZsb3cteDogYXV0bzsgfVxuXG4uc21hbGxlci1pbnB1dCB7XG4gIHdpZHRoOiAxMDBweDsgfVxuXG4vKi5jZGstZHJhZy1wcmV2aWV3IHtcclxuICAgIGJveC1zaXppbmc6IGJvcmRlci1ib3g7XHJcbiAgICBib3JkZXItcmFkaXVzOiA0cHg7XHJcbiAgICBib3gtc2hhZG93OiAwIDVweCA1cHggLTNweCByZ2JhKDAsIDAsIDAsIDAuMiksIDAgOHB4IDEwcHggMXB4IHJnYmEoMCwgMCwgMCwgMC4xNCksIDAgM3B4IDE0cHggMnB4IHJnYmEoMCwgMCwgMCwgMC4xMik7XHJcbn1cclxuXHJcbi5jZGstZHJhZy1hbmltYXRpbmcge1xyXG4gICAgdHJhbnNpdGlvbjogdHJhbnNmb3JtIDI1MG1zIGN1YmljLWJlemllcigwLCAwLCAwLjIsIDEpO1xyXG59XHJcblxyXG4uZXhhbXBsZS1ib3g6bGFzdC1jaGlsZCB7XHJcbiAgICBib3JkZXI6IG5vbmU7XHJcbn1cclxuXHJcbi5leGFtcGxlLWxpc3QuY2RrLWRyb3AtbGlzdC1kcmFnZ2luZyAuZXhhbXBsZS1ib3g6bm90KC5jZGstZHJhZy1wbGFjZWhvbGRlcikge1xyXG4gICAgdHJhbnNpdGlvbjogdHJhbnNmb3JtIDI1MG1zIGN1YmljLWJlemllcigwLCAwLCAwLjIsIDEpO1xyXG59XHJcblxyXG4uZXhhbXBsZS1jdXN0b20tcGxhY2Vob2xkZXIge1xyXG4gICAgYmFja2dyb3VuZDogI2NjYztcclxuICAgIGJvcmRlcjogZG90dGVkIDNweCAjOTk5O1xyXG4gICAgdHJhbnNpdGlvbjogdHJhbnNmb3JtIDI1MG1zIGN1YmljLWJlemllcigwLCAwLCAwLjIsIDEpO1xyXG59Ki9cbiJdfQ== */"

/***/ }),

/***/ "./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.ts":
/*!*************************************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.ts ***!
  \*************************************************************************************************************************/
/*! exports provided: DeadLoadsCalculatorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsCalculatorComponent", function() { return DeadLoadsCalculatorComponent; });
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "./node_modules/@angular/cdk/esm5/drag-drop.es5.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material_table__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/table */ "./node_modules/@angular/material/esm5/table.es5.js");
/* harmony import */ var _models_dead_loads_material_for_calculations__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../models/dead-loads/material-for-calculations */ "./src/app/modules/loads/models/dead-loads/material-for-calculations.ts");
/* harmony import */ var _models_dead_loads_units__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../models/dead-loads/units */ "./src/app/modules/loads/models/dead-loads/units.ts");
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
            template: __webpack_require__(/*! raw-loader!./dead-loads-calculator.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.html"),
            styles: [__webpack_require__(/*! ./dead-loads-calculator.component.scss */ "./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], DeadLoadsCalculatorComponent);
    return DeadLoadsCalculatorComponent;
}());



/***/ }),

/***/ "./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.scss":
/*!***************************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.scss ***!
  \***************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto; }\n\ntr.additions-hidden {\n  height: 0; }\n\ntr.summary-hidden {\n  display: none; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9sb2Fkcy9jb21wb25lbnRzL2RlYWQtbG9hZHMtY29tcG9uZW50cy9kZWFkLWxvYWRzLWRhdGEvQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvc3JjXFxhcHBcXG1vZHVsZXNcXGxvYWRzXFxjb21wb25lbnRzXFxkZWFkLWxvYWRzLWNvbXBvbmVudHNcXGRlYWQtbG9hZHMtZGF0YVxcZGVhZC1sb2Fkcy1kYXRhLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksaUJBQWlCO0VBQ2pCLGtCQUFrQixFQUFBOztBQUd0QjtFQUNJLFNBQVMsRUFBQTs7QUFHYjtFQUNJLGFBQWEsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvbG9hZHMvY29tcG9uZW50cy9kZWFkLWxvYWRzLWNvbXBvbmVudHMvZGVhZC1sb2Fkcy1kYXRhL2RlYWQtbG9hZHMtZGF0YS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbInRhYmxlLmNlbnRlciB7XHJcbiAgICBtYXJnaW4tbGVmdDogYXV0bztcclxuICAgIG1hcmdpbi1yaWdodDogYXV0bztcclxufVxyXG5cclxudHIuYWRkaXRpb25zLWhpZGRlbiB7XHJcbiAgICBoZWlnaHQ6IDA7XHJcbn1cclxuXHJcbnRyLnN1bW1hcnktaGlkZGVuIHtcclxuICAgIGRpc3BsYXk6IG5vbmU7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.ts":
/*!*************************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.ts ***!
  \*************************************************************************************************************/
/*! exports provided: DeadLoadsDataComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsDataComponent", function() { return DeadLoadsDataComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_dead_loads_material_for_calculations__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../models/dead-loads/material-for-calculations */ "./src/app/modules/loads/models/dead-loads/material-for-calculations.ts");
/* harmony import */ var _models_dead_loads_units__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../models/dead-loads/units */ "./src/app/modules/loads/models/dead-loads/units.ts");
/* harmony import */ var _services_dead_loads_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../services/dead-loads.service */ "./src/app/modules/loads/services/dead-loads.service.ts");
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
    DeadLoadsDataComponent.ctorParameters = function () { return [
        { type: _services_dead_loads_service__WEBPACK_IMPORTED_MODULE_3__["DeadLoadsService"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], DeadLoadsDataComponent.prototype, "materialAdded", void 0);
    DeadLoadsDataComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-dead-loads-data',
            template: __webpack_require__(/*! raw-loader!./dead-loads-data.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.html"),
            styles: [__webpack_require__(/*! ./dead-loads-data.component.scss */ "./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_dead_loads_service__WEBPACK_IMPORTED_MODULE_3__["DeadLoadsService"]])
    ], DeadLoadsDataComponent);
    return DeadLoadsDataComponent;
}());



/***/ }),

/***/ "./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.scss":
/*!*****************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.scss ***!
  \*****************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto; }\n\ntr.additions-hidden {\n  height: 0; }\n\ntr.summary-hidden {\n  display: none; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9sb2Fkcy9jb21wb25lbnRzL2RlYWQtbG9hZHMtY29tcG9uZW50cy9kZWFkLWxvYWRzL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxsb2Fkc1xcY29tcG9uZW50c1xcZGVhZC1sb2Fkcy1jb21wb25lbnRzXFxkZWFkLWxvYWRzXFxkZWFkLWxvYWRzLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksaUJBQWlCO0VBQ2pCLGtCQUFrQixFQUFBOztBQUd0QjtFQUNJLFNBQVMsRUFBQTs7QUFHYjtFQUNJLGFBQWEsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvbG9hZHMvY29tcG9uZW50cy9kZWFkLWxvYWRzLWNvbXBvbmVudHMvZGVhZC1sb2Fkcy9kZWFkLWxvYWRzLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsidGFibGUuY2VudGVyIHtcclxuICAgIG1hcmdpbi1sZWZ0OiBhdXRvO1xyXG4gICAgbWFyZ2luLXJpZ2h0OiBhdXRvO1xyXG59XHJcblxyXG50ci5hZGRpdGlvbnMtaGlkZGVuIHtcclxuICAgIGhlaWdodDogMDtcclxufVxyXG5cclxudHIuc3VtbWFyeS1oaWRkZW4ge1xyXG4gICAgZGlzcGxheTogbm9uZTtcclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts":
/*!***************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts ***!
  \***************************************************************************************************/
/*! exports provided: DeadLoadsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsComponent", function() { return DeadLoadsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
            template: __webpack_require__(/*! raw-loader!./dead-loads.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.html"),
            styles: [__webpack_require__(/*! ./dead-loads.component.scss */ "./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], DeadLoadsComponent);
    return DeadLoadsComponent;
}());



/***/ }),

/***/ "./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.scss":
/*!*****************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.scss ***!
  \*****************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table.center {\n  margin-left: auto;\n  margin-right: auto; }\n\ntr.additions-hidden {\n  height: 0; }\n\ntr.summary-hidden {\n  display: none; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9sb2Fkcy9jb21wb25lbnRzL3Nub3ctbG9hZHMtY29tcG9uZW50cy9zbm93LWxvYWRzL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxsb2Fkc1xcY29tcG9uZW50c1xcc25vdy1sb2Fkcy1jb21wb25lbnRzXFxzbm93LWxvYWRzXFxzbm93LWxvYWRzLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksaUJBQWlCO0VBQ2pCLGtCQUFrQixFQUFBOztBQUd0QjtFQUNJLFNBQVMsRUFBQTs7QUFHYjtFQUNJLGFBQWEsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvbG9hZHMvY29tcG9uZW50cy9zbm93LWxvYWRzLWNvbXBvbmVudHMvc25vdy1sb2Fkcy9zbm93LWxvYWRzLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsidGFibGUuY2VudGVyIHtcclxuICAgIG1hcmdpbi1sZWZ0OiBhdXRvO1xyXG4gICAgbWFyZ2luLXJpZ2h0OiBhdXRvO1xyXG59XHJcblxyXG50ci5hZGRpdGlvbnMtaGlkZGVuIHtcclxuICAgIGhlaWdodDogMDtcclxufVxyXG5cclxudHIuc3VtbWFyeS1oaWRkZW4ge1xyXG4gICAgZGlzcGxheTogbm9uZTtcclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts":
/*!***************************************************************************************************!*\
  !*** ./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts ***!
  \***************************************************************************************************/
/*! exports provided: SnowLoadsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SnowLoadsComponent", function() { return SnowLoadsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
            template: __webpack_require__(/*! raw-loader!./snow-loads.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.html"),
            styles: [__webpack_require__(/*! ./snow-loads.component.scss */ "./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], SnowLoadsComponent);
    return SnowLoadsComponent;
}());



/***/ }),

/***/ "./src/app/modules/loads/loads-routing.module.ts":
/*!*******************************************************!*\
  !*** ./src/app/modules/loads/loads-routing.module.ts ***!
  \*******************************************************/
/*! exports provided: LoadsRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoadsRoutingModule", function() { return LoadsRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_dead_loads_components_dead_loads_dead_loads_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads/dead-loads.component */ "./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts");
/* harmony import */ var _components_snow_loads_components_snow_loads_snow_loads_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/snow-loads-components/snow-loads/snow-loads.component */ "./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts");
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

/***/ "./src/app/modules/loads/loads.module.ts":
/*!***********************************************!*\
  !*** ./src/app/modules/loads/loads.module.ts ***!
  \***********************************************/
/*! exports provided: LoadsModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoadsModule", function() { return LoadsModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _loads_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./loads-routing.module */ "./src/app/modules/loads/loads-routing.module.ts");
/* harmony import */ var _components_dead_loads_components_dead_loads_calculator_dead_loads_calculator_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component */ "./src/app/modules/loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "./node_modules/@angular/cdk/esm5/drag-drop.es5.js");
/* harmony import */ var _components_dead_loads_components_dead_loads_data_dead_loads_data_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads-data/dead-loads-data.component */ "./src/app/modules/loads/components/dead-loads-components/dead-loads-data/dead-loads-data.component.ts");
/* harmony import */ var _components_dead_loads_components_dead_loads_dead_loads_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/dead-loads-components/dead-loads/dead-loads.component */ "./src/app/modules/loads/components/dead-loads-components/dead-loads/dead-loads.component.ts");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../md-components-module/md-components.module */ "./src/app/modules/md-components-module/md-components.module.ts");
/* harmony import */ var _script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../script-interpreter/script-interpreter.module */ "./src/app/modules/script-interpreter/script-interpreter.module.ts");
/* harmony import */ var _components_snow_loads_components_snow_loads_snow_loads_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./components/snow-loads-components/snow-loads/snow-loads.component */ "./src/app/modules/loads/components/snow-loads-components/snow-loads/snow-loads.component.ts");
/* harmony import */ var _ngx_translate_core__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @ngx-translate/core */ "./node_modules/@ngx-translate/core/fesm5/ngx-translate-core.js");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ../../services/translation.service */ "./src/app/services/translation.service.ts");
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
                _script_interpreter_script_interpreter_module__WEBPACK_IMPORTED_MODULE_10__["ScriptInterpreterModule"],
                _ngx_translate_core__WEBPACK_IMPORTED_MODULE_12__["TranslateModule"].forRoot({
                    loader: {
                        provide: _ngx_translate_core__WEBPACK_IMPORTED_MODULE_12__["TranslateLoader"],
                        useClass: _services_translation_service__WEBPACK_IMPORTED_MODULE_13__["TranslateLanguageLoader"]
                    }
                })
            ]
        })
    ], LoadsModule);
    return LoadsModule;
}());



/***/ }),

/***/ "./src/app/modules/loads/models/dead-loads/addition-for-calculations.ts":
/*!******************************************************************************!*\
  !*** ./src/app/modules/loads/models/dead-loads/addition-for-calculations.ts ***!
  \******************************************************************************/
/*! exports provided: AdditionForCalculations */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdditionForCalculations", function() { return AdditionForCalculations; });
var AdditionForCalculations = /** @class */ (function () {
    function AdditionForCalculations(addition) {
        this.origin = addition;
    }
    AdditionForCalculations.ctorParameters = function () { return [
        { type: undefined }
    ]; };
    return AdditionForCalculations;
}());



/***/ }),

/***/ "./src/app/modules/loads/models/dead-loads/enums/loadUnit.ts":
/*!*******************************************************************!*\
  !*** ./src/app/modules/loads/models/dead-loads/enums/loadUnit.ts ***!
  \*******************************************************************/
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

/***/ "./src/app/modules/loads/models/dead-loads/material-for-calculations.ts":
/*!******************************************************************************!*\
  !*** ./src/app/modules/loads/models/dead-loads/material-for-calculations.ts ***!
  \******************************************************************************/
/*! exports provided: MaterialForCalculations */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MaterialForCalculations", function() { return MaterialForCalculations; });
/* harmony import */ var _addition_for_calculations__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./addition-for-calculations */ "./src/app/modules/loads/models/dead-loads/addition-for-calculations.ts");

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
    MaterialForCalculations.ctorParameters = function () { return [
        { type: String },
        { type: undefined }
    ]; };
    return MaterialForCalculations;
}());



/***/ }),

/***/ "./src/app/modules/loads/models/dead-loads/units.ts":
/*!**********************************************************!*\
  !*** ./src/app/modules/loads/models/dead-loads/units.ts ***!
  \**********************************************************/
/*! exports provided: Units */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Units", function() { return Units; });
/* harmony import */ var _enums_loadUnit__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./enums/loadUnit */ "./src/app/modules/loads/models/dead-loads/enums/loadUnit.ts");

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

/***/ "./src/app/modules/loads/services/dead-loads.service.ts":
/*!**************************************************************!*\
  !*** ./src/app/modules/loads/services/dead-loads.service.ts ***!
  \**************************************************************/
/*! exports provided: DeadLoadsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeadLoadsService", function() { return DeadLoadsService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
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
    DeadLoadsService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"] }
    ]; };
    DeadLoadsService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], DeadLoadsService);
    return DeadLoadsService;
}());



/***/ }),

/***/ "./src/app/modules/md-components-module/md-components.module.ts":
/*!**********************************************************************!*\
  !*** ./src/app/modules/md-components-module/md-components.module.ts ***!
  \**********************************************************************/
/*! exports provided: MdComponentsModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MdComponentsModule", function() { return MdComponentsModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_material_select__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/select */ "./node_modules/@angular/material/esm5/select.es5.js");
/* harmony import */ var _angular_material_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/table */ "./node_modules/@angular/material/esm5/table.es5.js");
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/button */ "./node_modules/@angular/material/esm5/button.es5.js");
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/input */ "./node_modules/@angular/material/esm5/input.es5.js");
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/material/checkbox */ "./node_modules/@angular/material/esm5/checkbox.es5.js");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "./node_modules/@angular/cdk/esm5/drag-drop.es5.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _angular_material_card__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/card */ "./node_modules/@angular/material/esm5/card.es5.js");
/* harmony import */ var _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/material/autocomplete */ "./node_modules/@angular/material/esm5/autocomplete.es5.js");
/* harmony import */ var _angular_material_progress_bar__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/material/progress-bar */ "./node_modules/@angular/material/esm5/progress-bar.es5.js");
/* harmony import */ var _angular_material_radio__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/material/radio */ "./node_modules/@angular/material/esm5/radio.es5.js");
/* harmony import */ var _angular_material_expansion__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @angular/material/expansion */ "./node_modules/@angular/material/esm5/expansion.es5.js");
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/material/list */ "./node_modules/@angular/material/esm5/list.es5.js");
/* harmony import */ var _angular_material_tabs__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/material/tabs */ "./node_modules/@angular/material/esm5/tabs.es5.js");
/* harmony import */ var _angular_material_chips__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/material/chips */ "./node_modules/@angular/material/esm5/chips.es5.js");
/* harmony import */ var _angular_material_toolbar__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! @angular/material/toolbar */ "./node_modules/@angular/material/esm5/toolbar.es5.js");
/* harmony import */ var _angular_material_paginator__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @angular/material/paginator */ "./node_modules/@angular/material/esm5/paginator.es5.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! @angular/material/dialog */ "./node_modules/@angular/material/esm5/dialog.es5.js");
/* harmony import */ var _angular_material_tooltip__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! @angular/material/tooltip */ "./node_modules/@angular/material/esm5/tooltip.es5.js");
/* harmony import */ var _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! @angular/material/bottom-sheet */ "./node_modules/@angular/material/esm5/bottom-sheet.es5.js");
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
                _angular_material_tooltip__WEBPACK_IMPORTED_MODULE_21__["MatTooltipModule"],
                _angular_material_bottom_sheet__WEBPACK_IMPORTED_MODULE_22__["MatBottomSheetModule"]
            ],
            providers: [
                { provide: _angular_material_dialog__WEBPACK_IMPORTED_MODULE_20__["MAT_DIALOG_DEFAULT_OPTIONS"], useValue: { hasBackdrop: false } }
            ]
        })
    ], MdComponentsModule);
    return MdComponentsModule;
}());



/***/ }),

/***/ "./src/app/modules/pipes-module/pipes.module.ts":
/*!******************************************************!*\
  !*** ./src/app/modules/pipes-module/pipes.module.ts ***!
  \******************************************************/
/*! exports provided: PipesModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PipesModule", function() { return PipesModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _text_pipes_html_pipe__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./text-pipes/html-pipe */ "./src/app/modules/pipes-module/text-pipes/html-pipe.ts");
/* harmony import */ var _text_pipes_toNumber_pipe__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./text-pipes/toNumber-pipe */ "./src/app/modules/pipes-module/text-pipes/toNumber-pipe.ts");
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

/***/ "./src/app/modules/pipes-module/text-pipes/html-pipe.ts":
/*!**************************************************************!*\
  !*** ./src/app/modules/pipes-module/text-pipes/html-pipe.ts ***!
  \**************************************************************/
/*! exports provided: HtmlPipe */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HtmlPipe", function() { return HtmlPipe; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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

/***/ "./src/app/modules/pipes-module/text-pipes/toNumber-pipe.ts":
/*!******************************************************************!*\
  !*** ./src/app/modules/pipes-module/text-pipes/toNumber-pipe.ts ***!
  \******************************************************************/
/*! exports provided: ToNumberPipe */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ToNumberPipe", function() { return ToNumberPipe; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.scss":
/*!*********************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.scss ***!
  \*********************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n  position: relative;\n  top: -1.4em;\n  max-width: 205px; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2F1dG9jb21wbGV0ZS9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FsY3VsYXRvclxccGFyYW1ldGVyLWlucHV0c1xcYXV0b2NvbXBsZXRlXFxwYXJhbWV0ZXItYXV0b2NvbXBsZXRlLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksK0JBQTJCO0VBQzNCLGdCQUFnQjtFQUNoQixrQkFBa0I7RUFDbEIsV0FBVztFQUNYLGdCQUFnQixFQUFBIiwiZmlsZSI6InNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2F1dG9jb21wbGV0ZS9wYXJhbWV0ZXItYXV0b2NvbXBsZXRlLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsicC5wYXJhbWV0ZXItZGVzY3JpcHRpb24ge1xyXG4gICAgY29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjcpO1xyXG4gICAgZm9udC1zaXplOiA4Ny41JTtcclxuICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcclxuICAgIHRvcDogLTEuNGVtO1xyXG4gICAgbWF4LXdpZHRoOiAyMDVweDtcclxufVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.ts":
/*!*******************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.ts ***!
  \*******************************************************************************************************************************************/
/*! exports provided: ParameterAutocompleteComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterAutocompleteComponent", function() { return ParameterAutocompleteComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
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
            template: __webpack_require__(/*! raw-loader!./parameter-autocomplete.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.html"),
            styles: [__webpack_require__(/*! ./parameter-autocomplete.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterAutocompleteComponent);
    return ParameterAutocompleteComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.scss":
/*!*************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.scss ***!
  \*************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  max-width: 205px; }\n\ndiv.parameter-radio {\n  position: relative;\n  top: -2em; }\n\ndiv.parameter-radio label {\n  font-size: 75%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2NoZWNrYm94L0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItaW5wdXRzXFxjaGVja2JveFxccGFyYW1ldGVyLWNoZWNrYm94LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksK0JBQTJCO0VBQzNCLGdCQUFlLEVBQUE7O0FBR25CO0VBQ0ksa0JBQWlCO0VBQ2pCLFNBQVMsRUFBQTs7QUFHYjtFQUNJLGNBQWMsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9jaGVja2JveC9wYXJhbWV0ZXItY2hlY2tib3guY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJwLnBhcmFtZXRlci1kZXNjcmlwdGlvbiB7XHJcbiAgICBjb2xvcjogcmdiYSgyNTUsMjU1LDI1NSwuNyk7XHJcbiAgICBtYXgtd2lkdGg6MjA1cHg7XHJcbn1cclxuXHJcbmRpdi5wYXJhbWV0ZXItcmFkaW97XHJcbiAgICBwb3NpdGlvbjpyZWxhdGl2ZTtcclxuICAgIHRvcDogLTJlbTtcclxufVxyXG5cclxuZGl2LnBhcmFtZXRlci1yYWRpbyBsYWJlbHtcclxuICAgIGZvbnQtc2l6ZTogNzUlO1xyXG59Il19 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.ts":
/*!***********************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.ts ***!
  \***********************************************************************************************************************************/
/*! exports provided: ParameterCheckboxComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterCheckboxComponent", function() { return ParameterCheckboxComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/checkbox */ "./node_modules/@angular/material/esm5/checkbox.es5.js");
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
            template: __webpack_require__(/*! raw-loader!./parameter-checkbox.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.html"),
            styles: [__webpack_require__(/*! ./parameter-checkbox.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterCheckboxComponent);
    return ParameterCheckboxComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.scss":
/*!***************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.scss ***!
  \***************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".figures-button {\n  padding-right: 3px;\n  margin-right: 3px;\n  cursor: pointer; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2ZpZ3VyZXMtYnV0dG9uL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItaW5wdXRzXFxmaWd1cmVzLWJ1dHRvblxcZmlndXJlcy1idXR0b24uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxrQkFBa0I7RUFDbEIsaUJBQWlCO0VBQ2pCLGVBQWUsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9maWd1cmVzLWJ1dHRvbi9maWd1cmVzLWJ1dHRvbi5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5maWd1cmVzLWJ1dHRvbiB7XHJcbiAgICBwYWRkaW5nLXJpZ2h0OiAzcHg7XHJcbiAgICBtYXJnaW4tcmlnaHQ6IDNweDtcclxuICAgIGN1cnNvcjogcG9pbnRlcjtcclxufVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.ts":
/*!*************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.ts ***!
  \*************************************************************************************************************************************/
/*! exports provided: FiguresButtonComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FiguresButtonComponent", function() { return FiguresButtonComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/material/dialog */ "./node_modules/@angular/material/esm5/dialog.es5.js");
/* harmony import */ var _figures_parameter_figures_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../figures/parameter-figures.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var FiguresButtonComponent = /** @class */ (function () {
    function FiguresButtonComponent(dialog) {
        this.dialog = dialog;
    }
    FiguresButtonComponent.prototype.openFigures = function () {
        var dialogConfig = new _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialogConfig"]();
        dialogConfig.disableClose = false;
        dialogConfig.autoFocus = true;
        dialogConfig.width = 'auto';
        dialogConfig.data = this.parameter;
        var dialogRef = this.dialog.open(_figures_parameter_figures_component__WEBPACK_IMPORTED_MODULE_2__["ParameterFiguresComponent"], dialogConfig);
        dialogRef.afterClosed().subscribe(function (result) {
        });
    };
    FiguresButtonComponent.ctorParameters = function () { return [
        { type: _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialog"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Object)
    ], FiguresButtonComponent.prototype, "parameter", void 0);
    FiguresButtonComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'figures-button',
            template: __webpack_require__(/*! raw-loader!./figures-button.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.html"),
            styles: [__webpack_require__(/*! ./figures-button.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialog"]])
    ], FiguresButtonComponent);
    return FiguresButtonComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.scss":
/*!***********************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.scss ***!
  \***********************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9maWd1cmVzL3BhcmFtZXRlci1maWd1cmVzLmNvbXBvbmVudC5zY3NzIn0= */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.ts":
/*!*********************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.ts ***!
  \*********************************************************************************************************************************/
/*! exports provided: ParameterFiguresComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterFiguresComponent", function() { return ParameterFiguresComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/material/dialog */ "./node_modules/@angular/material/esm5/dialog.es5.js");
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


var ParameterFiguresComponent = /** @class */ (function () {
    function ParameterFiguresComponent(dialogRef, parameter) {
        this.dialogRef = dialogRef;
        this.parameter = parameter;
    }
    ParameterFiguresComponent.prototype.onCloseClick = function () {
        this.dialogRef.close();
    };
    ParameterFiguresComponent.ctorParameters = function () { return [
        { type: _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialogRef"] },
        { type: undefined, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"], args: [_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MAT_DIALOG_DATA"],] }] }
    ]; };
    ParameterFiguresComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'parameter-figures',
            template: __webpack_require__(/*! raw-loader!./parameter-figures.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.html"),
            styles: [__webpack_require__(/*! ./parameter-figures.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.scss")]
        }),
        __param(1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])(_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MAT_DIALOG_DATA"])),
        __metadata("design:paramtypes", [_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialogRef"], Object])
    ], ParameterFiguresComponent);
    return ParameterFiguresComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.scss":
/*!*******************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.scss ***!
  \*******************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n  position: relative;\n  top: -1.4em;\n  max-width: 205px; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL2lucHV0L0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItaW5wdXRzXFxpbnB1dFxccGFyYW1ldGVyLWlucHV0LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksK0JBQTJCO0VBQzNCLGdCQUFnQjtFQUNoQixrQkFBaUI7RUFDakIsV0FBVTtFQUNWLGdCQUFlLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1pbnB1dHMvaW5wdXQvcGFyYW1ldGVyLWlucHV0LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsicC5wYXJhbWV0ZXItZGVzY3JpcHRpb24ge1xyXG4gICAgY29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjcpO1xyXG4gICAgZm9udC1zaXplOiA4Ny41JTtcclxuICAgIHBvc2l0aW9uOnJlbGF0aXZlO1xyXG4gICAgdG9wOi0xLjRlbTtcclxuICAgIG1heC13aWR0aDoyMDVweDtcclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.ts":
/*!*****************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.ts ***!
  \*****************************************************************************************************************************/
/*! exports provided: ParameterInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterInputComponent", function() { return ParameterInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../models/enums/valueType */ "./src/app/modules/script-interpreter/models/enums/valueType.ts");
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
            template: __webpack_require__(/*! raw-loader!./parameter-input.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.html"),
            styles: [__webpack_require__(/*! ./parameter-input.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterInputComponent);
    return ParameterInputComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.scss":
/*!****************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.scss ***!
  \****************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9wYXJhbWV0ZXJzLWZvcm0vcGFyYW1ldGVyLWZvcm0uY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.ts":
/*!**************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.ts ***!
  \**************************************************************************************************************************************/
/*! exports provided: ParameterFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterFormComponent", function() { return ParameterFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/valueOptionSettings */ "./src/app/modules/script-interpreter/models/enums/valueOptionSettings.ts");
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
            template: __webpack_require__(/*! raw-loader!./parameter-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.html"),
            styles: [__webpack_require__(/*! ./parameter-form.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterFormComponent);
    return ParameterFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.scss":
/*!*******************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.scss ***!
  \*******************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  max-width: 205px; }\n\ndiv.parameter-radio {\n  position: relative;\n  top: -2em; }\n\ndiv.parameter-radio label {\n  font-size: 75%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL3JhZGlvL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItaW5wdXRzXFxyYWRpb1xccGFyYW1ldGVyLXJhZGlvLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksK0JBQTJCO0VBQzNCLGdCQUFlLEVBQUE7O0FBR25CO0VBQ0ksa0JBQWlCO0VBQ2pCLFNBQVMsRUFBQTs7QUFHYjtFQUNJLGNBQWMsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3IvcGFyYW1ldGVyLWlucHV0cy9yYWRpby9wYXJhbWV0ZXItcmFkaW8uY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJwLnBhcmFtZXRlci1kZXNjcmlwdGlvbiB7XHJcbiAgICBjb2xvcjogcmdiYSgyNTUsMjU1LDI1NSwuNyk7XHJcbiAgICBtYXgtd2lkdGg6MjA1cHg7XHJcbn1cclxuXHJcbmRpdi5wYXJhbWV0ZXItcmFkaW97XHJcbiAgICBwb3NpdGlvbjpyZWxhdGl2ZTtcclxuICAgIHRvcDogLTJlbTtcclxufVxyXG5cclxuZGl2LnBhcmFtZXRlci1yYWRpbyBsYWJlbHtcclxuICAgIGZvbnQtc2l6ZTogNzUlO1xyXG59Il19 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.ts":
/*!*****************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.ts ***!
  \*****************************************************************************************************************************/
/*! exports provided: ParameterRadioComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterRadioComponent", function() { return ParameterRadioComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
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
            template: __webpack_require__(/*! raw-loader!./parameter-radio.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.html"),
            styles: [__webpack_require__(/*! ./parameter-radio.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterRadioComponent);
    return ParameterRadioComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.scss":
/*!*********************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.scss ***!
  \*********************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "p.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%;\n  position: relative;\n  top: -1.4em;\n  max-width: 205px; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL3NlbGVjdC9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FsY3VsYXRvclxccGFyYW1ldGVyLWlucHV0c1xcc2VsZWN0XFxwYXJhbWV0ZXItc2VsZWN0LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksK0JBQTJCO0VBQzNCLGdCQUFnQjtFQUNoQixrQkFBa0I7RUFDbEIsV0FBVztFQUNYLGdCQUFnQixFQUFBIiwiZmlsZSI6InNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItaW5wdXRzL3NlbGVjdC9wYXJhbWV0ZXItc2VsZWN0LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsicC5wYXJhbWV0ZXItZGVzY3JpcHRpb24ge1xyXG4gICAgY29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjcpO1xyXG4gICAgZm9udC1zaXplOiA4Ny41JTtcclxuICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcclxuICAgIHRvcDogLTEuNGVtO1xyXG4gICAgbWF4LXdpZHRoOiAyMDVweDtcclxufVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.ts":
/*!*******************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.ts ***!
  \*******************************************************************************************************************************/
/*! exports provided: ParameterSelectComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterSelectComponent", function() { return ParameterSelectComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
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
            template: __webpack_require__(/*! raw-loader!./parameter-select.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.html"),
            styles: [__webpack_require__(/*! ./parameter-select.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterSelectComponent);
    return ParameterSelectComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.scss":
/*!********************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.scss ***!
  \********************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".parameter-result-header {\n  position: relative;\n  top: 0.4em; }\n\n.parameter-result-value {\n  font-size: 120%; }\n\n.parameter-result-important {\n  border-bottom-style: dotted;\n  border-top-style: dotted;\n  border-color: #9c27b0;\n  border-width: 3px; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9wYXJhbWV0ZXItcmVzdWx0cy9wYXJhbWV0ZXItcmVzdWx0L0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1jYWxjdWxhdG9yXFxwYXJhbWV0ZXItcmVzdWx0c1xccGFyYW1ldGVyLXJlc3VsdFxccGFyYW1ldGVyLXJlc3VsdC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGtCQUFpQjtFQUNqQixVQUFTLEVBQUE7O0FBR2I7RUFDSSxlQUFlLEVBQUE7O0FBR25CO0VBQ0ksMkJBQTJCO0VBQzNCLHdCQUF3QjtFQUN4QixxQkFBNkI7RUFDN0IsaUJBQWlCLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1jYWxjdWxhdG9yL3BhcmFtZXRlci1yZXN1bHRzL3BhcmFtZXRlci1yZXN1bHQvcGFyYW1ldGVyLXJlc3VsdC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5wYXJhbWV0ZXItcmVzdWx0LWhlYWRlcntcclxuICAgIHBvc2l0aW9uOnJlbGF0aXZlO1xyXG4gICAgdG9wOjAuNGVtO1xyXG59XHJcblxyXG4ucGFyYW1ldGVyLXJlc3VsdC12YWx1ZXtcclxuICAgIGZvbnQtc2l6ZTogMTIwJTtcclxufVxyXG5cclxuLnBhcmFtZXRlci1yZXN1bHQtaW1wb3J0YW50IHtcclxuICAgIGJvcmRlci1ib3R0b20tc3R5bGU6IGRvdHRlZDtcclxuICAgIGJvcmRlci10b3Atc3R5bGU6IGRvdHRlZDtcclxuICAgIGJvcmRlci1jb2xvcjogcmdiKDE1NiwzOSwxNzYpO1xyXG4gICAgYm9yZGVyLXdpZHRoOiAzcHg7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.ts":
/*!******************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.ts ***!
  \******************************************************************************************************************************************/
/*! exports provided: ParameterResultComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterResultComponent", function() { return ParameterResultComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../models/enums/valueType */ "./src/app/modules/script-interpreter/models/enums/valueType.ts");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
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
        //valueClass: string;
        //forbiddenSigns = ['(', ')', ',', '.', '^'];
        this.valueTypes = _models_enums_valueType__WEBPACK_IMPORTED_MODULE_1__["ValueType"];
        this.valueTypesMapping = { 'number': 0, 'text': 1 };
    }
    ParameterResultComponent.prototype.ngOnInit = function () {
        // this.forbiddenSigns.forEach(fs => this.valueClass = this.parameter.name.replace(fs, ''));
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
            template: __webpack_require__(/*! raw-loader!./parameter-result.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.html"),
            styles: [__webpack_require__(/*! ./parameter-result.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ParameterResultComponent);
    return ParameterResultComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.scss":
/*!**********************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.scss ***!
  \**********************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "table {\n  width: 100%; }\n\n.mat-hint {\n  margin-bottom: 10px;\n  display: inline-block;\n  align-content: flex-start; }\n\n.form-inline {\n  -webkit-transform: scale(0.9);\n          transform: scale(0.9);\n  -webkit-transform-origin: left;\n          transform-origin: left; }\n\n.parameter-description {\n  color: rgba(255, 255, 255, 0.7);\n  font-size: 87.5%; }\n\n.mat-form-field-paddings {\n  padding-bottom: 0px; }\n\n.calculate {\n  margin-top: 10px; }\n\nmat-chip-list {\n  list-style-type: none;\n  display: flex;\n  justify-content: center; }\n\nmat-chip-list mat-chip {\n  display: list-item;\n  padding: 5px 10px;\n  margin: 10px 3px 0px; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FsY3VsYXRvci9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FsY3VsYXRvclxcc2NyaXB0LWNhbGN1bGF0b3IuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxXQUFXLEVBQUE7O0FBR2Y7RUFDSSxtQkFBa0I7RUFDbEIscUJBQW9CO0VBQ3BCLHlCQUF3QixFQUFBOztBQUc1QjtFQUNJLDZCQUFxQjtVQUFyQixxQkFBcUI7RUFDckIsOEJBQXNCO1VBQXRCLHNCQUFzQixFQUFBOztBQUcxQjtFQUNJLCtCQUEyQjtFQUMzQixnQkFBZ0IsRUFBQTs7QUFHcEI7RUFDSSxtQkFBbUIsRUFBQTs7QUFHdkI7RUFDSSxnQkFBZSxFQUFBOztBQUduQjtFQUNJLHFCQUFxQjtFQUNyQixhQUFhO0VBQ2IsdUJBQXVCLEVBQUE7O0FBRzNCO0VBQ0ksa0JBQWtCO0VBQ2xCLGlCQUFpQjtFQUNqQixvQkFBb0IsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhbGN1bGF0b3Ivc2NyaXB0LWNhbGN1bGF0b3IuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJ0YWJsZXtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59XHJcblxyXG4ubWF0LWhpbnQge1xyXG4gICAgbWFyZ2luLWJvdHRvbToxMHB4O1xyXG4gICAgZGlzcGxheTppbmxpbmUtYmxvY2s7XHJcbiAgICBhbGlnbi1jb250ZW50OmZsZXgtc3RhcnQ7XHJcbn1cclxuXHJcbi5mb3JtLWlubGluZSB7XHJcbiAgICB0cmFuc2Zvcm06IHNjYWxlKDAuOSk7XHJcbiAgICB0cmFuc2Zvcm0tb3JpZ2luOiBsZWZ0O1xyXG59XHJcblxyXG4ucGFyYW1ldGVyLWRlc2NyaXB0aW9uIHtcclxuICAgIGNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LC43KTtcclxuICAgIGZvbnQtc2l6ZTogODcuNSU7XHJcbn1cclxuXHJcbi5tYXQtZm9ybS1maWVsZC1wYWRkaW5ncyB7XHJcbiAgICBwYWRkaW5nLWJvdHRvbTogMHB4O1xyXG59XHJcblxyXG4uY2FsY3VsYXRle1xyXG4gICAgbWFyZ2luLXRvcDoxMHB4O1xyXG59XHJcblxyXG5tYXQtY2hpcC1saXN0IHtcclxuICAgIGxpc3Qtc3R5bGUtdHlwZTogbm9uZTtcclxuICAgIGRpc3BsYXk6IGZsZXg7XHJcbiAgICBqdXN0aWZ5LWNvbnRlbnQ6IGNlbnRlcjtcclxufVxyXG5cclxubWF0LWNoaXAtbGlzdCBtYXQtY2hpcCB7XHJcbiAgICBkaXNwbGF5OiBsaXN0LWl0ZW07XHJcbiAgICBwYWRkaW5nOiA1cHggMTBweDtcclxuICAgIG1hcmdpbjogMTBweCAzcHggMHB4O1xyXG59Il19 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts":
/*!********************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts ***!
  \********************************************************************************************************/
/*! exports provided: ScriptCalculatorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptCalculatorComponent", function() { return ScriptCalculatorComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../models/enums/valueType */ "./src/app/modules/script-interpreter/models/enums/valueType.ts");
/* harmony import */ var _models_parametersGroup__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../models/parametersGroup */ "./src/app/modules/script-interpreter/models/parametersGroup.ts");
/* harmony import */ var _services_calculation_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../services/calculation.service */ "./src/app/modules/script-interpreter/services/calculation.service.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../services/parameter.service */ "./src/app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../services/script.service */ "./src/app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../../../services/translation.service */ "./src/app/services/translation.service.ts");
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
    function ScriptCalculatorComponent(route, scriptService, parameterService, calculationService, translationService) {
        this.route = route;
        this.scriptService = scriptService;
        this.parameterService = parameterService;
        this.calculationService = calculationService;
        this.translationService = translationService;
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]();
        this.parameterOptions = _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"];
    }
    ScriptCalculatorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id;
        var sub = this.route.params.subscribe(function (params) {
            id = +params['id'];
        });
        if (id != undefined)
            this.getScript(id);
        sub.unsubscribe();
        this.translationService.languageChanged$.subscribe(function (language) {
            if (id != undefined) {
                _this.getScript(id, language);
                _this.resultParameters = [];
                _this.valueChanged = true;
            }
        });
    };
    ScriptCalculatorComponent.prototype.getScript = function (id, language) {
        var _this = this;
        this.scriptService.getScript(id).subscribe(function (script) {
            _this.script = script;
            console.log("Script", _this.script);
            _this.setParameters();
        }, function (error) { return console.error(error); });
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
        var visibleParameters = this.parameters
            .filter(function (p) { return (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].editable) != 0 &&
            (p.context & _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_3__["ParameterOptions"].optional) == 0 &&
            _this.validateVisibility(p); });
        var validationResult = visibleParameters
            .every(function (p) { return p.value != undefined && p.value != "" && _this.validateData(p); });
        if (!validationResult)
            this.setErrorMessages(visibleParameters);
        else
            this.errorMessages = [];
        return validationResult;
    };
    ScriptCalculatorComponent.prototype.calculate = function () {
        var _this = this;
        this.isCalculating = true;
        this.calculationService.calculate(this.script.id, this.parameters.filter(function (p) { return _this.validateVisibility(p); }))
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
        var visibilityValidatorEquation = parameter.visibilityValidator;
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
    ScriptCalculatorComponent.prototype.validateData = function (parameter) {
        if (!parameter.dataValidator)
            return true;
        var dataValidatorEquation = parameter.dataValidator;
        this.parameters.forEach(function (p) {
            var value = p.valueType == _models_enums_valueType__WEBPACK_IMPORTED_MODULE_4__["ValueType"].number ? p.value : "'" + p.value + "'";
            dataValidatorEquation = dataValidatorEquation.split("[" + p.name + "]").join(value);
        });
        try {
            var result = eval(dataValidatorEquation);
            if (result != null)
                return result;
            else
                return true;
        }
        catch (e) {
            return true;
        }
    };
    ScriptCalculatorComponent.prototype.setErrorMessages = function (visibleParameters) {
        var _this = this;
        this.errorMessages = [];
        var wrongParameters = visibleParameters.filter(function (p) { return p.value && p.dataValidator && !_this.validateData(p); });
        wrongParameters.forEach(function (wp) {
            var pureValidationEquation = wp.dataValidator
                .replace('[', '')
                .replace(']', '')
                .replace('&&', ' AND ')
                .replace('||', ' OR ')
                .replace(/\s{2,}/g, ' ')
                .replace(/\r?\n|\r/g, ' ');
            _this.errorMessages.push(pureValidationEquation);
        });
    };
    ScriptCalculatorComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"] },
        { type: _services_script_service__WEBPACK_IMPORTED_MODULE_8__["ScriptService"] },
        { type: _services_parameter_service__WEBPACK_IMPORTED_MODULE_7__["ParameterService"] },
        { type: _services_calculation_service__WEBPACK_IMPORTED_MODULE_6__["CalculationService"] },
        { type: _services_translation_service__WEBPACK_IMPORTED_MODULE_9__["TranslationService"] }
    ]; };
    ScriptCalculatorComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'script-calculator',
            template: __webpack_require__(/*! raw-loader!./script-calculator.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.html"),
            styles: [__webpack_require__(/*! ./script-calculator.component.scss */ "./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _services_script_service__WEBPACK_IMPORTED_MODULE_8__["ScriptService"],
            _services_parameter_service__WEBPACK_IMPORTED_MODULE_7__["ParameterService"],
            _services_calculation_service__WEBPACK_IMPORTED_MODULE_6__["CalculationService"],
            _services_translation_service__WEBPACK_IMPORTED_MODULE_9__["TranslationService"]])
    ], ScriptCalculatorComponent);
    return ScriptCalculatorComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-card/script-card.component.scss":
/*!**********************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-card/script-card.component.scss ***!
  \**********************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".script-card {\n  max-width: 400px; }\n\n.script-header-image {\n  background-image: url(\"https://lorempixel.com/100/100/?random=12\");\n  background-size: cover; }\n\n.actions {\n  position: absolute;\n  left: 0;\n  bottom: 0; }\n\n.footer > button:not(.actions) {\n  position: absolute;\n  right: 0;\n  bottom: 0; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtY2FyZC9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtY2FyZFxcc2NyaXB0LWNhcmQuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxnQkFBZ0IsRUFBQTs7QUFFcEI7RUFDSSxrRUFBa0U7RUFDbEUsc0JBQXNCLEVBQUE7O0FBRzFCO0VBQ0ksa0JBQWtCO0VBQ2xCLE9BQU87RUFDUCxTQUFTLEVBQUE7O0FBR2I7RUFDSSxrQkFBa0I7RUFDbEIsUUFBUTtFQUNSLFNBQVMsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhcmQvc2NyaXB0LWNhcmQuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuc2NyaXB0LWNhcmQge1xyXG4gICAgbWF4LXdpZHRoOiA0MDBweDtcclxufVxyXG4uc2NyaXB0LWhlYWRlci1pbWFnZSB7XHJcbiAgICBiYWNrZ3JvdW5kLWltYWdlOiB1cmwoJ2h0dHBzOi8vbG9yZW1waXhlbC5jb20vMTAwLzEwMC8/cmFuZG9tPTEyJyk7XHJcbiAgICBiYWNrZ3JvdW5kLXNpemU6IGNvdmVyO1xyXG59XHJcblxyXG4uYWN0aW9ucyB7XHJcbiAgICBwb3NpdGlvbjogYWJzb2x1dGU7XHJcbiAgICBsZWZ0OiAwO1xyXG4gICAgYm90dG9tOiAwO1xyXG59XHJcblxyXG4uZm9vdGVyID4gYnV0dG9uOm5vdCguYWN0aW9ucykge1xyXG4gICAgcG9zaXRpb246IGFic29sdXRlO1xyXG4gICAgcmlnaHQ6IDA7XHJcbiAgICBib3R0b206IDA7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-card/script-card.component.ts":
/*!********************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-card/script-card.component.ts ***!
  \********************************************************************************************/
/*! exports provided: ScriptCardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptCardComponent", function() { return ScriptCardComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../services/script.service */ "./src/app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _services_auth_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../services/auth.service */ "./src/app/services/auth.service.ts");
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
    function ScriptCardComponent(scriptService, auth) {
        this.scriptService = scriptService;
        this.auth = auth;
        this.deleted = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
    }
    ScriptCardComponent.prototype.delete = function (script) {
        var _this = this;
        if (confirm("Are you sure that you want to remove \"" + script.name + "\"?")) {
            this.scriptService.delete(script.id).subscribe(function () {
                _this.deleted.emit(script.id);
            });
        }
    };
    ScriptCardComponent.ctorParameters = function () { return [
        { type: _services_script_service__WEBPACK_IMPORTED_MODULE_1__["ScriptService"] },
        { type: _services_auth_service__WEBPACK_IMPORTED_MODULE_2__["AuthService"] }
    ]; };
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
            template: __webpack_require__(/*! raw-loader!./script-card.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-card/script-card.component.html"),
            styles: [__webpack_require__(/*! ./script-card.component.scss */ "./src/app/modules/script-interpreter/components/script-card/script-card.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_script_service__WEBPACK_IMPORTED_MODULE_1__["ScriptService"],
            _services_auth_service__WEBPACK_IMPORTED_MODULE_2__["AuthService"]])
    ], ScriptCardComponent);
    return ScriptCardComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-cards/script-cards.component.scss":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-cards/script-cards.component.scss ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWNhcmRzL3NjcmlwdC1jYXJkcy5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-cards/script-cards.component.ts":
/*!**********************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-cards/script-cards.component.ts ***!
  \**********************************************************************************************/
/*! exports provided: ScriptCardsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptCardsComponent", function() { return ScriptCardsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../services/script.service */ "./src/app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../services/translation.service */ "./src/app/services/translation.service.ts");
/* harmony import */ var _services_local_store_manager_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/local-store-manager.service */ "./src/app/services/local-store-manager.service.ts");
/* harmony import */ var _services_db_keys__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/db-keys */ "./src/app/services/db-keys.ts");
/* harmony import */ var _services_search_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../services/search.service */ "./src/app/services/search.service.ts");
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
    function ScriptCardsComponent(scriptService, translationService, localStorage, searchService) {
        this.scriptService = scriptService;
        this.translationService = translationService;
        this.localStorage = localStorage;
        this.searchService = searchService;
        this.pageSizeOptions = [5, 10, 25, 50];
        this.pageSize = 10;
        this.pageIndex = 0;
    }
    ScriptCardsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.setScripts();
        this.translationService.languageChanged$.subscribe(function (language) {
            _this.setScripts(language);
        });
        this.searchService.searched$.subscribe(function (value) {
            _this.filterValue = value;
            _this.setFilteredScripts();
        });
    };
    ScriptCardsComponent.prototype.setScripts = function (lang) {
        var _this = this;
        this.scriptService.getScripts(lang).subscribe(function (scripts) {
            _this.scripts = scripts;
            _this.setFilteredScripts();
            _this.setPage();
        }, function (error) { return console.error(error); });
    };
    ScriptCardsComponent.prototype.setFilteredScripts = function () {
        var _this = this;
        this.filteredScripts = this.scripts;
        if (this.groupFilters != undefined)
            this.filteredScripts = this.filteredScripts.filter(function (s) { return _this.groupFilters.indexOf(s.groupName) != -1; });
        if (this.tagFilters != undefined)
            this.filteredScripts = this.filteredScripts.filter(function (s) { return _this.tagFilters.every(function (tf) { return s.tags.map(function (t) { return t.name; }).indexOf(tf) != -1; }); });
        if (this.filterValue)
            this.filteredScripts = this.filteredScripts.filter(function (s) {
                return s.name && s.name.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.author && s.author.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.accordingTo && s.accordingTo.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.groupName && s.groupName.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.tags && s.tags.some(function (t) { return t.name && t.name.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0; });
            });
        console.log(this.filteredScripts);
        this.activeScripts = this.filteredScripts.slice(0, this.pageSize);
    };
    ScriptCardsComponent.prototype.onDeleted = function (scriptId) {
        this.scripts = this.scripts.filter(function (s) { return s.id != scriptId; });
        this.setFilteredScripts();
    };
    ScriptCardsComponent.prototype.onPageChanged = function (e) {
        var _this = this;
        setTimeout(function () {
            _this.localStorage.savePermanentData(e.pageSize, _services_db_keys__WEBPACK_IMPORTED_MODULE_4__["DBkeys"].PAGESIZE);
            _this.localStorage.savePermanentData(e.pageIndex, _services_db_keys__WEBPACK_IMPORTED_MODULE_4__["DBkeys"].PAGEINDEX);
        });
        this.setPage(e);
    };
    ScriptCardsComponent.prototype.setPage = function (e) {
        var pageSize = this.pageSize;
        var pageIndex = 0;
        if (e != undefined) {
            pageSize = e.pageSize;
            pageIndex = e.pageIndex;
        }
        else if (this.localStorage.exists(_services_db_keys__WEBPACK_IMPORTED_MODULE_4__["DBkeys"].PAGESIZE) && this.localStorage.exists(_services_db_keys__WEBPACK_IMPORTED_MODULE_4__["DBkeys"].PAGEINDEX)) {
            pageSize = this.localStorage.getData(_services_db_keys__WEBPACK_IMPORTED_MODULE_4__["DBkeys"].PAGESIZE);
            pageIndex = this.localStorage.getData(_services_db_keys__WEBPACK_IMPORTED_MODULE_4__["DBkeys"].PAGEINDEX);
        }
        while (pageIndex * pageSize > this.filteredScripts.length)
            pageIndex -= 1;
        var firstCut = pageIndex * pageSize;
        var secondCut = firstCut + pageSize;
        this.pageSize = pageSize;
        this.pageIndex = pageIndex;
        this.activeScripts = this.filteredScripts.slice(firstCut, secondCut);
    };
    ScriptCardsComponent.ctorParameters = function () { return [
        { type: _services_script_service__WEBPACK_IMPORTED_MODULE_1__["ScriptService"] },
        { type: _services_translation_service__WEBPACK_IMPORTED_MODULE_2__["TranslationService"] },
        { type: _services_local_store_manager_service__WEBPACK_IMPORTED_MODULE_3__["LocalStoreManager"] },
        { type: _services_search_service__WEBPACK_IMPORTED_MODULE_5__["SearchService"] }
    ]; };
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
            template: __webpack_require__(/*! raw-loader!./script-cards.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-cards/script-cards.component.html"),
            styles: [__webpack_require__(/*! ./script-cards.component.scss */ "./src/app/modules/script-interpreter/components/script-cards/script-cards.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_script_service__WEBPACK_IMPORTED_MODULE_1__["ScriptService"],
            _services_translation_service__WEBPACK_IMPORTED_MODULE_2__["TranslationService"],
            _services_local_store_manager_service__WEBPACK_IMPORTED_MODULE_3__["LocalStoreManager"],
            _services_search_service__WEBPACK_IMPORTED_MODULE_5__["SearchService"]])
    ], ScriptCardsComponent);
    return ScriptCardsComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.scss":
/*!******************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.scss ***!
  \******************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".full-width {\n  width: 98%; }\n\n.form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n.value-options-border {\n  box-shadow: 10px 5px 5px black;\n  border: 1px solid black; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9wYXJhbWV0ZXJzLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtZm9ybVxccGFyYW1ldGVycy1mb3JtXFxkYXRhLXBhcmFtZXRlci1mb3JtXFxkYXRhLXBhcmFtZXRlci1mb3JtLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUNBO0VBQ0ksVUFBVSxFQUFBOztBQUdkO0VBQ0ksZ0JBQWdCO0VBQ2hCLGdCQUFnQjtFQUNoQixXQUFXLEVBQUE7O0FBR2Y7RUFDSSw4QkFBOEI7RUFDOUIsdUJBQXVCLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL3BhcmFtZXRlcnMtZm9ybS9kYXRhLXBhcmFtZXRlci1mb3JtL2RhdGEtcGFyYW1ldGVyLWZvcm0uY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJcclxuLmZ1bGwtd2lkdGgge1xyXG4gICAgd2lkdGg6IDk4JTtcclxufVxyXG5cclxuLmZvcm0tbWVkaXVtIHtcclxuICAgIG1pbi13aWR0aDogMTUwcHg7XHJcbiAgICBtYXgtd2lkdGg6IDM0MHB4O1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbi52YWx1ZS1vcHRpb25zLWJvcmRlciB7XHJcbiAgICBib3gtc2hhZG93OiAxMHB4IDVweCA1cHggYmxhY2s7XHJcbiAgICBib3JkZXI6IDFweCBzb2xpZCBibGFjaztcclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.ts":
/*!****************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.ts ***!
  \****************************************************************************************************************************************/
/*! exports provided: DataParameterFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DataParameterFormComponent", function() { return DataParameterFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/checkbox */ "./node_modules/@angular/material/esm5/checkbox.es5.js");
/* harmony import */ var _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/radio */ "./node_modules/@angular/material/esm5/radio.es5.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../../../common/errors/app-error-state-matcher */ "./src/app/common/errors/app-error-state-matcher.ts");
/* harmony import */ var _models_enums_parameterOptions__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../models/enums/parameterOptions */ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts");
/* harmony import */ var _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../models/enums/valueOptionSettings */ "./src/app/modules/script-interpreter/models/enums/valueOptionSettings.ts");
/* harmony import */ var _models_enums_valueType__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../../models/enums/valueType */ "./src/app/modules/script-interpreter/models/enums/valueType.ts");
/* harmony import */ var _models_parameterImpl__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../../../models/parameterImpl */ "./src/app/modules/script-interpreter/models/parameterImpl.ts");
/* harmony import */ var _models_valueOptionImpl__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../../../models/valueOptionImpl */ "./src/app/modules/script-interpreter/models/valueOptionImpl.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../../../../services/parameter.service */ "./src/app/modules/script-interpreter/services/parameter.service.ts");
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
        var position = this.value.nativeElement.selectionEnd;
        if (position >= 0) {
            var value = this.parameterValue.value;
            this.parameterValue.setValue(value.slice(0, position) + ("[" + parameter.name + "]") + value.slice(position));
            this.value.nativeElement.focus();
            this.value.nativeElement.selectionEnd = position + ("[" + parameter.name + "]").length;
        }
        else {
            this.parameterValue.setValue(this.parameterValue.value + "[" + parameter.name + "]");
            this.value.nativeElement.focus();
            this.value.nativeElement.selectionEnd = this.parameterValue.value.length;
        }
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
            .subscribe(function () {
            _this.updated.emit(_this.parameterForm.value);
        }, function (error) { return console.error(error); });
    };
    DataParameterFormComponent.prototype.setValueOptionsSettings = function () {
        this.allowUserValues = this.newParameter.valueOptionSetting == _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_6__["ValueOptionSettings"].UserInput;
    };
    DataParameterFormComponent.ctorParameters = function () { return [
        { type: _services_parameter_service__WEBPACK_IMPORTED_MODULE_10__["ParameterService"] }
    ]; };
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
            template: __webpack_require__(/*! raw-loader!./data-parameter-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.html"),
            styles: [__webpack_require__(/*! ./data-parameter-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_parameter_service__WEBPACK_IMPORTED_MODULE_10__["ParameterService"]])
    ], DataParameterFormComponent);
    return DataParameterFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.scss":
/*!**********************************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.scss ***!
  \**********************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL2RhdGEtcGFyYW1ldGVyLWZvcm0vZXhpc3RpbmctZmlndXJlcy1kaWFsb2cvZXhpc3RpbmctZmlndXJlcy1kaWFsb2cuY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.ts":
/*!********************************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.ts ***!
  \********************************************************************************************************************************************************************/
/*! exports provided: ExistingFiguresDialogComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ExistingFiguresDialogComponent", function() { return ExistingFiguresDialogComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/material/dialog */ "./node_modules/@angular/material/esm5/dialog.es5.js");
/* harmony import */ var _services_figure_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../services/figure.service */ "./src/app/modules/script-interpreter/services/figure.service.ts");
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
    ExistingFiguresDialogComponent.ctorParameters = function () { return [
        { type: _angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialogRef"] },
        { type: undefined, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"], args: [_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MAT_DIALOG_DATA"],] }] },
        { type: _services_figure_service__WEBPACK_IMPORTED_MODULE_2__["FigureService"] }
    ]; };
    ExistingFiguresDialogComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-existing-figures-dialog',
            template: __webpack_require__(/*! raw-loader!./existing-figures-dialog.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.html"),
            styles: [__webpack_require__(/*! ./existing-figures-dialog.component.scss */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.scss")]
        }),
        __param(1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])(_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MAT_DIALOG_DATA"])),
        __metadata("design:paramtypes", [_angular_material_dialog__WEBPACK_IMPORTED_MODULE_1__["MatDialogRef"], Object, _services_figure_service__WEBPACK_IMPORTED_MODULE_2__["FigureService"]])
    ], ExistingFiguresDialogComponent);
    return ExistingFiguresDialogComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.scss":
/*!******************************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.scss ***!
  \******************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL2RhdGEtcGFyYW1ldGVyLWZvcm0vZmlndXJlLXBhcmFtZXRlci1mb3JtL2ZpZ3VyZS1wYXJhbWV0ZXItZm9ybS5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.ts":
/*!****************************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.ts ***!
  \****************************************************************************************************************************************************************/
/*! exports provided: FigureParameterFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FigureParameterFormComponent", function() { return FigureParameterFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_figure_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../../services/figure.service */ "./src/app/modules/script-interpreter/services/figure.service.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/dialog */ "./node_modules/@angular/material/esm5/dialog.es5.js");
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
        var nativeELement = this.fileInput.nativeElement;
        this.figureService.upload(this.parameterId.value, nativeELement.files[0])
            .subscribe(function () {
            //this.figures.push(figure) BROKEN
        });
    };
    FigureParameterFormComponent.prototype.remove = function (figure) {
        var _this = this;
        this.figureService.detach(this.parameterId.value, figure.id)
            .subscribe(function () { return _this.figures = _this.figures.filter(function (f) { return f.id != figure.id; }); });
    };
    FigureParameterFormComponent.ctorParameters = function () { return [
        { type: _services_figure_service__WEBPACK_IMPORTED_MODULE_1__["FigureService"] },
        { type: _angular_material_dialog__WEBPACK_IMPORTED_MODULE_3__["MatDialog"] }
    ]; };
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
            template: __webpack_require__(/*! raw-loader!./figure-parameter-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.html"),
            styles: [__webpack_require__(/*! ./figure-parameter-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_figure_service__WEBPACK_IMPORTED_MODULE_1__["FigureService"],
            _angular_material_dialog__WEBPACK_IMPORTED_MODULE_3__["MatDialog"]])
    ], FigureParameterFormComponent);
    return FigureParameterFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.scss":
/*!************************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.scss ***!
  \************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".full-width {\n  width: 98%; }\n\n.form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9wYXJhbWV0ZXJzLWZvcm0vZGF0YS1wYXJhbWV0ZXItZm9ybS92YWx1ZS1vcHRpb25zLWZvcm0vQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvc3JjXFxhcHBcXG1vZHVsZXNcXHNjcmlwdC1pbnRlcnByZXRlclxcY29tcG9uZW50c1xcc2NyaXB0LWZvcm1cXHBhcmFtZXRlcnMtZm9ybVxcZGF0YS1wYXJhbWV0ZXItZm9ybVxcdmFsdWUtb3B0aW9ucy1mb3JtXFx2YWx1ZS1vcHRpb25zLWZvcm0uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0E7RUFDSSxVQUFVLEVBQUE7O0FBR2Q7RUFDSSxnQkFBZ0I7RUFDaEIsZ0JBQWdCO0VBQ2hCLFdBQVcsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL2RhdGEtcGFyYW1ldGVyLWZvcm0vdmFsdWUtb3B0aW9ucy1mb3JtL3ZhbHVlLW9wdGlvbnMtZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxyXG4uZnVsbC13aWR0aCB7XHJcbiAgICB3aWR0aDogOTglO1xyXG59XHJcblxyXG4uZm9ybS1tZWRpdW0ge1xyXG4gICAgbWluLXdpZHRoOiAxNTBweDtcclxuICAgIG1heC13aWR0aDogMzQwcHg7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.ts":
/*!**********************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.ts ***!
  \**********************************************************************************************************************************************************/
/*! exports provided: ValueOptionsFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValueOptionsFormComponent", function() { return ValueOptionsFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../../../common/errors/app-error-state-matcher */ "./src/app/common/errors/app-error-state-matcher.ts");
/* harmony import */ var _models_enums_valueOptionSettings__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../models/enums/valueOptionSettings */ "./src/app/modules/script-interpreter/models/enums/valueOptionSettings.ts");
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
            template: __webpack_require__(/*! raw-loader!./value-options-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.html"),
            styles: [__webpack_require__(/*! ./value-options-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ValueOptionsFormComponent);
    return ValueOptionsFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.scss":
/*!******************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.scss ***!
  \******************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".parameters-list {\n  width: 800px;\n  max-width: 100%;\n  border-top: solid 1px gray;\n  border-left: solid 1px gray;\n  border-right: solid 1px gray;\n  display: block;\n  border-radius: 4px;\n  overflow: hidden;\n  background: #424242;\n  position: center;\n  margin-left: 20px; }\n\n.parameter-in-list {\n  border-bottom: solid 1px gray;\n  color: white;\n  display: flex;\n  flex-direction: row;\n  align-items: baseline;\n  justify-content: flex-start;\n  box-sizing: border-box;\n  cursor: move;\n  font-size: 14px;\n  background: #424242; }\n\n.selected-parameter {\n  border: dashed 3px #9c27b0; }\n\n.cdk-drag-preview {\n  box-sizing: border-box;\n  border-radius: 4px;\n  box-shadow: 0 5px 5px -3px rgba(0, 0, 0, 0.2), 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12); }\n\n.cdk-drag-animating {\n  transition: -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1), -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1); }\n\n.parameter-in-list.cdk-drop-list-dragging .parameter-in-list:not(.cdk-drag-placeholder) {\n  transition: -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1), -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1); }\n\n.parameter-placeholder {\n  background: #ccc;\n  border: dotted 3px #999;\n  min-height: 35px;\n  transition: -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1);\n  transition: transform 250ms cubic-bezier(0, 0, 0.2, 1), -webkit-transform 250ms cubic-bezier(0, 0, 0.2, 1); }\n\n.parameter-name {\n  font-size: 18px; }\n\n.parameter-container {\n  width: 100%;\n  display: flex;\n  align-items: center; }\n\n.parameter-data {\n  float: left;\n  width: 75%; }\n\n.parameter-options {\n  float: right; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9wYXJhbWV0ZXJzLWZvcm0vQzpcXEtQS19DYWxjc1xcQnVpbGRfSVRfV2ViXFxDbGllbnRBcHAvc3JjXFxhcHBcXG1vZHVsZXNcXHNjcmlwdC1pbnRlcnByZXRlclxcY29tcG9uZW50c1xcc2NyaXB0LWZvcm1cXHBhcmFtZXRlcnMtZm9ybVxccGFyYW1ldGVycy1mb3JtLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksWUFBWTtFQUNaLGVBQWU7RUFDZiwwQkFBMEI7RUFDMUIsMkJBQTJCO0VBQzNCLDRCQUE0QjtFQUM1QixjQUFjO0VBQ2Qsa0JBQWtCO0VBQ2xCLGdCQUFnQjtFQUNoQixtQkFBNEI7RUFDNUIsZ0JBQWdCO0VBQ2hCLGlCQUFpQixFQUFBOztBQUdyQjtFQUNJLDZCQUE2QjtFQUM3QixZQUFZO0VBQ1osYUFBYTtFQUNiLG1CQUFtQjtFQUNuQixxQkFBcUI7RUFDckIsMkJBQTJCO0VBQzNCLHNCQUFzQjtFQUN0QixZQUFZO0VBQ1osZUFBZTtFQUNmLG1CQUE0QixFQUFBOztBQUdoQztFQUNJLDBCQUFrQyxFQUFBOztBQUd0QztFQUNJLHNCQUFzQjtFQUN0QixrQkFBa0I7RUFDbEIscUhBQXFILEVBQUE7O0FBR3pIO0VBQ0ksOERBQXNEO0VBQXRELHNEQUFzRDtFQUF0RCwwR0FBc0QsRUFBQTs7QUFNMUQ7RUFDSSw4REFBc0Q7RUFBdEQsc0RBQXNEO0VBQXRELDBHQUFzRCxFQUFBOztBQUcxRDtFQUNJLGdCQUFnQjtFQUNoQix1QkFBdUI7RUFDdkIsZ0JBQWdCO0VBQ2hCLDhEQUFzRDtFQUF0RCxzREFBc0Q7RUFBdEQsMEdBQXNELEVBQUE7O0FBSTFEO0VBQ0ksZUFBZSxFQUFBOztBQUduQjtFQUNJLFdBQVc7RUFDWCxhQUFhO0VBQ2IsbUJBQW1CLEVBQUE7O0FBR3ZCO0VBQ0ksV0FBVztFQUNYLFVBQVUsRUFBQTs7QUFHZDtFQUNJLFlBQVksRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vcGFyYW1ldGVycy1mb3JtL3BhcmFtZXRlcnMtZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5wYXJhbWV0ZXJzLWxpc3Qge1xyXG4gICAgd2lkdGg6IDgwMHB4O1xyXG4gICAgbWF4LXdpZHRoOiAxMDAlO1xyXG4gICAgYm9yZGVyLXRvcDogc29saWQgMXB4IGdyYXk7XHJcbiAgICBib3JkZXItbGVmdDogc29saWQgMXB4IGdyYXk7XHJcbiAgICBib3JkZXItcmlnaHQ6IHNvbGlkIDFweCBncmF5O1xyXG4gICAgZGlzcGxheTogYmxvY2s7XHJcbiAgICBib3JkZXItcmFkaXVzOiA0cHg7XHJcbiAgICBvdmVyZmxvdzogaGlkZGVuO1xyXG4gICAgYmFja2dyb3VuZDogcmdiYSg2Niw2Niw2NiwxKTtcclxuICAgIHBvc2l0aW9uOiBjZW50ZXI7XHJcbiAgICBtYXJnaW4tbGVmdDogMjBweDtcclxufVxyXG5cclxuLnBhcmFtZXRlci1pbi1saXN0IHtcclxuICAgIGJvcmRlci1ib3R0b206IHNvbGlkIDFweCBncmF5O1xyXG4gICAgY29sb3I6IHdoaXRlO1xyXG4gICAgZGlzcGxheTogZmxleDtcclxuICAgIGZsZXgtZGlyZWN0aW9uOiByb3c7XHJcbiAgICBhbGlnbi1pdGVtczogYmFzZWxpbmU7XHJcbiAgICBqdXN0aWZ5LWNvbnRlbnQ6IGZsZXgtc3RhcnQ7XHJcbiAgICBib3gtc2l6aW5nOiBib3JkZXItYm94O1xyXG4gICAgY3Vyc29yOiBtb3ZlO1xyXG4gICAgZm9udC1zaXplOiAxNHB4O1xyXG4gICAgYmFja2dyb3VuZDogcmdiYSg2Niw2Niw2NiwxKTtcclxufVxyXG5cclxuLnNlbGVjdGVkLXBhcmFtZXRlciB7XHJcbiAgICBib3JkZXI6IGRhc2hlZCAzcHggcmdiKDE1NiwzOSwxNzYpO1xyXG59XHJcblxyXG4uY2RrLWRyYWctcHJldmlldyB7XHJcbiAgICBib3gtc2l6aW5nOiBib3JkZXItYm94O1xyXG4gICAgYm9yZGVyLXJhZGl1czogNHB4O1xyXG4gICAgYm94LXNoYWRvdzogMCA1cHggNXB4IC0zcHggcmdiYSgwLCAwLCAwLCAwLjIpLCAwIDhweCAxMHB4IDFweCByZ2JhKDAsIDAsIDAsIDAuMTQpLCAwIDNweCAxNHB4IDJweCByZ2JhKDAsIDAsIDAsIDAuMTIpO1xyXG59XHJcblxyXG4uY2RrLWRyYWctYW5pbWF0aW5nIHtcclxuICAgIHRyYW5zaXRpb246IHRyYW5zZm9ybSAyNTBtcyBjdWJpYy1iZXppZXIoMCwgMCwgMC4yLCAxKTtcclxufVxyXG5cclxuLnBhcmFtZXRlci1pbi1saXN0Omxhc3QtY2hpbGQge1xyXG59XHJcblxyXG4ucGFyYW1ldGVyLWluLWxpc3QuY2RrLWRyb3AtbGlzdC1kcmFnZ2luZyAucGFyYW1ldGVyLWluLWxpc3Q6bm90KC5jZGstZHJhZy1wbGFjZWhvbGRlcikge1xyXG4gICAgdHJhbnNpdGlvbjogdHJhbnNmb3JtIDI1MG1zIGN1YmljLWJlemllcigwLCAwLCAwLjIsIDEpO1xyXG59XHJcblxyXG4ucGFyYW1ldGVyLXBsYWNlaG9sZGVyIHtcclxuICAgIGJhY2tncm91bmQ6ICNjY2M7XHJcbiAgICBib3JkZXI6IGRvdHRlZCAzcHggIzk5OTtcclxuICAgIG1pbi1oZWlnaHQ6IDM1cHg7XHJcbiAgICB0cmFuc2l0aW9uOiB0cmFuc2Zvcm0gMjUwbXMgY3ViaWMtYmV6aWVyKDAsIDAsIDAuMiwgMSk7XHJcbn1cclxuXHJcbi8vIFBhcmFtZXRlciByb3dcclxuLnBhcmFtZXRlci1uYW1lIHtcclxuICAgIGZvbnQtc2l6ZTogMThweDtcclxufVxyXG5cclxuLnBhcmFtZXRlci1jb250YWluZXIge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAgYWxpZ24taXRlbXM6IGNlbnRlcjtcclxufVxyXG5cclxuLnBhcmFtZXRlci1kYXRhIHtcclxuICAgIGZsb2F0OiBsZWZ0O1xyXG4gICAgd2lkdGg6IDc1JTtcclxufVxyXG5cclxuLnBhcmFtZXRlci1vcHRpb25zIHtcclxuICAgIGZsb2F0OiByaWdodDtcclxufVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts":
/*!****************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts ***!
  \****************************************************************************************************************/
/*! exports provided: ParametersFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParametersFormComponent", function() { return ParametersFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _models_enums_parameter_filter__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../models/enums/parameter-filter */ "./src/app/modules/script-interpreter/models/enums/parameter-filter.ts");
/* harmony import */ var _models_parameterImpl__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../models/parameterImpl */ "./src/app/modules/script-interpreter/models/parameterImpl.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../services/parameter.service */ "./src/app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "./node_modules/@angular/cdk/esm5/drag-drop.es5.js");
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
        this.parameterService.getParameters(id, "en").subscribe(function (parameters) {
            _this.parameters = parameters;
            _this.onParametersToShowChange();
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
                .subscribe(function () {
                _this.parameters = _this.parameters.filter(function (p) { return p.id != parameterId; });
                _this.onParametersToShowChange();
                _this.refreshNumbering(_this.parameters.find(function (p) { return p.id == parameterId; }).number);
                _this.saveParameters();
            }, function (error) { return console.error(error); });
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
            .subscribe(function () {
            _this.getParameters(_this.scriptId);
            _this.editMode = false;
        });
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
        if (this.parameters.length == 0)
            this.newParameter.number = 0;
        else
            this.newParameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number; })) + 1;
    };
    ParametersFormComponent.prototype.saveParameters = function () {
        var _this = this;
        this.parameters.forEach(function (p) {
            _this.parameterService.update(_this.scriptId, p)
                .subscribe(function () { }, function (error) { return console.error(error); });
        });
    };
    ParametersFormComponent.ctorParameters = function () { return [
        { type: _services_parameter_service__WEBPACK_IMPORTED_MODULE_4__["ParameterService"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('defaultLanguage'),
        __metadata("design:type", Object)
    ], ParametersFormComponent.prototype, "defaultLanguage", void 0);
    ParametersFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-parameters-form',
            template: __webpack_require__(/*! raw-loader!./parameters-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.html"),
            styles: [__webpack_require__(/*! ./parameters-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_parameter_service__WEBPACK_IMPORTED_MODULE_4__["ParameterService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], ParametersFormComponent);
    return ParametersFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.scss":
/*!********************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.scss ***!
  \********************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n.full-width {\n  width: 98%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9zY3JpcHQtZGF0YS1mb3JtL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1mb3JtXFxzY3JpcHQtZGF0YS1mb3JtXFxzY3JpcHQtZGF0YS1mb3JtLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksZ0JBQWdCO0VBQ2hCLGdCQUFnQjtFQUNoQixXQUFXLEVBQUE7O0FBR2Y7RUFDSSxVQUFVLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL3NjcmlwdC1kYXRhLWZvcm0vc2NyaXB0LWRhdGEtZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5mb3JtLW1lZGl1bSB7XHJcbiAgICBtaW4td2lkdGg6IDE1MHB4O1xyXG4gICAgbWF4LXdpZHRoOiAzNDBweDtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59XHJcblxyXG4uZnVsbC13aWR0aCB7XHJcbiAgICB3aWR0aDogOTglO1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.ts":
/*!******************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.ts ***!
  \******************************************************************************************************************/
/*! exports provided: ScriptDataFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptDataFormComponent", function() { return ScriptDataFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../common/errors/app-error-state-matcher */ "./src/app/common/errors/app-error-state-matcher.ts");
/* harmony import */ var _models_enums_language__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../models/enums/language */ "./src/app/modules/script-interpreter/models/enums/language.ts");
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
        this.languages = _models_enums_language__WEBPACK_IMPORTED_MODULE_3__["Language"];
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
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptDefaultLanguage", {
        get: function () {
            return this.scriptForm.get('defaultLanguage');
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
            template: __webpack_require__(/*! raw-loader!./script-data-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.html"),
            styles: [__webpack_require__(/*! ./script-data-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.scss")]
        })
    ], ScriptDataFormComponent);
    return ScriptDataFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/script-form.component.scss":
/*!**********************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/script-form.component.scss ***!
  \**********************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n.full-width {\n  width: 100%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS9DOlxcS1BLX0NhbGNzXFxCdWlsZF9JVF9XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcbW9kdWxlc1xcc2NyaXB0LWludGVycHJldGVyXFxjb21wb25lbnRzXFxzY3JpcHQtZm9ybVxcc2NyaXB0LWZvcm0uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0E7RUFDSSxnQkFBZ0I7RUFDaEIsZ0JBQWdCO0VBQ2hCLFdBQVcsRUFBQTs7QUFHZjtFQUNJLFdBQVcsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vc2NyaXB0LWZvcm0uY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJcclxuLmZvcm0tbWVkaXVtIHtcclxuICAgIG1pbi13aWR0aDogMTUwcHg7XHJcbiAgICBtYXgtd2lkdGg6IDM0MHB4O1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbi5mdWxsLXdpZHRoIHtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59Il19 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/script-form.component.ts":
/*!********************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/script-form.component.ts ***!
  \********************************************************************************************/
/*! exports provided: ScriptFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptFormComponent", function() { return ScriptFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/script.service */ "./src/app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _services_tag_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../services/tag.service */ "./src/app/modules/script-interpreter/services/tag.service.ts");
/* harmony import */ var _parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./parameters-form/parameters-form.component */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts");
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
            defaultLanguage: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](0, _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required),
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
    Object.defineProperty(ScriptFormComponent.prototype, "scriptDefaultLanguage", {
        get: function () {
            return this.scriptForm.get('defaultLanguage');
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
        this.scriptService.getScript(id, "en").subscribe(function (script) {
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
                        if (!this.editMode) {
                            this.scriptService.create(this.scriptForm.value)
                                .subscribe(function (createdScript) {
                                _this.router.navigateByUrl('/scripts/edit/' + createdScript.id);
                            }, function (error) { throw error; });
                        }
                        else
                            this.scriptService.update(this.scriptForm.value)
                                .subscribe(function () { });
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
    ScriptFormComponent.ctorParameters = function () { return [
        { type: _services_script_service__WEBPACK_IMPORTED_MODULE_3__["ScriptService"] },
        { type: _services_tag_service__WEBPACK_IMPORTED_MODULE_4__["TagService"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])(_parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_5__["ParametersFormComponent"], { static: false }),
        __metadata("design:type", _parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_5__["ParametersFormComponent"])
    ], ScriptFormComponent.prototype, "parametersForm", void 0);
    ScriptFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'script-form',
            template: __webpack_require__(/*! raw-loader!./script-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/script-form.component.html"),
            styles: [__webpack_require__(/*! ./script-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/script-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_script_service__WEBPACK_IMPORTED_MODULE_3__["ScriptService"],
            _services_tag_service__WEBPACK_IMPORTED_MODULE_4__["TagService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], ScriptFormComponent);
    return ScriptFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.scss":
/*!****************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.scss ***!
  \****************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vdGFnLWZvcm0vdGFnLWZvcm0uY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.ts":
/*!**************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.ts ***!
  \**************************************************************************************************/
/*! exports provided: TagFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TagFormComponent", function() { return TagFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_tag_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../services/tag.service */ "./src/app/modules/script-interpreter/services/tag.service.ts");
/* harmony import */ var _angular_cdk_keycodes__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/cdk/keycodes */ "./node_modules/@angular/cdk/esm5/keycodes.es5.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/autocomplete */ "./node_modules/@angular/material/esm5/autocomplete.es5.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
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
    TagFormComponent.ctorParameters = function () { return [
        { type: _services_tag_service__WEBPACK_IMPORTED_MODULE_1__["TagService"] }
    ]; };
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
            template: __webpack_require__(/*! raw-loader!./tag-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.html"),
            styles: [__webpack_require__(/*! ./tag-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_tag_service__WEBPACK_IMPORTED_MODULE_1__["TagService"]])
    ], TagFormComponent);
    return TagFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.scss":
/*!*********************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.scss ***!
  \*********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n.full-width {\n  width: 100%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS90cmFuc2xhdGlvbi1mb3JtL3BhcmFtZXRlci10cmFuc2xhdGlvbi1mb3JtL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1mb3JtXFx0cmFuc2xhdGlvbi1mb3JtXFxwYXJhbWV0ZXItdHJhbnNsYXRpb24tZm9ybVxccGFyYW1ldGVyLXRyYW5zbGF0aW9uLWZvcm0uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0E7RUFDSSxnQkFBZ0I7RUFDaEIsZ0JBQWdCO0VBQ2hCLFdBQVcsRUFBQTs7QUFHZjtFQUNJLFdBQVcsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vdHJhbnNsYXRpb24tZm9ybS9wYXJhbWV0ZXItdHJhbnNsYXRpb24tZm9ybS9wYXJhbWV0ZXItdHJhbnNsYXRpb24tZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxyXG4uZm9ybS1tZWRpdW0ge1xyXG4gICAgbWluLXdpZHRoOiAxNTBweDtcclxuICAgIG1heC13aWR0aDogMzQwcHg7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufVxyXG5cclxuLmZ1bGwtd2lkdGgge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn1cclxuIl19 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.ts":
/*!*******************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.ts ***!
  \*******************************************************************************************************************************************************/
/*! exports provided: ParameterTranslationFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterTranslationFormComponent", function() { return ParameterTranslationFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../../common/errors/app-error-state-matcher */ "./src/app/common/errors/app-error-state-matcher.ts");
/* harmony import */ var _models_enums_language__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../models/enums/language */ "./src/app/modules/script-interpreter/models/enums/language.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../services/parameter.service */ "./src/app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _services_translations_parameter_translation_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../services/translations/parameter-translation.service */ "./src/app/modules/script-interpreter/services/translations/parameter-translation.service.ts");
/* harmony import */ var _services_translations_value_option_translation_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../../services/translations/value-option-translation.service */ "./src/app/modules/script-interpreter/services/translations/value-option-translation.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var ParameterTranslationFormComponent = /** @class */ (function () {
    function ParameterTranslationFormComponent(parameterTranslationService, valueOptionTranslationService, parameterService) {
        this.parameterTranslationService = parameterTranslationService;
        this.valueOptionTranslationService = valueOptionTranslationService;
        this.parameterService = parameterService;
        this.parametersTranslationsForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormArray"]([
            new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0'),
                parameterId: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0'),
                description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](),
                notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](),
                groupName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](),
                language: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0')
            })
        ]);
        this.languages = _models_enums_language__WEBPACK_IMPORTED_MODULE_4__["Language"];
        this.matcher = new _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_3__["AppErrorStateMatcher"]();
        this.mappedParameters = [];
    }
    Object.defineProperty(ParameterTranslationFormComponent.prototype, "translationLanguage", {
        get: function () {
            return this.translationForm.get('language');
        },
        enumerable: true,
        configurable: true
    });
    ParameterTranslationFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        var parameters$ = this.getParameters();
        var parametersTranslations$ = this.getParametersTranslations();
        Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["forkJoin"])([parameters$, parametersTranslations$]).subscribe(function (results) {
            _this.parameters = results[0];
            results[1].forEach(function (pt) { return _this.parametersTranslationsForm.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](pt.id),
                parameterId: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](pt.parameterId),
                description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](pt.description),
                notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](pt.notes),
                groupName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](pt.groupName),
                language: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](pt.language)
            })); });
            _this.setMappedParameters();
        });
    };
    ParameterTranslationFormComponent.prototype.setMappedParameters = function () {
        var _this = this;
        this.mappedParameters = [];
        var parametersTranslation = this.parametersTranslationsForm.value;
        this.parameters.forEach(function (p) {
            var mappedParameter = {
                parameter: p, translation: parametersTranslation.find(function (pt) { return pt.parameterId == p.id; }) ||
                    new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                        id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0'),
                        parameterId: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](p.id),
                        description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
                        notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
                        groupName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
                        language: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](_this.translationLanguage.value)
                    }).value,
                valueOptions: []
            };
            _this.mappedParameters.push(mappedParameter);
        });
        this.setValueOptions();
    };
    ParameterTranslationFormComponent.prototype.setValueOptions = function () {
        var _this = this;
        this.mappedParameters.forEach(function (mp) {
            _this.valueOptionTranslationService.getValueOptionsTranslations(mp.parameter.id, _this.translationLanguage.value)
                .subscribe(function (vot) {
                mp.parameter.valueOptions.forEach(function (vo) {
                    mp.valueOptions.push({
                        origin: vo, translation: vot.find(function (v) { return v.valueOptionId == vo.id; }) || new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                            id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](0),
                            valueOptionId: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](vo.id),
                            name: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
                            description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
                            language: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](_this.translationLanguage.value)
                        }).value
                    });
                });
            });
        });
    };
    ParameterTranslationFormComponent.prototype.getParametersTranslations = function () {
        return this.parameterTranslationService.getParametersTranslation(this.translationData.scriptId, this.translationLanguage.value);
    };
    ParameterTranslationFormComponent.prototype.getParameters = function () {
        return this.parameterService.getParameters(this.translationData.scriptId, this.translationLanguage.value);
    };
    ParameterTranslationFormComponent.prototype.parametersSubmit = function () {
        var _this = this;
        this.mappedParameters.forEach(function (mp) {
            if (mp.translation.id == 0 && mp.translation.description)
                _this.createParameterTranslation(mp.translation);
            else if (mp.translation.description)
                _this.updateParameterTranslation(mp.translation);
            mp.valueOptions.forEach(function (vo) {
                if (vo.translation.id == 0 && (vo.translation.name || vo.translation.description))
                    _this.createValueOptionTranslation(vo.translation);
                else if (vo.translation.name || vo.translation.description)
                    _this.updateValueOptionTranslation(vo.translation);
            });
        });
    };
    ParameterTranslationFormComponent.prototype.updateValueOptionTranslation = function (valueOptionTranslation) {
        this.valueOptionTranslationService.update(valueOptionTranslation)
            .subscribe(function (vot) { });
    };
    ParameterTranslationFormComponent.prototype.createValueOptionTranslation = function (valueOptionTranslation) {
        this.valueOptionTranslationService.create(valueOptionTranslation)
            .subscribe(function (vot) { });
    };
    ParameterTranslationFormComponent.prototype.updateParameterTranslation = function (parameterTranslation) {
        var _this = this;
        this.parameterTranslationService.update(parameterTranslation)
            .subscribe(function (updatedTranslation) {
            _this.parametersTranslationsForm.clear();
            _this.parametersTranslationsForm.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](updatedTranslation.id),
                parameterId: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](updatedTranslation.parameterId),
                description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](updatedTranslation.description),
                notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](updatedTranslation.notes),
                groupName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](updatedTranslation.groupName),
                language: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](updatedTranslation.language)
            }));
        });
    };
    ParameterTranslationFormComponent.prototype.createParameterTranslation = function (parameterTranslation) {
        var _this = this;
        this.parameterTranslationService.create(parameterTranslation)
            .subscribe(function (newTranslation) {
            _this.parametersTranslationsForm.clear();
            _this.parametersTranslationsForm.push(new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
                id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](newTranslation.id),
                parameterId: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](newTranslation.parameterId),
                description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](newTranslation.description),
                notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](newTranslation.notes),
                groupName: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](newTranslation.groupName),
                language: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](newTranslation.language)
            }));
        });
    };
    ParameterTranslationFormComponent.ctorParameters = function () { return [
        { type: _services_translations_parameter_translation_service__WEBPACK_IMPORTED_MODULE_6__["ParameterTranslationService"] },
        { type: _services_translations_value_option_translation_service__WEBPACK_IMPORTED_MODULE_7__["ValueOptionTranslationService"] },
        { type: _services_parameter_service__WEBPACK_IMPORTED_MODULE_5__["ParameterService"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('scriptForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], ParameterTranslationFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('translationForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], ParameterTranslationFormComponent.prototype, "translationForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('defaultLanguage'),
        __metadata("design:type", Number)
    ], ParameterTranslationFormComponent.prototype, "defaultLanguage", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('translationData'),
        __metadata("design:type", Object)
    ], ParameterTranslationFormComponent.prototype, "translationData", void 0);
    ParameterTranslationFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-parameter-translation-form',
            template: __webpack_require__(/*! raw-loader!./parameter-translation-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.html"),
            styles: [__webpack_require__(/*! ./parameter-translation-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_translations_parameter_translation_service__WEBPACK_IMPORTED_MODULE_6__["ParameterTranslationService"],
            _services_translations_value_option_translation_service__WEBPACK_IMPORTED_MODULE_7__["ValueOptionTranslationService"],
            _services_parameter_service__WEBPACK_IMPORTED_MODULE_5__["ParameterService"]])
    ], ParameterTranslationFormComponent);
    return ParameterTranslationFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.scss":
/*!***************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.scss ***!
  \***************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n.full-width {\n  width: 100%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS90cmFuc2xhdGlvbi1mb3JtL3NjcmlwdC10cmFuc2xhdGlvbi1mb3JtL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1mb3JtXFx0cmFuc2xhdGlvbi1mb3JtXFxzY3JpcHQtdHJhbnNsYXRpb24tZm9ybVxcc2NyaXB0LXRyYW5zbGF0aW9uLWZvcm0uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0E7RUFDSSxnQkFBZ0I7RUFDaEIsZ0JBQWdCO0VBQ2hCLFdBQVcsRUFBQTs7QUFHZjtFQUNJLFdBQVcsRUFBQSIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvc2NyaXB0LWludGVycHJldGVyL2NvbXBvbmVudHMvc2NyaXB0LWZvcm0vdHJhbnNsYXRpb24tZm9ybS9zY3JpcHQtdHJhbnNsYXRpb24tZm9ybS9zY3JpcHQtdHJhbnNsYXRpb24tZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxyXG4uZm9ybS1tZWRpdW0ge1xyXG4gICAgbWluLXdpZHRoOiAxNTBweDtcclxuICAgIG1heC13aWR0aDogMzQwcHg7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufVxyXG5cclxuLmZ1bGwtd2lkdGgge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn1cclxuIl19 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.ts":
/*!*************************************************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.ts ***!
  \*************************************************************************************************************************************************/
/*! exports provided: ScriptTranslationFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptTranslationFormComponent", function() { return ScriptTranslationFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _models_enums_language__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../models/enums/language */ "./src/app/modules/script-interpreter/models/enums/language.ts");
/* harmony import */ var _services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/translations/script-translation.service */ "./src/app/modules/script-interpreter/services/translations/script-translation.service.ts");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../../../common/errors/app-error-state-matcher */ "./src/app/common/errors/app-error-state-matcher.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var ScriptTranslationFormComponent = /** @class */ (function () {
    function ScriptTranslationFormComponent(scriptTranslationService, route) {
        this.scriptTranslationService = scriptTranslationService;
        this.route = route;
        this.languages = _models_enums_language__WEBPACK_IMPORTED_MODULE_3__["Language"];
        this.matcher = new _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_5__["AppErrorStateMatcher"]();
    }
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalDescription", {
        get: function () {
            return this.scriptForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalNotes", {
        get: function () {
            return this.scriptForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalDefaultLanguage", {
        get: function () {
            return this.scriptForm.get('defaultLanguage');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationId", {
        get: function () {
            return this.translationForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationScriptId", {
        get: function () {
            return this.translationForm.get('scriptId');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationName", {
        get: function () {
            return this.translationForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationDescription", {
        get: function () {
            return this.translationForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationNotes", {
        get: function () {
            return this.translationForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationLanguage", {
        get: function () {
            return this.translationForm.get('language');
        },
        enumerable: true,
        configurable: true
    });
    ScriptTranslationFormComponent.prototype.ngOnInit = function () {
        this.translationScriptId.setValue(this.translationData.scriptId);
        if (this.defaultLanguage == this.languages.english)
            this.translationLanguage.setValue(this.languages.polish);
        else
            this.translationLanguage.setValue(this.languages.english);
        this.getScriptTranslation(this.translationLanguage.value);
    };
    ScriptTranslationFormComponent.prototype.onLanguageChange = function ($event) {
        this.getScriptTranslation($event.value);
    };
    ScriptTranslationFormComponent.prototype.getScriptTranslation = function (language) {
        var _this = this;
        this.scriptTranslationService.getScriptTranslation(this.translationData.scriptId, language)
            .subscribe(function (translation) {
            if (translation) {
                _this.translationForm.patchValue(translation);
                _this.translationData.editMode = true;
            }
            else
                _this.translationData.editMode = false;
        });
    };
    ScriptTranslationFormComponent.ctorParameters = function () { return [
        { type: _services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_4__["ScriptTranslationService"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('scriptForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], ScriptTranslationFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('translationForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], ScriptTranslationFormComponent.prototype, "translationForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('defaultLanguage'),
        __metadata("design:type", Number)
    ], ScriptTranslationFormComponent.prototype, "defaultLanguage", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('translationData'),
        __metadata("design:type", Object)
    ], ScriptTranslationFormComponent.prototype, "translationData", void 0);
    ScriptTranslationFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-script-translation-form',
            template: __webpack_require__(/*! raw-loader!./script-translation-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.html"),
            styles: [__webpack_require__(/*! ./script-translation-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_4__["ScriptTranslationService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"]])
    ], ScriptTranslationFormComponent);
    return ScriptTranslationFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.scss":
/*!********************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.scss ***!
  \********************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".form-medium {\n  min-width: 150px;\n  max-width: 340px;\n  width: 100%; }\n\n.full-width {\n  width: 100%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9zY3JpcHQtaW50ZXJwcmV0ZXIvY29tcG9uZW50cy9zY3JpcHQtZm9ybS90cmFuc2xhdGlvbi1mb3JtL0M6XFxLUEtfQ2FsY3NcXEJ1aWxkX0lUX1dlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxtb2R1bGVzXFxzY3JpcHQtaW50ZXJwcmV0ZXJcXGNvbXBvbmVudHNcXHNjcmlwdC1mb3JtXFx0cmFuc2xhdGlvbi1mb3JtXFx0cmFuc2xhdGlvbi1mb3JtLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUNBO0VBQ0ksZ0JBQWdCO0VBQ2hCLGdCQUFnQjtFQUNoQixXQUFXLEVBQUE7O0FBR2Y7RUFDSSxXQUFXLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9tb2R1bGVzL3NjcmlwdC1pbnRlcnByZXRlci9jb21wb25lbnRzL3NjcmlwdC1mb3JtL3RyYW5zbGF0aW9uLWZvcm0vdHJhbnNsYXRpb24tZm9ybS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxyXG4uZm9ybS1tZWRpdW0ge1xyXG4gICAgbWluLXdpZHRoOiAxNTBweDtcclxuICAgIG1heC13aWR0aDogMzQwcHg7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufVxyXG5cclxuLmZ1bGwtd2lkdGgge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn1cclxuIl19 */"

/***/ }),

/***/ "./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.ts":
/*!******************************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.ts ***!
  \******************************************************************************************************************/
/*! exports provided: TranslationFormComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TranslationFormComponent", function() { return TranslationFormComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../common/errors/app-error-state-matcher */ "./src/app/common/errors/app-error-state-matcher.ts");
/* harmony import */ var _models_enums_language__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../models/enums/language */ "./src/app/modules/script-interpreter/models/enums/language.ts");
/* harmony import */ var _services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../services/translations/script-translation.service */ "./src/app/modules/script-interpreter/services/translations/script-translation.service.ts");
/* harmony import */ var _parameter_translation_form_parameter_translation_form_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./parameter-translation-form/parameter-translation-form.component */ "./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var TranslationFormComponent = /** @class */ (function () {
    function TranslationFormComponent(scriptTranslationService, route) {
        this.scriptTranslationService = scriptTranslationService;
        this.route = route;
        this.translationForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"]({
            id: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0'),
            scriptId: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"](''),
            language: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('0', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required),
            name: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(100)),
            description: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(500)),
            notes: new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(1000))
        });
        this.languages = _models_enums_language__WEBPACK_IMPORTED_MODULE_4__["Language"];
        this.matcher = new _common_errors_app_error_state_matcher__WEBPACK_IMPORTED_MODULE_3__["AppErrorStateMatcher"]();
        this.translationData = { editMode: false, scriptId: 0 };
    }
    Object.defineProperty(TranslationFormComponent.prototype, "originalName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "originalDescription", {
        get: function () {
            return this.scriptForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "originalNotes", {
        get: function () {
            return this.scriptForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "originalDefaultLanguage", {
        get: function () {
            return this.scriptForm.get('defaultLanguage');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationId", {
        get: function () {
            return this.translationForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationScriptId", {
        get: function () {
            return this.translationForm.get('scriptId');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationName", {
        get: function () {
            return this.translationForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationDescription", {
        get: function () {
            return this.translationForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationNotes", {
        get: function () {
            return this.translationForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationLanguage", {
        get: function () {
            return this.translationForm.get('language');
        },
        enumerable: true,
        configurable: true
    });
    TranslationFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.translationData.scriptId = +params['id'];
        });
        this.translationScriptId.setValue(this.translationData.scriptId);
        if (this.defaultLanguage == this.languages.english)
            this.translationLanguage.setValue(this.languages.polish);
        else
            this.translationLanguage.setValue(this.languages.english);
    };
    TranslationFormComponent.prototype.onScriptTranslationSubmit = function () {
        var _this = this;
        if (!this.translationData.editMode) {
            this.scriptTranslationService.create(this.translationForm.value)
                .subscribe(function (scriptTranslation) {
                _this.translationForm.patchValue(scriptTranslation);
                _this.translationData.editMode = true;
            }, function (error) { throw error; });
            this.parameterTranslationForm.parametersSubmit();
        }
        else {
            this.scriptTranslationService.update(this.translationForm.value)
                .subscribe(function (scriptTranslation) { return _this.translationForm.patchValue(scriptTranslation); });
            this.parameterTranslationForm.parametersSubmit();
        }
    };
    TranslationFormComponent.prototype.removeScriptTranslation = function () {
        var _this = this;
        var selectedLanguage = this.translationLanguage.value;
        this.scriptTranslationService.remove(this.translationId.value)
            .subscribe(function (scriptTranslation) {
            _this.translationForm.reset();
            _this.translationData.editMode = false;
            _this.translationScriptId.setValue(_this.translationData.scriptId);
            _this.translationLanguage.setValue(selectedLanguage);
        });
    };
    TranslationFormComponent.ctorParameters = function () { return [
        { type: _services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_5__["ScriptTranslationService"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"] }
    ]; };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('defaultLanguage'),
        __metadata("design:type", Number)
    ], TranslationFormComponent.prototype, "defaultLanguage", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('scriptForm'),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], TranslationFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('parameterTranslationForm', { static: false }),
        __metadata("design:type", _parameter_translation_form_parameter_translation_form_component__WEBPACK_IMPORTED_MODULE_6__["ParameterTranslationFormComponent"])
    ], TranslationFormComponent.prototype, "parameterTranslationForm", void 0);
    TranslationFormComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-translation-form',
            template: __webpack_require__(/*! raw-loader!./translation-form.component.html */ "./node_modules/raw-loader/index.js!./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.html"),
            styles: [__webpack_require__(/*! ./translation-form.component.scss */ "./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.scss")]
        }),
        __metadata("design:paramtypes", [_services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_5__["ScriptTranslationService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"]])
    ], TranslationFormComponent);
    return TranslationFormComponent;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/models/enums/language.ts":
/*!*********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/enums/language.ts ***!
  \*********************************************************************/
/*! exports provided: Language */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Language", function() { return Language; });
var Language;
(function (Language) {
    Language[Language["english"] = 0] = "english";
    Language[Language["polish"] = 1] = "polish";
    Language[Language["german"] = 2] = "german";
})(Language || (Language = {}));


/***/ }),

/***/ "./src/app/modules/script-interpreter/models/enums/parameter-filter.ts":
/*!*****************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/enums/parameter-filter.ts ***!
  \*****************************************************************************/
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

/***/ "./src/app/modules/script-interpreter/models/enums/parameterOptions.ts":
/*!*****************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/enums/parameterOptions.ts ***!
  \*****************************************************************************/
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

/***/ "./src/app/modules/script-interpreter/models/enums/valueOptionSettings.ts":
/*!********************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/enums/valueOptionSettings.ts ***!
  \********************************************************************************/
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

/***/ "./src/app/modules/script-interpreter/models/enums/valueType.ts":
/*!**********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/enums/valueType.ts ***!
  \**********************************************************************/
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

/***/ "./src/app/modules/script-interpreter/models/parameterImpl.ts":
/*!********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/parameterImpl.ts ***!
  \********************************************************************/
/*! exports provided: ParameterImpl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterImpl", function() { return ParameterImpl; });
/* harmony import */ var _enums_valueType__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./enums/valueType */ "./src/app/modules/script-interpreter/models/enums/valueType.ts");

var ParameterImpl = /** @class */ (function () {
    function ParameterImpl() {
        this.valueType = _enums_valueType__WEBPACK_IMPORTED_MODULE_0__["ValueType"].number;
        this.valueOptions = [];
        this.figures = [];
    }
    return ParameterImpl;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/models/parametersGroup.ts":
/*!**********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/parametersGroup.ts ***!
  \**********************************************************************/
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
    ParametersGroup.ctorParameters = function () { return [
        { type: String }
    ]; };
    return ParametersGroup;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/models/valueOptionImpl.ts":
/*!**********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/models/valueOptionImpl.ts ***!
  \**********************************************************************/
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

/***/ "./src/app/modules/script-interpreter/script-interpreter-routing.module.ts":
/*!*********************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/script-interpreter-routing.module.ts ***!
  \*********************************************************************************/
/*! exports provided: ScriptInterpreterRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptInterpreterRoutingModule", function() { return ScriptInterpreterRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_script_form_script_form_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/script-form/script-form.component */ "./src/app/modules/script-interpreter/components/script-form/script-form.component.ts");
/* harmony import */ var _components_script_calculator_script_calculator_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/script-calculator/script-calculator.component */ "./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts");
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

/***/ "./src/app/modules/script-interpreter/script-interpreter.module.ts":
/*!*************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/script-interpreter.module.ts ***!
  \*************************************************************************/
/*! exports provided: ScriptInterpreterModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptInterpreterModule", function() { return ScriptInterpreterModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _components_script_form_script_form_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/script-form/script-form.component */ "./src/app/modules/script-interpreter/components/script-form/script-form.component.ts");
/* harmony import */ var _components_script_form_parameters_form_parameters_form_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/script-form/parameters-form/parameters-form.component */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/parameters-form.component.ts");
/* harmony import */ var _components_script_calculator_script_calculator_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/script-calculator/script-calculator.component */ "./src/app/modules/script-interpreter/components/script-calculator/script-calculator.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_data_parameter_form_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/data-parameter-form.component */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/data-parameter-form.component.ts");
/* harmony import */ var _components_script_card_script_card_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./components/script-card/script-card.component */ "./src/app/modules/script-interpreter/components/script-card/script-card.component.ts");
/* harmony import */ var _components_script_cards_script_cards_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./components/script-cards/script-cards.component */ "./src/app/modules/script-interpreter/components/script-cards/script-cards.component.ts");
/* harmony import */ var _components_script_form_tag_form_tag_form_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./components/script-form/tag-form/tag-form.component */ "./src/app/modules/script-interpreter/components/script-form/tag-form/tag-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_input_parameter_input_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/input/parameter-input.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/input/parameter-input.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_select_parameter_select_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/select/parameter-select.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/select/parameter-select.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_autocomplete_parameter_autocomplete_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_radio_parameter_radio_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/radio/parameter-radio.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/radio/parameter-radio.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_parameters_form_parameter_form_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/parameters-form/parameter-form.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/parameters-form/parameter-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_results_parameter_result_parameter_result_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./components/script-calculator/parameter-results/parameter-result/parameter-result.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-results/parameter-result/parameter-result.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_value_options_form_value_options_form_component__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component.ts");
/* harmony import */ var _components_script_form_script_data_form_script_data_form_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./components/script-form/script-data-form/script-data-form.component */ "./src/app/modules/script-interpreter/components/script-form/script-data-form/script-data-form.component.ts");
/* harmony import */ var _components_script_form_translation_form_translation_form_component__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./components/script-form/translation-form/translation-form.component */ "./src/app/modules/script-interpreter/components/script-form/translation-form/translation-form.component.ts");
/* harmony import */ var _components_script_form_translation_form_script_translation_form_script_translation_form_component__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./components/script-form/translation-form/script-translation-form/script-translation-form.component */ "./src/app/modules/script-interpreter/components/script-form/translation-form/script-translation-form/script-translation-form.component.ts");
/* harmony import */ var _components_script_form_translation_form_parameter_translation_form_parameter_translation_form_component__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component */ "./src/app/modules/script-interpreter/components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_checkbox_parameter_checkbox_component__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_figure_parameter_form_figure_parameter_form_component__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_figures_parameter_figures_component__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/figures/parameter-figures.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures/parameter-figures.component.ts");
/* harmony import */ var _components_script_form_parameters_form_data_parameter_form_existing_figures_dialog_existing_figures_dialog_component__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component */ "./src/app/modules/script-interpreter/components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component.ts");
/* harmony import */ var _components_script_calculator_parameter_inputs_figures_button_figures_button_component__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! ./components/script-calculator/parameter-inputs/figures-button/figures-button.component */ "./src/app/modules/script-interpreter/components/script-calculator/parameter-inputs/figures-button/figures-button.component.ts");
/* harmony import */ var _services_script_service__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! ./services/script.service */ "./src/app/modules/script-interpreter/services/script.service.ts");
/* harmony import */ var _services_tag_service__WEBPACK_IMPORTED_MODULE_30__ = __webpack_require__(/*! ./services/tag.service */ "./src/app/modules/script-interpreter/services/tag.service.ts");
/* harmony import */ var _services_calculation_service__WEBPACK_IMPORTED_MODULE_31__ = __webpack_require__(/*! ./services/calculation.service */ "./src/app/modules/script-interpreter/services/calculation.service.ts");
/* harmony import */ var _services_parameter_service__WEBPACK_IMPORTED_MODULE_32__ = __webpack_require__(/*! ./services/parameter.service */ "./src/app/modules/script-interpreter/services/parameter.service.ts");
/* harmony import */ var _services_translations_parameter_translation_service__WEBPACK_IMPORTED_MODULE_33__ = __webpack_require__(/*! ./services/translations/parameter-translation.service */ "./src/app/modules/script-interpreter/services/translations/parameter-translation.service.ts");
/* harmony import */ var _services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_34__ = __webpack_require__(/*! ./services/translations/script-translation.service */ "./src/app/modules/script-interpreter/services/translations/script-translation.service.ts");
/* harmony import */ var _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_35__ = __webpack_require__(/*! ./../../common/errors/app-error-handler */ "./src/app/common/errors/app-error-handler.ts");
/* harmony import */ var _pipes_module_pipes_module__WEBPACK_IMPORTED_MODULE_36__ = __webpack_require__(/*! ../pipes-module/pipes.module */ "./src/app/modules/pipes-module/pipes.module.ts");
/* harmony import */ var _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_37__ = __webpack_require__(/*! ../md-components-module/md-components.module */ "./src/app/modules/md-components-module/md-components.module.ts");
/* harmony import */ var _services_figure_service__WEBPACK_IMPORTED_MODULE_38__ = __webpack_require__(/*! ./services/figure.service */ "./src/app/modules/script-interpreter/services/figure.service.ts");
/* harmony import */ var _ngx_translate_core__WEBPACK_IMPORTED_MODULE_39__ = __webpack_require__(/*! @ngx-translate/core */ "./node_modules/@ngx-translate/core/fesm5/ngx-translate-core.js");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_40__ = __webpack_require__(/*! ../../services/translation.service */ "./src/app/services/translation.service.ts");
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
                _components_script_form_translation_form_translation_form_component__WEBPACK_IMPORTED_MODULE_21__["TranslationFormComponent"],
                _components_script_calculator_parameter_results_parameter_result_parameter_result_component__WEBPACK_IMPORTED_MODULE_18__["ParameterResultComponent"],
                _components_script_calculator_parameter_inputs_checkbox_parameter_checkbox_component__WEBPACK_IMPORTED_MODULE_24__["ParameterCheckboxComponent"],
                _components_script_form_parameters_form_data_parameter_form_figure_parameter_form_figure_parameter_form_component__WEBPACK_IMPORTED_MODULE_25__["FigureParameterFormComponent"],
                _components_script_calculator_parameter_inputs_figures_parameter_figures_component__WEBPACK_IMPORTED_MODULE_26__["ParameterFiguresComponent"],
                _components_script_form_parameters_form_data_parameter_form_existing_figures_dialog_existing_figures_dialog_component__WEBPACK_IMPORTED_MODULE_27__["ExistingFiguresDialogComponent"],
                _components_script_form_translation_form_script_translation_form_script_translation_form_component__WEBPACK_IMPORTED_MODULE_22__["ScriptTranslationFormComponent"],
                _components_script_form_translation_form_parameter_translation_form_parameter_translation_form_component__WEBPACK_IMPORTED_MODULE_23__["ParameterTranslationFormComponent"],
                _components_script_calculator_parameter_inputs_figures_button_figures_button_component__WEBPACK_IMPORTED_MODULE_28__["FiguresButtonComponent"]
            ],
            imports: [
                _pipes_module_pipes_module__WEBPACK_IMPORTED_MODULE_36__["PipesModule"],
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__["BrowserAnimationsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
                _md_components_module_md_components_module__WEBPACK_IMPORTED_MODULE_37__["MdComponentsModule"],
                _ngx_translate_core__WEBPACK_IMPORTED_MODULE_39__["TranslateModule"].forRoot({
                    loader: {
                        provide: _ngx_translate_core__WEBPACK_IMPORTED_MODULE_39__["TranslateLoader"],
                        useClass: _services_translation_service__WEBPACK_IMPORTED_MODULE_40__["TranslateLanguageLoader"]
                    }
                })
            ],
            entryComponents: [
                _components_script_form_parameters_form_data_parameter_form_existing_figures_dialog_existing_figures_dialog_component__WEBPACK_IMPORTED_MODULE_27__["ExistingFiguresDialogComponent"],
                _components_script_calculator_parameter_inputs_figures_parameter_figures_component__WEBPACK_IMPORTED_MODULE_26__["ParameterFiguresComponent"]
            ],
            exports: [
                _components_script_cards_script_cards_component__WEBPACK_IMPORTED_MODULE_11__["ScriptCardsComponent"]
            ],
            providers: [
                _services_script_service__WEBPACK_IMPORTED_MODULE_29__["ScriptService"],
                _services_tag_service__WEBPACK_IMPORTED_MODULE_30__["TagService"],
                _services_calculation_service__WEBPACK_IMPORTED_MODULE_31__["CalculationService"],
                _services_parameter_service__WEBPACK_IMPORTED_MODULE_32__["ParameterService"],
                _services_figure_service__WEBPACK_IMPORTED_MODULE_38__["FigureService"],
                _services_translations_script_translation_service__WEBPACK_IMPORTED_MODULE_34__["ScriptTranslationService"],
                _services_translations_parameter_translation_service__WEBPACK_IMPORTED_MODULE_33__["ParameterTranslationService"],
                { provide: _angular_core__WEBPACK_IMPORTED_MODULE_0__["ErrorHandler"], useClass: _common_errors_app_error_handler__WEBPACK_IMPORTED_MODULE_35__["AppErrorHandler"] }
            ]
        })
    ], ScriptInterpreterModule);
    return ScriptInterpreterModule;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/calculation.service.ts":
/*!****************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/calculation.service.ts ***!
  \****************************************************************************/
/*! exports provided: CalculationService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CalculationService", function() { return CalculationService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../services/translation.service */ "./src/app/services/translation.service.ts");
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
    function CalculationService(http, translationService) {
        this.http = http;
        this.translationService = translationService;
    }
    CalculationService.prototype.calculate = function (scriptId, parameters, language) {
        return this.http.put('/api/scripts/' + scriptId + '/calculate/' + (language || this.translationService.getCurrentLanguage()), parameters);
    };
    CalculationService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"] },
        { type: _services_translation_service__WEBPACK_IMPORTED_MODULE_2__["TranslationService"] }
    ]; };
    CalculationService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"],
            _services_translation_service__WEBPACK_IMPORTED_MODULE_2__["TranslationService"]])
    ], CalculationService);
    return CalculationService;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/figure.service.ts":
/*!***********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/figure.service.ts ***!
  \***********************************************************************/
/*! exports provided: FigureService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FigureService", function() { return FigureService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
    FigureService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"] }
    ]; };
    FigureService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
    ], FigureService);
    return FigureService;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/parameter.service.ts":
/*!**************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/parameter.service.ts ***!
  \**************************************************************************/
/*! exports provided: ParameterService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterService", function() { return ParameterService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../services/translation.service */ "./src/app/services/translation.service.ts");
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
    function ParameterService(http, translationService) {
        this.http = http;
        this.translationService = translationService;
    }
    ParameterService.prototype.getParameters = function (scriptId, language) {
        return this.http.get('/api/scripts/' + scriptId + '/parameters/' + (language || this.translationService.getCurrentLanguage()));
    };
    ParameterService.prototype.create = function (scriptId, parameter) {
        return this.http.post('/api/scripts/' + scriptId + '/parameters', parameter);
    };
    ParameterService.prototype.update = function (scriptId, parameter) {
        return this.http.put('/api/scripts/' + scriptId + '/parameters/' + parameter.id, parameter);
    };
    ParameterService.prototype.delete = function (scriptId, parameterId) {
        return this.http.delete('/api/scripts/' + scriptId + '/parameters/' + parameterId);
    };
    ParameterService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"] },
        { type: _services_translation_service__WEBPACK_IMPORTED_MODULE_2__["TranslationService"] }
    ]; };
    ParameterService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"],
            _services_translation_service__WEBPACK_IMPORTED_MODULE_2__["TranslationService"]])
    ], ParameterService);
    return ParameterService;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/script.service.ts":
/*!***********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/script.service.ts ***!
  \***********************************************************************/
/*! exports provided: ScriptService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptService", function() { return ScriptService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../common/errors/app-error */ "./src/app/common/errors/app-error.ts");
/* harmony import */ var _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../common/errors/bad-input-error */ "./src/app/common/errors/bad-input-error.ts");
/* harmony import */ var _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../common/errors/not-found-error */ "./src/app/common/errors/not-found-error.ts");
/* harmony import */ var _services_translation_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../services/translation.service */ "./src/app/services/translation.service.ts");
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
    function ScriptService(http, translationService) {
        this.http = http;
        this.translationService = translationService;
    }
    ScriptService.prototype.getScripts = function (language) {
        return this.http.get('/api/scripts/' + (language || this.translationService.getCurrentLanguage()))
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.getScript = function (id, language) {
        return this.http.get('/api/scripts/' + id + '/' + (language || this.translationService.getCurrentLanguage()))
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.delete = function (id) {
        return this.http.delete('/api/scripts/' + id)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.create = function (script) {
        return this.http.post('/api/scripts', script)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_5__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.prototype.update = function (script) {
        return this.http.put('/api/scripts/' + script.id, script)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_5__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"] },
        { type: _services_translation_service__WEBPACK_IMPORTED_MODULE_7__["TranslationService"] }
    ]; };
    ScriptService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"],
            _services_translation_service__WEBPACK_IMPORTED_MODULE_7__["TranslationService"]])
    ], ScriptService);
    return ScriptService;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/tag.service.ts":
/*!********************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/tag.service.ts ***!
  \********************************************************************/
/*! exports provided: TagService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TagService", function() { return TagService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
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
    TagService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"] }
    ]; };
    TagService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], TagService);
    return TagService;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/translations/parameter-translation.service.ts":
/*!***************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/translations/parameter-translation.service.ts ***!
  \***************************************************************************************************/
/*! exports provided: ParameterTranslationService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParameterTranslationService", function() { return ParameterTranslationService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../common/errors/app-error */ "./src/app/common/errors/app-error.ts");
/* harmony import */ var _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../common/errors/not-found-error */ "./src/app/common/errors/not-found-error.ts");
/* harmony import */ var _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../common/errors/bad-input-error */ "./src/app/common/errors/bad-input-error.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ParameterTranslationService = /** @class */ (function () {
    function ParameterTranslationService(http) {
        this.http = http;
    }
    ParameterTranslationService.prototype.getParametersTranslation = function (scriptId, language) {
        return this.http.get('/api/parametersTranslations/' + scriptId + '/' + language)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ParameterTranslationService.prototype.update = function (parameterTranslation) {
        return this.http.put('/api/parametersTranslations/' + parameterTranslation.id, parameterTranslation)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ParameterTranslationService.prototype.create = function (parameterTranslation) {
        return this.http.post('/api/parametersTranslations', parameterTranslation)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ParameterTranslationService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"] }
    ]; };
    ParameterTranslationService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
    ], ParameterTranslationService);
    return ParameterTranslationService;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/translations/script-translation.service.ts":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/translations/script-translation.service.ts ***!
  \************************************************************************************************/
/*! exports provided: ScriptTranslationService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ScriptTranslationService", function() { return ScriptTranslationService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../common/errors/app-error */ "./src/app/common/errors/app-error.ts");
/* harmony import */ var _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../common/errors/bad-input-error */ "./src/app/common/errors/bad-input-error.ts");
/* harmony import */ var _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../common/errors/not-found-error */ "./src/app/common/errors/not-found-error.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ScriptTranslationService = /** @class */ (function () {
    function ScriptTranslationService(http) {
        this.http = http;
    }
    ScriptTranslationService.prototype.getScriptTranslation = function (scriptId, language) {
        return this.http.get('/api/scriptsTranslations/' + scriptId + '/' + language)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptTranslationService.prototype.create = function (scriptTranslation) {
        return this.http.post('/api/scriptsTranslations', scriptTranslation)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_5__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptTranslationService.prototype.update = function (scriptTranslation) {
        return this.http.put('/api/scriptsTranslations/' + scriptTranslation.id, scriptTranslation)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_5__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptTranslationService.prototype.remove = function (id) {
        return this.http.delete('/api/scriptsTranslations/' + id)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_6__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ScriptTranslationService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"] }
    ]; };
    ScriptTranslationService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
    ], ScriptTranslationService);
    return ScriptTranslationService;
}());



/***/ }),

/***/ "./src/app/modules/script-interpreter/services/translations/value-option-translation.service.ts":
/*!******************************************************************************************************!*\
  !*** ./src/app/modules/script-interpreter/services/translations/value-option-translation.service.ts ***!
  \******************************************************************************************************/
/*! exports provided: ValueOptionTranslationService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValueOptionTranslationService", function() { return ValueOptionTranslationService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../common/errors/app-error */ "./src/app/common/errors/app-error.ts");
/* harmony import */ var _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../common/errors/not-found-error */ "./src/app/common/errors/not-found-error.ts");
/* harmony import */ var _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../common/errors/bad-input-error */ "./src/app/common/errors/bad-input-error.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ValueOptionTranslationService = /** @class */ (function () {
    function ValueOptionTranslationService(http) {
        this.http = http;
    }
    ValueOptionTranslationService.prototype.getValueOptionsTranslations = function (parameterId, language) {
        return this.http.get('/api/valueOptionsTranslations/' + parameterId + '/' + language)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ValueOptionTranslationService.prototype.update = function (valueOptionTranslation) {
        return this.http.put('/api/valueOptionsTranslations/' + valueOptionTranslation.id, valueOptionTranslation)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ValueOptionTranslationService.prototype.create = function (valueOptionTranslation) {
        return this.http.post('/api/valueOptionsTranslations', valueOptionTranslation)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["retry"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            if (error.status === 400)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_bad_input_error__WEBPACK_IMPORTED_MODULE_6__["BadInputError"](error));
            if (error.status === 404)
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_not_found_error__WEBPACK_IMPORTED_MODULE_5__["NotFoundError"](error));
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new _common_errors_app_error__WEBPACK_IMPORTED_MODULE_4__["AppError"](error));
        }));
    };
    ValueOptionTranslationService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"] }
    ]; };
    ValueOptionTranslationService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
    ], ValueOptionTranslationService);
    return ValueOptionTranslationService;
}());



/***/ }),

/***/ "./src/app/services/auth.interceptor.ts":
/*!**********************************************!*\
  !*** ./src/app/services/auth.interceptor.ts ***!
  \**********************************************/
/*! exports provided: AuthInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthInterceptor", function() { return AuthInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _auth_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./auth.service */ "./src/app/services/auth.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var AuthInterceptor = /** @class */ (function () {
    function AuthInterceptor(injector) {
        this.injector = injector;
    }
    AuthInterceptor.prototype.intercept = function (request, next) {
        var auth = this.injector.get(_auth_service__WEBPACK_IMPORTED_MODULE_1__["AuthService"]);
        var token = (auth.isLoggedIn()) ? auth.getAuth().token : null;
        if (token) {
            request = request.clone({
                setHeaders: {
                    Authorization: "Bearer " + token
                }
            });
        }
        return next.handle(request);
    };
    AuthInterceptor.ctorParameters = function () { return [
        { type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"] }
    ]; };
    AuthInterceptor = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"]])
    ], AuthInterceptor);
    return AuthInterceptor;
}());



/***/ }),

/***/ "./src/app/services/auth.response.interceptor.ts":
/*!*******************************************************!*\
  !*** ./src/app/services/auth.response.interceptor.ts ***!
  \*******************************************************/
/*! exports provided: AuthResponseInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthResponseInterceptor", function() { return AuthResponseInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var _auth_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./auth.service */ "./src/app/services/auth.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var AuthResponseInterceptor = /** @class */ (function () {
    function AuthResponseInterceptor(injector, router) {
        this.injector = injector;
        this.router = router;
    }
    AuthResponseInterceptor.prototype.intercept = function (request, next) {
        var _this = this;
        this.auth = this.injector.get(_auth_service__WEBPACK_IMPORTED_MODULE_3__["AuthService"]);
        var token = (this.auth.isLoggedIn()) ? this.auth.getAuth().token : null;
        if (token) {
            // Zapamiętaj aktualne żądanie
            this.currentRequest = request;
            return next.handle(request)
                .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_5__["tap"])(function (event) {
                if (event instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpResponse"]) {
                    // Nic nie rób
                }
            }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_5__["catchError"])(function (error) {
                return _this.handleError(error, next);
            }));
        }
        else {
            return next.handle(request);
        }
    };
    AuthResponseInterceptor.prototype.handleError = function (err, next) {
        var _this = this;
        if (err instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpErrorResponse"]) {
            if (err.status === 401) {
                // Token JWT mógł przestać być ważny:
                // spróbuj otrzymać nowy za pomocą tokena odświeżania
                console.log("Token nieważny. Próba odświeżenia...");
                // Zapamiętaj aktualne żądanie jako poprzednie
                var previousRequest = this.currentRequest;
                // Za poniższy kod dziękuję użytkownikowi @mattjones61
                return this.auth.refreshToken()
                    .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_5__["flatMap"])(function (refreshed) {
                    var token = (_this.auth.isLoggedIn()) ? _this.auth.getAuth().token : null;
                    if (token) {
                        previousRequest = previousRequest.clone({
                            setHeaders: { Authorization: "Bearer " + token }
                        });
                        console.log("Reset tokena z nagłówka");
                    }
                    return next.handle(previousRequest);
                }));
            }
        }
        return rxjs__WEBPACK_IMPORTED_MODULE_2__["Observable"].throw(err);
    };
    AuthResponseInterceptor.ctorParameters = function () { return [
        { type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__["Router"] }
    ]; };
    AuthResponseInterceptor = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"],
            _angular_router__WEBPACK_IMPORTED_MODULE_4__["Router"]])
    ], AuthResponseInterceptor);
    return AuthResponseInterceptor;
}());



/***/ }),

/***/ "./src/app/services/auth.service.ts":
/*!******************************************!*\
  !*** ./src/app/services/auth.service.ts ***!
  \******************************************/
/*! exports provided: AuthService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthService", function() { return AuthService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
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




var AuthService = /** @class */ (function () {
    function AuthService(http, platformId) {
        this.http = http;
        this.platformId = platformId;
        this.authKey = "auth";
        this.clientId = "TestMakerFree";
    }
    // Przeprowadź logowanie
    AuthService.prototype.login = function (username, password) {
        var url = "api/token/auth";
        var data = {
            username: username,
            password: password,
            client_id: this.clientId,
            // Wymagane do zalogowania się przy użyciu nazwy użytkownika i hasła
            grant_type: "password",
            // Oddzielona spacjami lista zakresów, dla których token będzie ważny
            scope: "offline_access profile email"
        };
        return this.getAuthFromServer(url, data);
    };
    // Spróbuj odświeżyć token
    AuthService.prototype.refreshToken = function () {
        var url = "api/token/auth";
        var data = {
            client_id: this.clientId,
            // Wymagane do zalogowania się przy użyciu nazwy użytkownika i hasła
            grant_type: "refresh_token",
            refresh_token: this.getAuth().refresh_token,
            // Oddzielona spacjami lista zakresów, dla których token będzie ważny
            scope: "offline_access profile email"
        };
        return this.getAuthFromServer(url, data);
    };
    // Pobierz z serwera tokeny (dostępowy i odświeżania)
    AuthService.prototype.getAuthFromServer = function (url, data) {
        var _this = this;
        return this.http.post(url, data)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["map"])(function (res) {
            var token = res && res.token;
            // Jeśli jest token, logowanie się udało
            if (token) {
                // Zapamiętaj nazwę użytkownika i tokeny
                _this.setAuth(res);
                // Logowanie udane
                return true;
            }
            // Logowanie nieudane
            return rxjs__WEBPACK_IMPORTED_MODULE_2__["Observable"].throw('Unauthorized');
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (error) {
            return new rxjs__WEBPACK_IMPORTED_MODULE_2__["Observable"](error);
        }));
    };
    // Przeprowadź wylogowanie
    AuthService.prototype.logout = function () {
        this.setAuth(null);
        return true;
    };
    // Umieść dane o uwierzytelnieniu w localStorage lub usuń dane, jeśli przekazano NULL
    AuthService.prototype.setAuth = function (auth) {
        if (auth) {
            localStorage.setItem(this.authKey, JSON.stringify(auth));
        }
        else {
            localStorage.removeItem(this.authKey);
        }
        return true;
    };
    // Pobiera obiekt z danymi uwierzytelnienia (lub zwraca NULL, jeśli nie istnieje)
    AuthService.prototype.getAuth = function () {
        var i = localStorage.getItem(this.authKey);
        if (i) {
            return JSON.parse(i);
        }
        else {
            return null;
        }
    };
    // Zwraca TRUE, jeśli użytkownik jest zalogowany lub FALSE w sytuacji przeciwnej
    AuthService.prototype.isLoggedIn = function () {
        return localStorage.getItem(this.authKey) != null;
    };
    AuthService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"] },
        { type: undefined, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"], args: [_angular_core__WEBPACK_IMPORTED_MODULE_0__["PLATFORM_ID"],] }] }
    ]; };
    AuthService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __param(1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])(_angular_core__WEBPACK_IMPORTED_MODULE_0__["PLATFORM_ID"])),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"], Object])
    ], AuthService);
    return AuthService;
}());



/***/ }),

/***/ "./src/app/services/configuration.service.ts":
/*!***************************************************!*\
  !*** ./src/app/services/configuration.service.ts ***!
  \***************************************************/
/*! exports provided: ConfigurationService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ConfigurationService", function() { return ConfigurationService; });
/* harmony import */ var _translation_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./translation.service */ "./src/app/services/translation.service.ts");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _db_keys__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./db-keys */ "./src/app/services/db-keys.ts");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var _local_store_manager_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./local-store-manager.service */ "./src/app/services/local-store-manager.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var ConfigurationService = /** @class */ (function () {
    function ConfigurationService(localStorage, translationService) {
        this.localStorage = localStorage;
        this.translationService = translationService;
        this._language = null;
        this.onConfigurationImported = new rxjs__WEBPACK_IMPORTED_MODULE_3__["Subject"]();
        this.configurationImported$ = this.onConfigurationImported.asObservable();
        this.loadLocalChanges();
    }
    ConfigurationService_1 = ConfigurationService;
    Object.defineProperty(ConfigurationService.prototype, "language", {
        get: function () {
            return this._language || ConfigurationService_1.defaultLanguage;
        },
        set: function (value) {
            this._language = value;
            this.saveToLocalStore(value, _db_keys__WEBPACK_IMPORTED_MODULE_2__["DBkeys"].LANGUAGE);
            this.translationService.changeLanguage(value);
        },
        enumerable: true,
        configurable: true
    });
    ConfigurationService.prototype.loadLocalChanges = function () {
        if (this.localStorage.exists(_db_keys__WEBPACK_IMPORTED_MODULE_2__["DBkeys"].LANGUAGE)) {
            this._language = this.localStorage.getDataObject(_db_keys__WEBPACK_IMPORTED_MODULE_2__["DBkeys"].LANGUAGE);
            this.translationService.changeLanguage(this._language);
        }
        else {
            this.resetLanguage();
        }
    };
    ConfigurationService.prototype.saveToLocalStore = function (data, key) {
        var _this = this;
        setTimeout(function () { return _this.localStorage.savePermanentData(data, key); });
    };
    ConfigurationService.prototype.resetLanguage = function () {
        var language = this.translationService.useBrowserLanguage();
        if (language)
            this._language = language;
        else
            this._language = this.translationService.useDefaultLangage();
    };
    var ConfigurationService_1;
    ConfigurationService.defaultLanguage = 'en';
    ConfigurationService.ctorParameters = function () { return [
        { type: _local_store_manager_service__WEBPACK_IMPORTED_MODULE_4__["LocalStoreManager"] },
        { type: _translation_service__WEBPACK_IMPORTED_MODULE_0__["TranslationService"] }
    ]; };
    ConfigurationService = ConfigurationService_1 = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root',
        }),
        __metadata("design:paramtypes", [_local_store_manager_service__WEBPACK_IMPORTED_MODULE_4__["LocalStoreManager"],
            _translation_service__WEBPACK_IMPORTED_MODULE_0__["TranslationService"]])
    ], ConfigurationService);
    return ConfigurationService;
}());



/***/ }),

/***/ "./src/app/services/db-keys.ts":
/*!*************************************!*\
  !*** ./src/app/services/db-keys.ts ***!
  \*************************************/
/*! exports provided: DBkeys */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DBkeys", function() { return DBkeys; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var DBkeys = /** @class */ (function () {
    function DBkeys() {
    }
    DBkeys.LANGUAGE = 'language';
    DBkeys.PAGEINDEX = 'pageIndex';
    DBkeys.PAGESIZE = 'pageSize';
    DBkeys = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])()
    ], DBkeys);
    return DBkeys;
}());



/***/ }),

/***/ "./src/app/services/local-store-manager.service.ts":
/*!*********************************************************!*\
  !*** ./src/app/services/local-store-manager.service.ts ***!
  \*********************************************************/
/*! exports provided: LocalStoreManager */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LocalStoreManager", function() { return LocalStoreManager; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _utilities__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./utilities */ "./src/app/services/utilities.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var LocalStoreManager = /** @class */ (function () {
    function LocalStoreManager() {
        this.syncKeys = [];
        this.reservedKeys = [
            'sync_keys',
            'addToSyncKeys',
            'removeFromSyncKeys',
            'getSessionStorage',
            'setSessionStorage',
            'addToSessionStorage',
            'removeFromSessionStorage',
            'clearAllSessionsStorage'
        ];
    }
    LocalStoreManager_1 = LocalStoreManager;
    LocalStoreManager.prototype.savePermanentData = function (data, key) {
        if (key === void 0) { key = LocalStoreManager_1.DBKEY_USER_DATA; }
        this.testForInvalidKeys(key);
        this.removeFromSessionStorage(key);
        this.localStorageSetItem(key, data);
    };
    LocalStoreManager.prototype.exists = function (key) {
        if (key === void 0) { key = LocalStoreManager_1.DBKEY_USER_DATA; }
        var data = sessionStorage.getItem(key);
        if (data == null)
            data = localStorage.getItem(key);
        return data != null;
    };
    LocalStoreManager.prototype.getDataObject = function (key, isDateType) {
        if (key === void 0) { key = LocalStoreManager_1.DBKEY_USER_DATA; }
        if (isDateType === void 0) { isDateType = false; }
        var data = this.getData(key);
        if (data != null) {
            if (isDateType)
                data = new Date(data);
            return data;
        }
        else
            return null;
    };
    LocalStoreManager.prototype.getData = function (key) {
        if (key === void 0) { key = LocalStoreManager_1.DBKEY_USER_DATA; }
        this.testForInvalidKeys(key);
        var data = this.sessionStorageGetItem(key);
        if (data == null) {
            data = this.localStorageGetItem(key);
        }
        return data;
    };
    LocalStoreManager.prototype.removeFromSessionStorage = function (keyToRemove) {
        this.removeFromSessionStorageHelper(keyToRemove);
        this.removeFromSyncKeysBackup(keyToRemove);
        localStorage.setItem('removeFromSessionStorage', keyToRemove);
        localStorage.removeItem('removeFromSessionStorage');
    };
    LocalStoreManager.prototype.removeFromSessionStorageHelper = function (keyToRemove) {
        sessionStorage.removeItem(keyToRemove);
        this.removeFromSyncKeysHelper(keyToRemove);
    };
    LocalStoreManager.prototype.removeFromSyncKeysBackup = function (key) {
        var storedSyncKeys = this.getSyncKeysFromStorage();
        var index = storedSyncKeys.indexOf(key);
        if (index > -1) {
            storedSyncKeys.splice(index, 1);
            this.localStorageSetItem(LocalStoreManager_1.DBKEY_SYNC_KEYS, storedSyncKeys);
        }
    };
    LocalStoreManager.prototype.getSyncKeysFromStorage = function (defaultValue) {
        if (defaultValue === void 0) { defaultValue = []; }
        var data = this.localStorageGetItem(LocalStoreManager_1.DBKEY_SYNC_KEYS);
        if (data == null)
            return defaultValue;
        else
            return data;
    };
    LocalStoreManager.prototype.removeFromSyncKeysHelper = function (key) {
        var index = this.syncKeys.indexOf(key);
        if (index > -1) {
            this.syncKeys.splice(index, 1);
        }
    };
    LocalStoreManager.prototype.testForInvalidKeys = function (key) {
        if (!key) {
            throw new Error('key cannot be empty');
        }
        if (this.reservedKeys.some(function (x) { return x == key; })) {
            throw new Error("The storage key \"" + key + "\" is reserved and cannot be used. Please use a different key");
        }
    };
    LocalStoreManager.prototype.localStorageSetItem = function (key, data) {
        localStorage.setItem(key, JSON.stringify(data));
    };
    LocalStoreManager.prototype.localStorageGetItem = function (key) {
        return _utilities__WEBPACK_IMPORTED_MODULE_1__["Utilities"].JsonTryParse(localStorage.getItem(key));
    };
    LocalStoreManager.prototype.sessionStorageGetItem = function (key) {
        return _utilities__WEBPACK_IMPORTED_MODULE_1__["Utilities"].JsonTryParse(sessionStorage.getItem(key));
    };
    var LocalStoreManager_1;
    LocalStoreManager.DBKEY_USER_DATA = 'user_data';
    LocalStoreManager.DBKEY_SYNC_KEYS = 'sync_keys';
    LocalStoreManager = LocalStoreManager_1 = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])()
        /**
        * Provides a wrapper for accessing the web storage API and synchronizing session storage across tabs/windows.
        */
    ], LocalStoreManager);
    return LocalStoreManager;
}());



/***/ }),

/***/ "./src/app/services/search.service.ts":
/*!********************************************!*\
  !*** ./src/app/services/search.service.ts ***!
  \********************************************/
/*! exports provided: SearchService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SearchService", function() { return SearchService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var SearchService = /** @class */ (function () {
    function SearchService() {
        this.onSearch = new rxjs__WEBPACK_IMPORTED_MODULE_1__["Subject"]();
        this.searched$ = this.onSearch.asObservable();
    }
    SearchService.prototype.search = function (value) {
        var _this = this;
        setTimeout(function () {
            _this.onSearch.next(value);
        });
    };
    SearchService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root',
        }),
        __metadata("design:paramtypes", [])
    ], SearchService);
    return SearchService;
}());



/***/ }),

/***/ "./src/app/services/translation.service.ts":
/*!*************************************************!*\
  !*** ./src/app/services/translation.service.ts ***!
  \*************************************************/
/*! exports provided: TranslationService, TranslateLanguageLoader */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TranslationService", function() { return TranslationService; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TranslateLanguageLoader", function() { return TranslateLanguageLoader; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _ngx_translate_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @ngx-translate/core */ "./node_modules/@ngx-translate/core/fesm5/ngx-translate-core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TranslationService = /** @class */ (function () {
    function TranslationService(translate) {
        this.translate = translate;
        this.languages = ['en', 'pl', 'de'];
        this.onLanguageChanged = new rxjs__WEBPACK_IMPORTED_MODULE_2__["Subject"]();
        this.languageChanged$ = this.onLanguageChanged.asObservable();
        this.addLanguages(this.languages);
        this.setDefaultLanguage('en');
    }
    TranslationService.prototype.addLanguages = function (lang) {
        this.translate.addLangs(lang);
    };
    TranslationService.prototype.setDefaultLanguage = function (lang) {
        this.translate.setDefaultLang(lang);
    };
    TranslationService.prototype.getDefaultLanguage = function () {
        return this.translate.defaultLang;
    };
    TranslationService.prototype.getBrowserLanguage = function () {
        return this.translate.getBrowserLang();
    };
    TranslationService.prototype.getCurrentLanguage = function () {
        return this.translate.currentLang;
    };
    TranslationService.prototype.getLoadedLanguages = function () {
        return this.translate.langs;
    };
    TranslationService.prototype.useBrowserLanguage = function () {
        var browserLang = this.getBrowserLanguage();
        if (browserLang.match(/en|pl|de/)) {
            this.changeLanguage(browserLang);
            return browserLang;
        }
    };
    TranslationService.prototype.useDefaultLangage = function () {
        return this.changeLanguage(null);
    };
    TranslationService.prototype.changeLanguage = function (language) {
        var _this = this;
        if (!language) {
            language = this.getDefaultLanguage();
        }
        if (language != this.translate.currentLang) {
            setTimeout(function () {
                _this.translate.use(language);
                _this.onLanguageChanged.next(language);
            });
        }
        return language;
    };
    TranslationService.prototype.getTranslation = function (key, interpolateParams) {
        return this.translate.instant(key, interpolateParams);
    };
    TranslationService.prototype.getTranslationAsync = function (key, interpolateParams) {
        return this.translate.get(key, interpolateParams);
    };
    TranslationService.LanguageCodes = [{ 'en': 0 }, { 'pl': 1 }, { 'de': 2 }];
    TranslationService.ctorParameters = function () { return [
        { type: _ngx_translate_core__WEBPACK_IMPORTED_MODULE_1__["TranslateService"] }
    ]; };
    TranslationService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root',
        }),
        __metadata("design:paramtypes", [_ngx_translate_core__WEBPACK_IMPORTED_MODULE_1__["TranslateService"]])
    ], TranslationService);
    return TranslationService;
}());

var TranslateLanguageLoader = /** @class */ (function () {
    function TranslateLanguageLoader() {
    }
    TranslateLanguageLoader.prototype.getTranslation = function (lang) {
        switch (lang) {
            case 'en':
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(__webpack_require__(/*! ../../assets/locale/en.json */ "./src/assets/locale/en.json"));
            case 'pl':
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(__webpack_require__(/*! ../../assets/locale/pl.json */ "./src/assets/locale/pl.json"));
            case 'de':
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(__webpack_require__(/*! ../../assets/locale/de.json */ "./src/assets/locale/de.json"));
            default:
        }
    };
    return TranslateLanguageLoader;
}());



/***/ }),

/***/ "./src/app/services/utilities.ts":
/*!***************************************!*\
  !*** ./src/app/services/utilities.ts ***!
  \***************************************/
/*! exports provided: Utilities */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Utilities", function() { return Utilities; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var Utilities = /** @class */ (function () {
    function Utilities() {
    }
    Utilities.JsonTryParse = function (value) {
        try {
            return JSON.parse(value);
        }
        catch (e) {
            if (value === 'undefined') {
                return void 0;
            }
            return value;
        }
    };
    Utilities = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])()
    ], Utilities);
    return Utilities;
}());



/***/ }),

/***/ "./src/assets/locale/de.json":
/*!***********************************!*\
  !*** ./src/assets/locale/de.json ***!
  \***********************************/
/*! exports provided: app, login, register, carousel, about, deadLoadsModule, snowLoadsModule, scriptsForm, scriptCard, scriptCalculator, default */
/***/ (function(module) {

module.exports = {"app":{"Home":"Hauptseite","NewScript":"Neues Skript","About":"Über das Projekt","Loads":{"Header":"Last","DeadLoads":"Eigenlasten","SnowLoads":"Schneelasten"},"Register":"Register","LogIn":"Log in","LogOut":"Log out","Languages":{"Language":"Sprache","English":"Englisch","Polish":"Polieren","German":"Deutsche"},"Search":"Search"},"login":{"Title":"Log in","UsernameOrEmail":"Username or email address","WriteProperUsernameOrPassword":"Write proper username or password.","Password":"Password","WritePassword":"Write password.","RememberMe":"Remember me","LogIn":"Log in","ForgotPassword":"Forgot password?","DontHaveAccount":"Don't have account? Click here to create one!"},"register":{"RegisterNewUser":"Register new user","WriteUsername":"Write username...","WriteProperUsername":"Write proper username.","WriteEmail":"Write email...","WriteProperEmail":"Write proper email.","WritePassword":"Write password...","WriteProperPassword":"Write proper password.","RepeatPassword":"Repeat password...","WrongPasswordConfirmation":"Password and its confirmation are not the same.","WriteDisplayedName":"Write displayed name...","WriteProperDisplayedName":"Write proper displayed name.","Register":"Register","Cancel":"Cancel"},"carousel":{"Next":"Suche","Previous":"Bisherige","SnowLoads":{"Header":"Schneelasten","Description":"Rechner für Schneelasten auschecken."},"DeadLoads":{"Header":"Eigenlasten","Description":"Überprüfen Sie die Taschenrechner auf tote Lasten."},"About":{"Header":"Über das Projekt","Description":"Lesen Sie mehr über das Projekt und den Autor dieser Website."}},"about":{"Overall":{"Header":"Overall informations","Description":"The site contains a large number of calculators which based mostly on Eurocodes with Polish national annexes."},"SnowLoad":{"Header":"Snow load calculators","Description":"Mostly based on <i>Eurocode 1 - Actions on structures Part 1-3: General actions - Snow loads</i> with Polish national annex. <br/>This calculator contains all possible design situations and roof types which are described in the document. <br/>This calculators shouldn't be used for or doesn't have informations how to calculate:","List":["sites at altitudes above 1 500m,","impact snow loads resulting from sliding off or falling from a higher roof,","additional wind loads which could result from changes in shape or size of the construction works due to the presence of snow or the accretion of ice,","loads in areas where snow is present all year round,","ice loading,","lateral loading due to snow (e.g. lateral loads exerted by drifts),","snow loads on bridges."]},"DeadLoad":{"Header":"Dead load calculator","Description":"Mostly based on <i>Eurocode 1 - Actions on structures Part 1-1: General actions - Densities, self-weight, imposed loads for buildings</i> with Polish national annex and on Polish standard document <i>PN-82/B-02001 Building loads - permanent loads</i> which contains informations about the density of the building materials. <br/>This calculator allows us to get the information about the weight of all layers in the structure."},"Author":{"Header":"Author: Konrad Kania","Description":"I graduated at the Technical University in £ód at the faculty of Civil Engineering. <br/>Currently, I also finished postgraduate studies at Polish Academy of Science and work for building company as a programmer since the beginning of March 2017. </br>I treat building designing with great passion the same as the programming. <br/>This way of doing things and possibilities which comes with those two branches bring me an idea to make something for overall usage. <br/>I started working on this site since September 2018 and I hope that there will be only more and better content available for everyone."}},"deadLoadsModule":{"Header":"Dead loads calculator","Categories":"Categories","Subcategories":"Subcategories","Name":"Name","MinimumDensity":"Minimum<br/>Density","MaximumDensity":"Maximum<br/>Density","Unit":"Unit","Add":"Add","Category":"Category","Length":"Length [cm]","Width":"Width [cm]","Thickness":"Thickness [cm]","Remove":"Remove","Total":"Total"},"snowLoadsModule":{"Header":"Snow loads calculators"},"scriptsForm":{"Header":"Script","AddScript":"Add Script","UpdateScript":"Update Script","ScriptData":{"Header":"Script data","Name":{"Header":"Name","Hint":"Script name","MinLengthError":"Name should be minimum {{requiredLength}} characters long.","MaxLengthError":"Name should be maximum {{requiredLength}} characters long.","RequiredError":" Name is <strong>required</strong>."},"Author":{"Header":"Author","Hint":"Script author","MaxLengthError":"Author name should be maximum {{requiredLength}} characters long."},"Document":{"Header":"Document","Hint":"Accoording to","MaxLengthError":"Document name should be maximum {{requiredLength}} characters long."},"Group":{"Header":"Group","Hint":"Category for a script","Statica":"Statica","Loads":"Loads","Concrete":"Concrete","Steel":"Steel","Timber":"Timber","Soils":"Soils","Other":"Other"},"DefaultLanguage":{"Hint":"Select default language","RequiredError":" Language is <strong>required</strong>."},"Description":{"Header":"Description","Hint":"Description for script","MinLengthError":"Description should be minimum {{requiredLength}} characters long.","MaxLengthError":"Description should be maximum {{requiredLength}} characters long.","RequiredError":" Description is <strong>required</strong>."},"IncludeNote":"Include Note","Note":{"Header":"Note","Hint":"Additional notes for script","MaxLengthError":"Note should be maximum {{requiredLength}} characters long."}},"Tags":{"Header":"Tags","AddNewTags":"Add new tags"},"Parameters":{"Header":"Parameters","ParametersFilterLabel":"Select parameters","AllParameters":"All parameters","DataParameters":"Data parameters","StaticParameters":"Static parameters","CalculationParameters":"Calculation parameters","Edit":"Edit","Remove":"Remove","NewParameter":"New parameter","EditMode":{"ParameterTypePicker":"Pick parameter type","ParameterTypes":{"Editable":"Editable","Static":"Static","Calculable":"Calculable","Visible":"Visible","Important":"Important","Optional":"Optional"},"Name":{"Header":"Name","Hint":"Parameter name","MaxLengthError":"Name should be maximum {{requiredLength}} characters long.","RequiredError":"Name is <strong>required</strong>."},"Unit":{"Header":"Unit","Hint":"Parameter unit","MaxLengthError":"Unit should be maximum {{requiredLength}} characters long."},"Document":{"Header":"Document","Hint":"Parameter according to","MaxLengthError":"Document name should be maximum {{requiredLength}} characters long."},"ValueType":{"Header":"Value Type","Hint":"Parameter value type","Number":"Number","Text":"Text"},"GroupName":{"Header":"Group name","Hint":"Group name for parameter","MaxLengthError":"Group name should be maximum {{requiredLength}} characters long."},"Value":{"Header":"Value","Hint":"Value for parameter","MaxLengthError":"Value should be maximum {{requiredLength}} characters long."},"Description":{"Header":"Description","Hint":"Description for parameter","MaxLengthError":"Description should be maximum {{requiredLength}} characters long."},"VisibilityValidator":{"Header":"Visibility validator","Hint":"Visibility validator","MaxLengthError":"Visibility validator should be maximum {{requiredLength}} characters long."},"DataValidator":{"Header":"Data validator","Hint":"Data validator","MaxLengthError":"Data validator should be maximum {{requiredLength}} characters long."},"Note":{"Header":"Note","Hint":"Additional notes for parameter","MaxLengthError":"Note should be maximum {{requiredLength}} characters long."},"Update":"Update"},"Add":"Add","ValueOptions":{"Header":"Value Options","Hint":"Provide some selectable data","None":"None","AllowAny":"Allow any values","Boolean":"Is boolean","Name":{"Header":"Name","Hint":"Name"},"Value":{"Header":"Value","Hint":"Value"},"Description":{"Header":"Description","Hint":"Description for value option"},"Remove":"Remove","Add":"Add"},"Figures":{"Header":"Pictures","Hint":"Provide additional pictures for parameter","Remove":"Remove"}},"Translations":{"Header":"Translations","Add":"Add Translation","Update":"Update Translation","Remove":"Remove"}},"scriptCard":{"Calculate":"Calculate","Edit":"Edit","Delete":"Delete"},"scriptCalculator":{"StaticData":"Static data","Calculate":"Calculate","Results":"Results","Controls":{"Default":"Default","True":"True","Figures":"Pictures"}}};

/***/ }),

/***/ "./src/assets/locale/en.json":
/*!***********************************!*\
  !*** ./src/assets/locale/en.json ***!
  \***********************************/
/*! exports provided: app, login, register, carousel, about, deadLoadsModule, snowLoadsModule, scriptsForm, scriptCard, scriptCalculator, default */
/***/ (function(module) {

module.exports = {"app":{"Home":"Home","NewScript":"New script","About":"About project","Loads":{"Header":"Loads","DeadLoads":"Dead Loads","SnowLoads":"Snow Loads"},"Register":"Register","LogIn":"Log in","LogOut":"Log out","Languages":{"Language":"Language","English":"English","Polish":"Polish","German":"German"},"Search":"Search"},"login":{"Title":"Log in","UsernameOrEmail":"Username or email address","WriteProperUsernameOrPassword":"Write proper username or password.","Password":"Password","WritePassword":"Write password.","RememberMe":"Remember me","LogIn":"Log in","ForgotPassword":"Forgot password?","DontHaveAccount":"Don't have account? Click here to create one!"},"register":{"RegisterNewUser":"Register new user","WriteUsername":"Write username...","WriteProperUsername":"Write proper username.","WriteEmail":"Write email...","WriteProperEmail":"Write proper email.","WritePassword":"Write password...","WriteProperPassword":"Write proper password.","RepeatPassword":"Repeat password...","WrongPasswordConfirmation":"Password and its confirmation are not the same.","WriteDisplayedName":"Write displayed name...","WriteProperDisplayedName":"Write proper displayed name.","Register":"Register","Cancel":"Cancel"},"carousel":{"Next":"Next","Previous":"Previous","SnowLoads":{"Header":"Snow Loads","Description":"Check out calculators for snow loads."},"DeadLoads":{"Header":"Dead Loads","Description":"Check out calculators for dead loads."},"About":{"Header":"About project","Description":"Read more about the project and the author of this site."}},"about":{"Overall":{"Header":"Overall informations","Description":"The site contains a large number of calculators which based mostly on Eurocodes with Polish national annexes."},"SnowLoad":{"Header":"Snow load calculators","Description":"Mostly based on <i>Eurocode 1 - Actions on structures Part 1-3: General actions - Snow loads</i> with Polish national annex. <br/>This calculator contains all possible design situations and roof types which are described in the document. <br/>This calculators shouldn't be used for or doesn't have informations how to calculate:","List":["sites at altitudes above 1 500m,","impact snow loads resulting from sliding off or falling from a higher roof,","additional wind loads which could result from changes in shape or size of the construction works due to the presence of snow or the accretion of ice,","loads in areas where snow is present all year round,","ice loading,","lateral loading due to snow (e.g. lateral loads exerted by drifts),","snow loads on bridges."]},"DeadLoad":{"Header":"Dead load calculator","Description":"Mostly based on <i>Eurocode 1 - Actions on structures Part 1-1: General actions - Densities, self-weight, imposed loads for buildings</i> with Polish national annex and on Polish standard document <i>PN-82/B-02001 Building loads - permanent loads</i> which contains informations about the density of the building materials. <br/>This calculator allows us to get the information about the weight of all layers in the structure."},"Author":{"Header":"Author: Konrad Kania","Description":"I graduated at the Technical University in £ódŸ at the faculty of Civil Engineering. <br/>Currently, I also finished postgraduate studies at Polish Academy of Science and work for building company as a programmer since the beginning of March 2017. </br>I treat building designing with great passion the same as the programming. <br/>This way of doing things and possibilities which comes with those two branches bring me an idea to make something for overall usage. <br/>I started working on this site since September 2018 and I hope that there will be only more and better content available for everyone."}},"deadLoadsModule":{"Header":"Dead loads calculator","Categories":"Categories","Subcategories":"Subcategories","Name":"Name","MinimumDensity":"Minimum<br/>Density","MaximumDensity":"Maximum<br/>Density","Unit":"Unit","Add":"Add","Category":"Category","Length":"Length [cm]","Width":"Width [cm]","Thickness":"Thickness [cm]","Remove":"Remove","Total":"Total"},"snowLoadsModule":{"Header":"Snow loads calculators"},"scriptsForm":{"Header":"Script","AddScript":"Add Script","UpdateScript":"Update Script","ScriptData":{"Header":"Script data","Name":{"Header":"Name","Hint":"Script name","MinLengthError":"Name should be minimum {{requiredLength}} characters long.","MaxLengthError":"Name should be maximum {{requiredLength}} characters long.","RequiredError":" Name is <strong>required</strong>."},"Author":{"Header":"Author","Hint":"Script author","MaxLengthError":"Author name should be maximum {{requiredLength}} characters long."},"Document":{"Header":"Document","Hint":"Accoording to","MaxLengthError":"Document name should be maximum {{requiredLength}} characters long."},"Group":{"Header":"Group","Hint":"Category for a script","Statica":"Statica","Loads":"Loads","Concrete":"Concrete","Steel":"Steel","Timber":"Timber","Soils":"Soils","Other":"Other"},"DefaultLanguage":{"Hint":"Select default language","RequiredError":" Language is <strong>required</strong>."},"Description":{"Header":"Description","Hint":"Description for script","MinLengthError":"Description should be minimum {{requiredLength}} characters long.","MaxLengthError":"Description should be maximum {{requiredLength}} characters long.","RequiredError":" Description is <strong>required</strong>."},"IncludeNote":"Include Note","Note":{"Header":"Note","Hint":"Additional notes for script","MaxLengthError":"Note should be maximum {{requiredLength}} characters long."}},"Tags":{"Header":"Tags","AddNewTags":"Add new tags"},"Parameters":{"Header":"Parameters","ParametersFilterLabel":"Select parameters","AllParameters":"All parameters","DataParameters":"Data parameters","StaticParameters":"Static parameters","CalculationParameters":"Calculation parameters","Edit":"Edit","Remove":"Remove","NewParameter":"New parameter","EditMode":{"ParameterTypePicker":"Pick parameter type","ParameterTypes":{"Editable":"Editable","Static":"Static","Calculable":"Calculable","Visible":"Visible","Important":"Important","Optional":"Optional"},"Name":{"Header":"Name","Hint":"Parameter name","MaxLengthError":"Name should be maximum {{requiredLength}} characters long.","RequiredError":"Name is <strong>required</strong>."},"Unit":{"Header":"Unit","Hint":"Parameter unit","MaxLengthError":"Unit should be maximum {{requiredLength}} characters long."},"Document":{"Header":"Document","Hint":"Parameter according to","MaxLengthError":"Document name should be maximum {{requiredLength}} characters long."},"ValueType":{"Header":"Value Type","Hint":"Parameter value type","Number":"Number","Text":"Text"},"GroupName":{"Header":"Group name","Hint":"Group name for parameter","MaxLengthError":"Group name should be maximum {{requiredLength}} characters long."},"Value":{"Header":"Value","Hint":"Value for parameter","MaxLengthError":"Value should be maximum {{requiredLength}} characters long."},"Description":{"Header":"Description","Hint":"Description for parameter","MaxLengthError":"Description should be maximum {{requiredLength}} characters long."},"VisibilityValidator":{"Header":"Visibility validator","Hint":"Visibility validator","MaxLengthError":"Visibility validator should be maximum {{requiredLength}} characters long."},"DataValidator":{"Header":"Data validator","Hint":"Data validator","MaxLengthError":"Data validator should be maximum {{requiredLength}} characters long."},"Note":{"Header":"Note","Hint":"Additional notes for parameter","MaxLengthError":"Note should be maximum {{requiredLength}} characters long."},"Update":"Update"},"Add":"Add","ValueOptions":{"Header":"Value Options","Hint":"Provide some selectable data","None":"None","AllowAny":"Allow any values","Boolean":"Is boolean","Name":{"Header":"Name","Hint":"Name"},"Value":{"Header":"Value","Hint":"Value"},"Description":{"Header":"Description","Hint":"Description for value option"},"Remove":"Remove","Add":"Add"},"Figures":{"Header":"Pictures","Hint":"Provide additional pictures for parameter","Remove":"Remove"}},"Translations":{"Header":"Translations","Add":"Add Translation","Update":"Update Translation","Remove":"Remove"}},"scriptCard":{"Calculate":"Calculate","Edit":"Edit","Delete":"Delete"},"scriptCalculator":{"StaticData":"Static data","Calculate":"Calculate","Results":"Results","Controls":{"Default":"Default","True":"True","Figures":"Pictures"}}};

/***/ }),

/***/ "./src/assets/locale/pl.json":
/*!***********************************!*\
  !*** ./src/assets/locale/pl.json ***!
  \***********************************/
/*! exports provided: app, login, register, carousel, about, deadLoadsModule, snowLoadsModule, scriptsForm, scriptCard, scriptCalculator, default */
/***/ (function(module) {

module.exports = {"app":{"Home":"Strona główna","NewScript":"Nowy skrypt","About":"O projekcie","Loads":{"Header":"Obciążenia","DeadLoads":"Stałe","SnowLoads":"Śnieg"},"Register":"Zarejestruj","LogIn":"Zaloguj","LogOut":"Wyloguj","Languages":{"Language":"Language","English":"Angielski","Polish":"Polski","German":"Niemiecki"},"Search":"Szukaj"},"login":{"Title":"Zaloguj się","UsernameOrEmail":"Nazwa użytkownika lub adres e-mail","WriteProperUsernameOrPassword":"Wpisz poprawną nazwę użytkownika lub adress e-mail.","Password":"Hasło","WritePassword":"Wpisz hasło.","RememberMe":"Zapamiętaj mnie","LogIn":"Zaloguj","ForgotPassword":"Zapomniałeś hasła?","DontHaveAccount":"Nie masz konta? Kliknij tu, aby je utworzyć!"},"register":{"RegisterNewUser":"Zarejestruj nowego użytkownika","WriteUsername":"Write username...","WriteProperUsername":"Proszę wpisać poprawną nazwę użytkownika.","WriteEmail":"Wpisz e-mail...","WriteProperEmail":"Wpisz właściwy adres e-mail.","WritePassword":"Wpisz hasło...","WriteProperPassword":"Wpisz poprawne hasło.","RepeatPassword":"Powtórz hasło...","WrongPasswordConfirmation":"Hasło i jego potwierdzenie nie są zgodne.","WriteDisplayedName":"Określ wyświetlaną nazwę użytkownika...","WriteProperDisplayedName":"Wpisz poprawną nazwę użytkownika do wyświetlania.","Register":"Zarejestruj","Cancel":"Anuluj"},"carousel":{"Next":"Następny","Previous":"Poprzedni","SnowLoads":{"Header":"Obciążenia śniegiem","Description":"Zobacz kalkulatory do obciążeń śniegiem."},"DeadLoads":{"Header":"Obciążenia stałe","Description":"Zobacz kalkulatory do obciążeń stałych."},"About":{"Header":"O projekcie","Description":"Przeczytaj więcej o projekcie i o autorze tej strony."}},"about":{"Overall":{"Header":"Ogólne informacje","Description":"Na stronie znajdziesz dużą liczbę kalkulatorów budowlanych z których większość bazuje na Eurokodach wraz z polskim aneksem."},"SnowLoad":{"Header":"Kalkulatory obciążenia śniegiem","Description":"Bazują głównie na <i>Eurokod 1 - Oddziaływania na konstrukcje Część 1-3: Oddziaływania ogólne - Obciążenie śniegiem</i> wraz z polskim załącznikiem krajowym. </br>Kalkulatory zawierają wszystkie przypadki obliczeniowe jakie zawarto w dokumencie. </br>Nie powinno się korzystać z tych kalkulatorów, bądź nie ma informacji jak obliczać, w przypadkach:","List":["konstrukcji znajdujących się ponad 1 500m n.p.m.,","uderzeniowego obciążenia śniegiem wynikającego z ześlizgu lub upadku śniegu z wyższego dachu,","dodatkowego obciążenia wiatrem, które mogłoby wynikać ze zmian kształtu lub rozmiarów budowli z powodu obecności śniegu lub osadzania lodu,","obciążenia na obszarach, gdzie śnieg zalega przez cały rok,","obciążenia oblodzeniem,","obciążenia bocznego wywieranego przez śnieg (np. obciążenia bocznego wywieranego przez zaspy),","obciążenia śniegiem mostów."]},"DeadLoad":{"Header":"Kalkulatory obciążeń stałych","Description":"Bazują głównie na <i>Eurokod 1 - Oddziaływania na konstrukcje Część 1-1: Oddziaływania ogólne - Ciężar objętościowy, ciężar własny, obciążenia użytkowe w budynkach</i> wraz z polskim załącznikiem krajowym oraz na polskim dokumencie <i>PN-82/B-02001 Obciążenia budowli - Obciążenia stałe</i>, który zawiera informacje o ciężarach objętościowych materiałów budowlanych. </br>Ten kalkulator pozawala na uzyskanie informacji o wadze poszczególnych warstw w konstrukcji."},"Author":{"Header":"Autor: Konrad Kania","Description":"Jestem absolwentem Politechniki Łódzkiej, kierunek Budownictwo. </br>Obecnie, skończyłem również studia podyplomowe w Polskiej Akademii Nauk i pracuję dla firmy budowlanej już od początku marca 2017 roku jako programista. </br>Traktuję budownictwo i programowanie z wielką pasją. </br>Takie podejście wraz z możliwościami jakie tkwią w tych dwóch branżach podsunęły mi pomysł na zrobienie czegoś do ogólnego użytku. </br>Zacząłem pracować nad tą stroną od września 2018 i mam nadzieję, że będzie tylko bogatsza w coraz to lepszą zawartość dostępną dla wszystkich."}},"deadLoadsModule":{"Header":"Kalkulator obciążeń stałych","Categories":"Kategorie","Subcategories":"Podkategorie","Name":"Nazwa","MinimumDensity":"Minimalny<br/>ciężar","MaximumDensity":"Maksymalny<br/>ciężar","Unit":"Jednostka","Add":"Dodaj","Category":"Kategoria","Length":"Długość [cm]","Width":"Szerokość [cm]","Thickness":"Grubość [cm]","Remove":"Usuń","Total":"Suma"},"snowLoadsModule":{"Header":"Kalkulatory obciążenia śniegiem"},"scriptsForm":{"Header":"Skrypt","AddScript":"Dodaj Skrypt","UpdateScript":"Aktualizuj Skrypt","ScriptData":{"Header":"Dane skryptu","Name":{"Header":"Nazwa","Hint":"Nazwa skryptu","MinLengthError":"Nazwa powinna mieć minimum {{requiredLength}} znaków.","MaxLengthError":"Nazwa powinna mieć maksimum {{requiredLength}} znaków.","RequiredError":" Nazwa jest <strong>wymagana</strong>."},"Author":{"Header":"Autor","Hint":"Autor skryptu","MaxLengthError":"Imię autora powinien mieć mniej niż {{requiredLength}} znaków."},"Document":{"Header":"Dokument","Hint":"Zgodnie z","MaxLengthError":"Nazwa dokumentu nie powinna przekraczać {{requiredLength}} znaków."},"Group":{"Header":"Grupa","Hint":"Kategoria skryptu","Statica":"Statyka","Loads":"Obciążenia","Concrete":"Beton","Steel":"Stal","Timber":"Drewno","Soils":"Grunty","Other":"Inne"},"DefaultLanguage":{"Hint":"Wybierz język domyślny","RequiredError":"Język jest <strong>wymagany</strong>."},"Description":{"Header":"Opis","Hint":"Opis skryptu","MinLengthError":"Opis skrytpu powinien mieć więcej niż {{requiredLength}} znaków.","MaxLengthError":"Opis skrytpu powinien mieć mniej niż {{requiredLength}} znaków.","RequiredError":"Opis jest <strong>wymagany</strong>."},"IncludeNote":"Uwzględnij notatkę","Note":{"Header":"Notatka","Hint":"Dodatkowe notatki do skryptu","MaxLengthError":"Notatka nie powinna przekraczać {{requiredLength}} znaków."}},"Tags":{"Header":"Tagi","AddNewTags":"Dodaj nowe tagi"},"Parameters":{"Header":"Parametry","ParametersFilterLabel":"Filtruj parametry","AllParameters":"Wszystkie","DataParameters":"Dane","StaticParameters":"Statyczne","CalculationParameters":"Obliczane","Edit":"Edytuj","Remove":"Usuń","NewParameter":"Nowy parametr","EditMode":{"ParameterTypePicker":"Wybierz typ parametru","ParameterTypes":{"Editable":"Edytowalny","Static":"Statyczny","Calculable":"Obliczany","Visible":"Widoczny","Important":"Ważny","Optional":"Opcjonalny"},"Name":{"Header":"Nazwa","Hint":"Nazwa parametru","MaxLengthError":"Nazwa nie powinna mieć więcej niż {{requiredLength}} znaków.","RequiredError":"Nazwa jest <strong>wymagana</strong>."},"Unit":{"Header":"Jednostka","Hint":"Jednostka parametru","MaxLengthError":"Jednostka może mieć maksymalnie {{requiredLength}} znaków."},"Document":{"Header":"Dokument","Hint":"Dokument powiązany","MaxLengthError":"Nazwa dokumentu może mieć maksymalnie {{requiredLength}} znaków."},"ValueType":{"Header":"Typ wartości","Hint":"Typ wartości parametru","Number":"Wartość","Text":"Tekst"},"GroupName":{"Header":"Nazwa grupy","Hint":"Nazwa grupy parametru","MaxLengthError":"Nazwa grupy może mieć maksymalnie {{requiredLength}} znaków."},"Value":{"Header":"Wartość","Hint":"Wartość parametru","MaxLengthError":"Wartość może mieć maksymalnie {{requiredLength}} znaków."},"Description":{"Header":"Opis","Hint":"Opis parametru","MaxLengthError":"Opis parametru może mieć maksymalnie {{requiredLength}} znaków."},"VisibilityValidator":{"Header":"Walidacja widoczności","Hint":"Walidacja widoczności","MaxLengthError":"Walidacja widoczności może mieć maksymalnie {{requiredLength}} znaków."},"DataValidator":{"Header":"Walidacja danych","Hint":"Walidacja danych","MaxLengthError":"Walidacja danych może mieć maksymalnie {{requiredLength}} znaków."},"Note":{"Header":"Notatka","Hint":"Dodatkowe komentarze do parametru","MaxLengthError":"Notatka nie może przekraczać {{requiredLength}} znaków."},"Update":"Aktualizuj"},"Add":"Dodaj","ValueOptions":{"Header":"Wartości wybieralne","Hint":"Wartości do wyboru","None":"Brak","AllowAny":"Zezwól na dowolną","Boolean":"Prawda/Fałsz","Name":{"Header":"Nazwa","Hint":"Nazwa"},"Value":{"Header":"Wartość","Hint":"Wartość"},"Description":{"Header":"Opis","Hint":"Opis dla wartości wybieralnej"},"Remove":"Usuń","Add":"Dodaj"},"Figures":{"Header":"Obrazki","Hint":"Dodaj dodatkowe obrazki do parametrów","Remove":"Usuń"}},"Translations":{"Header":"Tłumaczenia","Add":"Dodaj Tłumaczenie","Update":"Aktualizuj Tłumaczenie","Remove":"Usuń"}},"scriptCard":{"Calculate":"Oblicz","Edit":"Edytuj","Delete":"Usuń"},"scriptCalculator":{"StaticData":"Stałe","Calculate":"Oblicz","Results":"Wyniki","Controls":{"Default":"Domyślne","True":"Prawda","Figures":"Obrazki"}}};

/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
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
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! exports provided: getBaseUrl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getBaseUrl", function() { return getBaseUrl; });
/* harmony import */ var hammerjs__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! hammerjs */ "./node_modules/hammerjs/hammer.js");
/* harmony import */ var hammerjs__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(hammerjs__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");





function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
var providers = [
    { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];
if (_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__["platformBrowserDynamic"])(providers).bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_3__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\KPK_Calcs\Build_IT_Web\ClientApp\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main-es5.js.map