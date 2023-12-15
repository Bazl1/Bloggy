import s from './AccountPage.module.scss';
import { IoSettingsSharp } from "react-icons/io5";
import FileInputImg from '../../components/FileInputImg/FileInputImg';
import ChangePassword from '../../components/ChangePassword/ChangePassword';
import ChangeName from '../../components/ChangeName/ChangeName';
import { useContext } from 'react';
import { Context } from '../../main';

const AccountPage: React.FC = () => {
    const {store} = useContext(Context)

    return (
        <section className={s.account}>
            <div className="container">
                {store.isAuth ?
                <div className={s.account__inner}>
                    <h2 className={s.account__title}><span><IoSettingsSharp /></span>Your account settings</h2>
                    <div className={s.account__box}>
                        <div className={s.account__columns}>
                            <h3 className={s.account__sub_title}>Edit profile photo</h3>
                            <FileInputImg />
                        </div>
                        <div className={s.account__columns}>
                            <ChangeName />
                            <ChangePassword />
                        </div>
                    </div>
                </div>
                :
                <div className={s.account__inner}>
                    Log in...
                </div>
                }
            </div>
        </section>
    );
};

export default AccountPage;
