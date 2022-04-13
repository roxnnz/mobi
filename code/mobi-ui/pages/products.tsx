import type { NextPage } from 'next';
const Profile: NextPage = () => {
  return (
    <div className="columns">
      <div className="column">
        <h1 className="bd-notification is-full">Store Name</h1>
        <div className="columns is-mobile">
          <div className="column is-one-third">
            <p className="bd-notification is-danger">Product</p>
            <p>Example product</p>
          </div>
          <div className="column is-half">
            <p className="bd-notification is-danger">Description</p>
            <p>Example Description</p>
          </div>
          <div className="column is-one-fifth">
            <p className="bd-notification is-danger">Price</p>
            <p>example price</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
