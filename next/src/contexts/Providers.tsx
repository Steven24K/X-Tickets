"use client"
import { Suspense } from "react";
import { getCurrentUser } from "@/app/api";
import { AuthContext } from "./AuthContext";


export function ContextProvider({ children }: { children: React.ReactNode }) {
    return <AuthContext value={getCurrentUser()}>
        <Suspense>
            {children}
        </Suspense>
    </AuthContext>;
}
