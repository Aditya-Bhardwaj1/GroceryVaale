import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products: Product[] = []
  baseUrl = "http://localhost:34567/api/soti/products"
  constructor(private http: HttpClient) { }

  getProductsByCategoryId(categoryId: number):Observable<Product[]>{
    return this.http.get<Product[]>(`${this.baseUrl}/${categoryId}`)
  }

}
