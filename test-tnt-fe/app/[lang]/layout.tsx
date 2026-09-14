import { Navbar } from "@/components/layout/Navbar";

export default function LangLayout({ children }: LayoutProps<"/[lang]">) {
  return (
    <>
      <Navbar />
      {children}
    </>
  );
}
