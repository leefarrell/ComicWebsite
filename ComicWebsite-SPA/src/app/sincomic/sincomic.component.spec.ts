/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SincomicComponent } from './sincomic.component';

describe('SincomicComponent', () => {
  let component: SincomicComponent;
  let fixture: ComponentFixture<SincomicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SincomicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SincomicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
