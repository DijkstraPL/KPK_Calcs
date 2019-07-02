import { TranslationService } from "./translation.service";
import { Injectable } from "@angular/core";
import { DBkeys } from "./db-keys";
import { Subject } from "rxjs";
import { LocalStoreManager } from "./local-store-manager.service";

interface UserConfiguration {
    language: string;
}

@Injectable()
export class ConfigurationService {
    public static readonly defaultLanguage: string = 'en';
    private _language: string = null;

    constructor(private localStorage: LocalStoreManager,
        private translationService: TranslationService) {
        this.loadLocalChanges();
    }

    set language(value: string) {
        this._language = value;
        this.saveToLocalStore(value, DBkeys.LANGUAGE);
        this.translationService.changeLanguage(value);
    }
    get language() {
        return this._language || ConfigurationService.defaultLanguage;
    }

    private loadLocalChanges() {
        if (this.localStorage.exists(DBkeys.LANGUAGE)) {
            this._language = this.localStorage.getDataObject<string>(DBkeys.LANGUAGE);
            this.translationService.changeLanguage(this._language);
        } else {
            this.resetLanguage();
        }
    }
    
    private onConfigurationImported: Subject<boolean> = new Subject<boolean>();
    configurationImported$ = this.onConfigurationImported.asObservable();
    
    private saveToLocalStore(data: any, key: string) {
        setTimeout(() => this.localStorage.savePermanentData(data, key));
    }

    private resetLanguage() {
        const language = this.translationService.useBrowserLanguage();

        if (language) 
            this._language = language;
        else 
            this._language = this.translationService.useDefaultLangage();        
    }
}