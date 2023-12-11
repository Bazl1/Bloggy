import { useContext, useState } from 'react';
import s from './ChangePassword.module.scss'
import { Context } from '../../main';
import { observer } from 'mobx-react-lite';

const ChangePassword: React.FC = () => {
    const [newPassword, setNewPassword] = useState<string>('');
    const [repeatPassword, setRepeatPassword] = useState<string>('');


    const { store } = useContext(Context);

    const Submit = () => {
        if (newPassword && repeatPassword && newPassword !== repeatPassword) {
            return alert("Пароли не совпадают!");
        }

        return store.ChangePassword(newPassword);
    }
    return (
        <form className={s.account__password_form}>
            <h3 className={s.account__sub_title}>Изменить пароль пользователя</h3>
            <input onChange={(e) => setNewPassword(e.target.value)} value={newPassword} className={s.account__input} type="password" placeholder='Введите новый пароль' required />
            <input onChange={(e) => setRepeatPassword(e.target.value)} value={repeatPassword} className={s.account__input} type="password" placeholder='Повторите новый пароль' required />
            <button className={s.account__btn} onClick={Submit}>Сохранить</button>
        </form>
    )
}

export default observer(ChangePassword)