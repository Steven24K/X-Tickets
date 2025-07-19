import Link from "next/link"

export const NavBar = () => {
    return <header className="bg-gray-800 text-white py-2 px-4">
        <div className="flex items-center justify-between">
            <h1 className="text-2xl font-bold">
                <Link href="/">X Tickets</Link>
            </h1>
            <nav>
                <ul className="flex space-x-6 lg:text-lg sm:text-base">
                    <li>
                        <Link href="/" className="hover:underline">Home</Link>
                    </li>
                    <li>
                        <Link href="/about" className="hover:underline">About</Link>
                    </li>
                    <li>
                        <Link href="/contact" className="hover:underline">Contact</Link>
                    </li>
                </ul>
            </nav>
        </div>
    </header>
}