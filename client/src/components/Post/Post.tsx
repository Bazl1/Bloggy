import { Link } from 'react-router-dom'
import s from './Post.module.scss'
import user from '../../assets/img/icons/user.png'
import postImg from '../../assets/img/mem-2-1024x683.jpg'
import { IoMdArrowDropright } from "react-icons/io";

const Post = () => {
    return (
        <div className={s.home__item}>
            <div className={s.home__item_top}>
                <div className={s.home__item_user}>
                    <img className={s.home__item_user_img} src={user} alt="user" />
                    <p className={s.home__item_user_name}>Maxim</p>
                </div>
                <div className={s.home__item_data}>
                    <p className={s.home__item_data_time}>12/12/2023 15:14</p>
                </div>
            </div>
            <h3 className={s.home__item_title}>Подумай об этом!</h3>
            <img className={s.home__item_img} src={postImg} alt="post-img" />
            <div className={s.home__item_data_categorys}>
                <div className={s.home__item_data_category}>Memes</div>
                <div className={s.home__item_data_category}>Memes</div>
            </div>
            <p className={s.home__item_text}>Lorem ipsum dolor sit amet consectetur adipisicing elit. Sit maiores placeat nihil illum consequatur optio totam libero a odit blanditiis explicabo distinctio ipsum nostrum, doloribus perferendis ea excepturi. Facere, fugit.
                Culpa incidunt quaerat blanditiis soluta deserunt officiis minus itaque, eius veniam fugiat voluptates ratione. Architecto quas necessitatibus, natus saepe cupiditate quisquam molestias perferendis. Eius, atque debitis. Aut in eligendi consequuntur!Lorem ipsum dolor sit amet consectetur adipisicing elit. Sit maiores placeat nihil illum consequatur optio totam libero a odit blanditiis explicabo distinctio ipsum nostrum, doloribus perferendis ea excepturi. Facere, fugit.
                Culpa incidunt quaerat blanditiis soluta deserunt officiis minus itaque, eius veniam fugiat voluptates ratione. Architecto quas necessitatibus, natus saepe cupiditate quisquam molestias perferendis. Eius, atque debitis. Aut in eligendi consequuntur!
                nostrum, doloribus perferendis ea excepturi. Facere, fugit.
                Culpa incidunt quaerat blanditiis soluta deserunt officiis minus itaque, eius veniam fugiat voluptates ratione. Architecto quas necessitatibus, natus saepe cupiditate quisquam molestias perferendis. Eius, atque debitis. Aut in eligendi consequuntur!</p>
            <Link to={'#'} className={s.home__item_btn}>Подробнее <span><IoMdArrowDropright /></span></Link>
        </div>
    )
}

export default Post