import { Either, IsLeft, IsRight } from '@/types/Func';
import { StrapiUserRequestBody } from '@/types/models/StrapiPayloads';
import { API, strapi, StrapiClient } from '@strapi/client';
import { StrapiAuthUser } from './StrapiAuthUser';
import { slugify } from '@/app/utils';
import { StrapiEvent, StrapiForm, StrapiHomePage, StrapiPage, StrapiShopOwner } from '@/types/models/StrapiCollections';

type ErrorMessage = string
export type ApiResponse<T> = Either<T, ErrorMessage>

export class StrapiClientAdapter {

    private client: StrapiClient;

    private blocksPopulator = ['Blocks', 'Blocks.Image', 'Blocks.PrimaryButton', 'Blocks.SecondaryButton', 'Blocks.PrimaryButton.InternalUrl', 'Blocks.SecondaryButton.InternalUrl', 'Blocks.form', 'Blocks.form.Fields', 'Blocks.form.Fields.Items']

    constructor() {
        this.client = strapi({
            baseURL: process.env.STRAPI_URL + '/api',
            auth: process.env.STRAPI_TOKEN,
        });
    }

    public async getHomepage(): Promise<ApiResponse<StrapiHomePage>> {
        const response = await this.client.single('homepage').find({
            populate: this.blocksPopulator,
        })
            .then((d: any) => IsLeft<StrapiHomePage, string>(d))
            .catch(() => IsRight<StrapiHomePage, string>('Request failed'))

        return response;
    }

    public async getAllEvents(page = 1, pageSize = 10): Promise<ApiResponse<StrapiEvent[] & API.DocumentResponseCollection>> {
        const response = await this.client.collection('events').find({
            populate: ['Image', 'Owner', 'DatesAndTimes', 'SubEvents', 'Venue'],
            pagination: {
                page: page,
                pageSize: pageSize,
                withCount: true,
            }
        })
            .then((d: any) => IsLeft<StrapiEvent[] & API.DocumentResponseCollection, string>(d))
            .catch(() => IsRight<StrapiEvent[] & API.DocumentResponseCollection, string>('Request failed'))

        return response;
    }

    public async getAllEventOwners(): Promise<ApiResponse<StrapiShopOwner[]>> {
        const response = await this.client.collection('users').find({
            populate: ["ProfilePicture"]
        })
            .then((d: any) => IsLeft<StrapiShopOwner[], string>(d))
            .catch(() => IsRight<StrapiShopOwner[], string>('Request failed'))
        return response;
    }

    public async getPageBySlug(_slug: string): Promise<ApiResponse<StrapiPage>> {
        // Feature request Strapi Client: Use slug in findOne instead of only documentID
        const response = await this.client.collection('pages').find({
            populate: this.blocksPopulator,
            filters: {
                slug: { $eq: _slug }
            }
        })
            .then((d: any) => {
                if (d.data.length == 0) return IsRight<StrapiPage, string>('Request failed')
                return IsLeft<StrapiPage, string>(d.data[0])
            })
            .catch(() => IsRight<StrapiPage, string>('Request failed'))

        return response
    }

    public async getFormById(id: string): Promise<ApiResponse<StrapiForm>> {
        const response = await this.client.collection('forms').findOne(id, {
            populate: ['Fields', 'Fields.Items'],
        })
            .then((d: any) => IsLeft<StrapiForm, string>(d.data))
            .catch(() => IsRight<StrapiForm, string>('Request failed'))
        return response
    }

    // TODO: Use /auth/local/register
    public async createUser(data: StrapiUserRequestBody): Promise<ApiResponse<API.Document>> {
        const response = await this.client.fetch('/users', {
            headers: {
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify({ ...data, slug: slugify(data.username) }),
        })

        let body = await response.json()
        if (response.ok) return IsLeft<API.Document, string>(body)

        let msg = body?.error?.message || 'User creation failed'
        if (body?.error?.details && body?.error?.details?.errors) {
            msg += body.error.details.errors.reduce((acc: string, error: any) => {
                return acc + ` - ${error.message}`
            }, '');
        }
        return IsRight<API.Document, string>(msg);
    }

    public async getEventOwnerBySlug(slug: string): Promise<ApiResponse<StrapiShopOwner>> {
        const response = await this.client.collection('users').find({
            populate: ["ProfilePicture", "Banner", 'Events', 'Events.Image', 'Events.Venue', 'Events.DatesAndTimes'],
            filters: {
                slug: { $eq: slug },
            },
            status: 'published'
        })
            .then((d: any) => {
                if (d.length == 0) return IsRight<StrapiShopOwner, string>('No results')
                return IsLeft<StrapiShopOwner, string>(d[0])
            })
            .catch(() => IsRight<StrapiShopOwner, string>('Request failed'))
        return response
    }

    public async loginAsUser(data: StrapiAuthUser): Promise<ApiResponse<any>> {
        const response = await this.client.fetch('/auth/local', {
            headers: {
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(json => IsLeft<any, string>(json))
            .catch(() => IsRight<any, string>('Login failed'))

        return response
    }

    // BUG: Fetch in Strapi Client overides Authorization header
    public async getCurrentUser(token: string): Promise<ApiResponse<StrapiShopOwner>> {
        const response = await fetch(process.env.STRAPI_URL + '/api/users/me', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then(response => response.ok ? response.json() : Promise.reject(response.status))
            .then(json => IsLeft<StrapiShopOwner, string>(json))
            .catch(() => IsRight<StrapiShopOwner, string>('No user logged in'))

        return response
    }

    public async uploadFile(file: string, name: string): Promise<ApiResponse<API.Document>> {
        const formData = new FormData();
        // Convert base64 string to a Buffer and append as a Blob/File
        const matches = file.match(/^data:(.+);base64,(.+)$/);
        if (!matches) throw new Error('Invalid base64 file string');
        const mimeType = matches[1];
        const base64Data = matches[2];
        const byteCharacters = atob(base64Data);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray], { type: mimeType });
        formData.append('files', blob, `${name}-${Date.now().toLocaleString()}.` + mimeType.split('/')[1]);

        const response = await this.client.fetch('/upload', {
            method: 'POST',
            body: formData,
        })
            .then(response => response.json())
            .then(json => IsLeft<API.Document, string>(json))
            .catch(() => IsRight<API.Document, string>('Upload failed'))

        return response
    }

    public async updateUser(user_token: string, id: string, data: Partial<StrapiUserRequestBody>): Promise<ApiResponse<API.Document>> {
        const response = await fetch(process.env.STRAPI_URL + `/api/users/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${user_token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        })
            .then(response => response.ok ? response.json() : Promise.reject())
            .then(d => IsLeft<API.Document, string>(d.data))
            .catch(() => IsRight<API.Document, string>('Request failed'))
        return response
    }

    public async createEvent(user_token: string, data: Partial<StrapiEvent>): Promise<ApiResponse<StrapiEvent>> {
        const response = await fetch(process.env.STRAPI_URL + '/api/events', {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${user_token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ ...data, Image: data.ImageId })
        })
            .then(response => response.ok ? response.json() : Promise.reject())
            .then(d => IsLeft<StrapiEvent, string>(d.data))
            .catch(() => IsRight<StrapiEvent, string>('Request failed'))
        return response
    }

}