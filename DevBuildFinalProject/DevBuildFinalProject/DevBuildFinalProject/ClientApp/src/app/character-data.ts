import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NewPlayer } from './Interfaces/NewPlayer';

@Injectable({ providedIn: 'root' })

export class CharacterDataService {
  constructor(private http: HttpClient) { }

  addPlayer(newPlayer: NewPlayer) {
    return this.http.post<NewPlayer>('/api/character/new', newPlayer);
  }
  getCurrentUser() {
    return this.http.get('/api/character/currentuser');
  }
  getEnemyByProgress(progress: number) {
    return this.http.get(`/api/character/enemy/${progress}`);
  }
}
