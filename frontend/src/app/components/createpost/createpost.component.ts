import { Component, OnInit } from '@angular/core';
import { PostService } from '../../services/post.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Post } from "../../models/post";
import { Router } from "@angular/router";


@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {

  angForm: FormGroup;

  
  constructor(private postservice: PostService, private fb: FormBuilder, private router: Router) {
    this.createForm();
  }

  createForm() {
    this.angForm = this.fb.group({
      author: ['', [Validators.required, Validators.email]],
      title: ['', Validators.required],
      text: ['', Validators.required]

    });
  }

  public createNewPost(author, title, text) {
    let post: Post = new Post();
    post.author = author;
    post.text = text;
    post.title = title;
    post.commentCount = 0;
    this.postservice.createNewPost(post).subscribe(()=>{
      this.router.navigate(['post',post.id]);
    });
  }

  ngOnInit() {
  }

}
