// http://localhost:3000/stores/07829341-b4b7-4b34-aa4d-9dc848a1cee9

import { NextPage } from "next";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";
import { ProductsList } from "../../components/ProductsList";
import { Product } from "../../models/Product";
import { Store } from "../../models/Store";
import ProductData from "../../services/ProductsData";
import StoreData from "../../services/StoresData";

const pAPIClient = new ProductData();
const sAPIClient = new StoreData();

const Store: NextPage = () => {
    const router = useRouter()
    const { storeId } = router.query
    const [storeProductData, setStoreProductData] = useState<Array<Product>>([]);
    const initStore: Store = {
        storeId: "",
        storeName: "",
        phoneNumber: "",
        website: "",
        address: ""
    }
    const [storeData, setStoreData] = useState<Store>(initStore);

    useEffect(() => {
        if (storeId) {
            sAPIClient.getStoreByStoreId(storeId).then(res => setStoreData(res))
            pAPIClient.getProductsByStoreId(storeId).then(res => setStoreProductData(res))
        }
    }, [storeId])

    return (
        <>
            <div>Store name: {storeData.storeName}</div>
            <div>Store phone number: {storeData.phoneNumber}</div>
            <div>Store website: {storeData.website}</div>
            <div>Store address: {storeData.address}</div>
            <hr />
            <ProductsList products={storeProductData} />
        </>
    );
};

export default Store;