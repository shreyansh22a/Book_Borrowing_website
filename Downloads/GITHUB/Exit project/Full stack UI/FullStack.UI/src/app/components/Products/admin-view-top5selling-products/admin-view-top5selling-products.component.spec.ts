import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewTop5sellingProductsComponent } from './admin-view-top5selling-products.component';

describe('AdminViewTop5sellingProductsComponent', () => {
  let component: AdminViewTop5sellingProductsComponent;
  let fixture: ComponentFixture<AdminViewTop5sellingProductsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminViewTop5sellingProductsComponent]
    });
    fixture = TestBed.createComponent(AdminViewTop5sellingProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
