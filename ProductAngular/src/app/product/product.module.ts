import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ProductComponent } from './product/product.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductDialogComponent } from './product-dialog/product-dialog.component';
import { CreateProductDialog } from './create-product-dialog/create-product-dialog.component';


@NgModule({
  declarations: [
    ProductComponent,
    ProductDetailComponent,
    ProductDialogComponent,
    CreateProductDialog,
  ],
  imports: [
    SharedModule
  ],
  exports: [
    ProductComponent,
    ProductDetailComponent
  ]
})
export class ProductModule { }
