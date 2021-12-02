import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamousPersonDetailComponent } from './famous-person-detail.component';

describe('FamousPersonDetailComponent', () => {
  let component: FamousPersonDetailComponent;
  let fixture: ComponentFixture<FamousPersonDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FamousPersonDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FamousPersonDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
