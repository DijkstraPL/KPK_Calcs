import { ErrorHandler } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {   
    handleError(error: Response | any) {
        alert("An unexpected error occurred.")
        console.log(error);
    }
}