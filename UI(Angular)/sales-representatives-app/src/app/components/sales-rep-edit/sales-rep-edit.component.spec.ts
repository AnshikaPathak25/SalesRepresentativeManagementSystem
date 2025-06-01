import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesRepEditComponent } from './sales-rep-edit.component';

describe('SalesRepEditComponent', () => {
  let component: SalesRepEditComponent;
  let fixture: ComponentFixture<SalesRepEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalesRepEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalesRepEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
