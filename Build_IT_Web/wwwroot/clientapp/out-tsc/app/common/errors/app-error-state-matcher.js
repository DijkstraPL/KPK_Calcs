var AppErrorStateMatcher = /** @class */ (function () {
    function AppErrorStateMatcher() {
    }
    AppErrorStateMatcher.prototype.isErrorState = function (control, form) {
        var isSubmitted = form && form.submitted;
        return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
    };
    return AppErrorStateMatcher;
}());
export { AppErrorStateMatcher };
//# sourceMappingURL=app-error-state-matcher.js.map