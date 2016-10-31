import { Component, OnInit } from '@angular/core';
import { NotebookService } from "./notebook.service";
import  { NotebookDetailComponent }  from "./notebook-detail.component"
import { Observable } from 'rxjs';
import { Router, Params } from '@angular/router';


@Component({
  selector: 'notebooks',
  template: require('./notebook-list.html'),
  providers: [NotebookService],
  directives: [NotebookDetailComponent]
})
export class NotebookListComponent implements OnInit {

    public notebooks: Notebook[];

    constructor(private router: Router, private notebookservice: NotebookService){}

    ngOnInit(){
      this.getNotebooks();
    }

    getNotebooks(){
      this.notebookservice.getNotebooks().subscribe(res => {
        console.log(res);
        this.notebooks = res;
      });
    }

  //   onSelect(notebook: Notebook) {
  //   this.router.navigate(['/notebook', notebook.notebookId]);
  // }

}
