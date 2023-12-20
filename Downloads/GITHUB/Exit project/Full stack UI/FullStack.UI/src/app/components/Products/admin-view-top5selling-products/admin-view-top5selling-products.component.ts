import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-admin-view-top5selling-products',
  templateUrl: './admin-view-top5selling-products.component.html',
  styleUrls: ['./admin-view-top5selling-products.component.css']
})
export class AdminViewTop5sellingProductsComponent implements OnInit {
  topSellingProducts: any[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getTopSellingProducts();
  }

  getTopSellingProducts(): void {
    this.productService.getTopSellingProducts().subscribe(
      (response: any[]) => {
        console.log(response);
        this.topSellingProducts = response; // Assign the response directly since it contains productID and totalQuantitySold
        this.getProductDetails();
      },
      (error: any) => {
        console.log('Error occurred while fetching top-selling products:', error);
      }
    );
  }
  
  getProductDetails(): void {
    console.log('Top Selling Products:', this.topSellingProducts);
    this.topSellingProducts.forEach((product: any) => {
      this.productService.getProductById(product.productID).subscribe(
        (response: any) => {
          console.log('Product Details Response:', response);
          product.productDetails = response; // Assign the product details to the product object
        },
        (error: any) => {
          console.log(`Error occurred while fetching product details for product ID ${product.productID}:`, error);
        }
      );
    });
  }
  
  
  getRatingClass(quantitySold: number): string {
    if (quantitySold >= 5) {
      return 'rating-five';
    } else if (quantitySold >= 4) {
      return 'rating-four';
    } else if (quantitySold >= 3) {
      return 'rating-three';
    } else if (quantitySold >= 2) {
      return 'rating-two';
    } else {
      return 'rating-one';
    }
  }
  
}
