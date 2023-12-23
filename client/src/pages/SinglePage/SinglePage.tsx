import { useParams } from 'react-router-dom';
import s from './SinglePage.module.scss'
import { useEffect, useState } from 'react';
import { IPost } from '../../models/IPost';
import PostService from '../../service/PostsService';

type Params = {
  [key: string]: string | undefined
}

const SinglePage = () => {
  const { id } = useParams<Params>();
  const [post, setPost] = useState<IPost | null>(null);

  async function GetSinglePost(postId: string) {
    try {
      const response = await PostService.GetSinglePosts(postId);
      if (response.data?.result?.posts) {
        setPost(response.data.result.posts);
      }
    } catch (error) {
      console.error(error);
    }
  }

  useEffect(() => {
    if (id) {
      GetSinglePost(id);
    }
  }, [id]);

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