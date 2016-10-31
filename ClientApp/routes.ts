import { RouterConfig } from '@angular/router';
import { Home } from './components/home/home';
import { NotebookListComponent } from './components/notebooks/notebook-list.component';
import { NotebookDetailComponent } from './components/notebooks/notebook-detail.component';
import { FetchData } from './components/fetch-data/fetch-data';
import { Counter } from './components/counter/counter';

export const routes: RouterConfig = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: Home },
    { path: 'notebooks', component: NotebookListComponent },
    { path: 'notebook/:id', component: NotebookDetailComponent },
    { path: '**', redirectTo: 'home' }
];
