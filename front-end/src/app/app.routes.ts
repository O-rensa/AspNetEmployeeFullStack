import { Routes } from '@angular/router';
import { EmployeesComponent } from './main/Employee/pages/employees/employees.component';
import { CreateOrEditEmployeeComponent } from './main/Employee/pages/create-or-edit-employee/create-or-edit-employee.component';
import { ViewEmployeeComponent } from './main/Employee/pages/view-employee/view-employee.component';

export const routes: Routes = [
    {
        path: "main/employee",
        component: EmployeesComponent
    },
    {
        path: "main/employee/createOrEdit",
        component: CreateOrEditEmployeeComponent,
    },
    {
        path: "main/employee/view",
        component: ViewEmployeeComponent,
    },
    {
        path: "**",
        redirectTo: "main/employee",
        pathMatch: "full",
    }
];
