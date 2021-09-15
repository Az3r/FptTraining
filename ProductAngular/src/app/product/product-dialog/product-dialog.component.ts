import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-product-dialog',
  templateUrl: './product-dialog.component.html',
  styleUrls: ['./product-dialog.component.sass']
})
export class ProductDialogComponent implements OnInit {

  @Input() action: "create" | "edit"

  constructor(public dialogRef: MatDialogRef<ProductDialogComponent>, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  close() {
    this.dialogRef.close();
  }

  delete() {
    this.dialog.open(ConfirmDialogComponent, {data: {
      title: "Delete Product",
      message: "You are about to remove this product, this action is irreversible. Do you want to proceed?"
    }})
  }

}
