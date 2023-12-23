import { useEffect, useContext } from 'react'
import { Context } from "../../main";
import { useLocation } from 'react-router-dom'

const ScrollToTop = () => {
    const { store } = useContext(Context)
    const { pathname } = useLocation();
    useEffect(() => {
        window.scrollTo(0, 0)
        store.setActiveSidebar(false)
    }, [pathname])

    return null
}

export default ScrollToTop