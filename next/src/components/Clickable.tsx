import { ClickableProps } from "@/types/PageBlock";
import Link from "next/link";

type ClickablePropsExtra = {
    className?: string
    children?: React.ReactNode
}

export const Clickable = (props: ClickableProps & ClickablePropsExtra) => {
    const { Title, Url, InternalUrl, Internal, className, children } = props;
    return <Link
        aria-label={Title}
        target={Internal ? "_self" : "_blank"}
        href={Internal ? InternalUrl.slug : Url}
        className={className}
    >
        {children || Title}
    </Link>
}