import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ErrorComponent } from './error/error.component';


const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'error',
        component: ErrorComponent,
        data: {
          title: 'Error Page'
        }
      },  
      {
        path: 'login',
        component: LoginComponent,
        data: {
          title: 'Login Page'
        }
      },      
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContentPagesRoutingModule { }
