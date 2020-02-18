import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FullLayoutComponent } from './layout/full-layout/full-layout.component';
import { Full_ROUTES } from './shared/routes/full-layout.routes';
import { ContentLayoutComponent } from './layout/content/content.component';
import { Content_ROUTES } from './shared/routes/content-layout.routes';
import { AuthGuard } from './core/auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  { path: '', component: FullLayoutComponent, data: { title: 'full Views' }, children: Full_ROUTES, canActivate: [AuthGuard] },
  { path: '', component: ContentLayoutComponent, data: { title: 'content Views' }, children: Content_ROUTES },
  {
    path: '**',
    redirectTo: 'error'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
