import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class NotebookService {  

    constructor(private http: Http) {
        
    }

    test () {
        console.log("test test test .... ");
    }
     getNotebooks (): Observable<Notebook[]> {
         let test = this.http.get('/api/Notebook/Notebooks')
                    .map(this.extractData)
                    .catch(this.handleError);

        console.log(typeof(test));
        return test;
    }
    //   addHero (name: string): Observable<Hero> {
    //     let headers = new Headers({ 'Content-Type': 'application/json' });
    //     let options = new RequestOptions({ headers: headers });
    //     return this.http.post(this.heroesUrl, { name }, options)
    //                     .map(this.extractData)
    //                     .catch(this.handleError);
    //   }
    private extractData(res: Response) {
        let body = res.json();
        return body.data || { };
    }
    private handleError (error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
        const body = error.json() || '';
        const err = body.error || JSON.stringify(body);
        errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
        errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

}