import ProductAPIClient from '../api/ProductAPIClient';
import { Product } from '../models/Product';

/**
 * @description ProductData is a class provice set and get products.
 * @export ProductData class
 * @class ProductsData
 */
export default class ProductsData {

  ProductAPIClient: ProductAPIClient;

  constructor() {
    this.ProductAPIClient = new ProductAPIClient();
  }

  public async getProducts(): Promise<Array<Product>> {
    return await this.ProductAPIClient.get();
  }

  //TODO: change type any to string;
  public async getProductsByStoreId(storeId: any): Promise<Array<Product> | undefined> {
    try {
      return await this.ProductAPIClient.getProductsByStoreId(storeId);
    } catch (error) {
      console.log(error)
    }
  }
}
