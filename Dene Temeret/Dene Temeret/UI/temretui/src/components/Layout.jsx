import React from 'react'
import NavBar from './NavBar'
import Fotter from './Fotter'
import { Outlet } from 'react-router-dom'

function Layout
() {
    return (
        <>
            <NavBar />
            <Outlet />
            <Fotter />
        </>


    )
}

export default Layout
