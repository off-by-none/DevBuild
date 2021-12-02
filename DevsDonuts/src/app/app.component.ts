import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'spark-starter-angular';
  isSpinningDonutBtnBool:boolean = false;
  isSpinningDevBtnBool:boolean = false;

  isSpinningDonutBtn = function() {
    this.isSpinningDonutBtnBool = true;
  }

  isSpinningDevBtn = function() {
    this.isSpinningDevBtnBool = true;
  }

}