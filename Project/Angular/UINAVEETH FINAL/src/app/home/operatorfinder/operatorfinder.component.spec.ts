import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatorfinderComponent } from './operatorfinder.component';

describe('OperatorfinderComponent', () => {
  let component: OperatorfinderComponent;
  let fixture: ComponentFixture<OperatorfinderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperatorfinderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OperatorfinderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
