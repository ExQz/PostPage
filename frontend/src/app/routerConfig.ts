
import { Routes } from '@angular/router';
import { CommentComponent } from './components/comment/comment.component';
import { PostElementComponent } from './components/post-element/post-element.component';
import { CreatepostComponent } from './components/createpost/createpost.component';
import { PostsComponent } from './components/posts/posts.component';


export const appRoutes: Routes = [
  {
    path: 'comment',
    component: CommentComponent
  },
  {
    path: 'post',
    component: PostElementComponent
  },
  {
    path: 'post/:id',
    component: PostElementComponent
  },
  {
    path: 'createpost',
    component: CreatepostComponent
  },
  {
    path: 'posts',
    component: PostsComponent
  },
  {
    path: '',
    component: PostsComponent
  }
];
