class MobiAPIClient{
    headers: { 'Content-Type': string; };
    host: string;
    fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>;

    constructor(){
        this.host = "https://localhost:7086"
        this.headers = {
            'Content-Type': 'application/json',
        }
        this.fetch = fetch;
    }
}

export default MobiAPIClient;