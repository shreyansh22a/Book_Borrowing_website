import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewRecentOrdersComponent } from './admin-view-recent-orders.component';

describe('AdminViewRecentOrdersComponent', () => {
  let component: AdminViewRecentOrdersComponent;
  let fixture: ComponentFixture<AdminViewRecentOrdersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminViewRecentOrdersComponent]
    });
    fixture = TestBed.createComponent(AdminViewRecentOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
