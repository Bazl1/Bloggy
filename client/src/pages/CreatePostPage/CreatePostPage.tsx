import { useContext, useState } from 'react';
import s from './CreatePostPage.module.scss'
import { observer } from 'mobx-react-lite';
import { IoCreate } from "react-icons/io5";
import { Context } from '../../main';
import CreatePostFileInput from '../../components/CreatePostFileInput/CreatePostFileInput';
import CreatePostForm from '../../components/CreatePostForm/CreatePostForm';
import CreatePostSelectCategorys from '../../components/CreatePostSelectCategorys/CreatePostSelectCategorys';
import { SnackbarProvider, enqueueSnackbar } from 'notistack';

const CreatePostPage = () => {
    const [imgUrl, setImgUrl] = useState<any>('')
    const [postTitle, setPostTitle] = useState<string>('')
    const [postDescr, setPostDescr] = useState<string>('')
    const [selectedCategories, setSelectedCategories] = useState<number[]>([]);
    const [open, setOpen] = useState<boolean>(false)
    const { store } = useContext(Context)


    const Submit = (isValid: any) => {
        if (isValid) {
            enqueueSnackbar("Post successfully created!")
            setPostTitle('')
            setPostDescr('')
            setImgUrl('')
            return store.CreatePost(postTitle, postDescr, selectedCategories, imgUrl)
        } else {
            enqueueSnackbar("Fill out the form correctly")
        }
    }

    return (
        <>
            <SnackbarProvider autoHideDuration={3000} />
            <section className={s.postform}>
                <div className="container">
                    <div className={s.postform__inner}>
                        <h2 className={s.postform__title}><span><IoCreate /></span>Create a post</h2>
                        <div className={s.postform__row}>
                            <div className={s.postform__columns}>
                                <CreatePostFileInput imgUrl={imgUrl} setImgUrl={setImgUrl} />
                            </div>
                            <div className={s.postform__columns}>
                                <CreatePostForm postTitle={postTitle} setPostTitle={setPostTitle} postDescr={postDescr} setPostDescr={setPostDescr} Submit={Submit} />
                                <button onClick={() => setOpen(current => !current)} className={s.postform__category_all}>Select post category</button>
                            </div>
                        </div>
                        <CreatePostSelectCategorys selectedCategories={selectedCategories} setSelectedCategories={setSelectedCategories} open={open} setOpen={setOpen} />
                    </div>
                </div>
            </section>
        </>
    )
}

export default observer(CreatePostPage)