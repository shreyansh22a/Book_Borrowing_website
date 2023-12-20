export type Decimal = number;

export interface Order {
    orderID: string;
    userID: string;
    productID: string;
    totalMoneyPaid: number | Decimal;
    orderTime: Date;
    orderDate: Date;
    productQuantity:number;
    // Include other necessary properties
  }
  