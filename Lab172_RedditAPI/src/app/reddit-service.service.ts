import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Posts, Post } from './interfaces/ireddit';

@Injectable({
  providedIn: 'root'
})

export class RedditService {
  apiUrl = 'https://www.reddit.com/r/aww/.json';

  constructor(private http:HttpClient) { }

  getPosts() {
    return this.http.get<Posts>(`${this.apiUrl}`)
  }

}
