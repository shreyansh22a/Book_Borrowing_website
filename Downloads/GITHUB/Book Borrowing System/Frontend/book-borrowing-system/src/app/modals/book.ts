export interface Book {
    

    id: string;
    name: string;
    rating: number;
    author: string;
    genre: string;
    isBookAvailable: boolean;
    description: string;
    lentByUserId: string ; // Make these properties nullable
    currentlyBorrowedById?: string | null;
  }
  
  export interface BorrowBook {
    
    selectedRating: number;
    id: string;
    name: string;
    rating: number;
    author: string;
    genre: string;
    isBookAvailable: boolean;
    description: string;
    lentByUserId: string ; // Make these properties nullable
    currentlyBorrowedById?: string | null;
  }