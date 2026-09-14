"use client";

import { ProductCard } from "@/components/product/ProductCard";

interface Product {
  id: string;
  name: string;
  price: number;
  stock: number;
  imageUrl?: string;
}

interface ProductGridProps {
  products: Product[];
  onAddToCart?: (id: string) => void;
  emptyLabel?: string;
}

export function ProductGrid({ products, onAddToCart, emptyLabel = "No products" }: ProductGridProps) {
  if (products.length === 0) {
    return <p className="py-16 text-center text-gray-400">{emptyLabel}</p>;
  }

  return (
    <div className="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
      {products.map((p, i) => (
        <div
          key={p.id}
          style={{ animationDelay: `${i * 60}ms` }}
          className="animate-in fade-in slide-in-from-bottom-2 fill-mode-both"
        >
          <ProductCard
            name={p.name}
            price={p.price}
            stock={p.stock}
            imageUrl={p.imageUrl}
            onAddToCart={() => onAddToCart?.(p.id)}
          />
        </div>
      ))}
    </div>
  );
}
