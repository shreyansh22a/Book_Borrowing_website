import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/app/services/user-service.service';
import { ProductService } from 'src/app/services/product.service';
import { CartItem } from 'src/app/Models/CartItem';
import { Router } from '@angular/router';
import { CartItem1 } from 'src/app/Models/CartItem';

@Component({
  selector: 'app-user-cart',
  templateUrl: './user-cart.component.html',
  styleUrls: ['./user-cart.component.css']
})
export class UserCartComponent implements OnInit {
  productDetails: any[] = [];
  cartItems: any[] = [];
  totalPrice: number = 0;
  totalDiscount: number = 0;
  totalAmountToPay: number = 0;
  showSuccessAlert: boolean = false;
  showFailureAlert: boolean = false;
  showFailureAlert3: boolean = false;
  showSuccessAlert4: boolean = false;
  showSuccessAlert5: boolean = false;
  
  

  constructor(
    private cartService: UserServiceService,
    private productService: ProductService,
    private router:Router,
    
  ) { }

  ngOnInit(): void {
    const userId = localStorage.getItem('userId') as string;
    this.cartService.getUserCart(userId).subscribe(
      (response: any[]) => {
        this.cartItems = response;
        console.log(response);
        for (const item of this.cartItems) {
          this.getProductDetails(item.productID);

        }
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  getProductDetails(productId: string) {
    this.productService.getProductById(productId).subscribe(
      (response: any) => {
        console.log(response);
        const productIndex = this.cartItems.findIndex((item) => item.productID === productId);
        if (productIndex !== -1) {
          this.cartItems[productIndex].productName = response.productName;
          this.cartItems[productIndex].image = response.image;
          this.cartItems[productIndex].price = response.price;
          this.cartItems[productIndex].description = response.description;
          this.cartItems[productIndex].discount = response.discount;
          this.cartItems[productIndex].availableQuantity = response.availableQuantity;
        }
        console.log(this.cartItems);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  calculateTotalPriceToPay(): number {
    let totalPriceToPay = 0;
    for (const item of this.cartItems) {
      totalPriceToPay +=   (item.price -(item.discount*item.price/100)) * item.productQuantity;
    }
    return totalPriceToPay;
  }
  placeOrder() {
    const userId = localStorage.getItem('userId') as string;
  
    for (const item of this.cartItems) {
      const totalQuantity = item.productQuantity;
      const availableQuantity = item.availableQuantity;
  
      if (totalQuantity > availableQuantity) {
        this.showFailureAlert3 = true;
        setTimeout(() => {
          this.showFailureAlert3 = false;
        }, 3000);
        return;
      }
    }
  
    for (const item of this.cartItems) {
      const order: any = {
        userID: userId,
        productID: item.productID,
        totalMoneyPaid: Math.round((item.price - (item.discount * item.price / 100)) * item.productQuantity),

        productQuantity: item.productQuantity
      };
  
      this.cartService.addOrder(order).subscribe(
        (response: any) => {
          console.log(response);
          this.cartItems = [];
          this.totalAmountToPay = 0;
          this.showSuccessAlert = true;
          setTimeout(() => {
            this.showSuccessAlert = false;
          }, 3000);
        },
        (error: any) => {
          console.log(error);
          this.showFailureAlert = true;
          setTimeout(() => {
            this.showFailureAlert = false;
          }, 3000);
        }
      );
  
      this.cartService.emptyUserCart(userId).subscribe(
        (response: any) => {
          console.log(response);
        },
        (error: any) => {
          console.log(error);
        }
      );
  
      this.productService.updateProductQuantity(item.productID, item.productQuantity).subscribe(
        (response: any) => {
          console.log(response);
        },
        (error: any) => {
          console.log(error);
        }
      );
    }
  }
  

  deleteCartItem(cartId: string): void {
    this.cartService.deleteCartItem(cartId).subscribe(
      (response) => {
        console.log(response);
        this.cartItems = this.cartItems.filter(product => cartId !== cartId);
        window.location.reload();
        this.showSuccessAlert5 = true;

        setTimeout(() => {
          this.showSuccessAlert5 = false;
        }, 3000);
        const index = this.cartItems.findIndex(item => item.cartId === cartId);
        if (index !== -1) {
          this.cartItems.splice(index, 1);
        }
      },
      (error) => {
        console.log('Error deleting cart item:', error);
      }
    );
  }
  

  emptyCart(): void {
    const userId = localStorage.getItem('userId') as string;
    this.cartService.emptyUserCart(userId).subscribe(
      (response: any) => {
        console.log(response);
        this.showSuccessAlert4 = true;
        setTimeout(() => {
          this.showSuccessAlert4 = false;
        }, 3000);
      },
      (error: any) => {
        console.log(error);
      }
    );
    this.cartItems = [];
  }

  decreaseQuantity(item: any): void {
    if (item.productQuantity > 1) {
      item.productQuantity--;
    }
  }
  
  increaseQuantity(item: any): void {
    if (item.productQuantity < item.availableQuantity) {
      item.productQuantity++;
    }
  }
   showProductDetails(item:any) {
    console.log("maaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",item.productID);
    this.router.navigate(['/Product-user-view', item.productID]);
  }

}

