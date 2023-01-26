import React from 'react'
import ProductCard from '../individuals/ProductCard'

const ProductsGrid = ({title}) => {
  return (
    <section className="product-grid">
        <div className="container">
            <div className="title">{title}</div>

            <div className="row row-cols-1 row-cols-md-4 g-4">
                <ProductCard />
                <ProductCard />
                <ProductCard />
                <ProductCard />
                <ProductCard />
                <ProductCard />
                <ProductCard />
                <ProductCard />
            </div>
        </div>
    </section>
  )
}

export default ProductsGrid