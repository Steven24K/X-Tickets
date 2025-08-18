import { faChevronLeft, faChevronRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Link from "next/link"

interface PaginationProps {
    page: number;
    pageSize: number;
    pageCount: number;
    total: number;
}

export const Pagination = (props: PaginationProps) => {
    const { page, pageCount } = props;

    return <div className="col-span-full flex justify-between gap-4">
        <div>
            {page > 1 ? (
                <Link
                    href={`?page=${page - 1}`}
                    className="px-4 py-2 bg-gray-200 rounded hover:bg-gray-300 transition-colors"
                    aria-disabled={page <= 1}
                    tabIndex={page <= 1 ? -1 : 0}
                >
                    <FontAwesomeIcon icon={faChevronLeft} />
                </Link>
            ) : (
                <span className="px-4 py-2 opacity-0 select-none"></span>
            )}
        </div>
        <div>
            {page < pageCount ? (
                <Link
                    href={`?page=${page + 1}`}
                    className="px-4 py-2 bg-gray-200 rounded hover:bg-gray-300 transition-colors"
                >
                    <FontAwesomeIcon icon={faChevronRight} />
                </Link>
            ) : (
                <span className="px-4 py-2 opacity-0 select-none"></span>
            )}
        </div>
    </div>
}