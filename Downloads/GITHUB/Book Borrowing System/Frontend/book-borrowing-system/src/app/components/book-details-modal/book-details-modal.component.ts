// book-details-modal.component.ts

import { Component, Inject, Input } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Book } from 'src/app/modals/book';

@Component({
  selector: 'app-book-details-modal',
  templateUrl: './book-details-modal.component.html',
  styleUrls: ['./book-details-modal.component.css']
})
export class BookDetailsModalComponent {

  @Input() data: Book;

  constructor(
    public dialogRef: MatDialogRef<BookDetailsModalComponent>,
    @Inject(MAT_DIALOG_DATA) public receivedData: any
  ) {
    this.data = receivedData;
  }

  closeDialog() {
    this.dialogRef.close();
  }
  renderStarRating(rating: number): any[] {
    const stars = [];
    const fullStars = Math.floor(rating);
    const halfStar = rating - fullStars >= 0.5;

    for (let i = 0; i < fullStars; i++) {
      stars.push({ type: 'full' });
    }

    if (halfStar) {
      stars.push({ type: 'half' });
    }

    for (let i = stars.length; i < 5; i++) {
      stars.push({ type: 'empty' });
    }

    return stars;
  }

}
