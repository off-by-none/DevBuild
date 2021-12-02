import { Component, OnInit, Input } from '@angular/core';
import { Donut, Donuts } from '../interfaces/donut';
import { DonutService } from '../donut-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-donut-edit',
  templateUrl: './donut-edit.component.html',
  styleUrls: ['./donut-edit.component.scss']
})
export class DonutEditComponent implements OnInit {
  donut:Donut;
  @Input() id:number;
  
  constructor(private DonutService:DonutService,
    private route:ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
 
      this.DonutService.getDonut(this.id).subscribe(
        (data: Donut) => this.donut = { ...data },
        error => console.error(error)
      );
    })
  }

}
