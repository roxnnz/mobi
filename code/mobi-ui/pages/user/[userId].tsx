import type { NextPage } from 'next';
import { User } from '../../models/User';
import UserData from '../../services/UsersData';
import { useRouter } from 'next/router'
import { useState, useEffect } from 'react';
const userData = new UserData();

const Profile: NextPage = () => {
    const router = useRouter()
    const { userId } = router.query
    const [user, setUser] = useState<User>();

    useEffect(() => {
        userData.getUserByUserId(userId).then(res => setUser(res))
    }, [userId])


    return (
        <div>
            {user?.userId ? <><h2 className="title is-2">Name: {user?.name}</h2>
                <h2 className="title is-2">Email: {user?.email}</h2></> : null}
        </div>
    );
};

export default Profile;
