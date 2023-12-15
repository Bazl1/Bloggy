import { Link } from "react-router-dom"
import FormRgister from "../../components/FormRegister/FormRgister"
import s from './RegistrationPage.module.scss'

const RegistrationPage = () => {
    return (
        <div className={s.registration}>
            <div className="container">
                <div className={s.registration__inner}>
                    <h2 className={s.registration__title}>Welcome!<br/>Register your account</h2>
                    <FormRgister />
                    <p className={s.registration__small_text}>Already have an account? <span><Link to={'/login'} className={s.registration__link}>Login</Link></span></p>
                </div>
            </div>
        </div>
    )
}

export default RegistrationPage