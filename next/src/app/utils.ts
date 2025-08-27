import { Product } from "@/types/Func";

export const convertNumber = (page: any) => isNaN(Number(page)) ? 1 : Number(page);

export const formatDateTime = (dateTime: string): Product<string, string> => {
    const dateObj = new Date(dateTime);
    const dayNames = ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"];
    const monthNames = [
        "Jan", "Feb", "Mar", "Apr", "May", "Jun",
        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
    ];
    return [
        `${dayNames[dateObj.getDay()]} ${dateObj.getDate()} ${monthNames[dateObj.getMonth()]} ${dateObj.getFullYear()}`,
        `${dateObj.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}`
    ]
}