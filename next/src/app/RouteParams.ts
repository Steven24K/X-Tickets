import { Either } from "@/types/Func"
import { API } from "@strapi/client"

type RouteParams = {
    slug: string
}

type QueryParams = {
    page?: string
    success?: string
    error?: string
}

export type AuthProps = {
    user: Either<API.Document, Error>
}

export type PageProps = {
    params: Promise<RouteParams>
    searchParams: Promise<QueryParams>
}