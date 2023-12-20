import { useForm } from 'react-hook-form';
import s from './CreatePostForm.module.scss'

interface ICreatePostForm {
    postTitle: string;
    setPostTitle: (value: string) => void;
    postDescr: string;
    setPostDescr: (value: string) => void;
    Submit: (isValid: any) => void;
}

const CreatePostForm = ({ postTitle, setPostTitle, postDescr, setPostDescr, Submit }: ICreatePostForm) => {
    const {
        register,
        formState: { errors, isValid },
        handleSubmit,
    } = useForm({
        mode: 'onBlur'
    })

    return (
        <>
            <form className={s.postform__form} onSubmit={handleSubmit(() => Submit(isValid))}>
                <label className={s.postform__input_box}>
                    <span>Post title</span>
                    <input {...register('PostTitle', {
                        required: true,
                        minLength: 3,
                    })} onChange={(e) => setPostTitle(e.target.value)} value={postTitle} className={s.postform__input} type="text" placeholder='Enter title' />
                    {errors.PostTitle && errors.PostTitle.type === "required" ? <div className={s.postform__error_message}>This field is required</div> : ''}
                    {errors.PostTitle && errors.PostTitle.type === "minLength" ? <div className={s.postform__error_message}>Minimum password length 3 characters</div> : ''}
                </label>
                <label className={s.postform__input_box}>
                    <span>Post description</span>
                    <textarea {...register('PostDescription', {
                        required: true,
                        minLength: 10,
                    })} onChange={(e) => setPostDescr(e.target.value)} value={postDescr} className={s.postform__textarea} placeholder='Enter description'></textarea>
                    {errors.PostDescription && errors.PostDescription.type === "required" ? <div className={s.postform__error_message}>This field is required</div> : ''}
                    {errors.PostDescription && errors.PostDescription.type === "minLength" ? <div className={s.postform__error_message}>Minimum password length 10 characters</div> : ''}
                </label>
                <button type='submit' className={s.postform__btn}>Submit</button>
            </form>
        </>
    )
}

export default CreatePostForm