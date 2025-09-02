import { formValidationFlow, slugify } from "@/app/utils"
import { StrapiClientAdapter } from "@/services/StrapiClient"
import { StrapiEvent } from "@/types/models/StrapiCollections"
import { cookies } from "next/dist/server/request/cookies"
import { redirect } from "next/navigation"

export async function POST(request: Request) {
    let formData = await request.formData()
    let referer = new URL(request.headers.get('Referer')!)

    let _cookies = await cookies()
    if (!_cookies.has('token')) return redirect(`${referer.pathname}?error=Unauthorized&success=false`)
    let user_token = _cookies.get('token')!.value


    let url = new URL(request.url)
    if (!url.searchParams.has('form_id')) redirect(`${referer.pathname}?error=Invalid parameter&success=false`)

    let form_id = url.searchParams.get('form_id')!

    let strapi = new StrapiClientAdapter()
    let form = await strapi.getFormById(form_id)
    if (form.kind == 'r') redirect(`${referer.pathname}?error=Form not found&success=false`)

    let result = formValidationFlow(form.v)(formData)

    if (result.kind == 'r') redirect(`${referer.pathname}?error=Please fill in the required fields&success=false`)


    // Extract all files from formData
    let files: { [key: string]: { name: string; type: string; base64: string, strapi_id: number }[] } = {};
    for (let [key, value] of formData.entries()) {
        if (value instanceof File && value.size > 0) {
            if (!files[key]) files[key] = [];
            const arrayBuffer = await value.arrayBuffer();
            const base64 = `data:${value.type};base64,${Buffer.from(arrayBuffer).toString('base64')}`;
            // console.log("File (base64):", base64);

            const fileUploadResponse = await strapi.uploadFile(base64, value.name)
            if (fileUploadResponse.kind === 'r') {
                redirect(`${referer.pathname}?error=File upload failed&success=false`)
            }
            // console.log("Uploaded file response:", fileUploadResponse.v);
            files[key].push({
                name: value.name,
                type: value.type,
                strapi_id: fileUploadResponse.v[0].id,
                base64,
            });
        }
    }


    // console.log("Uploaded files (base64):", files);
    // Process form data
    // console.log(result.v)

    let user = await strapi.getCurrentUser(user_token)
    if (user.kind === 'r') redirect(`${referer.pathname}?error=User not found&success=false`)
    // Map DatesAndTimes fields to array of objects
    const datesAndTimes = Object.entries(result.v)
        .filter(([key]) => key.startsWith('DatesAndTimes['))
        .map(([, value]) => ({
            DateTime: new Date(value as string).toISOString()
        }));

    let body: Partial<StrapiEvent> = {
        ...result.v,
        Owner: user.v,
        ImageId: files['Image'][0].strapi_id,
        slug: slugify(result.v.Title),
        DatesAndTimes: datesAndTimes as any
    }

    console.log(body)
    const response = await strapi.createEvent(user_token, body)
    if (response.kind === 'r') redirect(`${referer.pathname}?error=Event creation failed&success=false`)


    if (form.v.RedirectUrl) redirect(form.v.RedirectUrl)
    redirect(`${referer.pathname}?success=true`)
}