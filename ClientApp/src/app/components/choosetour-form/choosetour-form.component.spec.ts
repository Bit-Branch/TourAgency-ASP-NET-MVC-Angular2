import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosetourFormComponent } from './choosetour-form.component';

describe('ChoosetourFormComponent', () => {
  let component: ChoosetourFormComponent;
  let fixture: ComponentFixture<ChoosetourFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChoosetourFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChoosetourFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
