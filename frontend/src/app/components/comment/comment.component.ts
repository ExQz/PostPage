import { Comment } from '../../models/comment';
import { CommentService } from '../../services/comment.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  @Input() comment: Comment;

  editMode = false;

  angForm: FormGroup;

  constructor(private commentService: CommentService, private fb: FormBuilder) {
    this.createForm();
  }

  ngOnInit() {

  }

  createForm() {
    this.angForm = this.fb.group({
      comAuthor: ['', [Validators.required, Validators.email]],
      comText: ['', Validators.required]

    });
  }

  changeMode() {
    this.editMode = !this.editMode;
  }

  update(author, text) {
    let comment: Comment = new Comment();
    comment.text = text;
    comment.author = author;
    comment.postId = this.comment.postId;
    comment.id = this.comment.id;
    this.commentService.update(comment).subscribe(() => {
      location.reload();
    });
  }

  delete() {
    this.commentService.delete(this.comment.id).subscribe(() => {
      location.reload();
    });
  }
}
