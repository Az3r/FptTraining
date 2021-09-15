import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateProductDialog } from './create-product-dialog.component';

describe('CreateProductDialogComponent', () => {
  let component: CreateProductDialog;
  let fixture: ComponentFixture<CreateProductDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateProductDialog ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateProductDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
