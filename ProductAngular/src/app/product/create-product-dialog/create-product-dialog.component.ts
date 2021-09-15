import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-product-dialog',
  templateUrl: './create-product-dialog.component.html',
  styleUrls: ['./create-product-dialog.component.sass']
})
export class CreateProductDialog implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<CreateProductDialog>
  ) { }

  ngOnInit(): void {
  }

  close() {
    this.dialogRef.close();
  }

}
