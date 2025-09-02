"use client"

import { AuthContext } from "@/contexts/AuthContext"
import { ApiResponse } from "@/services/StrapiClient"
import { StrapiShopOwner } from "@/types/models/StrapiCollections"
import Link from "next/link"
import { useContext } from "react"

interface ShopOwnerInfoProps {
    slug: string
    eventOwner: ApiResponse<StrapiShopOwner>
}

export const ShopOwnerInfo = (props: ShopOwnerInfoProps) => {
    const { slug, eventOwner } = props
    if (eventOwner.kind == 'r') return <div>Failed to load owner info</div>
    
    const user = useContext(AuthContext)

    const isOwner = user.kind == 'l' && user.v.slug === slug

    return <div className="ml-40 flex flex-wrap items-center gap-4 mt-2">
        {isOwner ? (
            <form className="flex flex-wrap items-center gap-2" method="post" action='/api/updateUserForm'>
                <input
                    name='username'
                    type="text"
                    defaultValue={eventOwner.v.username}
                    className="text-xl font-bold border-b border-gray-300 focus:outline-none focus:border-blue-500 bg-transparent"
                    style={{ maxWidth: 200 }}
                />
                <input type='hidden' name="id" value={eventOwner.v.id} />
                <button
                    type="submit"
                    className="text-blue-600 text-sm font-semibold hover:underline"
                >
                    Save
                </button>
            </form>
        ) : (
            <h1 className="m-0 text-xl">{eventOwner.v.username}</h1>
        )}
        <span className="text-gray-500">@{eventOwner.v.slug}</span>
        {isOwner && (
            <Link
                href="/settings"
                className="ml-4 px-3 py-1 bg-gray-200 rounded text-sm font-semibold hover:bg-gray-300"
            >
                Settings
            </Link>
        )}
    </div>
}