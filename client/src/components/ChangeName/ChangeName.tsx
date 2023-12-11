import { useContext, useState } from "react"
import s from './ChangeName.module.scss'
import { Context } from "../../main";
import { observer } from "mobx-react-lite";

const ChangeName: React.FC = () => {
    const [newName, setNewName] = useState<string>('');

    const { store } = useContext(Context);


    return (
        <form className={s.account__name_form}>
            <h3 className={s.account__sub_title}>Изменить пароль пользователя</h3>
            <input onChange={(e) => setNewName(e.target.value)} value={newName} className={s.account__input} type="text" placeholder='Введите новое имя' required />
            <button className={s.account__btn} onClick={() => store.ChangeName(newName)} >Сохранить</button>
        </form>
    )
}

export default observer(ChangeName)