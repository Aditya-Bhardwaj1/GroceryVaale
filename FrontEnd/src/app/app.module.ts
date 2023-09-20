import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CarasoolComponent } from './carasool/carasool.component';
import { CardbodyComponent } from './cardbody/cardbody.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CarasoolComponent,
    CardbodyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
