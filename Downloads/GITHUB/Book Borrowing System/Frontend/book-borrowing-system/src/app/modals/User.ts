export interface User {
    name: string;
    username: string;
    password: string;
    tokensAvailable: number;
    booksBorrowed: number;
    booksLent: number;
  }
  
  export interface RegisterUser {
    
    name: string;
    username: string;
    password: string;
    
  }
  export interface LoginUser {
    
    
    username: string;
    password: string;
    
  }
  