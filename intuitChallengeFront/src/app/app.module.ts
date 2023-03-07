import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CustomerListComponent } from './components/customers/customer-list/customer-list.component';
import { CustomersComponent } from './components/customers/customers.component';
import { CustomerService } from './services/customer.service';
import { AppRoutingModule } from './app-routing.module';
import { CustomerComponent } from './components/customers/customer/customer.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent,
    CustomerComponent,
    CustomersComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
