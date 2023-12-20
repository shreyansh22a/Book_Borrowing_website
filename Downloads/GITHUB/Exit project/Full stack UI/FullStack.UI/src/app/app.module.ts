import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSliderModule } from '@angular/material/slider';
import { FormsModule } from '@angular/forms';
import {ReactiveFormsModule} from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListComponent } from './components/Products/product-list/product-list.component';
import {  HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './components/Register/register.component';
import { LoginComponent } from './components/Login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminviewComponent } from './components/adminview/adminview.component';
import { UserviewComponent } from './components/userview/userview.component';
import { AddProductComponent } from './components/Products/add-product/add-product.component';
import { EditProductComponent } from './components/Products/edit-product/edit-product.component';
import { ProductViewComponent } from './components/Products/product-view/product-view.component';
import { ProductUserViewComponent } from './components/Products/product-user-view/product-user-view.component';
import { UsernavbarComponent } from './components/navbar/usernavbar/usernavbar.component';
import { AdminNavbarComponent } from './components/navbar/admin-navbar/admin-navbar.component';
import { HomeNavbarComponent } from './components/navbar/home-navbar/home-navbar.component';
import { UserOrdersComponent } from './components/user-orders/user-orders.component';
import { UserCartComponent } from './components/user-cart/user-cart.component';
import { AnimatedAlertComponent } from './components/animated-alert/animated-alert.component';
import { AdminViewRecentOrdersComponent } from './components/admin-view-recent-orders/admin-view-recent-orders.component';
import { AdminViewTop5sellingProductsComponent } from './components/Products/admin-view-top5selling-products/admin-view-top5selling-products.component';


@NgModule({
  declarations: [
    
    AppComponent,
    ProductListComponent,
    RegisterComponent,  

    
    LoginComponent, AdminviewComponent, UserviewComponent, AddProductComponent, EditProductComponent, ProductViewComponent, ProductUserViewComponent, UsernavbarComponent, AdminNavbarComponent, HomeNavbarComponent, UserOrdersComponent, UserCartComponent, AnimatedAlertComponent, AdminViewRecentOrdersComponent, AdminViewTop5sellingProductsComponent
  ],
  imports: [
    MatSliderModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ToastrModule,
    MatSnackBarModule,
    
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
