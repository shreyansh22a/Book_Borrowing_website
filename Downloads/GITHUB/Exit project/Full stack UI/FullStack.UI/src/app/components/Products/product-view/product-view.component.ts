import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { Products } from 'src/app/Models/product.model';
import { Review } from 'src/app/Models/Review';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
  productId!: string;
  product!: Products;
  reviews: Review[] = [];

  constructor(private route: ActivatedRoute, private productService: ProductService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.productId = params['id'];
      this.getProductDetails();
      this.getReviewsByProductId(this.productId);
    });
  }
  getReviewsByProductId(productId: string) {
    this.productService.getReviewsByProductId(productId).subscribe(
      (reviews: Review[]) => {
        this.reviews = reviews;
      },
      (error) => {
        console.error('Error fetching reviews:', error);
      }
    );
  }

  getProductDetails() {
    this.productService.getProductById(this.productId).subscribe(
      response => {
        this.product = response;
      },
      error => {
        // Handle the error if the product details cannot be retrieved
      }
    );
  }
}
