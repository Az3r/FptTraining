import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-product-dialog',
  templateUrl: './product-dialog.component.html',
  styleUrls: ['./product-dialog.component.sass']
})
export class ProductDialogComponent implements OnInit {

  constructor(public dialog: MatDialogRef<ProductDialogComponent>) { }

  ngOnInit(): void {
  }

  close() {
    this.dialog.close();
  }

}
