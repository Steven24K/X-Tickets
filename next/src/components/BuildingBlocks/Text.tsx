import { PageBlock } from "@/types/PageBlock"
import { BlocksRenderer } from "@strapi/blocks-react-renderer"

export const TextBlock = (block: PageBlock) => {
    if (block.__component !== 'blocks.text-block') return <div>Block does not exist {JSON.stringify(block)}</div>
    const { Title, Content } = block

    return <div className="text-block px-4">
        {Title && <h2 className="text-2xl font-bold mb-2">{Title}</h2>}
        {Content && <div className="text-base">
            <BlocksRenderer content={Content} />
        </div>}
    </div>
}