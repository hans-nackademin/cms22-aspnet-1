import React from 'react'
import Image from '../../assets/images/showcase-img.png'

const Showcase = () => {
  return (
    <section className="showcase">
        
        <div className="container">
            <div className="content">
                <div className="titles">
                    <p className="title-2">GET UP TO 40% OFF</p>
                    <p className="title-1">Don't Miss This Opportunity</p>
                    <p className="title-3">Online shopping free home delivery over $100</p>
                    <button className="btn btn-theme mt-4">SHOP NOW</button>
                </div>            
            </div>
            <img src={Image} alt="" />
        </div>
    </section>
  )
}

export default Showcase