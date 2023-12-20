import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/Products/product-list/product-list.component';
import { RegisterComponent } from './components/Register/register.component';
import { LoginComponent } from './components/Login/login.component';
import { AdminviewComponent } from './components/adminview/adminview.component';
import { UserviewComponent } from './components/userview/userview.component';
import { AddProductComponent } from './components/Products/add-product/add-product.component';
import { EditProductComponent } from './components/Products/edit-product/edit-product.component';
import { ProductViewComponent } from './components/Products/product-view/product-view.component';
import { ProductUserViewComponent } from './components/Products/product-user-view/product-user-view.component';
import { UserCartComponent } from './components/user-cart/user-cart.component';
import { UserOrdersComponent } from './components/user-orders/user-orders.component';
import { AdminViewRecentOrdersComponent } from './components/admin-view-recent-orders/admin-view-recent-orders.component';
import { AuthGuard } from './auth-guard';
import { AdminAuthGuard } from './auth-guard-admin';
import { AdminViewTop5sellingProductsComponent } from './components/Products/admin-view-top5selling-products/admin-view-top5selling-products.component';

const routes: Routes = [
  {
    path: "My_Orders/:id",
    component: UserOrdersComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "Top-5-Product",
    component: AdminViewTop5sellingProductsComponent,
    canActivate: [AdminAuthGuard]
  },
  {
    path: "My_Cart/:id",
    component: UserCartComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "Product-user-view/:id",
    component: ProductUserViewComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "Product-view/:id",
    component: ProductViewComponent,
  },
  {
    path: "Edit-Product/:id",
    component: EditProductComponent,
    canActivate: [AdminAuthGuard]
  },
  {
    path: "",
    component: ProductListComponent
  },
  {
    path: "Products",
    component: ProductListComponent
  },
  {
    path: "Register",
    component: RegisterComponent
  },
  {
    path: "Login",
    component: LoginComponent
  },
  {
    path: '',
    redirectTo: '/Login',
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: '/Register',
    pathMatch: 'full'
  },
  {
    path: "Admin-view",
    component: AdminviewComponent,
    canActivate: [AdminAuthGuard],
    children: [
      {
        path: "Add-Product",
        component: AddProductComponent,
        canActivate: [AdminAuthGuard]
      },
      {
        path: "Recent-Orders",
        component: AdminViewRecentOrdersComponent,
        canActivate: [AdminAuthGuard]
      },
      {
        path: "Top-5-Product",
        component: AdminViewTop5sellingProductsComponent,
        canActivate: [AdminAuthGuard]
      }
    ]
  },
  {
    path: "User-view",
    component: UserviewComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "Add-Product",
    component: AddProductComponent,
    canActivate: [AdminAuthGuard]
  },
  {
    path: "Recent-Orders",
    component: AdminViewRecentOrdersComponent,
    canActivate: [AdminAuthGuard]
    
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
