import { Either, EitherA, EitherB } from '@/types/Func';
import { StrapiUser } from '@/types/models/StrapiUser';
import { API, strapi, StrapiClient } from '@strapi/client';

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
            .then(d => EitherA<API.DocumentResponse, Error>(d))
            .catch(() => EitherB<API.DocumentResponse, Error>(new Error('Request failed')))

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
            .then(d => EitherA<API.DocumentResponseCollection, Error>(d))
            .catch(() => EitherB<API.DocumentResponseCollection, Error>(new Error('Request failed')))
        return response;
    }

    public async getAllEventOwners(): Promise<Either<any[], Error>> {
        const response = await this.client.collection('users').find({
            populate: ["ProfilePicture"]
        })
            .then((d: any) => EitherA<any[], Error>(d))
            .catch(() => EitherB<any[], Error>(new Error('Request failed')))
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
                if (d.data.length == 0) return EitherB<API.Document, Error>(new Error('Request failed'))
                return EitherA<API.Document, Error>(d.data[0])
            })
            .catch(() => EitherB<API.Document, Error>(new Error('Request failed')))
        return response
    }

    public async getFormById(id: string): Promise<Either<API.Document, Error>> {
        const response = await this.client.collection('forms').findOne(id, {
            populate: ['Fields', 'Fields.Items'],
        })
            .then(d => EitherA<API.Document, Error>(d.data))
            .catch(() => EitherB<API.Document, Error>(new Error('Request failed')))
        return response
    }

    public async createUser(data: StrapiUser): Promise<Either<API.Document, Error>> {
        const response = await this.client.fetch('/users', {
            headers: {
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(data),
        })

        let body = await response.json()
        if (response.ok) return EitherA<API.Document, Error>(body)

        let msg = body?.error?.message || 'User creation failed'
        if (body?.error?.details && body?.error?.details?.errors) {
            msg += body.error.details.errors.reduce((acc: string, error: any) => {
                return acc + ` - ${error.message}`
            }, '')
        }
        return EitherB<API.Document, Error>(new Error(msg))
    }
}