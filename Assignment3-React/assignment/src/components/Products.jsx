import React from 'react'
import Product from './Product'
import { useSelector } from 'react-redux'
const styles={
    width:'100%',
    display:'flex',
    flexWrap:'wrap',
    justifyContent:'space-between',
    marginTop:'3%'
}
function Products() {
     const products=useSelector(state=>state.products)
    return (
    <div style={styles}>
        {products && products.map(product=><Product product={product}/>)}
    </div>
  )
}

export default Products