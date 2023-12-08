import s from './LoginPage.module.scss';
import logo from '../../assets/img/logo.png';
import FormLogin from '../../components/FormLogin/FormLogin';
import { Link } from 'react-router-dom';

const LoginPage = () => {
    return (
        <section className={s.login}>
            <div className="container">
                <div className={s.login__inner}>
                    <img className={s.login__logo} src={logo} alt="logo" />
                    <FormLogin />
                    <p className={s.login__small_text}>Еще нет аккаунта ? <span><Link to={'/registration'} className={s.login__link}>Зарегистрироваться</Link></span></p>
                </div>
            </div>
        </section>
    )
}

export default LoginPage