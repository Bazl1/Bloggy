import { Link } from "react-router-dom"
import FormRgister from "../../components/FormRegister/FormRgister"
import s from './RegistrationPage.module.scss'

const RegistrationPage = () => {
    return (
        <div className={s.registration}>
            <div className="container">
                <div className={s.registration__inner}>
                    <h2 className={s.registration__title}>Добро пожаловать! Зарегистрируйте свой аккаунт</h2>
                    <FormRgister />
                    <p className={s.registration__small_text}>Уже есть аккаунт? <span><Link to={'/login'} className={s.registration__link}>Авторизироваться</Link></span></p>
                </div>
            </div>
        </div>
    )
}

export default RegistrationPage