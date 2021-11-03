import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EdithotelFormComponent } from './edithotel-form.component';

describe('EdithotelFormComponent', () => {
  let component: EdithotelFormComponent;
  let fixture: ComponentFixture<EdithotelFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EdithotelFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EdithotelFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
