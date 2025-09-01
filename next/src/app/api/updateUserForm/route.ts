import { slugify } from "@/app/utils";
import { StrapiClientAdapter } from "@/services/StrapiClient";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";
import { NextResponse } from "next/server";

export async function POST(request: Request) {
    let _cookies = await cookies()
    if (!_cookies.has('token')) return NextResponse.error()
    let token = _cookies.get('token')!.value

    let formData = await request.formData()
    let referer = new URL(request.headers.get('Referer')!)

    const _username = formData.get('username')!.toString()
    const _slug = slugify(_username)

    let body = {
        id: formData.get('id')!.toString(),
        data: {
            username: _username,
            slug: _slug,
            // Add other fields as needed
        }
    }
    const strapi = new StrapiClientAdapter()

    const response = await strapi.updateUser(token, body.id, body.data)

    redirect(`/organizer/${_slug}`)
}   