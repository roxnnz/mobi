import StoreAPIClient from '../api/StoreAPIClient';
import { Store } from '../models/Store';
/**
 * @description StoresData is a class provice set and get stores.
 * @export StoresData class
 * @class StoresData
 */
export default class StoresData {
  storeAPIClient: StoreAPIClient;
  constructor() {
    this.storeAPIClient = new StoreAPIClient()
  }

  public async getAllStores(): Promise<Array<Store>> {
    return await this.storeAPIClient.get();
  }

  // TODO: Change to string from any;
  public async getStoreByStoreId(storeId: any): Promise<Store> {
    return await this.storeAPIClient.getByStoreId(storeId);
  }
}
