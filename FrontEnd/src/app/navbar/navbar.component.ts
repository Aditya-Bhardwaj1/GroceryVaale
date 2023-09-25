import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
   c(){
    console.log("workinggg");
   }

  public searchText:string="";
  productName:string="";
  productPrice:number=0;

  constructor(private productService:ProductService,private router:Router){}

  searchProduct(){
    if(this.searchText=="")

    {

      console.log("here")

      this.productService.setSearchDetails(this.productName,this.productPrice);

      this.router.navigate(["product-search"],{

        queryParams:{name:"",price:0}

      })

    }

    else{

 

      const splitArray= this.searchText.valueOf().split(" ");

      splitArray.forEach((val)=>{

 

        if(!isNaN(Number(val)))

        {

          this.productPrice=Number(val);

        }

        if(isNaN(Number(val)))

        {

          this.productName=val;

        }

      } )

      this.productService.setSearchDetails(this.productName,this.productPrice);

      this.router.navigate(["product-search"]

      ,{

        queryParams:{name:this.productName,price:this.productPrice}

      })

    }
  }
   
}
