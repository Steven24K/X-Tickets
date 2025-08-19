import { DisplayBlocks } from "@/components/DisplayBlocks"
import { PageProps } from "../RouteParams"
import { notFound } from "next/navigation"
import { StrapiClientAdapter } from "@/services/StrapiClient"
import { metadata } from "../layout"

export default async function CMSPage(props: PageProps) {
    const { params } = props
    const { slug } = await params

    const strapi = new StrapiClientAdapter()
    const page = await strapi.getPageBySlug(slug)

    if (page.kind == 'r') notFound()

    console.log(page.v)
        
    const title = page.v.Title
    const description = page.v.Description
    const blocks = page.v.Blocks

    metadata.title = title
    metadata.description = description


    return <DisplayBlocks blocks={blocks} pageProps={props} />

}