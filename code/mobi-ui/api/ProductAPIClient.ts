import APIClient from "./APIClient";
import { Product } from '../models/Product';

export default class ProductAPIClient extends APIClient {

    constructor() {
        super();
    }

    public async get() {
        try {
            const response = await fetch(`${this.host}/api/products`);
            const data = response.json();
            return data;
        } catch (error) {
            console.error('Error:', error);
        }
    }

    // TODO: change any to string type;
    public async getProductsByStoreId(storeId: any) {
        try {
            const response = await fetch(`${this.host}/api/products/${storeId}`);
            const data = response.json();
            return data;
        } catch (error) {
            console.error('Error:', error);
        }
    }

    public post() {
        // for futrue post calls
    }
}