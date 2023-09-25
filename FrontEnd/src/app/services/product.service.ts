import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products: Product[] = []
  baseUrl = "http://localhost:34567/api/soti/products"
  public productName?:string;
  public productPrice?:number;
  constructor(private http: HttpClient) { }

  getProductsByCategoryId(categoryId: number):Observable<Product[]>{
    return this.http.get<Product[]>(`${this.baseUrl}/getProductByCategoryId/${categoryId}`)
  }

  getSearchedProducts( ):Observable<Product[]>{
    this.setSearchDetails("pro",0);
    const params= new HttpParams()
  .set('productName',this.productName!)
  .set('productPrice',this.productPrice!);
    return this.http.get<Product[]>(this.baseUrl+'/getSearchedProducts',{params} );
  
  }

  setSearchDetails( productName:string ,productPrice:number):void{
    this.productName=productName;
    this.productPrice=productPrice;
  }

}
