import { StrapiClientAdapter } from "@/services/StrapiClient"
import { IsRight } from "@/types/Func"
import { API } from "@strapi/client"
import { cookies } from "next/headers"
import Link from "next/link"

export const NavBar = async () => {
    const strapi = new StrapiClientAdapter()
    let _cookies = await cookies()
    let maybeUser = IsRight<API.Document, Error>(new Error('No user'))
    if (_cookies.has('token')) {
        let token = _cookies.get('token')!.value
        maybeUser = await strapi.getCurrentUser(token)
    }
    return <header className="bg-gray-800 text-white py-2 px-4">
        <div className="flex items-center justify-between">
            <h1 className="text-2xl font-bold">
                <Link href="/">X Tickets</Link>
            </h1>
            <nav>
                <ul className="flex space-x-6 lg:text-lg sm:text-base">
                    {
                        maybeUser.kind == 'l' ? <>
                        <li>
                            <Link href="/profile" className="hover:underline">Welcome {maybeUser.v.username}</Link>
                        </li>
                        <li>
                            <Link href="/logout" className="hover:underline">Logout</Link>
                        </li>
                        </>
                            : <>
                                <li>
                                    <Link href="/sign-up" className="hover:underline">Sign-up</Link>
                                </li>
                                <li>
                                    <Link href="/login" className="hover:underline">Login</Link>
                                </li>
                            </>
                    }
                </ul>
            </nav>
        </div>
    </header>
}