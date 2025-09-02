import { API } from "@strapi/client";
import { PageBlock } from "../PageBlock";
import { StrapiImage } from "../StrapiImage";
import { StrapiFormField } from "../FormFields";

export type StrapiHomePage = API.DocumentResponse & {
    Title: string 
    Description: string
    Blocks: PageBlock[]
}

export type StrapiShopOwner = API.DocumentResponse & {
    id: string
    username: string 
    email: string
    slug: string
    ProfilePicture: StrapiImage
    Banner: StrapiImage
    Events: StrapiEvent[]
}

export type StrapiDateTime = API.DocumentResponse & {
    DateTime: string
}

export type StrapiVenue = API.DocumentResponse & {
    Name: string
    Capacity: number
    Adress: string
    PostCode: string
    City: string
}

export type StrapiEvent = API.DocumentResponse & {
    Title: string
    Description: string
    Price: number
    slug: string
    Image: StrapiImage
    ImageId?: number
    Owner: StrapiShopOwner
    DatesAndTimes: StrapiDateTime[]
    SubEvents: StrapiEvent[]
    Venue: StrapiVenue
}

export type StrapiPage = API.DocumentResponse & {
    Title: string
    Description: string
    slug: string
    Blocks: PageBlock[]
}

export type StrapiForm = API.DocumentResponse & {
    Title: string
    Fields: StrapiFormField[]
    SubmitText: string
    SubmitButton: string
    SubmitAction: string
    RedirectUrl: string
}