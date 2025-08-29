import { Either, IsLeft, IsRight, Product } from "@/types/Func";
import { API } from "@strapi/client";

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

type JsonObject = { [key: string]: any };

const transformFormData = (formData: FormData): JsonObject => formData.entries().reduce((acc, [key, value]) => ({ ...acc, [key]: value }), {})

export const formValidationFlow = (form: API.Document) => (formData: FormData): Either<JsonObject, false> => {
    let allFieldsFilled = form.Fields
        .filter((f: any) => f.Required)
        .reduce((acc: boolean, f: any) => acc && formData.has(f.Name) && formData.get(f.Name)!.toString().trim() !== '', true)

    let hiddenFieldsChanged = form.Fields
        .filter((f: any) => f.__component === 'form-fields.hidden')
        .reduce((acc: boolean, f: any) => acc || (formData.has(f.Name) && formData.get(f.Name)!.toString() !== f.DefaultValue), false)

    if (!allFieldsFilled || hiddenFieldsChanged) return IsRight(false)
    return IsLeft(transformFormData(formData))
};
