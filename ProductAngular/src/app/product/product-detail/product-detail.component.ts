import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProductDetail } from 'src/app/shared/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent implements OnInit {

  editting: boolean = false
  id: string | null
  product: IProductDetail

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id')
    if (this.id) {
      this.productService.getProduct(this.id).subscribe(item => {
        if (item) {
          this.product = item
          console.log(this.product)
        }
      })
    }
  }

  edit() {
    this.editting = true;
  }

}
