import { DisplayBlocks } from "@/components/DisplayBlocks";
import { StrapiClientAdapter } from "@/services/StrapiClient";
import { PageProps } from "./RouteParams";
import { notFound } from "next/navigation";
import { metadata } from "./layout";


export default async function Home(props: PageProps) {
  const strapi = new StrapiClientAdapter();
  const homepage = await strapi.getHomepage();
  if (homepage.kind == 'r') notFound()

  const title = homepage.v.data.Title
  const description = homepage.v.data.Description
  const blocks = homepage.v.data.Blocks

  metadata.title = title
  metadata.description = description

  return <DisplayBlocks blocks={blocks} pageProps={props} />
}
