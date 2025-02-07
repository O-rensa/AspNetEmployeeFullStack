import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EmployeeServiceProxy } from '../../data/employeeServiceProxy';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-employee',
  imports: [
    FormsModule
  ],
  templateUrl: './view-employee.component.html',
  styleUrl: './view-employee.component.css'
})
export class ViewEmployeeComponent implements OnInit {
  position: string | undefined;
  fName: string | undefined;
  mName: string | undefined;
  lName: string | undefined;
  age: number | undefined;

  constructor(
    private _location: Location,
    private _employeeServiceProxy: EmployeeServiceProxy,
    private _activatedRoute: ActivatedRoute
  ){}

  ngOnInit(): void {
    let id: string | undefined;
    this._activatedRoute.queryParams.subscribe(params => {
      id = params["id"];
      if (id) {
        this._employeeServiceProxy.getEmployeeById(id)
        .subscribe({
          next: (res) => {
            this.fName = res.firstName;
            this.mName = res.middleName;
            this.lName = res.lastName;
            this.age = res.age;
            this.position = res.title;
          },
          error: (_) => {
            this.back();
          }
        })
      } else {
        this.back();
      }
    })
  }

  back(): void {
    this._location.back();
  }
}
