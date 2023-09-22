import { NgModule } from '@angular/core';
import { Route, RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { CarasoolComponent } from './carasool/carasool.component';
import { CardbodyComponent } from './cardbody/cardbody.component';
import { FooterComponent } from './footer/footer.component';

const routes: Routes = [
    // { path : "", redirectTo: "/home", pathMatch: "full"},
    // {path : "home", component: NavbarComponent},
    // {path : "home", component: CarasoolComponent},
    // {path : "home", component: CardbodyComponent},
    // {path : "home", component: FooterComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }