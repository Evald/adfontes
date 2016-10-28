import { Component, OnInit } from '@angular/core';
import { NotebookService } from "./notebook.service";
import { Observable } from 'rxjs';


@Component({
  selector: 'notebooks',
  template: require('./notebooks.html'),
  providers: [NotebookService]
})
export class NotebooksComponent implements OnInit {

    public notebooks : Notebook[];
    public errorMessage : string;

    constructor(private notebookservice : NotebookService){}

    ngOnInit(){
      this.getNotebooks();
      this.notebookservice.test();

      for (var index = 0; index < this.notebooks.length; index++) {
        var element = this.notebooks[index];
        console.log(element.title)
      }
    }

    getNotebooks(){
      this.notebookservice.getNotebooks()
        .subscribe(
          data => this.notebooks = data,
          error =>  this.errorMessage = <any>error);
  }

}
