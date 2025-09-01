import { StrapiClientAdapter } from "@/services/StrapiClient";
import { OverviewProps } from "@/types/OverviewProps"
import Image from "next/image"
import Link from "next/link"

export const OwnersOverview = async (props: OverviewProps) => {
  const strapi = new StrapiClientAdapter();
  const entries = await strapi.getAllEventOwners();
  if (entries.kind == 'r') return 'Error while fetching'
  return <section className="my-12 px-1">
    <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-5 gap-8 justify-items-center">
      {entries.v
        .filter(e => e.ProfilePicture)
        .map(e => (
          <Link
            key={e.id}
            href={`/organizer/${e.slug}`}
            className="flex flex-col items-center group"
          >
            <Image
              src={e.ProfilePicture.url}
              alt={e.username}
              width={240}
              height={240}
              className="rounded-full object-cover border-2 border-gray-400 group-hover:border-gray-700 transition-all"
            />
            <span className="mt-2 text-base font-medium text-gray-700 text-center">{e.username}</span>
          </Link>
        ))}
    </div>
  </section>
}