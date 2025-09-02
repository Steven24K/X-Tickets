import { PageProps } from "@/app/RouteParams";
import { formatDateTime } from "@/app/utils";
import { ImageUploader } from "@/components/ImageUploader";
import { ShopOwnerInfo } from "@/components/ShopOwnerInfo";
import { StrapiClientAdapter } from "@/services/StrapiClient";
import Image from "next/image";
import Link from "next/link";
import { notFound } from "next/navigation";

export default async function OrganizerProfilePage(props: PageProps) {
    const pathParams = await props.params

    const slug = pathParams.slug
    const strapi = new StrapiClientAdapter()

    const eventOwner = await strapi.getEventOwnerBySlug(slug)
    if (eventOwner.kind == 'r') notFound()

    // TODO: Make components from authorized content
    const isOwner = true

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
                <div className="mt-30 px-8">
                    <div className="flex items-center justify-between mb-6">
                        <h2 className="text-2xl font-semibold">Upcoming Events</h2>
                        {isOwner && (
                            <Link
                                href="/event/create"
                                className="px-4 py-2 bg-green-600 text-white rounded-lg font-semibold text-base hover:bg-green-700"
                            >
                                + New Event
                            </Link>
                        )}
                    </div>
                    <div className="flex flex-col gap-6">
                        {eventOwner.v.Events.filter((event: any) => event.publishedAt !== null).length === 0 && (
                            <div className="flex flex-col items-center justify-center py-16 text-gray-500 bg-white rounded-xl shadow-inner">
                                <h3 className="text-xl font-semibold mb-2">No upcoming events</h3>
                                <p className="mb-4 text-center max-w-xs">
                                    {isOwner
                                        ? "You haven't created any events yet. Start by adding your first event!"
                                        : "This organizer has no upcoming events at the moment."}
                                </p>
                                {isOwner && (
                                    <Link
                                        href="/event/create"
                                        className="px-5 py-2 bg-green-600 text-white rounded-lg font-semibold text-base hover:bg-green-700"
                                    >
                                        + Create Event
                                    </Link>
                                )}
                            </div>
                        )}
                        {eventOwner.v.Events
                            .filter((event: any) => event.publishedAt !== null)
                            .map((event: any) => {
                                let formattedDate = formatDateTime(event.DatesAndTimes[0].DateTime);
                                return (
                                    <div
                                        key={event.id}
                                        className="flex items-center bg-gray-50 rounded-xl shadow-sm p-6 gap-6 flex-wrap relative"
                                    >
                                        <Image
                                            src={event.Image ? event.Image.url : "/event.avif"}
                                            height={80}
                                            width={80}
                                            alt={`Event ${event.Title}`}
                                            className="w-20 h-20 rounded-lg object-cover shadow"
                                        />
                                        <div className="min-w-20">
                                            <div className="font-bold text-xl">{formattedDate[0]}</div>
                                            <div className="text-gray-400 text-lg">{formattedDate[1]}</div>
                                        </div>
                                        <div className="flex-1">
                                            <h3 className="m-0 text-lg font-semibold">{event.Title}</h3>
                                            <div className="text-gray-500 my-1">{event.Venue.Name}</div>
                                            <div className="text-gray-500 italic my-1">{event.Venue.Adress}, {event.Venue.PostCode} {event.Venue.City}</div>
                                        </div>
                                        <div className="font-bold text-lg">€{event.Price}</div>
                                        <div className="ml-4 mt-4 w-full flex justify-end gap-2">
                                            <Link
                                                href={`/event/${event.slug}`}
                                                className="px-5 py-2 bg-blue-600 text-white rounded-lg font-semibold text-base transition-colors duration-200 w-full max-w-[180px] text-center box-border hover:bg-blue-700"
                                            >
                                                Read more
                                            </Link>
                                            {isOwner && (
                                                <>
                                                    <Link
                                                        href={`/event/${event.slug}/edit`}
                                                        className="px-4 py-2 bg-yellow-500 text-white rounded-lg font-semibold text-base hover:bg-yellow-600"
                                                    >
                                                        Edit
                                                    </Link>
                                                    <form
                                                        action={`/event/${event.slug}/delete`}
                                                        method="POST"
                                                    >
                                                        <button
                                                            type="submit"
                                                            className="px-4 py-2 bg-red-600 text-white rounded-lg font-semibold text-base hover:bg-red-700"
                                                        >
                                                            Delete
                                                        </button>
                                                    </form>
                                                </>
                                            )}
                                        </div>
                                    </div>
                                )
                            })}
                    </div>
                </div>
            </div>
        </div>
    );
}
