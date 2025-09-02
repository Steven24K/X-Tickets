import type { Metadata } from "next";
import { cookies } from "next/headers";
import { SideBar } from "@/components/SideBar";
import { NavBar } from "@/components/NavBar";
import { Footer } from "@/components/Footer";
import { ContextProvider } from "@/contexts/Providers";
import { ApiResponse, StrapiClientAdapter } from "@/services/StrapiClient";
import { StrapiShopOwner } from "@/types/models/StrapiCollections";
import { IsRight } from "@/types/Func";

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

  const _cookies = await cookies()
  let maybeUser: ApiResponse<StrapiShopOwner> = IsRight('Unloaded')
  if (_cookies.has('token')) {
    const token = _cookies.get('token')?.value || ''
    const strapi = new StrapiClientAdapter()
    maybeUser = await strapi.getCurrentUser(token)
  }

  return (
    <html lang="en">
      <body>
        <ContextProvider currentUser={maybeUser}>
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
