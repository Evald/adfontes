import { Component, Input} from '@angular/core';
import { NoteListComponent } from '../notes/note-list.component';

@Component({
  selector: 'notebook',
  template: require('./notebook-detail.html'),
  directives: [NoteListComponent]
})
export class NotebookDetailComponent {
   
   @Input() notebook: Notebook;
   public showNotes: boolean = false;

    constructor(){ }

    toggleShowNotes(){
        this.showNotes = !this.showNotes;
    }

}
