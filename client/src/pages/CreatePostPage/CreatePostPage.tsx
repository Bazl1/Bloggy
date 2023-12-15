import { useContext, useEffect, useRef, useState } from 'react';
import s from './CreatePostPage.module.scss'
import { MdFileDownload } from "react-icons/md";
import { observer } from 'mobx-react-lite';
import { IoCreate } from "react-icons/io5";
import { IoIosCloseCircle } from "react-icons/io";
import { Context } from '../../main';
import PostService from '../../service/PostsService';
import { CategoryResponse } from '../../models/response/CategoryResponse';

const CreatePostPage = () => {
    const [postTitle, setPostTitle] = useState<string>('')
    const [postDescr, setPostDescr] = useState<string>('')
    const [open, setOpen] = useState<boolean>(false)
    const [selectedCategories, setSelectedCategories] = useState<number[]>([]);
    const [imgUrl, setImgUrl] = useState<any>('')
    const refImg = useRef<HTMLImageElement | null>(null);
    const [categorys, setCategorys] = useState<CategoryResponse[]>([])

    const { store } = useContext(Context)

    useEffect(() => {
        fetchCategory()
    }, [])

    async function fetchCategory() {
        try {
            const response = await PostService.fetchCategory();
            setCategorys(response.data.result.topics)
        } catch (error) {
            console.log(error)
        }
    }

    const toggleCategory = (categoryId: number) => {
        const index = selectedCategories.indexOf(categoryId);
        if (index === -1) {
            setSelectedCategories([...selectedCategories, categoryId]);
        } else {
            const updatedCategories = [...selectedCategories];
            updatedCategories.splice(index, 1);
            setSelectedCategories(updatedCategories);
        }
    };

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

    const Submit = (e: any) => {
        e.preventDefault()
        store.CreatePost(postTitle, postDescr, selectedCategories, imgUrl)
    }

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
                                    <input onChange={(e) => setPostTitle(e.target.value)} value={postTitle} className={s.postform__input} type="text" placeholder='Enter title' />
                                </label>
                                <label className={s.postform__input_box}>
                                    <span>Post description</span>
                                    <textarea onChange={(e) => setPostDescr(e.target.value)} value={postDescr} className={s.postform__textarea} placeholder='Enter description'></textarea>
                                </label>
                                <button type='submit' className={s.postform__btn} onClick={(e) => Submit(e)}>Submit</button>
                            </form>
                            <button onClick={() => setOpen(current => !current)} className={s.postform__category_all}>Select post category</button>
                        </div>
                    </div>
                    <div className={`${s.postform__popup} ${open ? s.postform__popup_active : ''}`}>
                        <div className={s.postform__popup_top}>
                            <h3 className={s.postform__popup_title}>Select a category</h3>
                            <button onClick={() => setOpen(false)} className={s.postform__popup_close}><IoIosCloseCircle /></button>
                        </div>
                        <div className={s.postform__popup_items}>
                            {categorys.map((item: any) => {
                                const isSelected = selectedCategories.includes(item.id);
                                return (
                                    <div className={s.postform__popup_item} key={item.id}>
                                        <button className={`${s.postform__item_btn} ${isSelected ? s.postform__item_btn_active : ''}`} onClick={() => toggleCategory(item.id)}>{item.name}</button>
                                    </div>
                                )
                            })}
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default observer(CreatePostPage)