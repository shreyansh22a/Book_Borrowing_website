import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { BookListComponent } from './components/Home-page/Home-page.component';
import { DashboardComponent } from './components/dashboard/dashboard.component'
import { UserBooksComponent } from './components/user-books/user-books.component';
import { UserBorrowedBooksComponent } from './components/user-borrowed-books/user-borrowed-books.component';
import { EditBookComponent } from './components/edit-book/edit-book.component';
import { AuthGuard } from './AuthGuard';
const routes: Routes = [
  { path: '', component: BookListComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard], children: [
    {path: 'user-books',component:UserBooksComponent,canActivate: [AuthGuard]},
    {path: 'user-borrowed-books',component:UserBorrowedBooksComponent,canActivate: [AuthGuard]} 
  ] },

  {path: 'user-books',component:UserBooksComponent,canActivate: [AuthGuard], children:[
    { path: 'edit-book/:id', component: EditBookComponent,canActivate: [AuthGuard] },
  ]},
  {path: 'user-borrowed-books',component:UserBorrowedBooksComponent,canActivate: [AuthGuard]},
  { path: 'edit-book/:id', component: EditBookComponent,canActivate: [AuthGuard] },
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  
}
