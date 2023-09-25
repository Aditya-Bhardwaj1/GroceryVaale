import { NgModule } from '@angular/core';
import { Route, RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { CarasoolComponent } from './carasool/carasool.component';
import { CardbodyComponent } from './cardbody/cardbody.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { SearchPageComponent } from './product/search-page/search-page.component';
const routes: Routes = [
    { path : "", redirectTo: "/home", pathMatch: "full"},
    {path : "home", component: HomeComponent},
     {path : "product-search", component: SearchPageComponent},
    // {path : "home", component: CardbodyComponent},
    // {path : "home", component: FooterComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }