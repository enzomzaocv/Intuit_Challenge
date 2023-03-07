import { Component, OnInit } from '@angular/core';
import { customerResponse } from '../../../interfaces/customerResponse';
import { CustomerService } from '../../../services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: []
})
export class CustomerListComponent implements OnInit {
  costumerList: customerResponse[] = [];

  constructor(
    private costumerService: CustomerService,
  ) { }

  ngOnInit() {
    this.getCustomers();
  }

  getCustomers(name?:string){
    name  = typeof(name) === 'undefined' ? "" : name;

    this.costumerService.getAllCustomers(name)
    .subscribe({
      next:(response) =>{
        this.costumerList = response
      },
      error(error) {
        alert(error.error)
      },
    });
  }

  onView(customer : customerResponse){

  }
}