
import { StrapiClientAdapter } from "@/services/StrapiClient";
import { IsRight } from "@/types/Func";
import { API } from "@strapi/client";
import { cookies } from "next/headers";

export const getCurrentUser = async () => {
      const strapi = new StrapiClientAdapter()
      let _cookies = await cookies()
      let maybeUser = IsRight<API.Document, Error>(new Error('No user'))
      if (_cookies.has('token')) {
        let token = _cookies.get('token')!.value
        maybeUser = await strapi.getCurrentUser(token)
      }
      return maybeUser
}