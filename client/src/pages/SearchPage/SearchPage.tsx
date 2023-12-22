import { useContext, useEffect } from 'react'
import s from './SearchPage.module.scss'
import { Context } from '../../main'
import { observer } from 'mobx-react-lite'
import Post from '../../components/Post/Post'
import { useParams } from 'react-router-dom'

interface Params {
    [key: string]: string | undefined;
}

const SearchPage = () => {
    const { store } = useContext(Context)
    const { id } = useParams<Params>()

    useEffect(() => {
        store.GetCategoryPosts(id)
    }, [id])

    return (
        <section className={s.search}>
            <div className="container">
                <div className={s.search__inner}>
                    <h2 className={s.search__title}>Search: {id}</h2>
                    <div className={s.search__items}>
                        {
                            store.loading ?
                                'Loading...'
                                :
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
            </div>
        </section>
    )
}

export default observer(SearchPage)