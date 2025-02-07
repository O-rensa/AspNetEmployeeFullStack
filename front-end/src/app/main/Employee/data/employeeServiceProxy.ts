import { inject, Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { catchError, Observable } from "rxjs";
import { baseServerUrl, handleError } from "../../../shared/appConsts";
import { GetEmployeeDto } from "./dto/getEmployeeDto";
import { CreateOrEditEmployeeDto } from "./dto/createOrEditEmployeeDto";

@Injectable({
  providedIn: "root",
})
export class EmployeeServiceProxy {
  private readonly baseUrl: string = baseServerUrl + "employee/";
  private readonly http: HttpClient = inject(HttpClient);

  
  getAll(): Observable<GetEmployeeDto[]> {
    const url = this.baseUrl + "getAll";
    return this.http.get<GetEmployeeDto[]>(url).pipe(catchError(handleError));
  }
  
  getEmployeeById(id: string): Observable<GetEmployeeDto> {
    const url = this.baseUrl + "getEmployeeById/" + id;
    return this.http.get<GetEmployeeDto>(url);
  }
  
  createEmployee(employee: CreateOrEditEmployeeDto): Observable<any> {
    const url = this.baseUrl + "createEmployee";
    return this.http.post(url, employee);
  }
  
  editEmployee(employee: CreateOrEditEmployeeDto): Observable<any> {
    const url = this.baseUrl + "editEmployee";
    return this.http.put(url, employee);
  }
  
  deleteEmployee(id: string): Observable<any> {
    const url = this.baseUrl + "deleteEmployee/" + id;
    return this.http.delete(url);
  }
}