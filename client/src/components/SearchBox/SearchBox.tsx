import { Link } from 'react-router-dom';
import s from './SearchBox.module.scss'
import { IoSearch } from "react-icons/io5";
import { useState } from 'react';

const SearchBox = () => {
    const [search, setSearch] = useState<string>('')

    return (
        <div className={s.home__input_box}>
            <input onChange={(e) => setSearch(e.target.value)} value={search} className={s.home__input} type="text" placeholder='Search...' />
            <Link to={'/posts/search/' + search} className={s.home__search_btn}><IoSearch /></Link>
        </div>
    )
}

export default SearchBox