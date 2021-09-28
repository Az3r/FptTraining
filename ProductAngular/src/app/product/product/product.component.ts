import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { ICategory, IProductMaster } from 'src/app/shared/models/product';
import { FindProductQuery, PaginationResponse, ProductService } from 'src/app/shared/services/product.service';
import { CreateProductDialog } from '../create-product-dialog/create-product-dialog.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.sass'],
  animations: [
    trigger("advance-search-field", [
      state("expanded", style({
        height: 550,
      })),
      state("collapsed", style({
        height: 0,
      })),
      transition("expanded => collapsed", [
        animate("300ms 0ms ease-out")
      ]),
      transition("collapsed => expanded", [
        animate("300ms 0ms ease-in")
      ])
    ])
  ]
})
export class ProductComponent implements OnInit {

  columns: string[] = ["name", "supplier", "category", "price", "rating"]

  pageSizes = [5, 10, 15, 20]

  products: IProductMaster[] = []

  searchForm?: FormGroup

  advanceSearch: boolean = false;

  categories: ICategory[] = []

  size: number = this.pageSizes[0];

  offset: number = 0;

  results?: PaginationResponse<IProductMaster>



  constructor(
    public dialog: MatDialog,
    private productService: ProductService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.productService.getCategories().then(item => {
      this.categories = item;
      this.searchForm = this.fb.group({
        name: [undefined],
        categories: this.fb.array(this.categories.map(() => false)),
        minPrice: [undefined],
        maxPrice: [undefined],
        sorting: this.fb.group({
          name: this.fb.control('asc'),
          price: this.fb.control('asc'),
          rating: this.fb.control('asc'),
        })
      })
    })
  }

  create() {
    this.dialog.open(CreateProductDialog, { width: "640px" })
  }

  toggleAdvanceSearch(value: boolean) {
    this.advanceSearch = value
  }

  onPaginationChanged(event: PageEvent) {
    this.size = event.pageSize;
    this.offset = event.pageIndex;
    this.onSearch()
  }

  async onSearch() {
    if (this.searchForm?.invalid) return;

    const value = this.searchForm!.value;
    const query: FindProductQuery = {
      name: value.name,
      categories: this.categories.filter((_, i) => value.categories[i]).map(item => item.id),
      size: this.size,
      offset: this.offset,
      sort: value.sorting,
      minPrice: value.minPrice,
      maxPrice: value.maxPrice
    }

    this.results = await this.productService.findProducts(query);
    this.products = this.results!.items;
  }

}
