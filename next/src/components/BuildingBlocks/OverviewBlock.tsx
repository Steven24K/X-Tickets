import { PageBlock } from "@/types/PageBlock"
import { EventOverview } from "../Overviews/EventOverview"
import { OwnersOverview } from "../Overviews/OwnersOverview"

export const OverviewBlock = (block: PageBlock) => {
    if (block.__component !== 'blocks.overview') return <div>Block does not exist {JSON.stringify(block)}</div>

    const { Entity, Paginated, Size, pageProps } = block

    switch (Entity) {
        case 'Events':
            return <EventOverview Paginated={Paginated} Size={Size} pageProps={pageProps} />
        case 'Owners':
            return <OwnersOverview Paginated={Paginated} Size={Size} pageProps={pageProps}  />
        default:
            return <div>No overview available for {Entity}</div>
    }
}