import { Link } from 'react-router-dom'
import s from './Post.module.scss'
import user from '../../assets/img/icons/user.png'
import { IoMdArrowDropright } from "react-icons/io";
import { ITopic } from '../../models/ITopic';
import { observer } from 'mobx-react-lite';

interface PostProps {
    title: string;
    imageUri: string;
    name: string;
    dateCreated: string;
    topics: ITopic[];
    description: string;
    postImg: string;
    postId: string;
}

const Post: React.FC<PostProps> = ({ title, imageUri, name, dateCreated, topics, description, postImg, postId }) => {

    return (
        <div className={s.home__item}>
            <div className={s.home__item_top}>
                <div className={s.home__item_user}>
                    {imageUri && typeof imageUri === 'string' && imageUri !== '' ?
                        <img className={s.home__item_user_img} src={imageUri} alt="user" />
                        : <img className={s.home__item_user_img} src={user} alt="user" />}
                    <p className={s.home__item_user_name}>{name}</p>
                </div>
                <div className={s.home__item_data}>
                    <p className={s.home__item_data_time}>{dateCreated}</p>
                </div>
            </div>
            <h3 className={s.home__item_title}>{title}</h3>
            {postImg && typeof postImg === 'string' && postImg !== '' ?
                <img className={s.home__item_img} src={postImg} alt="post-img" />
                : ''}
            <div className={s.home__item_data_categorys}>
                {topics.map(topic => {
                    return <div key={topic.id} className={s.home__item_data_category}>{topic.name}</div>
                })}
            </div>
            <p className={s.home__item_text}>{description}</p>
            <Link to={'/post/' + postId} className={s.home__item_btn}>Подробнее <span><IoMdArrowDropright /></span></Link>
        </div >
    )
}

export default observer(Post)