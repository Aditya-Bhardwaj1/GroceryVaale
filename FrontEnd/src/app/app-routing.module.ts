import { NgModule } from '@angular/core';
import { Route, RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { CarasoolComponent } from './carasool/carasool.component';
import { CardbodyComponent } from './cardbody/cardbody.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { SearchPageComponent } from './product/search-page/search-page.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactusComponent } from './contactus/contactus.component';
import { ProductlistComponent } from './productlist/productlist.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { AddCategoryComponent } from './category/add-category/add-category.component';
const routes: Routes = [
    { path : "", redirectTo: "/home", pathMatch: "full"},
    {path : "home", component: HomeComponent},
     {path : "product-search", component: SearchPageComponent},
     {path : "navbar", component: NavbarComponent},
    {path : "about-us", component: AboutusComponent},
    {path : "contact-us", component: ContactusComponent},
    {path : "allproducts", component: ProductlistComponent},
    {path : "login", component: LoginComponent},
    {path : "register", component: RegisterComponent},
    {path: "product-details/:productId", component: ProductDetailsComponent},
    {path: "edit-details/:productId", component: EditProductComponent},
    {path: "add-category", component: AddCategoryComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }