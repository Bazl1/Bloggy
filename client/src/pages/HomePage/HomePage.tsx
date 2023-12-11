import { Link } from 'react-router-dom';
import SearchBox from '../../components/SearchBox/SearchBox';
import s from './HomePage.module.scss'

const HomePage = () => {
  return (
    <main className="main">
      <section className={s.home}>
        <div className="container">
          <div className={s.home__top}>
            <SearchBox />
            <div className="home__items">
              <div className="home__item">
                <div className="home__item_top">
                  Юзера сюда
                </div>
                <h3 className="home__item_title"></h3>
                <img className="home__item_img" src="" alt="post-img" />
                <p className="home__item_text"></p>
                <Link to={'#'} className="home__item_btn">Подробнее</Link>
              </div>
            </div>
          </div>
        </div>
      </section>
    </main>
  )
}

export default HomePage