import { useContext, useEffect, useRef, useState } from 'react';
import s from './CreatePostPage.module.scss'
import { MdFileDownload } from "react-icons/md";
import { observer } from 'mobx-react-lite';
import { IoCreate } from "react-icons/io5";
import { IoIosCloseCircle } from "react-icons/io";
import { Context } from '../../main';
import PostService from '../../service/PostsService';

const CreatePostPage = () => {
    const [open, setOpen] = useState<boolean>(false)
    const [imgUrl, setImgUrl] = useState<any>('')
    const refImg = useRef<HTMLImageElement | null>(null);
    const [posts, setPosts] = useState<CategoryResponse[]>([])

    const { store } = useContext(Context)

    useEffect(() => {
        fetchCategory()
    }, [])

    async function fetchCategory() {
        try {
            const response = await PostService.fetchCategory();
            setPosts(response.data.result.topics)
        } catch (error) {
            console.log(error)
        }
    }

    const readURL = (event: React.ChangeEvent<HTMLInputElement>) => {
        const input = event.target;
        if (input.files && input.files[0]) {
            const reader = new FileReader();
            setImgUrl(input.files[0])
            reader.onload = function (e) {
                if (refImg.current) {
                    refImg.current.src = e.target?.result as string;
                }
            };
            reader.readAsDataURL(input.files[0]);
        }
    };

    return (
        <section className={s.postform}>
            <div className="container">
                <div className={s.postform__inner}>
                    <h2 className={s.postform__title}><span><IoCreate /></span>Create a post</h2>
                    <div className={s.postform__row}>
                        <div className={s.postform__columns}>
                            <div className={s.postform__input_file}>
                                {imgUrl !== '' ?
                                    <img
                                        ref={refImg}
                                        id="file_upload"
                                        src=''
                                        alt="post img"
                                        className={s.postform__upload_img}
                                    />
                                    :
                                    <div className={s.postform__null}>Post image</div>
                                }
                                <div className={s.postform__file_box}>
                                    <p className={s.postform__file_text}>
                                        Attach an image in JPG, PNG format.<br />
                                        Maximum size 800 KB.
                                    </p>
                                    <div className={s.postform__input_file_box}>
                                        <label className={s.postform__input_file_upload}>
                                            <MdFileDownload className={s.postform__input_file_icon} />
                                            <span className={s.postform__upload_label}>Upload a photo</span>
                                            <input className={s.postform__upload_input} type="file" onChange={readURL} accept="image/png, image/jpeg" />
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className={s.postform__columns}>
                            <form className={s.postform__form}>
                                <label className={s.postform__input_box}>
                                    <span>Post title</span>
                                    <input className={s.postform__input} type="text" placeholder='Enter title' />
                                </label>
                                <label className={s.postform__input_box}>
                                    <span>Post description</span>
                                    <textarea className={s.postform__textarea} placeholder='Enter description'></textarea>
                                </label>
                            </form>
                            <button className={s.postform__category_all}>Select post category</button>
                        </div>
                    </div>
                    <div className="postform__popup">
                        <div className="postform__popup_top">
                            <h3 className="postform__popup_title">Select a category</h3>
                            <button className="postform__popup_close"><IoIosCloseCircle /></button>
                        </div>
                        <div className="postform__popup_items">
                            <div className="postform__popup_item">

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default observer(CreatePostPage)