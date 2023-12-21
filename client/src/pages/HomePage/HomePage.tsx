import SearchBox from '../../components/SearchBox/SearchBox';
import s from './HomePage.module.scss'
import { observer } from 'mobx-react-lite';
import Post from '../../components/Post/Post';
import { useContext } from 'react';
import { Context } from '../../main';

const HomePage = () => {

  const { store } = useContext(Context)

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
        </div>
      </div>
    </section>
  )
}

export default observer(HomePage)