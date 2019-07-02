var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from "@angular/core";
import { Utilities } from "./utilities";
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
        return Utilities.JsonTryParse(localStorage.getItem(key));
    };
    LocalStoreManager.prototype.sessionStorageGetItem = function (key) {
        return Utilities.JsonTryParse(sessionStorage.getItem(key));
    };
    var LocalStoreManager_1;
    LocalStoreManager.DBKEY_USER_DATA = 'user_data';
    LocalStoreManager.DBKEY_SYNC_KEYS = 'sync_keys';
    LocalStoreManager = LocalStoreManager_1 = __decorate([
        Injectable()
        /**
        * Provides a wrapper for accessing the web storage API and synchronizing session storage across tabs/windows.
        */
    ], LocalStoreManager);
    return LocalStoreManager;
}());
export { LocalStoreManager };
//# sourceMappingURL=local-store-manager.service.js.map