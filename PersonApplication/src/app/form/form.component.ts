import { DialogRef, DIALOG_DATA } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Person } from '../services/models/person';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {

  constructor(public formBuilder:FormBuilder, public dialogRef:DialogRef, @Inject(DIALOG_DATA) public data: {person: Person, toUpdate:boolean}) { }

  public form!:FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: this.formBuilder.control('', [Validators.required]),
      lastName: this.formBuilder.control('', [Validators.required]),
      streetName: this.formBuilder.control('', [Validators.required]),
      houseNumber: this.formBuilder.control('', [Validators.required]),
      apartmentNumber: this.formBuilder.control(''),
      postalCode: this.formBuilder.control('', [Validators.required]),
      town: this.formBuilder.control('', [Validators.required]),
      phoneNumber: this.formBuilder.control('', [Validators.required]),
      dateOfBirth: this.formBuilder.control('', [Validators.required]),
    });
      if(this.data.toUpdate){
        this.form.patchValue(this.data.person);
      }
    }

    onSubmit(): void{
      this.dialogRef.close(this.form.getRawValue());
    }
}