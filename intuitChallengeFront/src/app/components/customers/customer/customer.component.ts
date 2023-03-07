import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

//  Service 
import { CustomerService } from '../../../services/customer.service';

import {customerResponse} from '../../../interfaces/customerResponse';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: []
})
export class CustomerComponent implements OnInit {

  customer : customerResponse = 
  {
    idCustomer: 0,
    name : "",
    surname : "",
    cuit: "",
    address : "",
    phone : "",
    email : "",
    birthdate : ""
  };

  isCreate = true;

  constructor(
    private router : Router,
    private route: ActivatedRoute,
    private customerService: CustomerService
  ) { }

  ngOnInit() {
    this.resetForm();

    let idCustomer = this.route.snapshot.paramMap.get('id');

    if(!idCustomer){
      this.isCreate = true;
    }else{
      this.customer.idCustomer = + (idCustomer)

      this.customerService.getCustomer(this.customer.idCustomer)
          .subscribe({
              next:(response) =>{
                this.customer = response
              },
              error(error) {
                alert(error.error)
              },
      });

      this.isCreate= false;
    }
  }

  onSubmit(customerForm: NgForm)
  {
    console.log(customerForm.value);
    
    this.customerService.addCustomer(customerForm.value)
    .subscribe({
      next:(response) =>{
        this.resetForm(customerForm);
        this.router.navigate(['clientes'])
      },
      error(error) {
        alert(error.error)
      }
    });
  }

  resetForm(customerForm?: NgForm)
  {
    if(customerForm != null){
        customerForm.reset();        
    }
  }
}