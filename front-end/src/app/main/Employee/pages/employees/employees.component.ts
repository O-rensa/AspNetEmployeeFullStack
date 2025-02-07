import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { EmployeeServiceProxy } from '../../data/employeeServiceProxy';
import { GetEmployeeDto } from '../../data/dto/getEmployeeDto';
import { Router } from '@angular/router';

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

  editEmployee(employeeId: string): void {
    const url = "/main/employee/createOrEdit?id=" + employeeId;
    this._router.navigateByUrl(url);
  }

  viewEmployee(employeeId: string): void {
    this._router.navigate(["/main/employee/view", { queryParams: { id: employeeId }}]);
  }

  deleteEmployee(id: string): void {
    this._employeeServiceProxy.deleteEmployee(id).subscribe();
  }
}
