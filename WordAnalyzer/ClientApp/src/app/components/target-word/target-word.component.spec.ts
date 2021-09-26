import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TargetWordComponent } from './target-word.component';

describe('TargetWordComponent', () => {
  let component: TargetWordComponent;
  let fixture: ComponentFixture<TargetWordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TargetWordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TargetWordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
