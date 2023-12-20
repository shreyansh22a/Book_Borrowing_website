import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/app/services/user-service.service';
import { ProductService } from 'src/app/services/product.service';
import { Observable, forkJoin } from 'rxjs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit {
  productDetails: any[] = [];
  updatedOrder: any[] = []; // New array to hold updated order items with product details

  constructor(
    private orderService: UserServiceService,
    private productService: ProductService,
    private router:Router
  ) {}

  ngOnInit(): void {
    const userId = localStorage.getItem('userId') as string;

    this.orderService.getUserOrders(userId).subscribe(
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
           
            console.log("Updated", this.productDetails); // You can check the updated productDetails array in the console
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
      this.productService.getProductById(productId).subscribe(
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
  showProductDetails(item:any) {
    console.log("maaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",item.productID);
    this.router.navigate(['/Product-user-view', item.productID]);
  }
 
}
