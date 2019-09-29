import { Injectable, ElementRef } from "@angular/core";
import { Subscription, Subject } from "rxjs";

@Injectable({
    providedIn: 'root',
})
export class SearchService {

    private onSearch = new Subject<string>();
    searched$ = this.onSearch.asObservable();

    constructor() {
    }

    search(value: string) {
        setTimeout(() => {
            this.onSearch.next(value);
        });
    }
}
