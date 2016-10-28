import { RouterConfig } from '@angular/router';
import { Home } from './components/home/home';
import { NotebooksComponent } from './components/notebooks/notebooks.component';
import { FetchData } from './components/fetch-data/fetch-data';
import { Counter } from './components/counter/counter';

export const routes: RouterConfig = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: Home },
    { path: 'notebooks', component: NotebooksComponent },
    { path: 'counter', component: Counter },
    { path: 'fetch-data', component: FetchData },
    { path: '**', redirectTo: 'home' }
];
