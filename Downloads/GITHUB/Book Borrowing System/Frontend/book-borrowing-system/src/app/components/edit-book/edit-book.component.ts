// edit-book.component.ts

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/modals/book';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {
  book: Book = {
    id: '', 
    name: '',
    author: '',
    rating: 0,
    genre: '',
    description: '',
    isBookAvailable: true,
    lentByUserId: '',
    currentlyBorrowedById: ''
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private bookService: BookService
  ) {}

  ngOnInit() {
    // Retrieve the book ID from the route parameters
    this.route.params.subscribe(params => {
      const bookId = params['id']; // Make sure to define 'id' in your route
      if (bookId) {
        // Call the book service to get the book details by ID
        this.bookService.getBookById(bookId).subscribe(
          (book: Book) => {
            this.book = book;
          },
          (error) => {
            console.error('Error fetching book details:', error);
          }
        );
      }
    });
  }

  saveChanges() {
    // Call the book service to update the book details
    this.bookService.updateBook(this.book.id, this.book).subscribe(
      (updatedBook: Book) => {
        console.log('Book updated successfully:', updatedBook);
        // Navigate back to the user-books component or any other desired location
        this.router.navigate(['/user-books']);
      },
      (error) => {
        console.error('Error updating book:', error);
      }
    );
  }
}
