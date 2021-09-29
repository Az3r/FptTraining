import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ICategory, ISupplier } from 'src/app/shared/models/product';
import { ICreateProductRequest, ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-create-product-dialog',
  templateUrl: './create-product-dialog.component.html',
  styleUrls: ['./create-product-dialog.component.sass']
})
export class CreateProductDialog implements OnInit {

  productForm?: FormGroup

  categories: ICategory[] = []
  suppliers: ISupplier[] = []

  submitting: boolean = false

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CreateProductDialog>,
    private snackbar: MatSnackBar,
    private router: Router,
    private productService: ProductService,
  ) { }

  async ngOnInit() {
    this.categories = await this.productService.getCategories();
    this.suppliers = await this.productService.getSuppliers();
    this.productForm = this.fb.group({
      name: [''],
      description: ['A short description about this product'],
      categories: this.fb.array(this.categories.map(() => false)),
      supplier: [''],
      price: [''],
      releasedDate: [''],
      goToDetail: [true]
    })
  }

  close() {
    this.dialogRef.close();
  }

  async onSubmit() {
    if (!this.productForm || this.productForm.invalid) return;

    try {
      this.submitting = true;
      this.dialogRef.disableClose = true;

      const form = this.productForm.value;
      console.log(form)

      const request: ICreateProductRequest = {
        name: form.name,
        description: form.description,
        supplierId: form.supplier,
        categoryIds: this.categories.filter((_, i) => form.categories[i]).map(item => item.id),
        price: form.price,
        releasedDate: new Date(form.releasedDate)
      }
      const product = await this.productService.createProduct(request);
      if (form.goToDetail) {
        this.router.navigate(["product", product.id])
        this.dialogRef.close()
      }

      this.snackbar.open("Create product successfully", undefined, { panelClass: "snackbar-success" })

    } catch (error) {
      console.error(error)
      this.snackbar.open("Failed to create product", undefined, { panelClass: "snackbar-error" })

    } finally {
      this.submitting = false;
      this.dialogRef.disableClose = false;
    }
  }

}
