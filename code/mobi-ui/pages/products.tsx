import type { NextPage } from 'next';
const Profile: NextPage = () => {
  return (
    <div class="columns">
      <div class="column">
        <p class="bd-notification is-danger">Store Name</p>
        <div class="columns is-mobile">
          <div class="column is-half">
            <p class="bd-notification is-danger">Product</p>
          </div>
          <div class="column">
            <p class="bd-notification is-danger">Description</p>
          </div>
          <div class="column">
            <p class="bd-notification is-danger">Price</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
