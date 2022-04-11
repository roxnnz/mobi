import type { NextPage } from 'next';
import { User } from '../models/User';
import UserData from '../services/UsersData';

const Profile: NextPage = () => {
  const userData = new UserData();
  const user = userData.getUserByLastName('li');

  return (
    <div>
      <h2 className="title is-2">Name: {user?.firstName}</h2>
    </div>
  );
};

export default Profile;
