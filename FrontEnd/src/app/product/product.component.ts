import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit, OnDestroy {
  products: Product[] =[];
  sub$?: Subscription;

  constructor(private productService: ProductService) { }
   ngOnInit(): void {
    this.sub$ = this.productService.getProducts().subscribe({
      next: (data) => {this.products = data},
      error: (err) => {console.error(err)}
    })
   }
   ngOnDestroy(): void {
     this.sub$?.unsubscribe();
   }
   
}
