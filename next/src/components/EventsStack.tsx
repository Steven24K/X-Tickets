"use client"
import { formatDateTime } from "@/app/utils";
import { AuthContext } from "@/contexts/AuthContext";
import { StrapiEvent } from "@/types/models/StrapiCollections";
import Image from "next/image";
import Link from "next/link";
import { useContext } from "react";

interface EventStackProps {
    slug: string
    events: StrapiEvent[]
}

export const EventStack = (props: EventStackProps) => {
    const { slug, events } = props;
    const user = useContext(AuthContext)

    const isOwner = user.kind == 'l' && user.v.slug === slug

    return <div className="mt-30 px-8">
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
            {events.length === 0 && (
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
            {events.map((event: any) => {
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
}