"use client";

import { useMemo, useState } from "react";
import { Input } from "@/components/ui/input";
import { ProductGrid } from "@/components/product/ProductGrid";
import { useCart } from "@/lib/cart-store";

interface Product {
  id: string;
  name: string;
  price: number;
  stock: number;
}

interface ProductBrowserProps {
  products: Product[];
  searchPlaceholder: string;
  emptyLabel: string;
}

export function ProductBrowser({ products, searchPlaceholder, emptyLabel }: ProductBrowserProps) {
  const [search, setSearch] = useState("");
  const { addItem } = useCart();

  const filtered = useMemo(() => {
    const q = search.trim().toLowerCase();
    if (!q) return products;
    return products.filter((p) => p.name.toLowerCase().includes(q));
  }, [products, search]);

  return (
    <>
      <div className="flex justify-center">
        <Input
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          placeholder={searchPlaceholder}
          className="max-w-md"
        />
      </div>

      <ProductGrid
        products={filtered}
        emptyLabel={emptyLabel}
        onAddToCart={(id) => {
          const product = filtered.find((p) => p.id === id);
          if (product) addItem(product);
        }}
      />
    </>
  );
}
