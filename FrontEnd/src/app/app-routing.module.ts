import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UpdateProductComponent } from './update-product/update-product.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';

const routes: Routes = [
  {path: '', component: ProductDetailComponent },
  { path: 'edit-details/:id', component: UpdateProductComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
