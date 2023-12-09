import { useContext } from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { Context } from '../../main';

const PrivateRoute = () => {
    const { store } = useContext(Context)
    if (!store.isAuth) {
        return <Navigate to="/login" />;
    }

    return <Outlet />;
}

export default PrivateRoute