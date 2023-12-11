import s from './FileInputImg.module.scss'
import { useContext, useRef, useState } from 'react';
import { Context } from '../../main';
import user from '../../assets/img/icons/user.png';
import { MdFileDownload } from "react-icons/md";
import { observer } from 'mobx-react-lite';

const FileInputImg = () => {

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
        <div className={s.account__form}>
            <div className={s.account__input_file}>
                {store.user.imageUri ?
                    <img
                        ref={refImg}
                        id="file_upload"
                        src={store.user.imageUri}
                        alt="your avatar"
                        className={s.account__upload_img}
                    />
                    :
                    <img
                        ref={refImg}
                        id="file_upload"
                        src={user}
                        alt="your avatar"
                        className={s.account__upload_img}
                    />
                }
                <div className={s.account__file_box}>
                    <p className={s.account__file_text}>
                        Прикрепить изображение в формате JPG, PNG.
                        Максимальный размер 800 Кб.
                    </p>
                    <div className={s.account__input_file_box}>
                        <label className={s.account__input_file_upload}>
                            <MdFileDownload className={s.account__input_file_icon} />
                            <span className={s.account__upload_label}>Загрузить фото</span>
                            <input className={s.account__upload_input} type="file" onChange={readURL} accept="image/png, image/jpeg" />
                        </label>
                    </div>
                </div>
            </div>
            <button className={s.account__form_btn} onClick={() => store.ChangeImg(imgUrl)}>Сохранить</button>
        </div>
    )
}

export default observer(FileInputImg)