import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.sass']
})
export class ConfirmDialogComponent implements OnInit {

  title: string
  message: string

  constructor(
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {title:string,message:string}
  ) { }

  ngOnInit(): void {
    this.title = this.data.title;
    this.message = this.data.message;
  }

  close(confirm: boolean) {
    this.dialogRef.close(confirm);
  }

}
