import { DisplayBlocks } from "@/components/DisplayBlocks";
import { StrapiClientAdapter } from "@/services/StrapiClient";
import { PageProps } from "./RouteParams";


export default async function Home(props: PageProps) {
  const strapi = new StrapiClientAdapter();
  const homepage = await strapi.getHomepage();
  return <DisplayBlocks blocks={homepage.data.Blocks} pageProps={props} />
}
