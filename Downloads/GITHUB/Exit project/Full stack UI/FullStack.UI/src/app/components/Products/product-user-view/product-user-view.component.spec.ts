import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductUserViewComponent } from './product-user-view.component';

describe('ProductUserViewComponent', () => {
  let component: ProductUserViewComponent;
  let fixture: ComponentFixture<ProductUserViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductUserViewComponent]
    });
    fixture = TestBed.createComponent(ProductUserViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
