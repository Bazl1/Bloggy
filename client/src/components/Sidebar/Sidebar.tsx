import { Link, NavLink } from "react-router-dom";
import menuList, { menuAuthList } from '../../assets/menuList';
import s from './Sidebar.module.scss'
import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../../main";
import { IoLogOutSharp } from "react-icons/io5";
import { CategoryResponse } from '../../models/response/CategoryResponse';
import PostService from "../../service/PostsService";
import { BiSolidCategory } from "react-icons/bi";
import { IoCreateOutline } from "react-icons/io5";

const Sidebar = ({ children }: any) => {
    const [posts, setPosts] = useState<CategoryResponse[]>([])
    const [open, setOpen] = useState<boolean>(false)

    const { store } = useContext(Context)

    useEffect(() => {
        fetchCategory()
    }, [])

    async function fetchCategory() {
        try {
            const response = await PostService.fetchCategory();
            setPosts(response.data.result.topics)
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <div className={s.sidebar_container}>
            <div className={open ? `${s.sidebar} ${s.sidebar__active}` : `${s.sidebar}`}>
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
                    {store.isAuth ? <NavLink to={'/create-post'} className={`${s.sidebar__item_link} ${s.sidebar__item_link_create}`}><span className={s.sidebar__icon}><IoCreateOutline /></span>Create a post</NavLink> : ''}
                </nav>
                <div className={s.sidebar__category}>
                    <ul className={open ? `${s.sidebar__list} ${s.sidebar__list_categorys} ${s.sidebar__list_categorys_active}` : `${s.sidebar__list} ${s.sidebar__list_categorys}`}>
                        {posts.map((item: any) => {
                            return (
                                <li key={item.id} className={`${s.sidebar__item} ${s.sidebar__item_category}`}>
                                    <NavLink to={'/posts/category/' + item.name} className={s.sidebar__item_btn}><span><BiSolidCategory /></span>{item.name}</NavLink>
                                </li>
                            )
                        })}
                    </ul>
                    <button onClick={() => setOpen(current => !current)} className={s.sidebar__more_btn}>{open ? "See less" : "See more"}</button>
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