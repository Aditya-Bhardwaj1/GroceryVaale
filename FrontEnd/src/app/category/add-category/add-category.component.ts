import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { CategoryService } from 'src/app/services/category.service';
import { UploadImageService } from 'src/app/services/upload-image.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss'],
})
export class AddCategoryComponent implements OnInit {
  isSubmitted: boolean = false;

  file: File | null = null;
  addCategoryForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private uploadImageService: UploadImageService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.addCategoryForm = this.fb.group({
      categoryName: [null, [Validators.required]],
      categoryImage: [null, [Validators.required]],
    });
  }

  onSubmit() {
    this.isSubmitted = true;
    this.uploadImageService.uploadFile(this.file!).subscribe({
      next: (data) => {
        console.log(data);
        this.categoryService
          .addCategory(
            this.addCategoryForm.controls['categoryName'].value,
            data
          )
          .subscribe({
            next: (data) => {
              console.log(data);
            },
            error: (err) => console.log(err),
          });
      },
      error: (err) => console.log(err),
    });
  }

  get f(): { [controlName: string]: AbstractControl } {
    return this.addCategoryForm.controls;
  }

  onSelectingImage(event: any) {
    this.file = event.target.files[0];
  }
}
