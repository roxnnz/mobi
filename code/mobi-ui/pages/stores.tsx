import type { NextPage } from 'next';
import { Store } from '../models/Store';
import StoresData from '../services/StoresData';
const storeDatasService = new StoresData();
const stores = storeDatasService.getAllStores();

const Stores: NextPage = () => {
    return (
        <div className="columns is-multiline">
            {stores.map((stores: Store, index) => (
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
                                    <p className="title is-5">{stores.Store}</p>
                                    <p className="subtitle is-6"> {stores.PhoneNumber}</p>
                                </div>
                            </div>
                            <div className="content">
                                <a href={stores.Website}>Website</a>
                            </div>
                            <div className="content">{stores.Address}</div>
                        </div>
                    </div>
                </div>
            ))}
        </div>
    );
};

export default Stores;