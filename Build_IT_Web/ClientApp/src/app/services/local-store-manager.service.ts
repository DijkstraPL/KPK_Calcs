import { Injectable } from "@angular/core";
import { Utilities } from "./utilities";

@Injectable()
/**
* Provides a wrapper for accessing the web storage API and synchronizing session storage across tabs/windows.
*/
export class LocalStoreManager {

    public static readonly DBKEY_USER_DATA = 'user_data';
    private static readonly DBKEY_SYNC_KEYS = 'sync_keys';
    private syncKeys: string[] = [];

    private reservedKeys: string[] =
        [
            'sync_keys',
            'addToSyncKeys',
            'removeFromSyncKeys',
            'getSessionStorage',
            'setSessionStorage',
            'addToSessionStorage',
            'removeFromSessionStorage',
            'clearAllSessionsStorage'
        ];

    public savePermanentData(data: any, key = LocalStoreManager.DBKEY_USER_DATA) {
        this.testForInvalidKeys(key);

        this.removeFromSessionStorage(key);
        this.localStorageSetItem(key, data);
    }

    public exists(key = LocalStoreManager.DBKEY_USER_DATA) {
        let data = sessionStorage.getItem(key);

        if (data == null) 
            data = localStorage.getItem(key);

        return data != null;
    }

    public getDataObject<T>(key = LocalStoreManager.DBKEY_USER_DATA, isDateType = false): T {
        let data = this.getData(key);

        if (data != null) {
            if (isDateType) 
                data = new Date(data);
            return <T>data;
        }
        else 
            return null;
    }

    public getData(key = LocalStoreManager.DBKEY_USER_DATA) {
        this.testForInvalidKeys(key);

        let data = this.sessionStorageGetItem(key);

        if (data == null) {
            data = this.localStorageGetItem(key);
        }

        return data;
    }

    private removeFromSessionStorage(keyToRemove: string) {
        this.removeFromSessionStorageHelper(keyToRemove);
        this.removeFromSyncKeysBackup(keyToRemove);

        localStorage.setItem('removeFromSessionStorage', keyToRemove);
        localStorage.removeItem('removeFromSessionStorage');
    }

    private removeFromSessionStorageHelper(keyToRemove: string) {

        sessionStorage.removeItem(keyToRemove);
        this.removeFromSyncKeysHelper(keyToRemove);
    }

    private removeFromSyncKeysBackup(key: string) {
        const storedSyncKeys = this.getSyncKeysFromStorage();

        const index = storedSyncKeys.indexOf(key);

        if (index > -1) {
            storedSyncKeys.splice(index, 1);
            this.localStorageSetItem(LocalStoreManager.DBKEY_SYNC_KEYS, storedSyncKeys);
        }
    }
    
    private getSyncKeysFromStorage(defaultValue: string[] = []): string[] {
        const data = this.localStorageGetItem(LocalStoreManager.DBKEY_SYNC_KEYS);

        if (data == null) 
            return defaultValue;
        else 
            return <string[]>data;        
    }

    private removeFromSyncKeysHelper(key: string) {
        const index = this.syncKeys.indexOf(key);

        if (index > -1) {
            this.syncKeys.splice(index, 1);
        }
    }

    private testForInvalidKeys(key: string) {
        if (!key) {
            throw new Error('key cannot be empty');
        }

        if (this.reservedKeys.some(x => x == key)) {
            throw new Error(`The storage key "${key}" is reserved and cannot be used. Please use a different key`);
        }
    }

    private localStorageSetItem(key: string, data: any) {
        localStorage.setItem(key, JSON.stringify(data));
    }

    private localStorageGetItem(key: string) {
        return Utilities.JsonTryParse(localStorage.getItem(key));
    }

    private sessionStorageGetItem(key: string) {
        return Utilities.JsonTryParse(sessionStorage.getItem(key));
    }

}