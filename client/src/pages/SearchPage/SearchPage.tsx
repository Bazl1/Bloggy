import { useContext, useEffect, useState } from 'react'
import s from './SearchPage.module.scss'
import { Context } from '../../main'
import { observer } from 'mobx-react-lite'
import Post from '../../components/Post/Post'
import { useParams } from 'react-router-dom'
import { useInView } from 'react-intersection-observer'

interface Params {
    [key: string]: string | undefined;
}

interface SearchProps {
    type: string;
}

const SearchPage = ({ type }: SearchProps) => {
    const { store } = useContext(Context)
    const { id } = useParams<Params>()

    const [page, setPage] = useState<number>(0)

    const [ref, inView] = useInView({
        threshold: 0.6,
        triggerOnce: true,
    })

    useEffect(() => {
        store.ClearPosts()
    }, [id])

    useEffect(() => {
        if (inView) {
            setPage((current: number) => current + 1)
        }
    }, [inView])

    useEffect(() => {
        store.GetSearchPosts(id, type, page)
    }, [id, type, page])

    return (
        <section className={s.search}>
            <div className="container">
                <div className={s.search__inner}>
                    <h2 className={s.search__title}>{store.posts.length <= 0 ? "No results" : `Search: ${id}`}</h2>
                    <div className={s.search__items}>
                        {
                            Array.isArray(store.posts) && store.posts.length > 0 ?
                                store.posts.map((item) => {
                                    return (
                                        <Post key={item.id} title={item.title} imageUri={item.author.imageUri} name={item.author.name} dateCreated={item.dateCreated} topics={item.topics} description={item.description} postImg={item.imageUri} postId={item.id} />
                                    )
                                })
                                : ''
                        }
                        {store.end ? '' : store.loading ? '' : <div ref={ref} className={s.search__loading}></div>}
                    </div>
                </div>
            </div>
        </section>
    )
}

export default observer(SearchPage)
