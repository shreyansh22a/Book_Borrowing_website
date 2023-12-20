import { Component } from '@angular/core';

import { UserServiceService } from 'src/app/services/user-service.service';
import { AppComponent } from 'src/app/app.component';
import { ProductService } from 'src/app/services/product.service';
import { Products } from 'src/app/Models/product.model';
import { Observable, forkJoin } from 'rxjs';
@Component({
  selector: 'app-admin-view-recent-orders',
  templateUrl: './admin-view-recent-orders.component.html',
  styleUrls: ['./admin-view-recent-orders.component.css']
})
export class AdminViewRecentOrdersComponent {

  productDetails: any[] = [];
  updatedOrder: any[] = []; 
 
  constructor(private appComponent: AppComponent,
    
    private userService: UserServiceService,
    private productservice: ProductService,) {
    
  }
  ngOnInit(): void {
    this.getOrderDetails();
    console.log("Updated111111",this.productDetails);
  }
  getOrderDetails()
  {
  this.userService.getAllOrders().subscribe(
    (response: any[]) => {
      this.productDetails = response; // Assign the received order items to productDetails
      console.log(this.productDetails); // You can check the response in the console

      const observables = this.productDetails.map(item => this.getProductDetails(item.productID));
      forkJoin(observables).subscribe(
        () => {
           // Sort the productDetails array
           this.productDetails.sort((a, b) => {
            const dateTimeA = new Date(a.orderDate).getTime();
            const dateTimeB = new Date(b.orderDate).getTime();
            
            if (dateTimeA === dateTimeB) {
              // If orderDate is the same, compare based on orderTime
              return new Date(b.orderTime).getTime() - new Date(a.orderTime).getTime();
            }
            
            return dateTimeB - dateTimeA; // Sort in descending order
          });
           
          console.log("Updated", this.productDetails);
           // You can check the updated productDetails array in the console
          this.updatedOrder = [...this.productDetails]; // Copy the sorted productDetails array to updatedOrder
        },
        (error: any) => {
          console.log(error); // Handle the error if necessary
        }
      );
    },
    (error: any) => {
      console.log(error); // Handle the error if necessary
    }
  );
}

getProductDetails(productId: string) {
  return new Observable((observer) => {
    this.productservice.getProductById(productId).subscribe(
      (response: any) => {
        const orderItems = this.productDetails.filter(item => item.productID === productId);
        orderItems.forEach(item => {
          item.productName = response.productName;
          item.image = response.image;
        });
        observer.next(); // Emit empty value to indicate completion
        observer.complete(); // Complete the Observable
      },

      (error: any) => {
        console.log(error);
        observer.error(error); // Emit the error if necessary
        observer.complete(); // Complete the Observable
      }
    );
  });
}


  
  
}
