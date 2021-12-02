import { Component, OnInit, Input } from '@angular/core';
import { Donut, Donuts } from '../interfaces/donut';
import { DonutService } from '../donut-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-donut-detail',
  templateUrl: './donut-detail.component.html',
  styleUrls: ['./donut-detail.component.scss']
})
export class DonutDetailComponent implements OnInit {
  donut:Donut;
  @Input() id:number;

  constructor(private DonutService:DonutService, 
    private route:ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
 
      this.DonutService.getDonut(this.id + 1).subscribe(
        (data: Donut) => this.donut = { ...data },
        error => console.error(error)
      );
    })
  }

}
