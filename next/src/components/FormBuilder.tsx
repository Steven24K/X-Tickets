export type FormField = DefaultField | Numberfield | DropDownField | RepeatField | InfoText

type GenericFormField = {
    id: number
    hide_label?: boolean
    label: string
    disabled?: boolean
    required?: boolean
    weight: number
    defaultValue?: string
}

type DefaultField = GenericFormField & {
    kind: 'text' | 'email' | 'password' | 'textarea' | 'date' | 'time' | 'checkbox' | 'hidden'
    name: string
}

type Numberfield = GenericFormField & {
    kind: 'number'
    name: string
    min_value?: number
    max_value?: number
    step?: number
}

type DropDownField = GenericFormField & {
    kind: 'dropdown'
    options: { name: string, value: string }[]
    name: string
}

type RepeatField = GenericFormField & {
    kind: 'repeat'
    edit: boolean
    fields: FormField[]
    name: string
}

type InfoText = { id: number, kind: 'info'; name: string, weight: number }


interface FieldRendererProps {
    field: FormField
}
export function FieldRenderer(props: FieldRendererProps) {
    const { field } = props
    switch (field.kind) {
        case 'date':
        case 'text':
        case 'time':
        case 'password':
        case 'email':
            return <div className="mb-4">
                {(!field.hide_label || field.hide_label == undefined) && <label className="block text-sm font-medium text-gray-700 mb-1">{field.label}{field.required ? " *" : ''}</label>}
                <input
                    className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-sky-500 disabled:bg-gray-100"
                    name={field.name}
                    type={field.kind}
                    defaultValue={field.defaultValue}
                    required={field.required}
                    disabled={field.disabled}
                />
            </div>
        case 'hidden':
            return <input
                name={field.name}
                type={'text'}
                hidden
                defaultValue={field.defaultValue}
                required={field.required}
                disabled={field.disabled}
            />
        case 'checkbox':
            return <div className="mb-4 flex items-center">
                <input
                    className="h-4 w-4 text-sky-600 border-gray-300 rounded focus:ring-sky-500"
                    name={field.name}
                    type={field.kind}
                    defaultValue={field.defaultValue}
                    required={field.required}
                    disabled={field.disabled}
                />
                {(!field.hide_label || field.hide_label == undefined) && <label htmlFor={field.name} className="ml-2 block text-sm text-gray-700">{field.label}{field.required ? " *" : ''}</label>}
            </div>
        case 'number':
            return <div className="mb-4">
                {(!field.hide_label || field.hide_label == undefined) && <label className="block text-sm font-medium text-gray-700 mb-1">{field.label}{field.required ? " *" : ''}</label>}
                <input
                    className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-sky-500 disabled:bg-gray-100"
                    name={field.name}
                    type={field.kind}
                    defaultValue={field.defaultValue}
                    required={field.required}
                    min={field.min_value}
                    max={field.max_value}
                    step={field.step}
                    disabled={field.disabled}
                />
            </div>
        case 'textarea':
            return <div className="mb-4">
                {(!field.hide_label || field.hide_label == undefined) && <label className="block text-sm font-medium text-gray-700 mb-1">{field.label}{field.required ? " *" : ''}</label>}
                <textarea
                    className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-sky-500 disabled:bg-gray-100"
                    name={field.name}
                    defaultValue={field.defaultValue}
                    required={field.required}
                    cols={40}
                    rows={10}
                    disabled={field.disabled}
                />
            </div>
        case 'dropdown':
            return <div className="mb-4">
                {(!field.hide_label || field.hide_label == undefined) && <label className="block text-sm font-medium text-gray-700 mb-1">{field.label}{field.required ? " *" : ''}</label>}
                {field.options.length === 0 && <p className="italic text-gray-500">Niet beschikbaar</p>}
                {field.options.length > 0 && <select
                    className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-sky-500 disabled:bg-gray-100"
                    name={field.name}
                    required={field.required}
                    disabled={field.disabled}
                >
                    <option value={''} disabled>Kies een optie</option>
                    {
                        field.options.map(opt => <option key={opt.name} value={opt.value}>{opt.name}</option>)
                    }
                </select>}
            </div>
        case 'info':
            return <div className="mb-4"><span className="italic text-gray-600">{field.name}</span></div>
        case 'repeat':
            return <div className="mb-4 text-yellow-700 bg-yellow-50 p-2 rounded">TODO: Implement repeater form fields. The idea is that the form can have a property of nested form fields</div>
        default:
            return <div className="mb-4 text-red-600 font-bold">No renderer implemented for {JSON.stringify(field)}</div>
    }
}

interface FormBuilderProps {
    fields: FormField[]
    isDisabled?: boolean
    submitBtnText?: string
    noSubmit?: boolean
    action: string
    method: 'get' | 'post'
}
export function FormBuilder(props: FormBuilderProps) {
    const { fields, isDisabled, noSubmit, submitBtnText, action, method } = props
    return <form className="max-w-lg space-y-6" action={action} method={method}>
        {
            fields.sort((a, b) => a.weight - b.weight)
                .map(field => <FieldRenderer key={`${field.id}_${field.name}_${field.kind}`} field={field} />)
        }
        {!noSubmit && <button
            disabled={isDisabled}
            type="submit"
            className="w-full py-2 px-4 bg-sky-600 hover:bg-sky-700 text-white font-semibold rounded-md shadow focus:outline-none focus:ring-2 focus:ring-sky-500 disabled:bg-gray-300"
        >
            {submitBtnText || 'Verstuur'}
        </button>}
    </form>
}