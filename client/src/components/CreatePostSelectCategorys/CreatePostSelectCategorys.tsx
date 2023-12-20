import { useEffect, useState } from 'react';
import s from './CreatePostSelectCategorys.module.scss'
import { IoIosCloseCircle } from "react-icons/io";
import PostService from '../../service/PostsService';

interface ISelectCategorys {
    selectedCategories: number[];
    setSelectedCategories: (value: number[]) => void;
    open: boolean;
    setOpen: (value: boolean) => void;
}

interface ICategorys {
    id: number,
    name: string;
}

const CreatePostSelectCategorys = ({ selectedCategories, setSelectedCategories, open, setOpen }: ISelectCategorys) => {
    const [categorys, setCategorys] = useState<ICategorys[]>([])

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
    return (
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
    )
}

export default CreatePostSelectCategorys