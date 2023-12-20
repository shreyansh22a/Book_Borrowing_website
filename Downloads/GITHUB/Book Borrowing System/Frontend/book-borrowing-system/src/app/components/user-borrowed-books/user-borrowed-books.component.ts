// user-borrowed-books.component.ts
import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { BorrowBook,Book } from 'src/app/modals/book';
import { UserService } from 'src/app/services/user.service';
import { BookDetailsModalComponent } from '../book-details-modal/book-details-modal.component';
import { MatDialog } from '@angular/material/dialog';
@Component({
  selector: 'app-user-borrowed-books',
  templateUrl: './user-borrowed-books.component.html',
  styleUrls: ['./user-borrowed-books.component.css'],
})
export class UserBorrowedBooksComponent implements OnInit {



  allBooks: Book[] = [];
  borrowedBooks: BorrowBook[] = [];
  emptyStars = Array(5).fill(0);
  selectedRating: number = 0;
 

  constructor(private bookService: BookService,private userservice:UserService,private dialog: MatDialog) {}

  ngOnInit(): void {
    // Call the service method to get all books
    this.refreshBorrowedBooks();
   
  }
  refreshBorrowedBooks()
  {
    this.bookService.getBooks().subscribe(
      (books) => {
        this.allBooks = books;
        const data: string | null = localStorage.getItem('data');
        const decodedToken = this.userservice.getDecodedToken(data);
        const userId = decodedToken.UserId;
        // Filter books based on the borrowedByUserId
        this.borrowedBooks = this.allBooks
        .filter((book) => book.currentlyBorrowedById === userId)
        .map((book) => ({ ...book, selectedRating: 0 }));
      
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
  returnBook(bookId: string) {
    this.bookService.returnBook(bookId).subscribe(
      () => {
        console.log('Book returned successfully');
        // Refresh the list of borrowed books
        this.refreshBorrowedBooks();
      },
      (error) => {
        console.error('Error returning book:', error);
      }
    );
  }
  selectRating(rating: number,book:any) {
    book.selectedRating=rating;
    console.log(book.name,book.selectedRating)
    
  }
  
  submitRating(book:any) {
    var bookId=book.id;
    var rating=(book.rating+book.selectedRating)/2;
    this.bookService.rateBook(bookId, rating).subscribe(
      (response) => {
        console.log('Book rated successfully:', response);
        // You can update the local book details if needed
       this.refreshBorrowedBooks();
      },
      (error) => {
        console.error('Error rating book:', error);
      }
    );


  }
  
  
}
