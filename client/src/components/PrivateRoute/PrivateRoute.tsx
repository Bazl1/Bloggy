import { useContext } from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { Context } from '../../main';

const PrivateRoute = () => {
    const { store } = useContext(Context)
    return store.isAuth ? <Outlet /> : <Navigate to="/login" />;
}

export default PrivateRoute