import s from './AccountPage.module.scss';
import { IoSettingsSharp } from "react-icons/io5";
import FileInputImg from '../../components/FileInputImg/FileInputImg';
import ChangePassword from '../../components/ChangePassword/ChangePassword';
import ChangeName from '../../components/ChangeName/ChangeName';

const AccountPage: React.FC = () => {

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
                            <ChangeName />
                            <ChangePassword />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default AccountPage;
