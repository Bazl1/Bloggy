import { observer } from 'mobx-react-lite'
import s from './FormRgister.module.scss'
import { useContext, useState } from 'react'
import { Context } from '../../main'
import { useNavigate } from 'react-router-dom'
import { useForm } from 'react-hook-form'
import { SnackbarProvider, enqueueSnackbar } from 'notistack'

const FormRgister = () => {
    const {
        register,
        formState: { errors, isValid },
        handleSubmit,
    } = useForm({
        mode: 'onBlur'
    })


    const navigate = useNavigate();
    const [username, setUsername] = useState<string>('')
    const [email, setEmail] = useState<string>('')
    const [password, setPassword] = useState<string>('')

    const { store } = useContext(Context)


    store.setRedirectCallback((path: string) => {
        navigate(path);
    });

    const Submit = () => {
        if (isValid) {
            store.registration(username, email, password)
            enqueueSnackbar("Congratulations on your successful registration!")
            setUsername('')
            setEmail('')
            setPassword('')
        } else {
            enqueueSnackbar("Fill out the form correctly")
        }
    }

    return (
        <>
            <SnackbarProvider autoHideDuration={3000} />
            <form className={s.form} onSubmit={handleSubmit(Submit)}>
                <input {...register('FirstName', {
                    required: true
                })} onChange={(e) => setUsername(e.target.value)} value={username} className={s.form__input} type="text" placeholder='Your name' />
                {errors.FirstName && errors.FirstName.type === "required" ? <div className={s.form__error_message}>This field is required</div> : ''}
                <input {...register('Email', {
                    required: true,
                    pattern: /^((([0-9A-Za-z]{1}[-0-9A-z\.]{1,}[0-9A-Za-z]{1})|([0-9А-Яа-я]{1}[-0-9А-я\.]{1,}[0-9А-Яа-я]{1}))@([-A-Za-z]{1,}\.){1,2}[-A-Za-z]{2,})$/u,
                })} onChange={(e) => setEmail(e.target.value)} value={email} className={s.form__input} type="email" placeholder='Your email' />
                {errors.Email && errors.Email.type === "required" ? <div className={s.form__error_message}>This field is required</div> : ''}
                {errors.Email && errors.Email.type === "pattern" ? <div className={s.form__error_message}>Incorrect email</div> : ''}
                <input {...register('Password', {
                    required: true,
                    minLength: 3,
                    maxLength: 21,
                })} onChange={(e) => setPassword(e.target.value)} value={password} className={s.form__input} type="password" placeholder='Your password' />
                {errors.Password && errors.Password.type === "required" ? <div className={s.form__error_message}>This field is required</div> : ''}
                {errors.Password && errors.Password.type === "minLength" ? <div className={s.form__error_message}>Minimum password length 3 characters</div> : ''}
                {errors.Password && errors.Password.type === "maxLength" ? <div className={s.form__error_message}>Maximum password length 21 characters</div> : ''}
                <button className={s.form__btn} type='submit'>Register</button>
            </form >
        </>
    )
}

export default observer(FormRgister)