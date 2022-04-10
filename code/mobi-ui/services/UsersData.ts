import UsersMockData from '../mock/users.json';
import { User } from '../models/User';
/**
 * @description ProductData is a class provice set and get products.
 * @export ProductData class
 * @class ProductsData
 */
export default class UsersData {
  users: Array<User>;
  constructor() {
    this.users = UsersMockData;
  }

  public getUserByLastName(lastName: string): User | undefined {
    return this.users.find((user) => user.lastName == lastName);
  }
}
