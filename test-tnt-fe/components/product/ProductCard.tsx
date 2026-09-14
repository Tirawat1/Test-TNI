"use client";

// Portable product card — plain Tailwind only.
// No image? Shows a colored placeholder with the first letter of the name.

interface ProductCardProps {
  name: string;
  price: number;
  stock: number;
  imageUrl?: string;
  addToCartLabel?: string;
  outOfStockLabel?: string;
  onAddToCart?: () => void;
}

export function ProductCard({
  name,
  price,
  stock,
  addToCartLabel = "Add to Cart",
  outOfStockLabel = "Out of Stock",
  onAddToCart,
}: ProductCardProps) {
  const inStock = stock > 0;

  return (
    <div className="group overflow-hidden rounded-2xl border border-gray-100 bg-white shadow-sm transition-all duration-300 hover:-translate-y-1 hover:shadow-xl">
      <span
        className={`absolute top-3 right-3 rounded-full px-2.5 py-1 text-xs font-semibold ${
          inStock
            ? "bg-emerald-100 text-emerald-700"
            : "bg-rose-100 text-rose-700"
        }`}
      >
        {inStock ? `${stock} left` : outOfStockLabel}
      </span>

      <div className="p-4">
        <h3 className="truncate font-semibold text-gray-900">{name}</h3>
        <p className="mt-1 text-xl font-bold text-indigo-600">฿{price}</p>
        <button
          disabled={!inStock}
          onClick={onAddToCart}
          className="mt-3 w-full rounded-lg bg-indigo-600 py-2.5 text-sm font-semibold text-white transition-all hover:bg-indigo-700 active:scale-95 disabled:cursor-not-allowed disabled:bg-gray-200 disabled:text-gray-400"
        >
          {inStock ? addToCartLabel : outOfStockLabel}
        </button>
      </div>
    </div>
  );
}
