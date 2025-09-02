import type { Metadata } from "next";
import { SideBar } from "@/components/SideBar";
import { NavBar } from "@/components/NavBar";
import { Footer } from "@/components/Footer";
import { ContextProvider } from "@/contexts/Providers";

import "./globals.scss";

export const metadata: Metadata = {
  title: " - X Tickets",
  description: "Selling tickets for your next event made easy.",
};

export default async function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <ContextProvider>
          <NavBar />
          <SideBar />
          <main className="container mx-auto min-h-screen">
            {children}
          </main>
          <Footer />
        </ContextProvider>
      </body>
    </html>
  );
}
