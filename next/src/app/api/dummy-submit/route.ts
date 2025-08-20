import { redirect } from "next/navigation"

export async function POST(request: Request) {
    let formData = await request.formData()
    let referer = new URL(request.headers.get('Referer')!)

    let url = new URL(request.url)
    let form_id = url.searchParams.get('form_id')

    // TODO: Get Form details by ID
    console.log(form_id)

    // Process form data
    console.log(formData)

    // TODO: Redirect to the page set in the CMS, else just back to the original page
    redirect(`${referer.pathname}?success=true`)
    // TODO: Send error msg ?error=... when form validation doesn't match
}