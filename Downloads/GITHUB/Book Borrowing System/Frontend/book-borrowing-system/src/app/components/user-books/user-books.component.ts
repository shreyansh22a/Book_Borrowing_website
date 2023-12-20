// user-books.component.ts

import { BookDetailsModalComponent } from '../book-details-modal/book-details-modal.component';
import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/modals/book';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-user-books',
  templateUrl: './user-books.component.html',
  styleUrls: ['./user-books.component.css']
})
export class UserBooksComponent implements OnInit {
  books: Book[] = [];

  constructor(private bookService: BookService, private dialog: MatDialog,private userservice:UserService,
    private route:Router) {}

  ngOnInit() {
    // Load books initially
    this.refreshBookList();
  }

  refreshBookList() {
    this.bookService.getBooks().subscribe(
      (books: Book[]) => {
        
        const data: string | null = localStorage.getItem('data');
        const decodedToken = this.userservice.getDecodedToken(data);
        const userId = decodedToken.UserId;
        this.books = books.filter(book => book.lentByUserId === userId);
      },
      (error) => {
        console.error('Error fetching books:', error);
      }
    );
  }
  showBookDetails(book: Book) {
    this.dialog.open(BookDetailsModalComponent, {
      data: book
    });
  }

  editBook(bookId: string) {
    this.route.navigate(['/edit-book', bookId]);
  }
  

  deleteBook(bookId: string) {
    // Display confirmation dialog
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: {
        message: 'Are you sure you want to delete this book?'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      // If the user confirms the deletion
      if (result) {
        // Call the book service to delete the book
        this.bookService.deleteBook(bookId).subscribe(
          () => {
            console.log('Book deleted successfully.');
            // Refresh the list of books after deletion
            this.refreshBookList();
          },
          (error) => {
            console.error('Error deleting book:', error);
          }
        );
      }
    });
  }
}
