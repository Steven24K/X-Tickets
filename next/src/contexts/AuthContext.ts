"use client"

import { createContext } from "react"
import { ApiResponse } from "@/services/StrapiClient"
import { IsRight } from "@/types/Func"
import { StrapiShopOwner } from "@/types/models/StrapiCollections"

export const AuthContext = createContext<ApiResponse<StrapiShopOwner>>(IsRight("Unloaded"))
