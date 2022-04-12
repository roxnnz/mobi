import type { NextPage } from 'next';
import { Product } from '../models/Product';
import ProductsData from '../services/ProductsData';
const productDataService = new ProductsData();
const products = productDataService.getProducts();

const Profile: NextPage = () => {
  return (
    <div className="columns is-multiline">
      {products.map((product: Product, index) => (
        <div key={index} className="column is-2">
          <div className="card">
            <div className="card-image">
              <figure className="image is-4by3">
                <img
                  src="https://bulma.io/images/placeholders/1280x960.png"
                  alt="Placeholder image"
                />
              </figure>
            </div>
            <div className="card-content">
              <div className="media">
                <div className="media-content">
                  <p className="title is-5">{product.Product}</p>
                  <p className="subtitle is-6">$ {product.Price}</p>
                </div>
              </div>
              <div className="content">{product.Description}</div>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
};

export default Profile;
