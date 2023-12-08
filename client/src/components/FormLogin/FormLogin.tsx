import s from './FormLogin.module.scss'
import { useState, useContext } from 'react'
import { observer } from 'mobx-react-lite'
import { Context } from '../../main'


const Form = () => {
    const [email, setEmail] = useState<string>('')
    const [password, setPassword] = useState<string>('')

    const { store } = useContext(Context)

    return (
        <div className={s.form}>
            <input onChange={(e) => setEmail(e.target.value)} value={email} className={s.form__input} type="email" placeholder='Ваш email' />
            <input onChange={(e) => setPassword(e.target.value)} value={password} className={s.form__input} type="password" placeholder='Ваш пароль' />
            <button onClick={() => store.login(email, password)} className={s.form__btn}>Авторизоваться</button>
        </div>
    )
}

export default observer(Form)