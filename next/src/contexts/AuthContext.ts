"use client"

import { ApiResponse } from "@/services/StrapiClient"
import { IsRight } from "@/types/Func"
import { StrapiShopOwner } from "@/types/models/StrapiCollections"
import { createContext } from "react"

export const AuthContext = createContext<Promise<ApiResponse<StrapiShopOwner>>>(Promise.resolve(IsRight("Unloaded")))
