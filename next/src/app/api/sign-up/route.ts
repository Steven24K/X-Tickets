import { StrapiClientAdapter } from "@/services/StrapiClient"
import { redirect } from "next/navigation"

export async function POST(request: Request) {
    let formData = await request.formData()
    let referer = new URL(request.headers.get('Referer')!)

    let url = new URL(request.url)
    if (!url.searchParams.has('form_id')) redirect(`${referer.pathname}?error=Invalid parameter&success=false`)
    let form_id = url.searchParams.get('form_id')!

    let strapi = new StrapiClientAdapter()
    let form = await strapi.getFormById(form_id)
    // console.log(form)
    if (form.kind == 'r') redirect(`${referer.pathname}?error=Form not found&success=false`)

    // Process form data
    // console.log(formData)

    // Required fields check
    let requiredFields = form.v.Fields.filter((f: any) => f.Required)
    let allFieldsMatch = requiredFields.reduce((acc: boolean, f: any) => acc && formData.has(f.Name) && formData.get(f.Name)!.toString().trim() !== '', true)
    if (!allFieldsMatch) redirect(`${referer.pathname}?error=Please fill in the required fields&success=false`)

    // Hidden fields not changed check
    let hiddenFields = form.v.Fields.filter((f: any) => f.__component === 'form-fields.hidden')
    let hiddenFieldsChanged = hiddenFields.reduce((acc: boolean, f: any) => acc || (formData.has(f.Name) && formData.get(f.Name)!.toString() !== f.DefaultValue), false)
    if (hiddenFieldsChanged) redirect(`${referer.pathname}?error=What are you trying to do?&success=false`)

    let json = formData.entries().reduce((acc, [key, value]) => ({ ...acc, [key]: value }), {})
    let response = await strapi.createUser(json as any)
    if (response.kind == 'r') redirect(`${referer.pathname}?error=${response.v.message}&success=false`)

    if (form.v.RedirectUrl) redirect(form.v.RedirectUrl)
    redirect(`${referer.pathname}?success=true`)
}