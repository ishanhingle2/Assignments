import React from 'react'
import { useSelector } from 'react-redux'
const styles = {
  fontSize:'30px'
}

function Title() {
    let value=0;
    value=useSelector(state=>state.products.length)
    return (
    <h1 style={styles} data-testid="title1">
       {value} Used Cars in India
    </h1>
  )
}

export default Title