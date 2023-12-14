import { NavLink } from "react-router-dom";
import menuList, { menuAuthList } from '../../assets/menuList';
import s from './Sidebar.module.scss'
import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../../main";
import { IoLogOutSharp } from "react-icons/io5";
import PostsService from '../../service/PostsService';
import { IPost } from '../../models/IPost';

const Sidebar = ({ children }: any) => {
    const [posts, setPosts] = useState<IPost[]>([])

    const { store } = useContext(Context)

    useEffect(() => {
        fetchCategory
    }, [])

    async function fetchCategory() {
        try {
            const response = await PostsService.fetchCategory();
            setPosts(response.data)
        } catch (error) {
            console.log(error)
        }
    }

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
                <div className={s.sidebar__category}>
                    {posts.map((item: any) => {
                        return (
                            <li key={item.id} className={s.sidebar__item}>
                                <button className={s.sidebar__item_link}>{item.name}</button>
                            </li>
                        )
                    })}
                </div>
                {store.isAuth ?
                    <div className="sidebar__authmenu">
                        <ul className={s.sidebar__list}>
                            {menuAuthList.listItem.map((item: any, index: number) => {
                                return (
                                    <li key={index} className={s.sidebar__item}>
                                        <NavLink to={item.path} className={s.sidebar__item_link}><span className={s.sidebar__icon}>{item.icon}</span>{item.name}</NavLink>
                                    </li>
                                )
                            })}
                            <li className={s.sidebar__item}>
                                <button onClick={() => store.logout()} className={`${s.sidebar__item_link} ${s.sidebar__item_link_logout}`}><span className={s.sidebar__icon}><IoLogOutSharp /></span>Logout</button>
                            </li>
                        </ul>
                    </div>
                    : ''
                }
            </div>
            <div className="wrapper">
                <main className="main">
                    {children}
                </main>
            </div>
        </div>
    )
}

export default observer(Sidebar)