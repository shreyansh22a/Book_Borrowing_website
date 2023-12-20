export type Decimal = number;

export interface Products {
  id: string;
  productName: string;
  description: string;
  category: string;
  availableQuantity: number;
  image: string;
  price: number | Decimal;
  discount: number;
  specification: string;
}

export interface AddProducts {
  productName: string;
  description: string;
  category: string;
  availableQuantity: number;
  image: string;
  price: number ;
  discount: number;
  specification: string;
}
