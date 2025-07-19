import type { Metadata } from "next";
import "./globals.scss";
import { SideBar } from "@/components/SideBar";
import { NavBar } from "@/components/NavBar";
import Link from "next/link";
import Image from "next/image";

export const metadata: Metadata = {
  title: "X Tickets",
  description: "Selling tickets for your next event made easy.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <NavBar />
        <SideBar />
        <main className="container mx-auto min-h-screen p-4">
          {children}
        </main>
      </body>
    </html>
  );
}
