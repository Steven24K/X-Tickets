type RouteParams = {
    slug: string
}

type QueryParams = {
    page?: string
}

export type PageProps = {
    params: Promise<RouteParams>
    searchParams: Promise<QueryParams>
}