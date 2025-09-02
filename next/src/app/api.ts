import { ApiResponse } from "@/services/StrapiClient";
import { IsRight } from "@/types/Func";
import { StrapiShopOwner } from "@/types/models/StrapiCollections";

export const getCurrentUser = (): Promise<ApiResponse<StrapiShopOwner>> =>
    fetch(`/api/getCurrentUser`)
        .then(response => response.ok ? response.json() : Promise.reject(response.status))
        .then(json => json)
        .catch(e => IsRight(e))