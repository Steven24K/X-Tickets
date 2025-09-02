"use client"
import { getCurrentUser } from "@/app/api";
import { AuthContext } from "./AuthContext";
import { Suspense } from "react";


export function ContextProvider({ children }: { children: React.ReactNode }) {
    return <AuthContext value={getCurrentUser()}>
        <Suspense>
            {children}
        </Suspense>
    </AuthContext>;
}
