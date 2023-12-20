import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../modals/book';
import { MatDialog } from '@angular/material/dialog';
import { BookDetailsModalComponent } from '../book-details-modal/book-details-modal.component';

@Component({
  selector: 'app-book-list',
  templateUrl: './Home-page.component.html',
  styleUrls: ['./Home-page.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  filteredBooks: Book[] = [];
  searchTerm: string = '';

  constructor(private bookService: BookService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.bookService.getBooks().subscribe((books) => {
      this.books = books;
      this.applySearchFilter();
    });
  }

  showBookDetails(book: Book) {
    this.dialog.open(BookDetailsModalComponent, {
      data: book
    });
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
