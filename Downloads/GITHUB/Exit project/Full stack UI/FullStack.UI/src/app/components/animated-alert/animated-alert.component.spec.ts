import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimatedAlertComponent } from './animated-alert.component';

describe('AnimatedAlertComponent', () => {
  let component: AnimatedAlertComponent;
  let fixture: ComponentFixture<AnimatedAlertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AnimatedAlertComponent]
    });
    fixture = TestBed.createComponent(AnimatedAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
