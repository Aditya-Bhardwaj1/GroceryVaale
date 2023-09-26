import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from '../../models/product.model';
import { Subscription } from 'rxjs';
import { ProductService } from '../../services/product.service';
import { Category } from '../../models/category.model';
import { CategoryService } from '../../services/category.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit{
  productForm!: FormGroup;
  submitted: boolean = false;
  mobileNoRegex: string = "^[0-9]*$";
  emailRegex: string = "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$";
  product?: Product;
  sub$?: Subscription;
  sub2$?:Subscription;
  categories?:Category[];
  isSubmitted: boolean = false;
  

  constructor(private productService:ProductService,private fb:FormBuilder, private categoryService: CategoryService, private router: Router,
    private route: ActivatedRoute ) { }

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
      productImage: [null,[Validators.required]],
      // password: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(25)]],
      // confirmPassword: [null,[Validators.required, Validators.minLength(8)]],
    }
    );
    const producId = this.route.snapshot.paramMap.get('productId');
    this.sub2$ = this.categoryService.getCategories().subscribe({
      next: (data)=>{this.categories=data; console.log(data)},
      error: (err) => {console.error(err)}
    })

    if (producId !== null)
    this.sub$ = this.productService.getProductsById(+producId).subscribe({
      next: (data) => {this.product = data; console.log(data);  this.productForm.patchValue(data); this.productForm.get("discontinuedd")?.patchValue(data.discontinued)},
      error: (err) => {console.error(err)}
    })
    

    
  }
  onSubmit(product1?: Product){
    
    console.log(this.productForm)
    console.log(product1?.productId)
    if(this.productForm?.valid){
      this.submitted = true;
     this.isSubmitted=true;
      this.sub$ = this.productService.updateProduct((product1?.productId!), this.productForm.value).subscribe({
        next: (data) => {this.product = data; this.doReset();},
        error: (err) => {console.error(err)}
      })
    }
    
   

    
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
