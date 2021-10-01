import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { ICategory, IProductMaster } from 'src/app/shared/models/product';
import { IFindProductQuery, IPaginationResponse, ProductService } from 'src/app/shared/services/product.service';
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

  pageSizes = [10, 15, 20]

  products: IProductMaster[] = []

  searchForm?: FormGroup

  advanceSearch: boolean = false;

  categories: ICategory[] = []

  size: number = this.pageSizes[0];

  offset: number = 0;

  results?: IPaginationResponse<IProductMaster>

  lastSearch: string = ""



  constructor(
    private dialog: MatDialog,
    private router: Router,
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
          name: this.fb.control('none'),
          price: this.fb.control('none'),
          rating: this.fb.control('none'),
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
    console.log(event)
    this.onSearch();
  }

  async onSearch() {
    const value = this.searchForm!.value;
    if (!value.name || this.searchForm!.invalid) return

    if (this.lastSearch !== value.name) {
      // reset offset because we are searching with new keyword
      this.offset = 0
    }


    const query: IFindProductQuery = {
      name: value.name,
      categories: this.categories.filter((_, i) => value.categories[i]),
      size: this.size,
      offset: this.offset,
      sort: value.sorting,
      minPrice: value.minPrice,
      maxPrice: value.maxPrice
    }

    this.results = await this.productService.findProducts(query);

    this.lastSearch = value.name;
    this.products = this.results!.items;
  }

  openProduct(row: IProductMaster) {
    this.router.navigate(["product", row.id])
  }

  toCategories(item: IProductMaster) {
    return item.categories.join(', ')
  }

  get totalItems() {
    if (!this.results) return 0;
    return this.results.totalPages * this.results.pageSize;
  }

}
