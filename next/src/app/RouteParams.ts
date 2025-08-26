type RouteParams = {
    slug: string
}

type QueryParams = {
    page?: string
    success?: string
    error?: string
}

export type PageProps = {
    params: Promise<RouteParams>
    searchParams: Promise<QueryParams>
}