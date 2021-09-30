import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ICategory, IProductDetail, ISupplier } from 'src/app/shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent implements OnInit {

  id?: string | null
  editting: boolean = false
  submitting: boolean = false
  product?: IProductDetail

  productForm?: FormGroup

  categories: ICategory[] = []
  suppliers: ISupplier[] = []

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private snackbar: MatSnackBar,
    private productService: ProductService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id')
    if (!this.id) return;

    this.productService.getProduct(this.id).then(item => {
      this.product = item
    })

    // preload categories and suppliers for editing product
    this.productService.getCategories().then(item => {
      this.categories = item;
    })

    this.productService.getSuppliers().then(item => {
      if (item) this.suppliers = item;
    })
  }

  toCategoryNames() {
    return this.product!.categories.map(item => item.name).join(', ')
  }

  editProduct(value: boolean) {
    this.editting = value;
    if (this.editting) {
      const selectedCategories = this.categories.map(category => this.product!.categories.findIndex(value => value.id === category.id) >= 0)
      this.productForm = this.formBuilder.group({
        name: [this.product!.name],
        description: [this.product!.description],
        categories: this.formBuilder.array(selectedCategories),
        supplier: [this.product!.supplier.id],
        price: [this.product!.price],
        releasedDate: [this.product!.releasedDate],
        discontinuedDate: [this.product!.discontinuedDate],
        detail: [this.product!.detail]
      })
    }
  }

  async onDelete() {
    try {
      this.submitting = true;
      await this.productService.deleteProduct(this.product!.id);

      this.snackbar.open("Delete successfully", undefined, { horizontalPosition: 'right', panelClass: "snackbar-success" });
      this.editting = false;
      this.router.navigate(["/product"])
    } catch (error) {
      this.snackbar.open("Failed to update", undefined, { horizontalPosition: 'right', panelClass: "snackbar-error" });
    } finally {
      this.submitting = false;
    }
  }

  async onSubmit() {
    if (!this.productForm?.valid) return;
    const form = this.productForm.value;
    console.log(form)


    try {
      this.submitting = true;
      await this.productService.updateProduct(this.product!.id, {
        name: form.name,
        description: form.description,
        categoryIds: this.categories.filter((_, i) => form.categories[i]).map(item => item.id),
        supplierId: form.supplier,
        price: form.price,
        releasedDate: new Date(form.releasedDate),
        discontinuedDate: form.discontinuedDate && new Date(form.discontinuedDate),
        detail: form.detail
      });

      this.product = {
        id: this.product!.id,
        name: form.name,
        description: form.description,
        categories: this.categories.filter((_, i) => form.categories[i]),
        supplier: this.suppliers.filter(s => s.id === form.supplier)[0],
        price: form.price,
        rating: this.product!.rating,
        releasedDate: new Date(form.releasedDate),
        discontinuedDate: form.discontinuedDate && new Date(form.discontinuedDate),
        detail: form.detail
      }

      this.snackbar.open("Update successfully", undefined, { horizontalPosition: 'right', panelClass: "snackbar-success" });
      this.editting = false;
    } catch (error) {

      this.snackbar.open("Failed to update", undefined, { horizontalPosition: 'right', panelClass: "snackbar-error" });
    } finally {
      this.submitting = false;
    }
  }

}
