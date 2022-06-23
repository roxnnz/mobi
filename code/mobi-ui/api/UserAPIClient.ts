import MobiAPIClient from "./APIClient";
import { IUserAPIClients } from "./IUserAPIClient";

class UserAPIClient extends MobiAPIClient implements IUserAPIClients {

    constructor() {
        super();
    }

    async getById(id: string) {
        try {
            const response = await fetch(`${this.host}/api/users/${id}`)
            const data = response.json()
            return data
        } catch (error) {
            console.error('Error:', error);
        }
    }
}

export default UserAPIClient;