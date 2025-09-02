"use client"

import { AuthContext } from "@/contexts/AuthContext"
import { PageBlock } from "@/types/PageBlock"
import { notFound } from "next/navigation"
import { useContext } from "react"

export const AuthorizeBlock = (props: PageBlock) => {
    if (props.__component !== 'blocks.authorize') return <div>Block does not exist {JSON.stringify(props)}</div>
    if (props.AllowPublic) return <></>
    const user = useContext(AuthContext)
    if (user.kind == 'r') return notFound()
    return <></>
}