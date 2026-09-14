import { defaultLocale, isLocale, type Locale } from "./config";

const dictionaries = {
  th: () => import("@/dictionaries/th.json").then((m) => m.default),
  en: () => import("@/dictionaries/en.json").then((m) => m.default),
};

export async function getDictionary(lang: string) {
  const locale: Locale = isLocale(lang) ? lang : defaultLocale;
  return dictionaries[locale]();
}
