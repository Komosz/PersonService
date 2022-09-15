import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormComponent } from './form/form.component';
import { Person } from './services/models/person';
import { PeopleService } from './services/people.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor (private dialog:Dialog, private peopleService:PeopleService){
    
  }

  openDialog() {
    const dialogRef = this.dialog.open(FormComponent, {width:"400px", data:{toUpdate:false}});
    dialogRef.closed.subscribe((person:Person)=>{this.peopleService.AddPeople(person).subscribe(x=>this.peopleService.GetPeople())});
  }
} 