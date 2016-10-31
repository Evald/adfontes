import { Component, OnInit, Input } from '@angular/core';
import { NoteService } from "./note.service";
import { Observable } from 'rxjs';
import { Router, Params } from '@angular/router';


@Component({
  selector: 'notes',
  template: require('./note-list.html'),
  providers: [NoteService],
  directives: []
})
export class NoteListComponent implements OnInit {

    
    public notes: Note[];
    @Input() notebookId: number;

    constructor(private router: Router, private noteservice: NoteService){}

    ngOnInit(){
      this.getNotes(this.notebookId);
    }

    getNotes(id: number){
      this.noteservice.getNotes(id).subscribe(res => {
        console.log(res);
        this.notes = res;
      });
    }

    onSelect(notebook: Notebook) {
    this.router.navigate(['/notebook', notebook.notebookId]);
  }

}
