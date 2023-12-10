import s from './AccountPage.module.scss';
import user from '../../assets/img/icons/user.png';
import { MdFileDownload } from "react-icons/md";
import { IoSettingsSharp } from "react-icons/io5";
import { useContext, useRef, useState } from 'react';
import { Context } from '../../main';
import { observer } from 'mobx-react-lite';

const AccountPage: React.FC = () => {
    const [imgUrl, setImgUrl] = useState<any>('')
    const refImg = useRef<HTMLImageElement | null>(null);

    const { store } = useContext(Context)

    const readURL = (event: React.ChangeEvent<HTMLInputElement>) => {
        const input = event.target;
        if (input.files && input.files[0]) {
            const reader = new FileReader();

            setImgUrl(input.files[0])

            reader.onload = function (e) {
                if (refImg.current) {
                    refImg.current.src = e.target?.result as string;
                }
            };
            reader.readAsDataURL(input.files[0]);
        }
    };

    return (
        <section className={s.account}>
            <div className="container">
                <div className={s.account__inner}>
                    <h2 className={s.account__title}><span><IoSettingsSharp /></span>Настройки вашего аккаунта</h2>
                    <div className={s.account__box}>
                        <div className={s.account__columns}>
                            <h3 className={s.account__sub_title}>Редактировать фото профиля</h3>
                            <div className={s.account__form}>
                                <div className={s.account__input_file}>
                                    <img
                                        ref={refImg}
                                        id="file_upload"
                                        src={user}
                                        alt="your image"
                                        className={s.account__upload_img}
                                    />
                                    <div className={s.account__file_box}>
                                        <p className={s.account__file_text}>
                                            Прикрепить изображение в формате JPG, PNG.
                                            Максимальный размер 800 Кб.
                                        </p>
                                        <div className={s.account__input_file_box}>
                                            <label className={s.account__input_file_upload}>
                                                <MdFileDownload className={s.account__input_file_icon} />
                                                <span className={s.upload_label}>Загрузить фото</span>
                                                <input type="file" onChange={readURL} accept="image/png, image/jpeg" />
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <button className={s.account__form_btn} onClick={() => store.ChangeImg(imgUrl)}>Сохранить</button>
                            </div>
                        </div>
                        <div className={s.account__columns}></div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default observer(AccountPage);
