import { cookies } from "next/headers";
import { NextRequest, NextResponse } from "next/server";

export  async function GET(request: NextRequest) {
    let _cookies = await cookies()
    await _cookies.delete('token')
    return NextResponse.redirect(new URL('/', request.url))
}