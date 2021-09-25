import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ICategory, ISupplier } from 'src/app/shared/product';

@Component({
  selector: 'app-create-product-dialog',
  templateUrl: './create-product-dialog.component.html',
  styleUrls: ['./create-product-dialog.component.sass']
})
export class CreateProductDialog implements OnInit {

  productForm: FormGroup

  categories: ICategory[]
  suppliers: ISupplier[]

  submitting: boolean

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CreateProductDialog>
  ) { }

  ngOnInit(): void {
    this.productForm = this.fb.group({
      name: [''],
      description: ['A short description about this product'],
      categories: this.fb.array([]),
      supplier: [''],
      price: [''],
      releasedDate: ['']
    })
  }

  close() {
    this.dialogRef.close();
  }

  onSubmit() {
    console.log(this.productForm.value)
  }

}
