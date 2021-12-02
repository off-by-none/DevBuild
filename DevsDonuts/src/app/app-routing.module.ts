import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { DonutsComponent } from './donuts/donuts.component';
import { DonutEditComponent } from './donut-edit/donut-edit.component';
import { FamousPersonDetailComponent } from './famous-person-detail/famous-person-detail.component';
import { FamousPeopleComponent } from './famous-people/famous-people.component';
import { DonutDetailComponent } from './donut-detail/donut-detail.component';
import { CommonModule } from '@angular/common';



const appRoutes: Routes = [
  { path: 'donut/:id/edit', component: DonutEditComponent },
  { path: 'donut', component: DonutsComponent },
  { path: 'donut/:id', component: DonutDetailComponent },
  { path: 'famous-people', component: FamousPeopleComponent },
  // { path: '', redirectTo: '/people', pathMatch: 'full' },
  // { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    
  ],
  imports: [RouterModule.forRoot(appRoutes), CommonModule, ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
