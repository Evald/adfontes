import { Component, OnInit } from '@angular/core';
import { NotebookService } from "./notebook.service";
import { Observable } from 'rxjs';


@Component({
  selector: 'notebooks',
  template: require('./notebooks.html'),
  providers: [NotebookService]
})
export class NotebooksComponent implements OnInit {

    public notebooks: Notebook[];

    constructor(private notebookservice: NotebookService){}

    ngOnInit(){
      this.getNotebooks();
    }

    getNotebooks(){
      this.notebookservice.getNotebooks().subscribe(res => {
        console.log(res);
        this.notebooks = res;
      });
    }

}
