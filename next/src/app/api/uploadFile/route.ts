import { StrapiClientAdapter } from "@/services/StrapiClient";
import { NextResponse } from "next/server";

export async function POST(request: Request) {
    const body = await request.json();
    const strapi = new StrapiClientAdapter();
    const result = await strapi.uploadFile(body.file, 'uploaded-file');
    if (result.kind === "l") {
        return NextResponse.json(result.v)
    } else {
        return NextResponse.error()
    }
}