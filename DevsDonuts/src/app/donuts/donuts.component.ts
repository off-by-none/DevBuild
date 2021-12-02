import { Component, OnInit } from '@angular/core';
import { Donut, Donuts } from '../interfaces/donut';
import { DonutService } from '../donut-service.service';

@Component({
  selector: 'app-donuts',
  templateUrl: './donuts.component.html',
  styleUrls: ['./donuts.component.scss']
})
export class DonutsComponent implements OnInit {
  donuts:Donuts;

  constructor(private DonutService: DonutService) { }

  ngOnInit(): void {
    this.DonutService.getDonuts().subscribe( 
      (data: Donuts)=> this.donuts = { ...data },
      error => console.error(error)
    )
  }

}
