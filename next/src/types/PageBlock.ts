import { PageProps } from "@/app/RouteParams"
import { StrapiImage } from "./StrapiImage"
import { BlocksContent } from "@strapi/blocks-react-renderer"
import { StrapiFormField } from "./FormFields"

export type PageBlock = (
    TextBlockProps |
    HeroBlockProps |
    ImageBlockProps |
    OverviewBlockProps | 
    FormBlockProps | 
    AuthorizeBlockProps
)
    & {
        pageProps: PageProps
    }


export type TextBlockProps = {
    __component: "blocks.text-block"
    id: number
    Title?: string
    Content: BlocksContent
}

export type ImageBlockProps = {
    __component: "blocks.image"
    id: number
    Image: StrapiImage
    Caption?: string
}

export type ClickableProps = {
    Title: string
    Url: string
    InternalUrl: {
        slug: string
    }
    Internal: boolean
}

export type HeroBlockProps = {
    __component: "blocks.hero"
    id: number
    Title: string
    Description: string
    Image: StrapiImage
    PrimaryButton: ClickableProps
    SecondaryButton: ClickableProps
}

export type OverviewBlockProps = {
    __component: "blocks.overview"
    id: number
    Entity: 'Events' | 'Owners'
    Paginated: boolean
    Size: number
}

export type FormBlockProps = {
    __component: "blocks.form"
    id: number
    form: {
        id: number
        documentId: string
        Title: string
        SubmitButton: string
        SubmitText: string
        SubmitAction: string
        RedirectUrl?: string
        Fields: StrapiFormField[]
    }
}

export type AuthorizeBlockProps = {
    __component: "blocks.authorize"
    id: number
    AllowPublic: boolean
}