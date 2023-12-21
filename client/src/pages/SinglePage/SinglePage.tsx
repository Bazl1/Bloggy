import { useParams } from 'react-router-dom';
import s from './SinglePage.module.scss'
import { useContext, useEffect } from 'react';
import { Context } from '../../main';
import { IPost } from '../../models/IPost';

type Params = {
  id: string
}

const SinglePage = () => {
  const { store } = useContext(Context)

  const { id } = useParams<Params>();
  const PostId: number = parseInt(id!);

  const post: IPost | undefined = store.posts.find(item => parseInt(item.id) === PostId);

  return (
    <section className={s.single_post}>
      <div className="container">
        <div className={s.single_post__inner}>
          {
            post?.imageUri !== '' ?
              <img className={s.single_post__img} src={post?.imageUri} alt="post_img" />
              : ''
          }
          <h2 className={s.single_post__title}>{post?.title}</h2>
          <div className={s.single_post__categorys}>
            {post?.topics.map(item => {
              return <div key={item.id} className={s.single_post__category}>{item.name}</div>
            })}
          </div>
          <div className={s.single_post__content}>
            {post?.description}
          </div>
        </div>
      </div>
    </section>
  )
}

export default SinglePage