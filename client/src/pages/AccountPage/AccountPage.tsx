import s from './AccountPage.module.scss';
import { IoSettingsSharp } from "react-icons/io5";
import FileInputImg from '../../components/FileInputImg/FileInputImg';
import { useContext, useState } from 'react';
import { Context } from '../../main';

const AccountPage: React.FC = () => {
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
        <section className={s.account}>
            <div className="container">
                <div className={s.account__inner}>
                    <h2 className={s.account__title}><span><IoSettingsSharp /></span>Настройки вашего аккаунта</h2>
                    <div className={s.account__box}>
                        <div className={s.account__columns}>
                            <h3 className={s.account__sub_title}>Редактировать фото профиля</h3>
                            <FileInputImg />
                        </div>
                        <div className={s.account__columns}>
                            <div className={s.account__password_form}>
                                <h3 className={s.account__sub_title}>Изменить пароль пользователя</h3>
                                <input onChange={(e) => setNewPassword(e.target.value)} value={newPassword} className={s.account__input} type="password" placeholder='Введите новый пароль' required />
                                <input onChange={(e) => setRepeatPassword(e.target.value)} value={repeatPassword} className={s.account__input} type="password" placeholder='Повторите новый пароль' required />
                                <button className={s.account__btn} onClick={Submit}>Сохранить</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default AccountPage;
