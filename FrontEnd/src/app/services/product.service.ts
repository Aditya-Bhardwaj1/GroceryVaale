import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../product';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  private baseUrl = "https://localhost:44336/api/soti/products"

  constructor(private http: HttpClient) {
    
   }

   getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/GetAllProducts`);
  }

  addProduct(product: Product): Observable<any> {
    //return this.http.post<any>(`${this.baseUrl}/addProduct`, product, { headers: this.authHeader });
    return this.http.post<any>(`${this.baseUrl}/addProduct`, product);
  }
}
