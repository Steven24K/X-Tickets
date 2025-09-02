import { redirect } from "next/navigation"

export async function POST(request: Request) {
    let formData = await request.formData()
    let referer = new URL(request.headers.get('Referer')!)

    let url = new URL(request.url)
    let form_id = url.searchParams.get('form_id')
    
    // TODO: Get Form details by ID
    console.log(form_id)

    // Extract all files from formData
    let files: { [key: string]: { name: string; type: string; base64: string }[] } = {};
    for (let [key, value] of formData.entries()) {
        if (value instanceof File && value.size > 0) {
            if (!files[key]) files[key] = [];
            const arrayBuffer = await value.arrayBuffer();
            const base64 = Buffer.from(arrayBuffer).toString('base64');
            files[key].push({
                name: value.name,
                type: value.type,
                base64,
            });
        }
    }
    console.log("Uploaded files (base64):", files);
    // Process form data
    console.log(formData)

    // TODO: Redirect to the page set in the CMS, else just back to the original page
    redirect(`${referer.pathname}?success=true`)
    // TODO: Send error msg ?error=... when form validation doesn't match
}