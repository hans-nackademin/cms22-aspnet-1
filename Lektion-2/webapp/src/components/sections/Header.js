import React from 'react'
import Logo from '../individuals/Logo'
import Menu from '../individuals/Menu'
import MenuLinkIcons from '../individuals/MenuLinkIcons'

const Header = () => {
  return (
    <section className="header container">
        <Logo />
        <Menu />
        <MenuLinkIcons />
    </section>
  )
}

export default Header