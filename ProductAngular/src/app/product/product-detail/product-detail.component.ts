import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ICategory, IProductDetail, ISupplier } from 'src/app/shared/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent implements OnInit {

  id?: string | null
  editting: boolean = false
  product?: IProductDetail

  productForm?: FormGroup

  categories: ICategory[] = []
  suppliers: ISupplier[] = []

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id')
    if (!this.id) return;

    this.productService.getProduct(this.id).then(item => {
      this.product = item
      console.log(this.product)
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
        categories: this.formBuilder.array(selectedCategories.map(item => this.formBuilder.control(item))),
        supplier: [this.product!.supplier.id],
        price: [this.product!.price],
        releasedDate: [this.product!.releasedDate],
        discontinuedDate: [this.product!.discontinuedDate],
        detail: [this.product!.detail]
      })
    }
  }

  onSubmit() {
    console.log(this.productForm!.value)
  }

}
