import { User } from '../models/User';
import UserAPiClient from '../api/UserAPIClient';

/**
 * @description ProductData is a class provice set and get products.
 * @export ProductData class
 * @class ProductsData
 */
export default class UsersData {
  users: Array<User>;
  userAPIClient: UserAPiClient;
  constructor() {
    this.userAPIClient = new UserAPiClient();
    this.users = [];
  }

  // TODO: change any to string type;
  public async getUserByUserId(userId: any): Promise<User> {
    return await this.userAPIClient.getById(userId);
  }
}
