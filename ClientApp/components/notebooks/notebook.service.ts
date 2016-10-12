import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class NotebookService {
    public notebooks: Notebook[];

    constructor(http: Http) {
        http.get('/api/SampleData/Notebooks').subscribe(result => {
            this.notebooks = result.json();
        });
    }

}