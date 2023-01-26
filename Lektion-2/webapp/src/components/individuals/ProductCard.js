import React from 'react'
import { NavLink } from 'react-router-dom'
import TempImage from '../../assets/images/blue-jacket.png'
import Rating from './Rating'

const ProductCard = () => {
  return (
    <div className="col">
        <div className="card">
            <div className="card-img-container">
              <img src={TempImage} class="card-img-top" alt="..." />
              <div className="card-menu d-xl-none">
                <button className="menu-link"><i className="fa-regular fa-heart"></i></button>
                <button className="menu-link"><i className="fa-regular fa-code-compare"></i></button>
                <button className="menu-link"><i className="fa-regular fa-bag-shopping"></i></button>
              </div>
              <NavLink to="/" className="btn btn-theme w-100 d-xl-none">QUICK VIEW</NavLink>
            </div>
            <div className="card-body">
                <p className="card-category">Jackets</p>
                <h5 className="card-title">Blue Jacket</h5>
                <Rating />
                <p className="card-price">5000</p>
            </div>
        </div>
    </div>
  )
}

export default ProductCard