import { useContext, useState } from "react"
import s from './ChangeName.module.scss'
import { Context } from "../../main";
import { observer } from "mobx-react-lite";
import { SnackbarProvider, enqueueSnackbar } from "notistack";
import { useForm } from "react-hook-form";

const ChangeName: React.FC = () => {
    const {
        register,
        formState: { errors, isValid },
        handleSubmit,
    } = useForm({
        mode: 'onBlur'
    })

    const [newName, setNewName] = useState<string>('');

    const { store } = useContext(Context);

    const Submit = () => {
        if (isValid) {
            store.ChangeName(newName)
            enqueueSnackbar("Name changed successfully")
            setNewName('')
        } else {
            enqueueSnackbar("Fill out the form correctly")
        }
    }

    return (
        <>
            <SnackbarProvider autoHideDuration={3000} />
            <form className={s.account__name_form} onSubmit={handleSubmit(Submit)}>
                <h3 className={s.account__sub_title}>Change user password</h3>
                <input {...register('FirstName', {
                    required: true
                })} onChange={(e) => setNewName(e.target.value)} value={newName} className={s.account__input} type="text" placeholder='Enter a new name'/>
                {errors.FirstName && errors.FirstName.type === "required" ? <div className={s.account__error_message}>This field is required</div> : ''}
                <button className={s.account__btn}>Submit</button>
            </form>
        </>
    )
}

export default observer(ChangeName)