import type { NextPage } from 'next';
const Profile: NextPage = () => {
  return (
    <div class="columns">
      <div class="column">
        <h1 class="bd-notification is-full">Store Name</h1>
        <div class="columns is-mobile">
          <div class="column is-one-third">
            <p class="bd-notification is-danger">Product</p>
            <p>Example product</p>
          </div>
          <div class="column is-half">
            <p class="bd-notification is-danger">Description</p>
            <p>Example Description</p>
          </div>
          <div class="column is-one-fifth">
            <p class="bd-notification is-danger">Price</p>
            <p>example price</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
