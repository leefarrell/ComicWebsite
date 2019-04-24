/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddComicComponent } from './add-comic.component';

describe('AddComicComponent', () => {
  let component: AddComicComponent;
  let fixture: ComponentFixture<AddComicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddComicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddComicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
