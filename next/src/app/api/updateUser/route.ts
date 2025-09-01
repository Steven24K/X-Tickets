import { StrapiClientAdapter } from "@/services/StrapiClient";
import { cookies } from "next/headers";
import { NextResponse } from "next/server";

export async function POST(request: Request) {
    let _cookies = await cookies()
    if (!_cookies.has('token')) return NextResponse.error()
    let token = _cookies.get('token')!.value

    const body = await request.json()
    const strapi = new StrapiClientAdapter()

    const response = await strapi.updateUser(token, body.id, { ProfilePicture: body.imageId })
    if (response.kind === "l") {
        return NextResponse.json('ok')
    }
    return NextResponse.error()
}   