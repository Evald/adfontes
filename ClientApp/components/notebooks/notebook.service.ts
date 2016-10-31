import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class NotebookService {  

    constructor(private http: Http) {
        
    }

     getNotebooks(): Observable<Notebook[]> {
          return this.http.get('/api/Notebook')
                    .map(res => res.json());
    }
    //   addHero (name: string): Observable<Hero> {
    //     let headers = new Headers({ 'Content-Type': 'application/json' });
    //     let options = new RequestOptions({ headers: headers });
    //     return this.http.post(this.heroesUrl, { name }, options)
    //                     .map(this.extractData)
    //                     .catch(this.handleError);
    //   }


}