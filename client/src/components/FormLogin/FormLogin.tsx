import s from './FormLogin.module.scss'
import { useState, useContext } from 'react'
import { observer } from 'mobx-react-lite'
import { Context } from '../../main'
import { useNavigate } from 'react-router-dom'
import { SnackbarProvider, enqueueSnackbar } from 'notistack'
import { useForm } from 'react-hook-form'


const Form = () => {
    const {
        register,
        formState: { errors, isValid },
        handleSubmit,
    } = useForm({
        mode: 'onBlur'
    })

    const navigate = useNavigate();
    const [email, setEmail] = useState<string>('')
    const [password, setPassword] = useState<string>('')

    const { store } = useContext(Context)

    store.setRedirectCallback((path: string) => {
        navigate(path);
    });

    const Submit = () => {
        if (isValid) {
            store.login(email, password)
            setEmail('')
            setPassword('')
        }
    }

    return (
        <>
            <SnackbarProvider autoHideDuration={3000} />
            <form className={s.form} onSubmit={handleSubmit(Submit)} >
                <input {...register('Email', {
                    required: true,
                    pattern: /^((([0-9A-Za-z]{1}[-0-9A-z\.]{1,}[0-9A-Za-z]{1})|([0-9А-Яа-я]{1}[-0-9А-я\.]{1,}[0-9А-Яа-я]{1}))@([-A-Za-z]{1,}\.){1,2}[-A-Za-z]{2,})$/u,
                })} onChange={(e) => setEmail(e.target.value)} value={email} className={s.form__input} type="email" placeholder='Enter email' />
                {errors.Email && errors.Email.type === "required" ? <div className={s.form__error_message}>This field is required</div> : ''}
                {errors.Email && errors.Email.type === "pattern" ? <div className={s.form__error_message}>Incorrect email</div> : ''}
                <input {...register('Password', {
                    required: true,
                    minLength: 3,
                    maxLength: 21,
                })} onChange={(e) => setPassword(e.target.value)} value={password} className={s.form__input} type="password" placeholder='Enter password' />
                {errors.Password && errors.Password.type === "required" ? <div className={s.form__error_message}>This field is required</div> : ''}
                {errors.Password && errors.Password.type === "minLength" ? <div className={s.form__error_message}>Minimum password length 3 characters</div> : ''}
                {errors.Password && errors.Password.type === "maxLength" ? <div className={s.form__error_message}>Maximum password length 21 characters</div> : ''}
                <button className={s.form__btn} type='submit'>Login</button>
            </form >
        </>
    )
}

export default observer(Form)