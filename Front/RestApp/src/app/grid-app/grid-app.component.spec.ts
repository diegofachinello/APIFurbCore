import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridAppComponent } from './grid-app.component';

describe('GridAppComponent', () => {
  let component: GridAppComponent;
  let fixture: ComponentFixture<GridAppComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridAppComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
