import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../modals/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:7019/api/Books'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  getBookById(id: string): Observable<Book> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Book>(url);
  }

  addBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.apiUrl, book);
  }

  updateBook(id: string, book: Book): Observable<Book> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<Book>(url, book);
  }

  deleteBook(id: string): Observable<Book> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<Book>(url);
  }

  borrowBook(bookId: string, borrowingUserId: string): Observable<Book> {
    const url = `${this.apiUrl}/borrow/${bookId}/${borrowingUserId}`;
    return this.http.put<Book>(url, null); // Use null as the request body for a simple PUT request
  }
  returnBook(bookId: string): Observable<any> {
    const url = `${this.apiUrl}/return/${bookId}`;
    return this.http.put(url, {});
  }
  rateBook(bookId: string, rating: number): Observable<any> {
    const url = `${this.apiUrl}/rate/${bookId}/${rating}`;
    return this.http.put(url, {});
  }
}
