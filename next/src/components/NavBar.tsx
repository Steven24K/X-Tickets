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
                        <Link href="/sign-up" className="hover:underline">Sign-up</Link>
                    </li>
                    <li>
                        <Link href="/login" className="hover:underline">Login</Link>
                    </li>
                </ul>
            </nav>
        </div>
    </header>
}