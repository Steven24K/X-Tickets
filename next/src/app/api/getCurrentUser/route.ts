import { StrapiClientAdapter } from "@/services/StrapiClient"
import { IsRight } from "@/types/Func"
import { cookies } from "next/headers"

export async function GET() {
    const _cookies = await cookies()
    if (!_cookies.has('token')) {
        return Response.json(IsRight("No user"))
    }
    let token = _cookies.get('token')?.value || ''
    const strapi = new StrapiClientAdapter()
    const maybeUser = await strapi.getCurrentUser(token)
    return Response.json(maybeUser)
}