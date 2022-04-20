import ProductsMockData from '../mock/products.json';
import { Product } from '../models/Product';
/**
 * @description ProductData is a class provice set and get products.
 * @export ProductData class
 * @class ProductsData
 */
export default class ProductsData {
  products: Array<Product>;
  constructor() {
    this.products = ProductsMockData;
  }

  public getProducts(): Array<Product> {
    return this.products;
  }
}
