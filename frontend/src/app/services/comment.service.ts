import { Comment } from '../models/comment';

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';

@Injectable()
export class CommentService {

  

  constructor(private http: HttpClient, private constants: Constants) { }

  addComment(comment) {
    return this.http.post(`${this.constants.commentsUrl}?postId=${comment.postId}`, comment);
  }

  getComments(postId): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${this.constants.commentsUrl}?postId=${postId}`);
  }

  delete(id) {
    return this.http.delete(`${this.constants.commentsUrl}/${id}`);
  }

  update(comment) {
    return this.http.put(`${this.constants.commentsUrl}/${comment.id}`, comment);
  }

}
