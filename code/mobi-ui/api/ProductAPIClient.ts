import APIClient from "./APIClient";

export default class ProductAPIClient extends APIClient {

    constructor() {
        super();
    }

    public get(): Promise<Response> {
        return this.fetch(`${this.host}/api/products`);
    }

    public post() {
        // for futrue post calls
    }
}