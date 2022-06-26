import type { NextPage } from 'next';
import Link from 'next/link';
import { useEffect, useState } from 'react';
import { Store } from '../models/Store';
import StoresData from '../services/StoresData';
const storeDatasService = new StoresData();

const Stores: NextPage = () => {

  const initStores: Array<Store> = [];
  const [stores, setStores] = useState(initStores);

  useEffect(() => {
    storeDatasService.getAllStores()
      .then(res => setStores(res))
  }, [])

  return (
    <>
      <div><h2 className='subtitle'>Stores:</h2></div>
      <hr />
      <div className="columns is-multiline">
        {stores.map((store: Store, index) => (
          <Link href={`/store/${store.storeId}`}>
            <div key={index} className="column is-3">
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
                      <p className="title is-5">{store.storeName}</p>
                      <p className="subtitle is-6"> {store.phoneNumber}</p>
                    </div>
                  </div>

                  {store.website != "N/A" ?
                    <div className="content">
                      <a href={store.website}>{store.website}</a>
                    </div> : null}

                  <div className="content">{store.address}</div>
                </div>
              </div>
            </div>
          </Link>
        ))}
      </div>
    </>

  );
};

export default Stores;
