import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Constants } from '../constants';
import { Post } from '../models/post';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class PostService {

  private _createPostSource = new ReplaySubject<Post>();
  public createPostObservable = this._createPostSource.asObservable();

  constructor(private http: HttpClient, private constants: Constants) { }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.constants.postsUrl);
  }

  getPost(postId): Observable<Post> {
    return this.http.get<Post>(`${this.constants.postsUrl}/${postId}`);
  }

  createNewPost(body: Post) {
    return this.http.post(this.constants.postsUrl, body, ).map((response) => {
      body.id = parseInt(response['id'], 10);
      this._createPostSource.next(body);
    });
  }

  delete(id) {
    return this.http.delete(`${this.constants.postsUrl}/${id}`);
  }

  update(post) {
    return this.http.put(`${this.constants.postsUrl}/${post.id}`, post);
  }
  
}
