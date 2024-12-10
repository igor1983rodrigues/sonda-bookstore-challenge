import { Routes } from '@angular/router';

export const APP_ROUTES: Routes = [{
    path: 'book',
    loadChildren: () => import('./book/book.module').then(m => m.BookModule)
},{
    path: 'author',
    loadChildren: () => import('./author/author.module').then(m => m.AuthorModule)
},{
    path: 'subject',
    loadChildren: () => import('./subject/subject.module').then(m => m.SubjectModule)
}];
