// dashboard.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/modals/book';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog,MatDialogRef } from '@angular/material/dialog';
import { BookDetailsModalComponent } from '../book-details-modal/book-details-modal.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  bookDetailsDialogRef: MatDialogRef<BookDetailsModalComponent> | null = null;
 // dashboard.component.ts

showBookDetails(book: Book) {
  this.dialog.open(BookDetailsModalComponent, {
    data: book
  });
}

addNewBook() {
  this.showAddBookForm();

}
  loggedIn: boolean = false;
  username: string = '';
  availableTokens: number = 0;
  userId:string="";
  books: Book[] = [];
  filteredBooks: Book[] = [];
 searchTerm="";

  showForm: boolean = false;
  newBookForm: FormGroup;


  constructor(private userService: UserService, private bookService: BookService,
    private dialog: MatDialog,
    private route:Router,
    private formBuilder: FormBuilder) {
      this.newBookForm = this.formBuilder.group({
        name: ['', Validators.required],
        author: ['', Validators.required],
        rating: [0, [Validators.required, Validators.min(0), Validators.max(5)]],
        genre: ['', Validators.required],
        description: ['', Validators.required],
      });
    }
    
  ngOnInit() {
    // Check if the user is logged in
    this.loggedIn = this.userService.isLoggedIn();

    if (this.loggedIn) {
      // Get user details
      const data: string | null = localStorage.getItem('data');

      // Now you can call the method
      const decodedToken = this.userService.getDecodedToken(data);

      this.username = decodedToken.UserName;
      
      this.userId=decodedToken.UserId
      this.userService.getUserById(this.userId).subscribe(
        (response)=>{
          this.availableTokens=response.tokensAvailable
        },
        (error) => {
          console.error('Error fetching users:', error);
        }
      );

  

      // Subscribe to the observable to get the books
      this.bookService.getBooks().subscribe(
        (books: Book[]) => {
          this.books = books;
          this.applySearchFilter();
        },
        (error) => {
          console.error('Error fetching books:', error);
        }
      );
    }
  }

 

 // dashboard.component.ts

 borrowBook(book: Book) {
  // Check if the user has enough tokens
  if (this.availableTokens < 1) {
    alert('User does not have enough tokens to borrow a book.');

    return;
  }

  // Get the userId of the user borrowing the book
  const borrowingUserId = this.userId;

  // Check if the book is not owned by the borrowing user
  if (book.lentByUserId.toUpperCase() === borrowingUserId.toUpperCase()) {
    alert("You can't borrow your own book");
    return;
  }

  // Deduct 1 token from the borrowing user

  // Update the book details
  book.isBookAvailable = false;
  book.currentlyBorrowedById = borrowingUserId;
  const capitalId = book.id.toUpperCase();
  console.log(capitalId);

  // Update the user's borrowed books
  this.bookService.borrowBook(capitalId, borrowingUserId).subscribe(
    () => {
      console.log('Book borrowed successfully:', book);

      // Update the user's available tokens
      this.userService.decrementUserTokens(this.userId).subscribe(
        () => {
          console.log('Tokens updated successfully');
        },
        (error) => {
          console.error('Error updating tokens:', error);
        }
      );

      this.userService.incrementUserTokens(book.lentByUserId).subscribe(
        () => {
          console.log('Tokens updated successfully');
        },
        (error) => {
          console.error('Error updating tokens:', error);
        }
      );

      // Refresh the list of books
      this.refreshBookList();
    },
    (error) => {
      console.error('Error borrowing book:', error);
    }
  );
}


  // Show the add new book form
  showAddBookForm() {
    this.showForm = true;
  }

  // Cancel adding a new book
  cancelAddBook() {
    this.showForm = false;
    // Reset the form
    this.newBookForm.reset();
  }

  onSubmitNewBook() {
    if (this.newBookForm.valid) {
      // Get the values from the form
      const newBook: Book = {
        id: 'string', 
        name: this.newBookForm.get('name')?.value,
        rating: 0,
        author: this.newBookForm.get('author')?.value,
        genre: this.newBookForm.get('genre')?.value,
        isBookAvailable: true, 
        description: this.newBookForm.get('description')?.value,
        lentByUserId: this.userId, // Prefill with username
        currentlyBorrowedById: null,
      };
      // Call your book service to add the new book
      this.bookService.addBook(newBook).subscribe(
        (createdBook) => {
         
          // Hide the form and reset it
          this.cancelAddBook();
          // Refresh the list of books
         
          
          alert("New book added successfully")
          this.refreshBookList();
          this.applySearchFilter();
        },
        (error) => {
          console.error('Error adding new book:', error);
          alert("Error adding new book")
        }
      );
    }
  }
  

  // Helper method to refresh the list of books
  private refreshBookList() {
    this.bookService.getBooks().subscribe(
      (books: Book[]) => {
        this.books = books;
      },
      (error) => {
        console.error('Error fetching books:', error);
      }
    );
  }
  searchBooks() {
    this.applySearchFilter();
  }
  
  private applySearchFilter() {
    this.filteredBooks = this.books.filter(
      (book) =>
        book.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        book.author.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        book.genre.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}


