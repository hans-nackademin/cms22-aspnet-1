import React from 'react'
import MenuLink from './MenuLink'

const MenuLinkIcons = () => {
  return (
    <div className="menulinkicons">
      <MenuLink name={(<i className="fa-regular fa-magnifying-glass"></i>)}  link="/search" />
      <MenuLink name={(<i className="fa-regular fa-code-compare"></i>)}  link="/compare" />
      <MenuLink name={(<i className="fa-regular fa-heart"></i>)}  link="/wishlist" />
      <MenuLink name={(<i className="fa-regular fa-bag-shopping"></i>)} link="/cart" />
    </div>
  )
}

export default MenuLinkIcons