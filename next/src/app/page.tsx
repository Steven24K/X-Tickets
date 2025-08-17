import { StrapiClientAdapter } from "@/services/StrapiClient";
import Image from "next/image";
import Link from "next/link";


export default async function Home() {
  const strapi = new StrapiClientAdapter();
  const events = await strapi.geAllEvents();
  return <>
    <div className="flex flex-col sm:flex-row items-center gap-4">
      <Image
        className="lg:mask-radial-[100%_100%] lg:mask-radial-from-75% lg:mask-radial-at-left"
        src="/sample-event.jpeg"
        alt="Event"
        width={500}
        height={200}
      />
      <div className="font-medium w-full">
        <h1 className="mt-2 text-base text-gray-700 text-center sm:text-left">
          All the tools you need for your next event!
        </h1>
        <p className="mt-1 text-sm leading-relaxed text-balance text-gray-500 text-center sm:text-left">
          Wheter you're organizing a concert, conference, or any other event, X Tickets has got you covered.
        </p>
        <div className="mt-4 flex flex-col sm:flex-row gap-2 items-center sm:items-start justify-center sm:justify-start">
          <Link href={"/signup"} className="mt-4 inline-block px-4 py-2 border border-blue-500 bg-blue-500 text-white hover:bg-white hover:text-blue-500 transition-colors">
            Start selling tickets
          </Link>
          <Link href={"/events"} className="mt-4 inline-block px-4 py-2 border border-blue-500 text-blue-500 hover:bg-blue-500 hover:text-white transition-colors">
            Explore events
          </Link>
        </div>
      </div>
    </div>

    <section className="mt-8 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
      {events.map((event) => {
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
    </section>

    <section className="my-12">
      <h2 className="text-2xl font-bold mb-6">Event organizers</h2>
      <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-5 gap-8 justify-items-center">
        {[
          {
            id: "musiclive",
            name: "MusicLive Inc.",
            image: "/sample-event.jpeg",
          },
          {
            id: "innovatex",
            name: "InnovateX",
            image: "/sample-event.jpeg",
          },
          {
            id: "artworld",
            name: "ArtWorld",
            image: "/sample-event.jpeg",
          },
          {
            id: "tastebuds",
            name: "TasteBuds",
            image: "/sample-event.jpeg",
          },
          {
            id: "janedoe",
            name: "Jane Doe",
            image: "/sample-event.jpeg",
          },
        ].map((org) => (
          <Link
            key={org.id}
            href={`/organizers/${org.id}`}
            className="flex flex-col items-center group"
          >
            <Image
              src={org.image}
              alt={org.name}
              width={96}
              height={96}
              className="rounded-full object-cover border-2 border-blue-500 group-hover:border-blue-700 transition-all"
            />
            <span className="mt-2 text-base font-medium text-gray-700 text-center">{org.name}</span>
          </Link>
        ))}
      </div>
    </section>
  </>
}
