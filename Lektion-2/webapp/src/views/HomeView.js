import React from 'react'
import Header from '../components/sections/Header'
import ProductsGrid from '../components/sections/ProductsGrid'
import Showcase from '../components/sections/Showcase'


const HomeView = () => {
  return (
    <div id="home">
      <Header />
      <Showcase />
      <ProductsGrid title="Featured Products" />
    </div>
  )
}

export default HomeView