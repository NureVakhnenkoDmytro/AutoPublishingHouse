import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditionComponent } from './add-edition.component';

describe('AddEditionComponent', () => {
  let component: AddEditionComponent;
  let fixture: ComponentFixture<AddEditionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
