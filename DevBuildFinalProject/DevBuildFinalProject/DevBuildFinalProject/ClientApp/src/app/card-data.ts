import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Card } from './Interfaces/Card';

@Injectable({ providedIn: 'root' })

export class CardDataService {
  constructor(private http: HttpClient) { }

  getAllCardsOwnedById(id: number) {
    return this.http.get<Card[]>(`/api/card/character/${id}`); //remember to use tilda
  }
}
