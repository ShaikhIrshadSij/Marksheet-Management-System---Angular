import { Routes, RouterModule } from '@angular/router';

//Route for content layout with sidebar, navbar and footer.

export const Full_ROUTES: Routes = [
  {
    path: 'dashboard',
    loadChildren: () => {
      return import('../../pages/pages.module').then(m => m.PagesModule);
    }
  },
];
