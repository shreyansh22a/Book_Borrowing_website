import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { Products } from 'src/app/Models/product.model';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AppComponent } from 'src/app/app.component';


@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  productId!: string;
  product: Products = {
    productName: '',
    description: '',
    category: '',
    availableQuantity: 0,
    image: '',
    price: 0,
    discount: 0,
    specification: '',
    id: ''
  };

  constructor(private route: ActivatedRoute, private productService: ProductService,
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private appComponent: AppComponent
    ) {this.appComponent.showNavBar = false;}


  ngOnInit() {
    this.route.params.subscribe(params => {
      this.productId = params['id'];
      this.getProductDetails();
    });
  }

  onFileSelected(event: any) {
    const imageFile: File = event.target.files[0];
  
    // Perform any necessary image validation here
    if (imageFile.type !== 'image/jpeg') {
      // Show an error message or take appropriate action for unsupported file format
      console.error('Only JPG files are supported.');
      this.openSnackBar('Only JPG files are supported.', 'Error!!!');
      return;
    }
  
    // Create a FormData object to send the file
    const formData = new FormData();
    formData.append('imageFile', imageFile);
    console.log(formData);
  
    // Make an HTTP request to the backend to save the image file
    this.http.post<any>('https://localhost:7100/api/ImageCopy/upload-image', formData)
      .subscribe(
        (response: any) => {
          if (response && response.imageUrl) {
            // Store the image URL in the product object
            this.product.image = response.imageUrl;
            console.log(response)
            console.log(this.product)
            this.openSnackBar('Image saved successfully', 'Success!!!');
            console.log('Image saved successfully:', response.imageUrl);
          } else {
            console.error('Invalid response:', response);
            this.openSnackBar('Invalid response', 'Error!!!');
          }
        },
        (error: any) => {
          console.error('Error saving image:', error);
          this.openSnackBar('Error saving image', 'Error!!!');
        }
      );
  }  
  getProductDetails() {
    this.productService.getProductById(this.productId).subscribe(
      (response): void => {
        this.product = response;
      },
      (error) => {
        console.log(error);
        // Handle the error if the product details cannot be retrieved
      }
    );
  }

  
    updateProduct() {
      this.productService.editProduct(this.product).subscribe(
        (response): any => {
          // Handle the success response, such as displaying a success message
          console.log(response);
          this.openSnackBar('Product editted','Success!!!');
        },
        (error): any => {
          // Handle the error, such as displaying an error message
          console.log(error);
        }
      );
    }

openSnackBar(message: string, action: string) {
  this.snackBar.open(message, action, {
    duration: 2000 // Adjust the duration as per your preference
  });
}
}

