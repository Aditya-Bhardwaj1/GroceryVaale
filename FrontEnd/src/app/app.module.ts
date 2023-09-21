import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CarasoolComponent } from './carasool/carasool.component';
import { CardbodyComponent } from './cardbody/cardbody.component';
import { FooterComponent } from './footer/footer.component';

const appRoutes: Routes = [
  { path: '', component: NavbarComponent} // localhost:8000
  //{path: 'login', component: logincomponnt}
  //{path : 'products', component: productcomponent}

]
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CarasoolComponent,
    CardbodyComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    [RouterModule.forRoot(appRoutes)],
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
