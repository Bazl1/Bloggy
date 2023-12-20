import { MdFileDownload } from "react-icons/md";
import { useRef } from 'react';
import s from './CreatePostFileInput.module.scss'

const CreatePostFileInput = ({ imgUrl, setImgUrl }: any) => {
    const refImg = useRef<HTMLImageElement | null>(null);

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
        <div className={s.postform__input_file}>
            {imgUrl !== '' ?
                <img
                    ref={refImg}
                    id="file_upload"
                    src=''
                    alt="post img"
                    className={s.postform__upload_img}
                />
                :
                <div className={s.postform__null}>Post image</div>
            }
            <div className={s.postform__file_box}>
                <p className={s.postform__file_text}>
                    Attach an image in JPG, PNG format.<br />
                    Maximum size 800 KB.
                </p>
                <div className={s.postform__input_file_box}>
                    <label className={s.postform__input_file_upload}>
                        <MdFileDownload className={s.postform__input_file_icon} />
                        <span className={s.postform__upload_label}>Upload a photo</span>
                        <input className={s.postform__upload_input} type="file" onChange={readURL} accept="image/png, image/jpeg" />
                    </label>
                </div>
            </div>
        </div>
    )
}

export default CreatePostFileInput