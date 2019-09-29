import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Material } from "../models/dead-loads/interfaces/material";
import { Subcategory } from "../models/dead-loads/interfaces/subcategory";
import { Category } from "../models/dead-loads/interfaces/category";

@Injectable({ providedIn: 'root' })
export class DeadLoadsService {
    constructor(private http: HttpClient) {

    }

    getCategories(): Observable<Category[]> {
        return this.http.get<Category[]>('/api/deadloads');
    }

    getSubcategories(categoryId: number): Observable<Subcategory[]> {
        return this.http.get<Subcategory[]>('/api/deadloads/' + categoryId + '/subcategories');
    }

    getMaterials(subcategoryId: number): Observable<Material[]> {
        return this.http.get<Material[]>('/api/deadloads/' + subcategoryId + '/materials');
    }
}