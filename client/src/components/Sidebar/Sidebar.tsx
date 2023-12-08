import { NavLink } from "react-router-dom";
import menuList from '../../assets/menuList';
import s from './Sidebar.module.scss'

const Sidebar = ({ children }: any) => {

    return (
        <div className={s.sidebar_container}>
            <div className={s.sidebar}>
                <nav className={s.sidebar__menu}>
                    <ul className={s.sidebar__list}>
                        {menuList.listItem.map((item: any, index: number) => {
                            return (
                                <li key={index} className={s.sidebar__item}>
                                    <NavLink to={item.path} className={s.sidebar__item_link}><span className={s.sidebar__icon}>{item.icon}</span>{item.name}</NavLink>
                                </li>
                            )
                        })}
                    </ul>
                </nav>
            </div>
            <div className="wrapper">
                <main className="main">
                    {children}
                </main>
            </div>
        </div>
    )
}

export default Sidebar