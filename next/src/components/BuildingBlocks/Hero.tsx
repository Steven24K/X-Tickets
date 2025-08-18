import { PageBlock } from "@/types/PageBlock"
import Image from "next/image"
import { Clickable } from "../Clickable"

export const HeroBlock = (block: PageBlock) => {
    if (block.__component !== 'blocks.hero') return <div>Block does not exist {JSON.stringify(block)}</div>
    const { Title, Description, Image: heroImage, PrimaryButton, SecondaryButton } = block
    return <div className="flex flex-col sm:flex-row items-center gap-4">
        <Image
            className="lg:mask-radial-[100%_100%] lg:mask-radial-from-75% lg:mask-radial-at-left"
            src={heroImage.url}
            alt={heroImage.alternativeText || Title}
            width={heroImage.width}
            height={heroImage.height}
        />
        <div className="font-medium w-full">
            {Title && <h1 className="mt-2 text-base text-gray-700 text-center sm:text-left">{Title}</h1>}
            {Description && <p className="mt-1 text-sm leading-relaxed text-balance text-gray-500 text-center sm:text-left">{Description}</p>}
            {(PrimaryButton || SecondaryButton) && <div className="mt-4 flex flex-col sm:flex-row gap-2 items-center sm:items-start justify-center sm:justify-start">
                {PrimaryButton && (
                    <Clickable
                        className="mt-4 inline-block px-4 py-2 border border-blue-500 bg-blue-500 text-white hover:bg-white hover:text-blue-500 transition-colors"
                        {...PrimaryButton}
                    >
                        {PrimaryButton.Title}
                    </Clickable>
                )}
                {SecondaryButton && (
                    <Clickable
                        className="mt-4 inline-block px-4 py-2 border border-blue-500 text-blue-500 hover:bg-blue-500 hover:text-white transition-colors"
                        {...SecondaryButton}
                    >
                        {SecondaryButton.Title}
                    </Clickable>
                )}
            </div>}
        </div>
    </div>
}