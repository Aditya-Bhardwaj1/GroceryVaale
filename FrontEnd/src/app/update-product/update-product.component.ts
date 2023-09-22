import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from '../models/product';
import { Subscription } from 'rxjs';
import { ProductService } from '../services/product.service';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';


@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.scss']
})
export class UpdateProductComponent implements OnInit{

  productForm!: FormGroup;
  submitted: boolean = false;
  mobileNoRegex: string = "^[0-9]*$";
  emailRegex: string = "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$";
  product?: Product;
  sub$?: Subscription;
  sub2$?:Subscription;
  categories?:Category[];
  isSubmitted: boolean = false;
  

  constructor(private productService:ProductService,private fb:FormBuilder, private categoryService: CategoryService ) { }

  ngOnInit(): void {
    
    this.productForm= this.fb.group({
      productName: [this.product?.productName, [Validators.required, Validators.minLength(3)]],
      //productName: new FormControl(this.product?.productName, Validators.required),
      description: [null, [Validators.required]],
      //discontinuedd: new FormControl(this.product?.discontinued,Validators.required),
     discontinuedd:[null,Validators.required],
      unitPrice: [null, [Validators.required]],
      unitsInStock:[null, Validators.required],
      categoryId: [null,[Validators.required]],
      // password: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(25)]],
      // confirmPassword: [null,[Validators.required, Validators.minLength(8)]],
    }
    )
    this.sub2$ = this.categoryService.getCategories().subscribe({
      next: (data)=>{this.categories=data; console.log(data)},
      error: (err) => {console.error(err)}
    })
    this.sub$ = this.productService.getProductsById(1001).subscribe({
      next: (data) => {this.product = data; console.log(data);  this.productForm.patchValue(data); this.productForm.get("discontinuedd")?.patchValue(data.discontinued)},
      error: (err) => {console.error(err)}
    })
    

    
  }
  onSubmit(product1?: Product){
    this.submitted = true;
    this.isSubmitted=true;
    console.log(this.productForm)
    console.log(product1?.productId)
    if(this.productForm?.valid){
      
      this.sub$ = this.productService.updateProduct((product1?.productId!), this.productForm.value).subscribe({
        next: (data) => {this.product = data},
        error: (err) => {console.error(err)}
      })
    }
    this.doReset();

    
  }

  getControl(key:string): AbstractControl{
    return this.productForm.controls[key];
  }

  get f(): {[controlName: string]: AbstractControl}{
    return this.productForm.controls;
  }

  doReset() {
    this.submitted = false;
    this.productForm.reset();
  }
  }


