import React, {useContext} from 'react'
import { Navbar,Nav } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import AppContext from '../../contexts/appContext';
import Logo from './../../logo.svg'
import { useIdentity } from './../../hooks/identity.hook'

const Navigation = () => {
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
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                {
                    logged && 
                    <Nav className="mr-auto">
                        <Nav.Link as={Link} to="/profile">Profile</Nav.Link>
                    </Nav>
                }
                
                <Nav className="ml-auto">
                    {isLogged() ?
                        <>
                        <Nav.Link disabled>{decodedToken.username}</Nav.Link>
                        <Nav.Link onClick={logoutHandler}>Logout</Nav.Link>
                        </>
                        :
                        <>
                            <Nav.Link as={Link} to="/register">Register</Nav.Link>
                            <Nav.Link as={Link} to="/login">Login</Nav.Link>
                        </>
                    }
                </Nav>
            </Navbar.Collapse>
            </Navbar>
        </div>
    )
    
}

export default Navigation