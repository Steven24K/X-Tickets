import { formValidationFlow } from "@/app/utils"
import { StrapiClientAdapter } from "@/services/StrapiClient"
import { cookies } from "next/headers"
import { redirect } from "next/navigation"

export async function POST(request: Request) {
    let formData = await request.formData()
    let referer = new URL(request.headers.get('Referer')!)

    let url = new URL(request.url)
    if (!url.searchParams.has('form_id')) redirect(`${referer.pathname}?error=Invalid parameter&success=false`)
    let form_id = url.searchParams.get('form_id')!

    let strapi = new StrapiClientAdapter()
    let form = await strapi.getFormById(form_id)
    if (form.kind == 'r') redirect(`${referer.pathname}?error=Form not found&success=false`)

    let result = formValidationFlow(form.v)(formData)

    if (result.kind == 'r') redirect(`${referer.pathname}?error=Please fill in the required fields&success=false`)

    let response = await strapi.loginAsUser(result.v as any)

    if (response.kind == 'r') redirect(`${referer.pathname}?error=${response.v}&success=false`)
    
     let _cookies = await cookies()
     _cookies.set('token', response.v.jwt)
     let user = response.v.user
    

    if (form.v.RedirectUrl) redirect(form.v.RedirectUrl.replace('{slug}', user.slug))
    redirect(`${referer.pathname}?success=true`)
}