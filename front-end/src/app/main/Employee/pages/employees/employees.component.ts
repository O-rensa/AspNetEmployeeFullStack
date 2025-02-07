import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { EmployeeServiceProxy } from '../../data/employeeServiceProxy';

@Component({
  selector: 'app-employees',
  imports: [
    CommonModule
  ],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit {
  showTable: boolean = true;

  constructor(
    private _employeeServiceProxy: EmployeeServiceProxy
  ) {
  }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {
    this._employeeServiceProxy.getAll()
      .subscribe({
        next: (res) => {
          console.log(res);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
