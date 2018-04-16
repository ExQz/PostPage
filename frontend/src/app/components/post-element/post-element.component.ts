import { PostService } from '../../services/post.service';
import { Component, OnInit, Input } from '@angular/core';
import { Post } from "../../models/post";
import { Comment } from "../../models/comment";
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from "@angular/router";
import { CommentService } from '../../services/comment.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-post-element',
  templateUrl: './post-element.component.html',
  styleUrls: ['./post-element.component.css']
})
export class PostElementComponent implements OnInit {

  @Input() comment: Comment;
  @Input() postas: Post;

  angForm: FormGroup;
  editForm: FormGroup;
  editMode = false;

  post: Post;
  comments: Comment[];
  postId: Number;
  constructor(private postService: PostService,
    private fb: FormBuilder,
    private commentService: CommentService,
    private http: HttpClient,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    this.createForm();
    this.createEditForm();
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.postId = params['id'];
    });
    this.postService.getPost(this.postId).subscribe(post => {
      if (post == null) {
        this.router.navigate(['posts']);
      } else {
        this.post = post;
      }
    });

    this.commentService.getComments(this.postId).subscribe(comments => {
      this.comments = comments;
    });
  }

  createForm() {
    this.angForm = this.fb.group({
      comAuthor: ['', [Validators.required, Validators.email]],
      comText: ['', Validators.required]
    });
  }

  createEditForm() {
    this.editForm = this.fb.group({
      author: ['', [Validators.required, Validators.email]],
      title: ['',Validators.required],
      text: ['', Validators.required]

    });
  }

  changeMode() {
    this.editMode = !this.editMode;
  }

  createNewComment(author, text) {
    let comment: Comment = new Comment();
    comment.text = text;
    comment.author = author;
    comment.postId = this.post.id;

    this.commentService.addComment(comment).subscribe(() => {
      location.reload();
    });
  }

  update(author, title, text) {
    let post: Post = new Post();
    post.author = author;
    post.text = text;
    post.title = title;
    post.commentCount = 0;
    post.id = this.post.id;
    this.postService.update(post).subscribe(()=>{
      location.reload();
    });
  }

  delete() {
    this.postService.delete(this.post.id).subscribe(() => {
      this.router.navigate(['posts']);
    });
  }

}
