import { ProductBrowser } from "@/components/product/ProductBrowser";
import { getDictionary } from "@/lib/i18n/get-dictionary";
import { getProducts } from "@/lib/api";

export default async function Page({ params }: PageProps<"/[lang]/product">) {
  const { lang } = await params;
  const [dict, products] = await Promise.all([
    getDictionary(lang),
    getProducts(),
  ]);

  const gridProducts = products.map((p) => ({
    id: String(p.id),
    code: p.code ?? "",
    name: (lang === "en" ? p.productNameEn : p.productNameTh) ?? p.code ?? "",
    price: p.costPerItem,
    stock: p.stock,
  }));

  return (
    <div className="mx-auto max-w-5xl w-full p-6 flex flex-col gap-6">
      <ProductBrowser
        products={gridProducts}
        searchPlaceholder={dict.product.searchPlaceholder}
        emptyLabel={dict.product.emptyLabel}
      />
    </div>
  );
}
