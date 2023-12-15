import { useContext, useState } from 'react';
import s from './ChangePassword.module.scss'
import { Context } from '../../main';
import { observer } from 'mobx-react-lite';
import { useForm } from 'react-hook-form';
import { SnackbarProvider, enqueueSnackbar } from 'notistack';

const ChangePassword: React.FC = () => {
    const {
        register,
        formState: { errors, isValid },
        handleSubmit,
    } = useForm({
        mode: 'onBlur'
    })

    const [newPassword, setNewPassword] = useState<string>('');
    const [repeatPassword, setRepeatPassword] = useState<string>('');


    const { store } = useContext(Context);

    const Submit = () => {
        if (newPassword && repeatPassword && newPassword !== repeatPassword) {
            return enqueueSnackbar("Password mismatch!");
        }

        if (isValid) {
            enqueueSnackbar("Password changed successfully")
            setNewPassword('')
            setRepeatPassword('')
            return store.ChangePassword(newPassword)
        } else {
            enqueueSnackbar("Fill out the form correctly")
        }
    }

    return (
        <>
            <SnackbarProvider autoHideDuration={3000} />
            <form className={s.account__password_form} onSubmit={handleSubmit(Submit)}>
                <h3 className={s.account__sub_title}>Change user password</h3>
                <input {...register('NewPassword', {
                    required: true,
                    minLength: 3,
                    maxLength: 21,
                })} onChange={(e) => setNewPassword(e.target.value)} value={newPassword} className={s.account__input} type="password" placeholder='Enter a new password' />
                {errors.NewPassword && errors.NewPassword.type === "required" ? <div className={s.account__error_message}>This field is required</div> : ''}
                {errors.NewPassword && errors.NewPassword.type === "minLength" ? <div className={s.account__error_message}>Minimum password length 3 characters</div> : ''}
                {errors.NewPassword && errors.NewPassword.type === "maxLength" ? <div className={s.account__error_message}>Maximum password length 21 characters</div> : ''}
                <input {...register('RepeatPassword', {
                    required: true,
                    minLength: 3,
                    maxLength: 21,
                })} onChange={(e) => setRepeatPassword(e.target.value)} value={repeatPassword} className={s.account__input} type="password" placeholder='Repeat new password' />
                {errors.RepeatPassword && errors.RepeatPassword.type === "required" ? <div className={s.account__error_message}>This field is required</div> : ''}
                {errors.RepeatPassword && errors.RepeatPassword.type === "minLength" ? <div className={s.account__error_message}>Minimum password length 3 characters</div> : ''}
                {errors.RepeatPassword && errors.RepeatPassword.type === "maxLength" ? <div className={s.account__error_message}>Maximum password length 21 characters</div> : ''}
                <button className={s.account__btn}>Submit</button>
            </form>
        </>
    )
}

export default observer(ChangePassword)