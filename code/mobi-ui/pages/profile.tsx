import type { NextPage } from 'next';

const Profile: NextPage = () => {
  return (
    <div>
      <h2 className="title is-2">Name: Leo</h2>

      <div className="columns">
        <div className="column">First column</div>
        <div className="column">Second column</div>
        <div className="column">Third column</div>
        <div className="column">Fourth column</div>
      </div>

      <div className="buttons">
        <button className="button is-info">Info</button>
        <button className="button is-success">Success</button>
        <button className="button is-warning">Warning</button>
        <button className="button is-danger">Danger</button>
      </div>
    </div>
  );
};

export default Profile;
