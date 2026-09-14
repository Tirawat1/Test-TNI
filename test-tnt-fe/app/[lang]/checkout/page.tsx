import { getDictionary } from "@/lib/i18n/get-dictionary";
import { CheckoutView } from "./CheckoutView";

export default async function Page({ params }: PageProps<"/[lang]/checkout">) {
  const { lang } = await params;
  const dict = await getDictionary(lang);

  return <CheckoutView cartTitle={dict.cart.cart} cartEmptyLabel={dict.cart.cart_empty} />;
}
