import { Component } from '@angular/core';

import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Subscription } from 'rxjs';

import { ProductService } from '../services/product.service';

import { Product } from '../models/product.model';

import { Category } from '../models/category.model';

import { CategoryService } from '../services/category.service';

 

@Component({

  selector: 'app-add-product',

  templateUrl: './add-product.component.html',

  styleUrls: ['./add-product.component.scss']

})

export class AddProductComponent {

  addForm!: FormGroup;

  submitted: boolean = false;

  isAdded: boolean = false;

  subProduct$?: Subscription;

  subCategory$?: Subscription;

  statusCode?: Number;

  product?: Product;

  categories?: Category[] = [];

 

  constructor(private productService: ProductService, private categoryService: CategoryService, private fb: FormBuilder){}

 

  ngOnInit(): void{

    this.addForm = this.fb.group({

      productName: [null, [Validators.required, Validators.minLength(3)]],

      description: [null, [Validators.required, Validators.minLength(10)]],

      unitPrice: [null, [Validators.required, Validators.min(1)]],

      unitsInStock: [null, [Validators.required, Validators.min(1)]],

      categoryId: [null, Validators.required],

      productImage: ['', Validators.required],

    })

 

    this.subCategory$ = this.categoryService.getCategories().subscribe((categories) => {

      console.log(categories);

     

      categories.forEach(category => {

        this.categories?.push(category);

      });

     

    });

    console.log(this.categories);

   

  }

 

  onSubmit() {

 

    this.product = new Product();

 

    this.product.productName = this.f['productName'].value;

    this.product.description = this.f['description'].value;

    this.product.unitPrice = this.f['unitPrice'].value;

    this.product.unitsInStock = this.f['unitsInStock'].value;

    this.product.discontinued = false;

    this.product.categoryId = this.f['categoryId'].value;

    this.product.productImage = this.f['productImage'].value;

 

    console.log(this.product);

 

    this.subProduct$ = this.productService.addProduct(this.product ).subscribe({

      next: (data) => {

        console.log(data);

        this.isAdded = data;

        this.submitted = true;

      },

      error: (err) => {

        console.error(err.status);

        this.isAdded = false;

        this.submitted = true;

      }

    })

   

  }

 

  resetForm(){

    this.addForm.markAsUntouched();

    this.submitted = false;

    this.isAdded = false;

    this.addForm.reset();

  }

 

  get f(): { [controlName: string]: AbstractControl } {

    return this.addForm.controls;

  }

 

  ngOnDestroy(): void {

    this.subProduct$?.unsubscribe();

    this.subCategory$?.unsubscribe();

  }

}
