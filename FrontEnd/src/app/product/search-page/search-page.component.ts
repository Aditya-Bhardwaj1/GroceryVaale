import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.scss'],
})
export class SearchPageComponent implements OnInit, OnDestroy {
  private subscription?: Subscription;
  productList: Product[] = [];

  constructor(private productService: ProductService) {}
  ngOnDestroy(): void {
    console.log(this.productList);

    this.subscription?.unsubscribe();
  }
  ngOnInit(): void {
    this.subscription = this.productService.getSearchedProducts().subscribe({
      next: (data) => {
        this.productList = data;
      },
      error: (err) => {
        console.error(err);
      },
    });
    console.log(this.productList);
    for (let i = 0; i < this.productList.length; i++) {
      const product = this.productList[i];
      console.log(product);
    }
  }
}
