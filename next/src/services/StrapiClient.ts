import { strapi, StrapiClient } from '@strapi/client';


export class StrapiClientAdapter {

    private client: StrapiClient;

    constructor() {
        this.client = strapi({
            baseURL: process.env.STRAPI_URL + '/api',
            auth: process.env.STRAPI_TOKEN,
        });
    }

    public async geAllEvents() {
        const response = await this.client.collection('events').find({
            populate: ['Image', 'Owner', 'DatesAndTimes', 'SubEvents', 'Venue']
        })
        return response.data;
    }
}