import { PageProps } from "@/app/RouteParams";
import { EventStack } from "@/components/EventsStack";
import { ImageUploader } from "@/components/ImageUploader";
import { ShopOwnerInfo } from "@/components/ShopOwnerInfo";
import { StrapiClientAdapter } from "@/services/StrapiClient";
import { notFound } from "next/navigation";

export default async function OrganizerProfilePage(props: PageProps) {
    const pathParams = await props.params

    const slug = pathParams.slug
    const strapi = new StrapiClientAdapter()

    const eventOwner = await strapi.getEventOwnerBySlug(slug)
    if (eventOwner.kind == 'r') notFound()

    return (
        <div>
            <div className="max-w-300 mx-auto">
                <div className="relative h-60 bg-gray-200">
                    <ImageUploader
                        entity="Banner"
                        imgClassName="w-full h-full object-cover"
                        editClassName="absolute top-2 right-2 bg-black bg-opacity-50 text-white px-3 py-1 rounded cursor-pointer text-sm z-10"
                        height={100}
                        width={320}
                        defaultImage="/banner.avif"
                        userId={eventOwner.v.id}
                        imageUrl={eventOwner.v.Banner?.url}
                        slug={slug}
                    />
                    <div className="absolute left-8 -bottom-16 flex items-center">
                        <div className="relative">
                            <ImageUploader
                                entity="ProfilePicture"
                                imgClassName="w-32 h-32 bg-white rounded-full border-4 border-white object-cover shadow-lg"
                                editClassName="absolute bottom-2 left-4 bg-black bg-opacity-60 text-white px-2 py-1 rounded cursor-pointer text-xs z-10"
                                height={128}
                                width={128}
                                defaultImage="/profile.avif"
                                userId={eventOwner.v.id}
                                imageUrl={eventOwner.v.ProfilePicture?.url}
                                slug={slug}
                            />
                        </div>
                    </div>
                    <ShopOwnerInfo slug={slug} eventOwner={eventOwner} />
                </div>
                <EventStack slug={slug} events={eventOwner.v.Events} />
            </div>
        </div>
    );
}
