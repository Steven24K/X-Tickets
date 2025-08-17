import Link from "next/link"

export async function Footer() {

    return <footer className="bg-gray-800 text-white py-8">
        <div className="container mx-auto px-4">
            <div className="flex flex-wrap -mx-4">
                <div className="w-full md:w-1/3 px-4 mb-8 md:mb-0">
                    <h3 className="text-lg font-semibold mb-4">X Tickets</h3>
                    <p className="mb-4">Selling tickets for your next event made easy.</p>
                    <ul>
                        <li className="mb-2">
                            <Link href="/" className="text-white hover:underline">Home</Link>
                        </li>
                        <li className="mb-2">
                            <Link href="/" className="text-white hover:underline">About</Link>
                        </li>
                        <li className="mb-2">
                            <Link href="/" className="text-white hover:underline">Contact</Link>
                        </li>
                    </ul>
                </div>

                <div className="w-full md:w-1/3 px-4 mb-8 md:mb-0">
                    <h3 className="text-lg font-semibold mb-4">On this site</h3>
                    <ul>
                        <li className="mb-2">
                            <Link href="/privacy" className="hover:underline">
                                Privacy
                            </Link>
                        </li>
                        <li className="mb-2">
                            <Link href="/terms-use" className="hover:underline">
                                Terms of Use
                            </Link>
                        </li>
                        <li className="mb-2">
                            <Link href="/terms" className="hover:underline">
                                Terms of Service
                            </Link>
                        </li>
                    </ul>
                </div>
                <div className="w-full md:w-1/3 px-4 mb-8 md:mb-0">
                    <h3 className="text-lg font-semibold mb-4">Get started</h3>
                    <ul>
                        <li className="mb-2">
                            <Link href="/sign-up" className="hover:underline">
                                Sign-Up
                            </Link>
                        </li>
                        <li className="mb-2">
                            <Link href="/login" className="hover:underline">
                                Login
                            </Link>
                        </li>
                        <li className="mb-2">
                            <Link href="/using" className="hover:underline">
                                How to use
                            </Link>
                        </li>
                        <li className="mb-2">
                            <Link href="/tricks-tips" className="hover:underline">
                                Tips and tricks
                            </Link>
                        </li>
                    </ul>
                </div>

            </div>

            <div className="mt-8 text-center">
                <p className="mb-4"><Link href={'https://www.instagram.com/hello_world_my_name_is_steven/'} className="underline">Instagram</Link></p>
                <p>© {new Date().getFullYear()} - X Tickets - X as in anything</p>
            </div>
        </div>
    </footer>
}