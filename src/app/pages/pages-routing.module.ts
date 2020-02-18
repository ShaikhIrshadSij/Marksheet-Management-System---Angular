import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MarksheetComponent } from './uploads/marksheet/marksheet.component';
import { MarksheetDataComponent } from './marksheet-data/marksheet-data.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: DashboardComponent,
        data: {
          title: 'Dashboard'
        }
      },
      {
        path: 'marksheet',
        component: MarksheetComponent,
        data: {
          title: 'Marksheet Upload'
        }
      },
      {
        path: 'marksheet-data',
        component: MarksheetDataComponent,
        data: {
          title: 'Marksheet Upload'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule { }
