import MobiAPIClient from "./APIClient";
import { IStoreAPIClient } from "./IStoreAPIClient";

class StoreAPIClient extends MobiAPIClient implements IStoreAPIClient {

    constructor() {
        super();
    }

    async getByStoreId(id: string) {
        try {
            const response = await fetch(`${this.host}/api/stores/${id}`)
            const data = response.json()
            return data
        } catch (error) {
            console.error('Error:', error);
        }
    }

    public async get() {
        try {
            const response = await fetch(`${this.host}/api/stores`)
            const data = response.json()
            return data
        } catch (error) {
            console.error('Error:', error);
        }
    }

    async post(data: any) {
        const conf = {
            method: 'POST',
            headers: this.headers,
            body: JSON.stringify(data),
        }
        try {
            const response = await fetch(`${this.host}/api/stores`, conf)
            const data = response.json()
            return data;
        } catch (error) {
            console.error('Error:', error);
        }
    }

}

export default StoreAPIClient;