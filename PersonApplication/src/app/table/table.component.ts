import { Dialog } from '@angular/cdk/dialog';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormComponent } from '../form/form.component';
import { Person } from '../services/models/person';
import { PeopleService } from '../services/people.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {

  dataSource!: Person[];
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'streetName', 'houseNumber', 'apartmentNumber', 'postalCode', 'town', 'phoneNumber', 'dateOfBirth', 'age', 'actions'];

  constructor(private peopleService:PeopleService, private dialog:Dialog) { }

  ngOnInit(): void {
    this.peopleService.behavior.subscribe(x => this.dataSource = x);
    this.peopleService.GetPeople();
  }
  
  onDeleteSubmit(id:number): void{
    this.peopleService.DeletePerson(id).subscribe(_=>this.peopleService.GetPeople());
  }

  openDialog(person:Person) {
    const dialogRef = this.dialog.open(FormComponent, {width:"400px", data:{person,toUpdate:true}});
    dialogRef.closed.subscribe((person2:Person)=>{
      const personToUpdate: Person = {...person2,id:person.id};
      this.peopleService.UpdatePerson(personToUpdate).subscribe(_=>this.peopleService.GetPeople())});
  }
}