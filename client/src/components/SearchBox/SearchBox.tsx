import s from './SearchBox.module.scss'
import { IoSearch } from "react-icons/io5";

const SearchBox = () => {
    return (
        <div className={s.home__input_box}>
            <input className={s.home__input} type="text" placeholder='Search...' />
            <button className={s.home__search_btn}><IoSearch /></button>
        </div>
    )
}

export default SearchBox