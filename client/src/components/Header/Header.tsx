import { Link, NavLink } from 'react-router-dom'
import s from './Header.module.scss'
import logo from '../../assets/img/logo.png'
import user from '../../assets/img/icons/user.png'
import { observer } from 'mobx-react-lite'
import { useContext } from 'react'
import { Context } from '../../main'
import { RxHamburgerMenu } from "react-icons/rx";

const Header = () => {
    const { store } = useContext(Context)

    return (
        <header className={s.header}>
            <div className="container-fluid">
                <div className={s.header__inner}>
                    <NavLink to={'/'}><img className={s.header__logo} src={logo} alt="logo" /></NavLink>
                    {store.isAuth ? (
                        <div className={`${s.header__user_box} ${s.header__mb_hidden}`}>
                            <div className={s.header__user_avatar}>
                                {store.user && typeof store.user.imageUri === 'string' && store.user.imageUri !== '' ?
                                    <img className={s.header__user_img} src={store.user.imageUri} alt="user" />
                                    : <img className={s.header__user_img} src={user} alt="user" />}
                            </div>
                            {store.user ? <div className={s.header__user_name}>Welcome ~ {store.user.name}</div> : <></>}
                        </div>
                    ) : (
                        <Link to={'/login'} className={s.header__auth_btn}>Login</Link>
                    )}
                    <div className={s.header__pc_hidden}>
                        <button className={s.header__burger} onClick={() => store.setActiveSidebar(true)}><RxHamburgerMenu /></button>
                    </div>
                </div>
            </div>
        </header>
    )
}

export default observer(Header)