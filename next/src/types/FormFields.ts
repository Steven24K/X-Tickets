export type StrapiFormField = StandardFormField |
    DropDown |
    HiddenField |
    InfoText

type StandardFormField = {
    __component: "form-fields.text" |
    "form-fields.email" |
    "form-fields.text-area" |
    "form-fields.check-box" |
    "form-fields.password" |
    "form-fields.number" |
    "form-fields.date-picker" |
    "form-fields.time-select"
    id: number
    Label: string
    Name: string
    Required: boolean
    DefaultValue?: string
}

type DropDown = {
    __component: "form-fields.drop-down"
    id: number
    Label: string
    Name: string
    Required: boolean
    Items: DropDownItem[]
}

type DropDownItem = {
    id: number
    Label: string
    Value: string
}

type HiddenField = {
    __component: "form-fields.hidden"
    id: number
    Label: string
    Name: string
    DefaultValue: string
}

type InfoText = {
    __component: "form-fields.info"
    id: number
    Message: string
}