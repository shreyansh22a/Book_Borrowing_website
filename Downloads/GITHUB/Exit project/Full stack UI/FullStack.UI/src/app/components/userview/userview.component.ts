import { Component,OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Products } from 'src/app/Models/product.model';
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';
import { CartItem1 } from 'src/app/Models/CartItem';
import { UserServiceService } from 'src/app/services/user-service.service';
@Component({
  selector: 'app-userview',
  templateUrl: './userview.component.html',
  styleUrls: ['./userview.component.css']
})
export class UserviewComponent implements OnInit {
  products: Products[] = [];
  paginatedProducts: Products[][] = [];
  currentPage = 1; // Current page number
  pageSize = 6; // Number of products per page
  filteredProducts: Products[] = []; // New property for filtered products
  ratings: { [productId: string]: number } = {};
  categories: string[] = []; // New property for product categories
  selectedCategory: string = ''; // New property for selected category
  searchKeyword: string = ''; // New property for search keyword
  showSuccessAlert1: boolean = false;
  showFailureAlert3: boolean = false;
  showFailureAlert1: boolean = false;
  
  cartItem: CartItem1 = {
    
    productId: '',
    userID: '',
    productQuantity: 1,
  };

  constructor(private productService: ProductService, private router: Router,
    private userservice: UserServiceService,
    private snackbar:MatSnackBar) {}

  showProductDetails(product: Products) {
    this.router.navigate(['/Product-user-view', product.id]);
  }
  handleProductItemClick(event: MouseEvent, product: Products) {
    const target = event.target as HTMLElement;
    if (target.tagName !== 'BUTTON') {
      this.showProductDetails(product);
  }
}
  ngOnInit(): void {
    this.productService.getAllProducts().subscribe({
      next: (products) => {
        this.products = products;
        this.filteredProducts = products; // Initialize filtered products with all products
        this.fetchRatingsForProducts(products);
        this.extractCategories(products);
        this.paginateProducts();
      },
      error: (error) => {
        console.log('Error:', error); // Handle the error appropriately
      }
    });
  }

  fetchRatingsForProducts(products: Products[]): void {
    for (const product of products) {
      this.productService.getAverageRating(product.id).subscribe({
        next: (rating) => {
          this.ratings[product.id] = rating;
        },
        error: (error) => {
          console.log('Error:', error); // Handle the error appropriately
        }
      });
    }
    this.paginateProducts();
  }

  extractCategories(products: Products[]): void {
    this.categories = [...new Set(products.map((product) => product.category))];
  }

  filterByCategory(): void {
    if (this.selectedCategory) {
      this.filteredProducts = this.products.filter((product) => product.category === this.selectedCategory);
    } else {
      this.filteredProducts = this.products;
    }
    this.paginateProducts();
  }

  filterByKeyword(): void {
    const keyword = this.searchKeyword.toLowerCase();
    this.filteredProducts = this.products.filter(
      (product) =>
        product.productName.toLowerCase().includes(keyword) ||
        product.description.toLowerCase().includes(keyword)
    );
    this.paginateProducts();
  }

  paginateProducts() {
    this.paginatedProducts = [];
    const pageCount = Math.ceil(this.filteredProducts.length / this.pageSize);
    for (let i = 0; i < pageCount; i++) {
      const startIndex = i * this.pageSize;
      const endIndex = startIndex + this.pageSize;
      const page = this.filteredProducts.slice(startIndex, endIndex);
      this.paginatedProducts.push(page);
    }
    this.currentPage = 1;
  }
  get pages(): number[] {
    return Array.from({ length: this.paginatedProducts.length }, (_, index) => index + 1);
  }
  changePage(pageNumber: number) {
    this.currentPage = pageNumber;
  }

  addToCart(productID: string, availableQuantity:number) {
    
    this.cartItem.userID = localStorage.getItem('userId') as string;
    this.cartItem.productId = productID;
    this.cartItem.productQuantity = 1;

    if (this.cartItem.productQuantity > availableQuantity) {
      this.showFailureAlert3 = true;

      setTimeout(() => {
        this.showFailureAlert3 = false;
      }, 3000);
    } else {
      this.userservice.addToCart(this.cartItem).subscribe(
        (response: any) => {
          console.log("product added", response);
          this.showSuccessAlert1 = true;
          this.openSnackBar('Product added to cart', 'Success!!!');

          setTimeout(() => {
            this.showSuccessAlert1 = false;
          }, 3000);
        },
        (error: any) => {
          console.error(error);
          this.showFailureAlert1 = true;

          setTimeout(() => {
            this.showFailureAlert1 = false;
          }, 3000);
        }
      );
    }
  }
  openSnackBar(message: string, action: string) {
    this.snackbar.open(message, action, {
      duration: 2000 // Adjust the duration as per your preference
    });
  }
}
