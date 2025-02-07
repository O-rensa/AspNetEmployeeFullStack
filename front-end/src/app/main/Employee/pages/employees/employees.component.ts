import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { EmployeeServiceProxy } from '../../data/employeeServiceProxy';
import { GetEmployeeDto } from '../../data/dto/getEmployeeDto';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-employees',
  imports: [
    CommonModule
  ],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit {
  showTable: boolean = false;
  employees: GetEmployeeDto[] = [];

  constructor(
    private _employeeServiceProxy: EmployeeServiceProxy,
    private _router: Router
  ) {
  }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employees = [];
    this.showTable = false;
    this._employeeServiceProxy.getAll()
      .subscribe({
        next: (res) => {
          this.employees = res;
          this.showTable = res.length > 0;
        },
        error: (err) => {
          console.log(err);
        }
      });
  }

  createEmployee(): void {
    this._router.navigateByUrl("/main/employee/createOrEdit");
  }

  editEmployee(employeeId: string): void {
    const url = "/main/employee/createOrEdit?id=" + employeeId;
    this._router.navigateByUrl(url);
  }

  viewEmployee(employeeId: string): void {
    const url = "/main/employee/view?id=" + employeeId;
    this._router.navigateByUrl(url);
  }

  deleteEmployee(id: string): void {
    this._employeeServiceProxy.deleteEmployee(id)
    .pipe(finalize(() => {
      this.getEmployees();
    }))
    .subscribe();
  }
}
