"use client"
import { AuthContext } from "@/contexts/AuthContext"
import Link from "next/link"
import { use, useContext } from "react"

export const NavBar = () => {
    const user = useContext(AuthContext)
    const _user = use(user)

    return <header className="bg-gray-800 text-white py-2 px-4">
        <div className="flex items-center justify-between">
            <h1 className="text-2xl font-bold">
                <Link href="/">X Tickets</Link>
            </h1>
            <nav>
                <ul className="flex space-x-6 lg:text-lg sm:text-base">
                    {
                        _user.kind == 'l' ? <>
                            <li>
                                <Link href={`/organizer/${_user.v.slug}`} className="hover:underline">Welcome {_user.v.username}</Link>
                            </li>
                            <li>
                                <a href="/logout" className="hover:underline">Logout</a>
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