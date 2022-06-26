import type { NextPage } from 'next';
import { Product } from '../models/Product';
import { useEffect, useState } from 'react'; //set initial state for the page, re-render the page 
import ProductsData from '../services/ProductsData';
import { ProductsList } from '../components/ProductsList';
const productsData = new ProductsData();


const Profile: NextPage = () => {

  let initialProducts: Array<Product> = [];
  const [products, setProducts] = useState(initialProducts);
  useEffect(() => {
    productsData.getProducts().then(res => setProducts(res))
  }, [])

  return (
    <>
      <div><h2 className='subtitle'>Products:</h2></div>
      <hr />
      <ProductsList products={products} />
    </>
  );
};

export default Profile;
