import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
   c(){
    console.log("workinggg");
   }

  public searchText?:string;
  productName:string="";
  productPrice:number=0;

  constructor(private productService:ProductService){}

  searchProduct(){
    console.log("workingjahjhva")
    if(this.searchText==null)
    {
      this.productService.setSearchDetails("",0);
    }
    else{
      const splitArray= this.searchText.split(" ");
      console.log(splitArray);
      splitArray.forEach((val)=>{
        if(!isNaN(Number(val)))
        {
          this.productPrice=Number(val);
        }
        if(isNaN(Number(val)))
        {
          this.productName=val;
        }
        console.log(val)
      } )
      this.productService.setSearchDetails(this.productName,this.productPrice);
    }

    console.log(this.searchText)
    console.log(this.productPrice)
    console.log(this.productName);
  }
   
}
