import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ProductComponent } from './product/product.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductDialogComponent } from './product-dialog/product-dialog.component';


@NgModule({
  declarations: [
    ProductComponent,
    ProductDetailComponent,
    ProductDialogComponent,
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
