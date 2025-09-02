"use client"
import { AuthContext } from "./AuthContext";
import { StrapiShopOwner } from "@/types/models/StrapiCollections";
import { ApiResponse } from "@/services/StrapiClient";

interface ContextProviderProps {
    children?: React.ReactNode
    currentUser: ApiResponse<StrapiShopOwner>
}

export function ContextProvider(props: ContextProviderProps) {
    const { children, currentUser } = props
    return <AuthContext value={currentUser}>
        {children}
    </AuthContext>;
}
