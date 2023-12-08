import { observer } from 'mobx-react-lite'
import s from './FormRgister.module.scss'
import { useContext, useState } from 'react'
import { Context } from '../../main'

const FormRgister = () => {
    const [username, setUsername] = useState<string>('')
    const [email, setEmail] = useState<string>('')
    const [password, setPassword] = useState<string>('')

    const { store } = useContext(Context)

    return (
        <div className={s.form}>
            <input onChange={(e) => setUsername(e.target.value)} value={username} className={s.form__input} type="text" placeholder='Ваше имя' required />
            <input onChange={(e) => setEmail(e.target.value)} value={email} className={s.form__input} type="email" placeholder='Ваша почта' required />
            <input onChange={(e) => setPassword(e.target.value)} value={password} className={s.form__input} type="password" placeholder='Ваш пароль' required />
            <button onClick={() => store.registration(username, email, password)} className={s.form__btn}>Зарегистрироваться</button>
        </div>
    )
}

export default observer(FormRgister)