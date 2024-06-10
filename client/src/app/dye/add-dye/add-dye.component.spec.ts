import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDyeComponent } from './add-dye.component';

describe('AddDyeComponent', () => {
  let component: AddDyeComponent;
  let fixture: ComponentFixture<AddDyeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDyeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDyeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
