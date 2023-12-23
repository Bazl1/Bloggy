import SearchBox from '../../components/SearchBox/SearchBox';
import s from './HomePage.module.scss'
import { observer } from 'mobx-react-lite';
import Post from '../../components/Post/Post';
import { useContext, useEffect, useState } from 'react';
import { Context } from '../../main';
import { useInView } from 'react-intersection-observer'

const HomePage = () => {
  const { store } = useContext(Context)
  const [page, setPage] = useState<number>(0)

  const [ref, inView] = useInView({
    threshold: 0.3,
    triggerOnce: true,
  })

  useEffect(() => {
    store.ClearPosts()
  }, [])

  useEffect(() => {
    if (inView) {
      setPage((current: number) => current + 1)
    }
  }, [inView])

  useEffect(() => {
    store.GetPosts(page)
  }, [page])

  return (
    <section className={s.home}>
      <div className="container">
        <div className={s.home__top}>
          <SearchBox />
        </div>
        <div className={s.home__items}>
          {
            Array.isArray(store.posts) && store.posts.length > 0 ?
              store.posts.map((item) => {
                return (
                  <Post key={item.id} title={item.title} imageUri={item.author.imageUri} name={item.author.name} dateCreated={item.dateCreated} topics={item.topics} description={item.description} postImg={item.imageUri} postId={item.id} />
                )
              })
              : ''
          }
          {store.loading ?
            'Loading...'
            : ''}
          {store.loading ? '' : <div ref={ref} className={s.home__loading}></div>}
        </div>
      </div>
    </section>
  )
}

export default observer(HomePage)