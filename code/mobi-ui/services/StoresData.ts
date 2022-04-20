import StoresMockData from '../mock/stores.json';
import { Store } from '../models/Store';
/**
 * @description StoresData is a class provice set and get stores.
 * @export StoresData class
 * @class StoresData
 */
export default class StoresData {
  stores: Array<Store>;
  constructor() {
    this.stores = StoresMockData;
  }

  public getAllStores(): Array<Store> {
    return this.stores;
  }
}
