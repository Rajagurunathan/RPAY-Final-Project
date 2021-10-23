import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BsnlComponent } from './bsnl.component';

describe('BsnlComponent', () => {
  let component: BsnlComponent;
  let fixture: ComponentFixture<BsnlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BsnlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BsnlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
