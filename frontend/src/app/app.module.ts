import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router'
import { appRoutes } from './routerConfig';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PostElementComponent } from './components/post-element/post-element.component';
import { CommentComponent } from './components/comment/comment.component';
import { CreatepostComponent } from './components/createpost/createpost.component';
import { PostService } from './services/post.service';
import { Constants } from './constants';
import { CommentService } from './services/comment.service';
import { PostsComponent } from './components/posts/posts.component';
import { PostComponent } from './components/post/post.component';




@NgModule({
  declarations: [
    AppComponent,
    PostElementComponent,
    CommentComponent,
    CreatepostComponent,
    PostsComponent,
    PostComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    PostService,
    Constants,
    CommentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
