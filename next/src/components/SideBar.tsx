"use client";
import { useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faShoppingCart, faClose, faTrashCan } from '@fortawesome/free-solid-svg-icons'

export const SideBar = () => {
    const [menuOpen, setMenuOpen] = useState(false);
    return (
        <>
            {!menuOpen && (
                <button
                    className="fixed bottom-5 right-5 z-50 bg-black text-white px-2 py-2 shadow-lg focus:outline-none border-black border-2 hover:bg-white hover:text-black transition-colors duration-300"
                    onClick={() => setMenuOpen((open) => !open)}
                    aria-label="Open menu"
                >
                    <span className="text-2xl">
                        <FontAwesomeIcon icon={faShoppingCart} />
                    </span>
                </button>
            )}
            <div
                className={`fixed top-0 right-0 h-full w-full sm:w-128 bg-black text-white shadow-lg z-40 flex flex-col transition-all duration-300 ${menuOpen
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
                    <span className="text-4xl cursor-pointer">
                        <FontAwesomeIcon icon={faClose} />
                    </span>
                </button>

                <div className="bg-white text-black rounded-lg shadow-md mx-8 mt-4 p-4">
                    <h2 className="text-xl font-bold mb-2">Shopping Cart</h2>
                    {/* Example cart items, replace with your cart state */}
                    <ul className="divide-y divide-gray-200">
                        <li className="py-2 flex items-center justify-between">
                            <div className="flex flex-col">
                                <span className="font-semibold">Concert of Legends</span>
                                <span className="text-sm text-gray-600">2024-07-15, 19:30</span>
                                <div className="flex items-center mt-1">
                                    <span className="text-sm mr-2">Tickets:</span>
                                    <select className="border rounded px-1 py-0.5 text-sm" defaultValue={2}>
                                        {[...Array(10)].map((_, i) => (
                                            <option key={i + 1} value={i + 1}>{i + 1}</option>
                                        ))}
                                    </select>
                                    <span className="ml-4 text-sm text-gray-700">€50,-/ticket</span>
                                    <span className="ml-4 text-sm font-semibold">Total: €100,-</span>
                                </div>
                            </div>
                            <button className="ml-4 text-red-500 hover:text-red-700" aria-label="Remove item">
                                <FontAwesomeIcon icon={faTrashCan} />
                            </button>
                        </li>
                        <li className="py-2 flex items-center justify-between">
                            <div className="flex flex-col">
                                <span className="font-semibold">Jazz Night</span>
                                <span className="text-sm text-gray-600">2024-08-02, 21:00</span>
                                <div className="flex items-center mt-1">
                                    <span className="text-sm mr-2">Tickets:</span>
                                    <select className="border rounded px-1 py-0.5 text-sm" defaultValue={4}>
                                        {[...Array(10)].map((_, i) => (
                                            <option key={i + 1} value={i + 1}>{i + 1}</option>
                                        ))}
                                    </select>
                                    <span className="ml-4 text-sm text-gray-700">€30,-/ticket</span>
                                    <span className="ml-4 text-sm font-semibold">Total: €120,-</span>
                                </div>
                            </div>
                            <button className="ml-4 text-red-500 hover:text-red-700" aria-label="Remove item">
                                <FontAwesomeIcon icon={faTrashCan} />
                            </button>
                        </li>
                    </ul>
                </div>

                <div className="bg-white text-black rounded-lg shadow-md mx-8 mt-4 p-4">
                    <p className="text-sm text-gray-600">Total: €220,-</p>
                </div>

                <div className="mx-8 mt-4">
                    <button
                        className="w-full bg-green-600 hover:bg-green-700 text-white font-bold py-3 px-6 rounded-lg text-lg transition-colors duration-200 shadow-md"
                        aria-label="Proceed to checkout"
                    >
                        Checkout
                    </button>
                </div>

                <div className="flex flex-col mt-8 space-y-6 px-8 text-3xl">
                    <a href="/" className="hover:underline">Home</a>
                    <a href="/about" className="hover:underline">About</a>
                    <a href="/contact" className="hover:underline">Contact</a>
                </div>
            </div>
        </>
    );
}   