import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddProducts } from 'src/app/Models/product.model';
import { ProductService } from 'src/app/services/product.service';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  productForm!: FormGroup;
  product: AddProducts = {
    productName: '',
    description: '',
    category: '',
    availableQuantity: 0,
    image: '',
    price: 0,
    discount: 0,
    specification: ''
  };

  constructor(
    private http: HttpClient,
    private productService: ProductService,
    private appComponent: AppComponent,
    private snackBar: MatSnackBar,
    private formBuilder: FormBuilder
  ) {
    this.appComponent.showNavBar = false;
  }

  ngOnInit() {
    this.productForm = this.formBuilder.group({
      productName: ['', Validators.required],
      description: ['', Validators.required],
      category: ['', Validators.required],
      availableQuantity: [0, [Validators.required, Validators.min(0)]],
      image:'',
      price: [0, [Validators.required, Validators.min(0)]],
      discount: [0, [Validators.min(0)]],
      specification: ['', Validators.required],
    });
  }
  
  isInvalid(controlName: string): boolean {
    const control = this.productForm.get(controlName);
    return control ? control.invalid && control.touched : false;
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
            this.productForm.patchValue({ image: response.imageUrl });
            
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
  
  addProduct() {
    if (this.productForm.valid) {
      
      this.product = { ...this.productForm.value };
    
       // Assign form values to the product object
      this.productService.addProduct(this.product).subscribe(
        response => {
          // Product added successfully, handle the response or navigate to another page
          this.openSnackBar('Product added successfully', 'Success!!!');
          console.log('Product added:', response);
          console.log(this.productForm);
          this.productForm.reset(); // Reset the form
        },
        error => {
          // Handle the error if the product could not be added
          this.openSnackBar('Error adding product', 'Error!!!');
          console.log('Error adding product:', error);
        }
      );
    } else {
      // Show an error message or take appropriate action when the form is invalid
      this.openSnackBar('Invalid form input', 'Error!!!');
    }
  }
  
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000 // Adjust the duration as per your preference
    });
  }
}
