import { PageBlock } from "@/types/PageBlock";
import { FormBuilder, FormField } from "../FormBuilder";
import { StrapiFormField } from "@/types/FormFields";

export const FormBlock = async (block: PageBlock) => {
    if (block.__component !== 'blocks.form') return <div>Block does not exist {JSON.stringify(block)}</div>
    const { form, pageProps } = block
    const { documentId, Title, Fields, SubmitButton, SubmitText, SubmitAction } = form

    const successSubmitted = (await pageProps.searchParams).success
    let submitted = false
    if (successSubmitted) {
        submitted = successSubmitted === 'true'
    }

    return <div className="px-2 my-4">
        <h1 className="pb-2 text-4xl">{Title}</h1>
        {submitted && <p className="bg-gray-100 rounded p-5">{SubmitText}</p>}
        {!submitted && <FormBuilder
            method="post"
            action={`${SubmitAction}?form_id=${documentId}`}
            submitBtnText={SubmitButton}
            fields={Fields.map(mapStrapiFieldToFormField)}
        />}
    </div>
}

const StrapiFieldType2FormFieldType = (strapi_type: StrapiFormField['__component']): FormField['kind'] => {
    switch (strapi_type) {
        case 'form-fields.text':
            return 'text'
        case 'form-fields.email':
            return 'email'
        case 'form-fields.password':
            return 'password'
        case 'form-fields.text-area':
            return 'textarea'
        case 'form-fields.check-box':
            return 'checkbox'
        case 'form-fields.number':
            return 'number'
        case 'form-fields.date-picker':
            return 'date'
        case 'form-fields.time-select':
            return 'time'
        case 'form-fields.hidden':
            return 'hidden'
        case 'form-fields.drop-down':
            return 'dropdown'
        case 'form-fields.info':
            return 'info'
        default:
            return 'info'
    }
}

function mapStrapiFieldToFormField<T>(field: StrapiFormField, index: number): FormField {
    switch (field.__component) {
        case 'form-fields.text':
        case 'form-fields.check-box':
        case 'form-fields.email':
        case 'form-fields.text-area':
        case 'form-fields.password':
        case 'form-fields.number':
        case 'form-fields.date-picker':
        case 'form-fields.time-select':
            return ({ kind: StrapiFieldType2FormFieldType(field.__component), label: field.Label, name: field.Name, weight: index, required: field.Required, defaultValue: field.DefaultValue, id: field.id }) as FormField
        case 'form-fields.hidden':
            return ({ kind: StrapiFieldType2FormFieldType(field.__component), label: field.Label, name: field.Name, weight: index, required: true, hide_label: true, defaultValue: field.DefaultValue, id: field.id }) as FormField
        case 'form-fields.drop-down':
            return ({ kind: 'dropdown', label: field.Label, name: field.Name, weight: index, required: field.Required, options: field.Items.map(v => ({ name: v.Label, value: v.Value })), id: field.id }) as FormField
        case 'form-fields.info':
            return ({ kind: 'info', name: field.Message, weight: index, id: field.id })
        default:
            return ({ kind: 'info', name: 'No field implemented for: ' + JSON.stringify(field), weight: index, id: -1 })
    }
}