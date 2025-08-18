import { PageBlock } from "@/types/PageBlock";
import Image from "next/image";

export const ImageBlock = (block: PageBlock) => {
    if (block.__component !== 'blocks.image') return <div>Block does not exist {JSON.stringify(block)}</div>
    const { Image: image, Caption } = block;
    return (
        <figure className="flex flex-col my-6 px-1">
            <Image
                src={image?.url}
                alt={image?.alternativeText || "Image"}
                width={image?.width}
                height={image?.height}
                className="rounded-lg shadow-md lg:max-w-200 sm:max-w-full h-auto"
            />
            {Caption && (
                <figcaption className="mt-2 text-sm text-gray-500">
                    {Caption}
                </figcaption>
            )}
        </figure>
    )

}