import { PageProps } from "@/app/RouteParams";
import { formatDateTime } from "@/app/utils";
import { StrapiClientAdapter } from "@/services/StrapiClient";
import Image from "next/image";
import Link from "next/link";
import { notFound } from "next/navigation";

export default async function OrganizerProfilePage(props: PageProps) {
    const { params } = props;
    const pathParams = await props.params

    const slug = pathParams.slug
    const strapi = new StrapiClientAdapter()

    const eventOwner = await strapi.getEventOwnerBySlug(slug)
    if (eventOwner.kind == 'r') notFound()

    return (
        <div>
            <div className="max-w-300 mx-auto">
                <div className="relative h-60 bg-gray-200">
                    <Image
                        src="/banner.avif"
                        height={100}
                        width={320}
                        alt="Banner"
                        className="w-full h-full object-cover"
                    />
                    <div className="absolute left-8 -bottom-16 flex items-center">
                        <Image
                            src={eventOwner.v.ProfilePicture ? eventOwner.v.ProfilePicture.url : "/profile.avif"}
                            alt="Organizer"
                            className="w-32 h-32 rounded-full border-4 border-white object-cover shadow-lg"
                            height={128}
                            width={128}
                        />

                    </div>
                    <div className="ml-40">
                        <h1 className="m-0 text-xl">{eventOwner.v.username}</h1>
                        <span className="text-gray-500">@{eventOwner.v.slug}</span>
                    </div>
                </div>
                <div className="mt-30 px-8">
                    <h2 className="text-2xl font-semibold mb-6">Upcoming Events</h2>
                    <div className="flex flex-col gap-6">
                        {eventOwner.v.Events
                        .filter((event: any) => event.publishedAt !== null)
                        .map((event: any) => {
                            let formattedDate = formatDateTime(event.DatesAndTimes[0].DateTime);
                            return (
                                <div
                                    key={event.id}
                                    className="flex items-center bg-gray-50 rounded-xl shadow-sm p-6 gap-6 flex-wrap"
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
                                    <div className="ml-4 mt-4 w-full flex justify-end">
                                        <Link
                                            href={`/event/${event.slug}`}
                                            className="px-5 py-2 bg-blue-600 text-white rounded-lg font-semibold text-base transition-colors duration-200 w-full max-w-[180px] text-center box-border hover:bg-blue-700"
                                        >
                                            Read more
                                        </Link>
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
