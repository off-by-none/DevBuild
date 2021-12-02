import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DonutEditComponent } from './donut-edit.component';

describe('DonutEditComponent', () => {
  let component: DonutEditComponent;
  let fixture: ComponentFixture<DonutEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DonutEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DonutEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
