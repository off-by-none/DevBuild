import { Component, OnInit } from '@angular/core';
import { RedditService } from '../reddit-service.service';
import { Posts } from '../interfaces/ireddit';

@Component({
  selector: 'app-api-view',
  templateUrl: './api-view.component.html',
  styleUrls: ['./api-view.component.css']
})

export class ApiViewComponent implements OnInit {
  
  posts:Posts;

  constructor(private redditService:RedditService) { }

  ngOnInit(): void {
    this.redditService.getPosts().subscribe(
      (data:Posts) => this.posts = { ...data }, 
      error => console.error(error)
    )
  }

}
