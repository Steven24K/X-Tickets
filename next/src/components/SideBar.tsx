"use client";
import { useState } from "react";

export const SideBar = () => {
    const [menuOpen, setMenuOpen] = useState(false);
    return (
        <>
            {!menuOpen && (
                <button
                    className="fixed bottom-5 right-5 z-50 bg-black text-white px-4 py-2 shadow-lg focus:outline-none border-black border-2 hover:bg-white hover:text-black transition-colors duration-300"
                    onClick={() => setMenuOpen((open) => !open)}
                    aria-label="Open menu"
                >
                    <span className="text-4xl">&#9776;</span>
                </button>
            )}
            <div
                className={`fixed top-0 right-0 h-full w-full sm:w-128 bg-black text-white shadow-lg z-40 flex flex-col transition-all duration-300 ${
                    menuOpen
                        ? "translate-x-0 opacity-100 scale-x-100"
                        : "translate-x-full opacity-0 scale-x-0 pointer-events-none"
                }`}
                style={{ transformOrigin: "right" }}
            >
                <button
                    className="self-end m-4 focus:outline-none"
                    onClick={() => setMenuOpen(false)}
                    aria-label="Close menu"
                >
                    <span className="text-6xl cursor-pointer">&times;</span>
                </button>
                <nav className="flex flex-col mt-8 space-y-6 px-8 text-3xl">
                    <a href="/" className="hover:underline">Home</a>
                    <a href="/about" className="hover:underline">About</a>
                    <a href="/contact" className="hover:underline">Contact</a>
                </nav>
            </div>
        </>
    );
}   