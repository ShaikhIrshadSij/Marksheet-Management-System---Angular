import { Routes, RouterModule } from '@angular/router';

//Route for content layout with sidebar, navbar and footer.

export const Content_ROUTES: Routes = [
  {
    path: '',
    loadChildren: () => import('../../content-pages/content.module').then(m => m.ContentPagesModule)
  },
];
