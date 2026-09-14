"use client";

import { create } from "zustand";
import { persist } from "zustand/middleware";

export interface CartItem {
  id: string;
  code: string;
  name: string;
  price: number;
  stock: number;
  quantity: number;
}

interface CartState {
  items: CartItem[];
  addItem: (item: Omit<CartItem, "quantity">) => boolean;
  removeItem: (id: string) => void;
  updateQuantity: (id: string, quantity: number) => boolean;
  clear: () => void;
}

const useCartStore = create<CartState>()(
  persist(
    (set, get) => ({
      items: [],
      addItem: (item) => {
        const existing = get().items.find((i) => i.id === item.id);
        const nextQuantity = (existing?.quantity ?? 0) + 1;
        if (nextQuantity > item.stock) return false;

        set((state) => ({
          items: existing
            ? state.items.map((i) =>
                i.id === item.id
                  ? { ...i, stock: item.stock, quantity: nextQuantity }
                  : i,
              )
            : [...state.items, { ...item, quantity: 1 }],
        }));
        return true;
      },
      removeItem: (id) =>
        set((state) => ({ items: state.items.filter((i) => i.id !== id) })),
      updateQuantity: (id, quantity) => {
        const item = get().items.find((i) => i.id === id);
        if (!item) return false;

        if (quantity <= 0) {
          set((state) => ({ items: state.items.filter((i) => i.id !== id) }));
          return true;
        }
        if (quantity > item.stock) return false;

        set((state) => ({
          items: state.items.map((i) => (i.id === id ? { ...i, quantity } : i)),
        }));
        return true;
      },
      clear: () => set({ items: [] }),
    }),
    { name: "cart" },
  ),
);

export function useCart() {
  const items = useCartStore((s) => s.items);
  const addItem = useCartStore((s) => s.addItem);
  const removeItem = useCartStore((s) => s.removeItem);
  const updateQuantity = useCartStore((s) => s.updateQuantity);
  const clear = useCartStore((s) => s.clear);

  const totalCount = items.reduce((sum, i) => sum + i.quantity, 0);
  const totalPrice = items.reduce((sum, i) => sum + i.quantity * i.price, 0);

  return {
    items,
    addItem,
    removeItem,
    updateQuantity,
    clear,
    totalCount,
    totalPrice,
  };
}
