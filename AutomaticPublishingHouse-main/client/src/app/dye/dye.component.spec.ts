import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DyeComponent } from './dye.component';

describe('DyeComponent', () => {
  let component: DyeComponent;
  let fixture: ComponentFixture<DyeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DyeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DyeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
