import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Donuts, Donut } from './interfaces/donut'

@Injectable({
  providedIn: 'root'
})
export class DonutService {
  apiUrl = 'https://grandcircusco.github.io/demo-apis/donuts.json';
  apiUrlSingle = 'https://grandcircusco.github.io/demo-apis/donuts/';
  ref:string;

  constructor(private http:HttpClient) { }

  getDonuts() {
    return this.http.get<Donuts>(this.apiUrl);
  }
  getDonut(id:number) {
    return this.http.get<Donut>(`${this.apiUrlSingle}/${id}.json`);
  }

}
