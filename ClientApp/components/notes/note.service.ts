import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class NoteService {  

    constructor(private http: Http) {
        
    }

     getNotes(parentId: number): Observable<Note[]> {
          return this.http.get(`api/Note/Parent/${parentId}`)
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