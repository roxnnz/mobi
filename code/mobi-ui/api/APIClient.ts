import { IMobiAPIClient } from "./IAPIClient";

class MobiAPIClient implements IMobiAPIClient {
    headers: { 'Content-Type': string; };
    host: string;

    constructor() {
        this.host = "https://localhost:7086"
        this.headers = {
            'Content-Type': 'application/json',
        }
    }
}

export default MobiAPIClient;