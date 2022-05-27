import type { NextPage } from 'next';
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
    <div className="columns is-multiline">
      {stores.map((stores: Store, index) => (
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
                  <p className="title is-5">{stores.storeName}</p>
                  <p className="subtitle is-6"> {stores.phoneNumber}</p>
                </div>
              </div>

              {stores.website != "N/A" ?
                <div className="content">
                  <a href={stores.website}>{stores.website}</a>
                </div> : null}

              <div className="content">{stores.address}</div>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
};

export default Stores;
