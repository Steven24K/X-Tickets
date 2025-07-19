import type { Metadata } from "next";
import "./globals.scss";

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
        <main>
          {children}
        </main>
      </body>
    </html>
  );
}
