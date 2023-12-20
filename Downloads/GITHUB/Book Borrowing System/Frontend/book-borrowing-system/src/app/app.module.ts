import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookListComponent } from './components/Home-page/Home-page.component';
import { NavbarComponent } from './components/Home_Navbar/navbar.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { JwtModule } from '@auth0/angular-jwt';
import { BookDetailsModalComponent } from './components/book-details-modal/book-details-modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserNavbarComponent } from './components/user-navbar/user-navbar.component';
import { UserBooksComponent } from './components/user-books/user-books.component';
import { UserBorrowedBooksComponent } from './components/user-borrowed-books/user-borrowed-books.component';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { EditBookComponent } from './components/edit-book/edit-book.component';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    NavbarComponent,
    RegisterComponent,
    LoginComponent,
    DashboardComponent,
    BookDetailsModalComponent,
    UserNavbarComponent,
    UserBooksComponent,
    UserBorrowedBooksComponent,
    ConfirmDialogComponent,
    EditBookComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MatDialogModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('data'),  
        allowedDomains: ['https://localhost:7019/swagger/index.html'], 
        disallowedRoutes: ['http://localhost:4200//login'], 
      },
    }),
    BrowserAnimationsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
