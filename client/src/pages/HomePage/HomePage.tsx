import SearchBox from '../../components/SearchBox/SearchBox';
import s from './HomePage.module.scss'
import { useContext } from 'react';
import { Context } from '../../main';
import { observer } from 'mobx-react-lite';
import Post from '../../components/Post/Post';

const HomePage = () => {
  const { store } = useContext(Context)

  return (
    <section className={s.home}>
      <div className="container">
        <div className={s.home__top}>
          <SearchBox />
        </div>
        <div className={s.home__items}>
          <Post />
        </div>
      </div>
    </section>
  )
}

export default observer(HomePage)