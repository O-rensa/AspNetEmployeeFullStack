import { Component, OnInit } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { ActivatedRoute } from '@angular/router';
import { EmployeeServiceProxy } from '../../data/employeeServiceProxy';
import { Location } from '@angular/common';
import { CreateOrEditEmployeeDto } from '../../data/dto/createOrEditEmployeeDto';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-create-or-edit-employee',
  imports: [
    FormsModule
  ],
  templateUrl: './create-or-edit-employee.component.html',
  styleUrl: './create-or-edit-employee.component.css'
})
export class CreateOrEditEmployeeComponent implements OnInit {
  id: string | undefined;
  position: string | undefined;
  fName: string | undefined;
  mName: string | undefined;
  lName: string | undefined;
  age: number | undefined;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _employeeServiceProxy: EmployeeServiceProxy,
    private _location: Location
  ) { }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe(params => {
      this.id = params["id"];
      if (this.id) {
        this._employeeServiceProxy.getEmployeeById(this.id)
        .subscribe({
          next: (res) => {
            this.fName = res.firstName,
            this.mName = res.middleName,
            this.lName = res.lastName,
            this.position = res.title,
            this.age = res.age
          },
          error: (_) => {
            this.back();
          }
        })
      }
    });
  }

  submit(): void {
    let payload = {
      id: this.id,
      firstName: this.fName,
      middleName: this.mName,
      lastName: this.lName,
      age: this.age,
      title: this.position
    } as CreateOrEditEmployeeDto;

    if (this.id) {
      this._employeeServiceProxy.editEmployee(payload)
      .pipe(finalize(() => {
        this.back();
      }))
      .subscribe();

    } else {
      this._employeeServiceProxy.createEmployee(payload)
      .pipe(finalize(() => {
        this.back();
      }))
      .subscribe();
    }
  }

  back(): void {
    this._location.back();
  }
}
