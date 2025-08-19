import { convertNumber } from "@/app/utils";
import { StrapiClientAdapter } from "@/services/StrapiClient";
import { OverviewProps } from "@/types/OverviewProps";
import Image from "next/image";
import Link from "next/link";
import { Pagination } from "../Pagination";

export const EventOverview = async (props: OverviewProps) => {
    const { Size, pageProps, Paginated } = props;

    const pageIndex = (await pageProps.searchParams).page
    const strapi = new StrapiClientAdapter();
    const entries = await strapi.getAllEvents(convertNumber(pageIndex), Size);
    if (entries.kind == 'r') return 'Error while fetching'

    const pageData = entries.v.meta.pagination

    return <section className="px-1 my-4 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
        {entries.v.data.map((event) => {
            const dateObj = new Date(event.DatesAndTimes[0].DateTime);
            const dayNames = ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"];
            const monthNames = [
                "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            ];
            const formattedDate = `${dayNames[dateObj.getDay()]} ${dateObj.getDate()} ${monthNames[dateObj.getMonth()]} ${dateObj.getFullYear()} at ${dateObj.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}`;
            return (
                <div key={event.id} className="overflow-hidden shadow-sm flex flex-col">
                    <Image
                        src={event.Image.url}
                        alt={event.Title}
                        width={event.Image.width || 400}
                        height={event.Image.height || 300}
                        className="object-cover w-full h-48"
                    />
                    <div className="p-4 flex-1 flex flex-col">
                        <h2 className="font-semibold text-4xl mb-2">{event.Title}</h2>
                        <p className="text-sm text-gray-800 mb-4">By: {event.Owner.username}</p>
                        <p className="text-md text-gray-800 mb-1">Price/ticket: €{event.Price}</p>
                        <p className="text-lg text-gray-800 mb-1">Date: {formattedDate}</p>
                        <p className="text-md text-gray-800 mb-1">Location: {event.Venue.Name}</p>
                        <Link
                            href={`/events/${event.slug}`}
                            className="mt-auto inline-block px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 transition-colors text-center"
                        >
                            More info
                        </Link>
                    </div>
                </div>
            );
        })}

        {Paginated && pageData &&
            <Pagination {...pageData} />}

    </section>
}