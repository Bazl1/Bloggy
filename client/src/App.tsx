import './assets/styles/global.scss';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ScrollToTop from './assets/utils/ScrollToTop';
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import Sidebar from './components/Sidebar/Sidebar';
import Header from './components/Header/Header';
import { observer } from 'mobx-react-lite'
import RegistrationPage from './pages/RegistrationPage/RegistrationPage';
import { FC, useContext, useEffect } from 'react';
import { Context } from './main';

const App: FC = () => {
  const { store } = useContext(Context)

  useEffect(() => {
    if (localStorage.getItem('token')) {
      store.checkAuth()
    }
  }, [])

  return (
    <>
      <Router>
        <ScrollToTop />
        <Header />

        <Sidebar>
          <Routes>
            {/* <Route exact path='/' element={<PrivateRoute />}>
              <Route exact path='/' element={<HomePage />} />
            </Route> */}
            <Route path='/' element={<HomePage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/registration" element={<RegistrationPage />} />
          </Routes>
        </Sidebar>

      </Router>
    </>
  );
}

export default observer(App);
