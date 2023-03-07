import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { customerResponse } from '../interfaces/customerResponse';
import { customerRequest } from '../interfaces/customerRequest';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  apiUrl: string = 'https://localhost:7013/api';
  customers: customerResponse[] = [];


  constructor(private httpClient: HttpClient) { }

  addCustomer(body:customerResponse):Observable<any>{
    return this.httpClient.post<customerResponse>(`${this.apiUrl}/Customer`, body);
  }

  getAllCustomers(name?:string):Observable<any>{
    return this.httpClient.get<customerResponse[]>(`${this.apiUrl}/Customer`);
  }

  getCustomer(id:number):Observable<any>{
    return this.httpClient.get<customerResponse>(`${this.apiUrl}/Customer/${id}`);
  }

  getCustomers(){
    return this.customers;
  }
}