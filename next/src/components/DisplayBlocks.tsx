import { PageProps } from "@/app/RouteParams"
import { PageBlock } from "@/types/PageBlock"
import { TextBlock } from "./BuildingBlocks/Text"
import { HeroBlock } from "./BuildingBlocks/Hero"
import { ImageBlock } from "./BuildingBlocks/ImageBlock"
import { OverviewBlock } from "./BuildingBlocks/OverviewBlock"
import { FormBlock } from "./BuildingBlocks/Form"

type DisplayBlockProps = {
    blocks: PageBlock[]
    children?: React.ReactNode
    pageProps: PageProps
}


export const DisplayBlocks = (props: DisplayBlockProps) => {
    const { blocks, children, pageProps } = props

    return <div className="container mx-auto">
        {
            blocks.map(block => {
                switch (block.__component) {
                    case 'blocks.text-block':
                        return <TextBlock key={`${block.__component}_${block.id}`} {...block} pageProps={pageProps} />
                    case 'blocks.hero':
                        return <HeroBlock key={`${block.__component}_${block.id}`} {...block} pageProps={pageProps} />
                    case 'blocks.image':
                        return <ImageBlock key={`${block.__component}_${block.id}`} {...block} pageProps={pageProps} />
                    case 'blocks.overview':
                        return <OverviewBlock key={`${block.__component}_${block.id}`} {...block} pageProps={pageProps} />
                    case 'blocks.form':
                        return <FormBlock key={`${block.__component}_${block.id}`} {...block} pageProps={pageProps}/>
                    default:
                        return <div key={JSON.stringify(block)}>Block does not exist {JSON.stringify(block)}</div>
                }
            })
        }

        {children}
    </div>
}