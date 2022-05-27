import type { NextPage } from 'next';
import { Product } from '../models/Product';
import { useEffect, useState } from 'react'; //set initial state for the page, re-render the page 
import ProductsData from '../services/ProductsData';
const productsData = new ProductsData();


const Profile: NextPage = () => {

  let initialProducts: Array<Product> = [];
  const [products, setProducts] = useState(initialProducts);
  useEffect(() => {
    productsData.getProducts().then(res => setProducts(res))
  }, [])

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
                  <p className="title is-5">{product.productName}</p>
                  <p className="subtitle is-6">$ {product.productPrice}</p>
                </div>
              </div>
              <div className="content">{product.productDescription}</div>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
};

export default Profile;
