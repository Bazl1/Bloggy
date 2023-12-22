import './assets/styles/global.scss';
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import ScrollToTop from './assets/utils/ScrollToTop';
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import Sidebar from './components/Sidebar/Sidebar';
import Header from './components/Header/Header';
import { observer } from 'mobx-react-lite'
import RegistrationPage from './pages/RegistrationPage/RegistrationPage';
import { FC, useContext, useEffect } from 'react';
import { Context } from './main';
import AccountPage from './pages/AccountPage/AccountPage';
import CreatePostPage from './pages/CreatePostPage/CreatePostPage';
import SinglePage from './pages/SinglePage/SinglePage';
import SearchPage from './pages/SearchPage/SearchPage';

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
            <Route path="/posts/search/:id" element={<SearchPage type={'search'} />} />
            <Route path="/posts/category/:id" element={<SearchPage type={'category'} />} />
            <Route path="/post/:id" element={<SinglePage />} />
            <Route path="/create-post" element={<CreatePostPage />} />
            <Route path="/account" element={<AccountPage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/registration" element={<RegistrationPage />} />
            <Route path="/" element={<HomePage />} />
            <Route path="*" element={<Navigate to="/" />} />
          </Routes>
        </Sidebar>
      </Router>
    </>
  );
}

export default observer(App);
