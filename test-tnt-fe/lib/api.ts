import axios from "axios";

export const api = axios.create({
  baseURL: process.env.BASEURL ?? "http://localhost:5144",
});

export interface Product {
  id: number;
  code: string | null;
  productNameTh: string | null;
  productNameEn: string | null;
  stock: number;
  costPerItem: number;
}

export interface CheckoutRequestItem {
  productId: number;
  quantity: number;
}

export interface CheckoutResponse {
  orderId: number;
  totalCost: number;
  createdAt: string;
}

export interface CheckoutErrorResponse {
  code: string;
  message: string;
}
export async function getProducts(): Promise<Product[]> {
  const res = await api.get<Product[]>("/api/products");
  return res.data;
}

export async function checkout(
  items: CheckoutRequestItem[],
): Promise<CheckoutResponse> {
  const res = await api.post<CheckoutResponse>("/api/checkout", { items });
  return res.data;
}
