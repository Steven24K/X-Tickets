import { strapi, StrapiClient } from '@strapi/client';

export class StrapiClientAdapter {

    private client: StrapiClient;

    constructor() {
        this.client = strapi({
            baseURL: process.env.STRAPI_URL + '/api',
            auth: process.env.STRAPI_TOKEN,
        });
    }

    public async getHomepage() {
        const response = await this.client.single('homepage').find({
            populate: ['Blocks', 'Blocks.Image', 'Blocks.PrimaryButton', 'Blocks.SecondaryButton', 'Blocks.PrimaryButton.InternalUrl', 'Blocks.SecondaryButton.InternalUrl'],
        })
        return response;
    }

    public async getAllEvents(page = 1, pageSize = 10) {
        const response = await this.client.collection('events').find({
            populate: ['Image', 'Owner', 'DatesAndTimes', 'SubEvents', 'Venue'],
            pagination: {
                page: page,
                pageSize: pageSize,
                withCount: true,
            }
        })
        return response;
    }

    public async getAllEventOwners(): Promise<any[]> {
        const response = await this.client.collection('users').find({
            populate: ["ProfilePicture"]
        }
        )
        return response as any;
    }
}