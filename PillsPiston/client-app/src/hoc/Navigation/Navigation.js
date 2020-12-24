import React, {useContext} from 'react'
import { Navbar,Nav } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import AppContext from '../../contexts/appContext';
import Logo from './../../logo.svg'
import { useIdentity } from './../../hooks/identity.hook'
import { useTranslation } from 'react-i18next';

const Navigation = () => {
    const { t, i18n } = useTranslation();
    const {isLogged, decodedToken} = useContext(AppContext);
    const {logout} = useIdentity()
    const logoutHandler = async (event) => {
        event.preventDefault();
        await logout()
        return
    }
    const logged = isLogged();
    return(
        <div>
            <Navbar bg="light" expand="lg">
            <Navbar.Brand as={Link} to="/">
                <img
                    src={Logo}
                    width="30"
                    height="30"
                    className="d-inline-block align-top"
                    alt=""
                />
                PillsPiston
            </Navbar.Brand>
            <Nav className="">
                <button onClick={() => i18n.changeLanguage('ua')}>Українська</button>
                <button onClick={() => i18n.changeLanguage('en')}>English</button>
            </Nav>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                {
                    logged && 
                    <Nav className="mr-auto">
                        <Nav.Link as={Link} to="/profile">{t("profile")}</Nav.Link>
                    </Nav>
                }
                
                <Nav className="ml-auto">
                    {isLogged() ?
                        <>
                        <Nav.Link disabled>{decodedToken.username}</Nav.Link>
                        <Nav.Link onClick={logoutHandler}>{t("logout")}</Nav.Link>
                        </>
                        :
                        <>
                            <Nav.Link as={Link} to="/register">{t("register")}</Nav.Link>
                            <Nav.Link as={Link} to="/login">{t("login")}</Nav.Link>
                        </>
                    }
                </Nav>
            </Navbar.Collapse>
            </Navbar>
        </div>
    )
    
}

export default Navigation