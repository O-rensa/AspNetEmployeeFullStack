import { throwError } from "rxjs";

export const baseServerUrl: string = "http://localhost:5069/v1/";

export const handleError = (error: any) => {
  console.log(error);
  return throwError(() => new Error("Something went wrong"));
}