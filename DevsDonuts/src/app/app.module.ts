import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { IconSetComponent } from '../icon-set.component';

import { SparkAngularModule } from "@sparkdesignsystem/spark-angular";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { DonutsComponent } from './donuts/donuts.component';
import { FamousPersonDetailComponent } from './famous-person-detail/famous-person-detail.component';
import { FamousPeopleComponent } from './famous-people/famous-people.component';
import { DonutDetailComponent } from './donut-detail/donut-detail.component';
import { DonutEditComponent } from './donut-edit/donut-edit.component';



@NgModule({
  declarations: [AppComponent,IconSetComponent, FamousPersonDetailComponent, FamousPeopleComponent, DonutsComponent,
    DonutDetailComponent,
    DonutEditComponent],
  imports: [
    SparkAngularModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
