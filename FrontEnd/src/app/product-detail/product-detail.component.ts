import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit, OnDestroy {
  product!: Product;
  sub$?: Subscription;

  constructor(private productService: ProductService, private router: Router) { }
   ngOnInit(): void {
    this.sub$ = this.productService.getProductsById(1003).subscribe({
      next: (data) => {this.product = data;},
      error: (err) => {console.error(err)}
    })
   }

   navigateToEditDetails(productId?: number) {
    // Navigate to the "Edit Details" page with the product's id as a route parameter
    this.router.navigate(['/edit-details', productId]);
  }
   ngOnDestroy(): void {
     this.sub$?.unsubscribe();
   }
}
