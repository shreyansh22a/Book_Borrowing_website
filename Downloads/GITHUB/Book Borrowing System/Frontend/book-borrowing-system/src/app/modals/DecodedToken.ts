// jwt-token.interface.ts
export interface DecodedToken {
    sub: string; // Subject (e.g., user ID)
    exp: number; // Expiration time
    iat: number; // Issued at time
    // Add other claims as needed
    UserId: string;
    UserName: string;
    TokensAvailable: string;
  }
  