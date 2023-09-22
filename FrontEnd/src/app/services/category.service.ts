import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseUrl : string ="http://localhost:34567/api/soti/categories"
  constructor(private http: HttpClient) { }
  getCategories():Observable<Category[]>{

    return this.http.get<Category[]>(`${this.baseUrl}/GetAllCategories`)
  }
}
