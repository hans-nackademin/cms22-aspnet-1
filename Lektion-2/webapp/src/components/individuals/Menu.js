import React from 'react'
import MenuLink from './MenuLink'

const Menu = () => {
  return (
    <nav className="menu">
      <MenuLink name="Home" link="/" />
      <MenuLink name="Products" link="/products" />
      <MenuLink name="Contacts" link="/contacts" />
    </nav>
  )
}

export default Menu