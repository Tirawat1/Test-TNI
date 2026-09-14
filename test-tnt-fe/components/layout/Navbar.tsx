"use client";

import Link from "next/link";
import { usePathname, useParams } from "next/navigation";
import { ShoppingCart } from "lucide-react";
import { locales } from "@/lib/i18n/config";
import { useCart } from "@/lib/cart-store";

export function Navbar() {
  const pathname = usePathname();
  const params = useParams<{ lang: string }>();
  const lang = params.lang;
  const { totalCount } = useCart();

  function switchLangHref(target: string) {
    const rest = pathname.split("/").slice(2).join("/");
    return `/${target}${rest ? `/${rest}` : ""}`;
  }

  return (
    <header className="flex h-16 items-center gap-4 border-b px-6">
      <Link href={`/${lang}/product`} className="mr-auto text-lg font-bold">
        Test-TNI
      </Link>

      <nav className="flex items-center gap-2 text-sm">
        {locales.map((l) => (
          <Link
            key={l}
            href={switchLangHref(l)}
            className={l === lang ? "font-semibold underline" : "text-gray-500"}
          >
            {l.toUpperCase()}
          </Link>
        ))}
      </nav>

      <Link
        href={`/${lang}/checkout`}
        className="relative flex size-9 items-center justify-center rounded-full hover:bg-black/5"
        aria-label="Cart"
      >
        <ShoppingCart size={20} strokeWidth={2} />
        {totalCount > 0 && (
          <span className="absolute top-0.5 right-0.5 flex size-4 items-center justify-center rounded-full bg-indigo-600 text-[10px] font-bold text-white">
            {totalCount}
          </span>
        )}
      </Link>
    </header>
  );
}
