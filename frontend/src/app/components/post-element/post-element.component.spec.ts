import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostElementComponent } from './post-element.component';

describe('PostComponent', () => {
  let component: PostElementComponent;
  let fixture: ComponentFixture<PostElementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PostElementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
