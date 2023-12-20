import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserBorrowedBooksComponent } from './user-borrowed-books.component';

describe('UserBorrowedBooksComponent', () => {
  let component: UserBorrowedBooksComponent;
  let fixture: ComponentFixture<UserBorrowedBooksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserBorrowedBooksComponent]
    });
    fixture = TestBed.createComponent(UserBorrowedBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
