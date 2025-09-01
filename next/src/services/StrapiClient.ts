import { Either, IsLeft, IsRight } from '@/types/Func';
import { StrapiUser } from '@/types/models/StrapiUser';
import { API, strapi, StrapiClient } from '@strapi/client';
import { StrapiAuthUser } from './StrapiAuthUser';
import { slugify } from '@/app/utils';

export class StrapiClientAdapter {

    private client: StrapiClient;

    private blocksPopulator = ['Blocks', 'Blocks.Image', 'Blocks.PrimaryButton', 'Blocks.SecondaryButton', 'Blocks.PrimaryButton.InternalUrl', 'Blocks.SecondaryButton.InternalUrl', 'Blocks.form', 'Blocks.form.Fields', 'Blocks.form.Fields.Items']

    constructor() {
        this.client = strapi({
            baseURL: process.env.STRAPI_URL + '/api',
            auth: process.env.STRAPI_TOKEN,
        });
    }

    public async getHomepage(): Promise<Either<API.DocumentResponse, Error>> {
        const response = await this.client.single('homepage').find({
            populate: this.blocksPopulator,
        })
            .then(d => IsLeft<API.DocumentResponse, Error>(d))
            .catch(() => IsRight<API.DocumentResponse, Error>(new Error('Request failed')))

        return response;
    }

    public async getAllEvents(page = 1, pageSize = 10): Promise<Either<API.DocumentResponseCollection, Error>> {
        const response = await this.client.collection('events').find({
            populate: ['Image', 'Owner', 'DatesAndTimes', 'SubEvents', 'Venue'],
            pagination: {
                page: page,
                pageSize: pageSize,
                withCount: true,
            }
        })
            .then(d => IsLeft<API.DocumentResponseCollection, Error>(d))
            .catch(() => IsRight<API.DocumentResponseCollection, Error>(new Error('Request failed')))
        return response;
    }

    public async getAllEventOwners(): Promise<Either<any[], Error>> {
        const response = await this.client.collection('users').find({
            populate: ["ProfilePicture"]
        })
            .then((d: any) => IsLeft<any[], Error>(d))
            .catch(() => IsRight<any[], Error>(new Error('Request failed')))
        return response;
    }

    public async getPageBySlug(_slug: string): Promise<Either<API.Document, Error>> {
        // Feature request Strapi Client: Use slug in findOne instead of only documentID
        const response = await this.client.collection('pages').find({
            populate: this.blocksPopulator,
            filters: {
                slug: { $eq: _slug }
            }
        })
            .then(d => {
                if (d.data.length == 0) return IsRight<API.Document, Error>(new Error('Request failed'))
                return IsLeft<API.Document, Error>(d.data[0])
            })
            .catch(() => IsRight<API.Document, Error>(new Error('Request failed')))
        return response
    }

    public async getFormById(id: string): Promise<Either<API.Document, Error>> {
        const response = await this.client.collection('forms').findOne(id, {
            populate: ['Fields', 'Fields.Items'],
        })
            .then(d => IsLeft<API.Document, Error>(d.data))
            .catch(() => IsRight<API.Document, Error>(new Error('Request failed')))
        return response
    }

    // TODO: Use /auth/local/register
    public async createUser(data: StrapiUser): Promise<Either<API.Document, Error>> {
        const response = await this.client.fetch('/users', {
            headers: {
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify({ ...data, slug: slugify(data.username) }),
        })

        let body = await response.json()
        if (response.ok) return IsLeft<API.Document, Error>(body)

        let msg = body?.error?.message || 'User creation failed'
        if (body?.error?.details && body?.error?.details?.errors) {
            msg += body.error.details.errors.reduce((acc: string, error: any) => {
                return acc + ` - ${error.message}`
            }, '')
        }
        return IsRight<API.Document, Error>(new Error(msg))
    }

    public async getEventOwnerBySlug(slug: string): Promise<Either<API.Document, Error>> {
        const response = await this.client.collection('users').find({
            populate: ["ProfilePicture", 'Events', 'Events.Image', 'Events.Venue', 'Events.DatesAndTimes'],
            filters: {
                slug: { $eq: slug },
            },
        })
            .then((d: any) => {
                if (d.length == 0) return IsRight<API.Document, Error>(new Error('No results'))
                return IsLeft<API.Document, Error>(d[0])
            })
            .catch(() => IsRight<API.Document, Error>(new Error('Request failed')))
        return response
    }

    public async loginAsUser(data: StrapiAuthUser): Promise<Either<any, Error>> {
        const response = await this.client.fetch('/auth/local', {
            headers: {
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(json => IsLeft<any, Error>(json))
            .catch(() => IsRight<any, Error>(new Error('Login failed')))

        return response
    }

    // BUG: Fetch in Strapi Client overides Authorization header
    public async getCurrentUser(token: string): Promise<Either<API.Document, Error>> {
        const response = await fetch(process.env.STRAPI_URL + '/api/users/me', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then(response => response.json())
            .then(json => IsLeft<API.Document, Error>(json))
            .catch(() => IsRight<API.Document, Error>(new Error('No user logged in')))

        return response
    }

    public async uploadFile(file: string): Promise<Either<API.Document, Error>> {
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
        formData.append('files', blob, `profile-picture-${Date.now().toLocaleString()}.` + mimeType.split('/')[1]);

        const response = await this.client.fetch('/upload', {
            method: 'POST',
            body: formData,
        })
            .then(response => response.json())
            .then(json => IsLeft<API.Document, Error>(json))
            .catch(() => IsRight<API.Document, Error>(new Error('Upload failed')))

        return response
    }

    public async updateUser(user_token: string, id: string, data: Partial<StrapiUser>): Promise<Either<API.Document, Error>> {
        const response = await fetch(process.env.STRAPI_URL + `/api/users/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${user_token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                ...data,
                slug: data.username ? slugify(data.username) : undefined
            })
        })
            .then(response => response.ok ? response.json() : Promise.reject())
            .then(d => IsLeft<API.Document, Error>(d.data))
            .catch(() => IsRight<API.Document, Error>(new Error('Request failed')))
        return response
    }

}