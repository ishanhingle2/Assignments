import React from 'react'

const styles={
    width:'47%',
    backgroundColor:'white',
    margin:'3px',
    borderRadius:'12px',
    padding:'0px 0px 12px 0px',
    marginTop:'10px',
    color:'333333',
    textOverflow:'ellipsis',
    height:'60%',
    outline:'rgb(255,0,0) dotted 0.4px'
}
const imageStyle={
   width:'100%',
   height:'250px',
   background:'#f9f9f9',
   display:'block'
}

const titleStyle={
    fontSize:'17px',
    fontWeight:'600',
    margin:'5%',
    overflow:'hidden',
    whiteSpace:'nowrap',
    textOverflow:'ellipsis'
}

const infoStyle={
    fontWeight:'400',
    fontSize:'10px',
    margin:'5%'
}

const buttonStyle={
    backgroundColor:'red',
    width:'90%',
    textAlign:'center',
    padding:'10px',
    color:'white',
    borderWidth:'0px',
    margin:'10px',
    fontSize:'17px'
}

function Product({product}) {
    const {carName,price,km,fuel,imageUrl,cityName}=product;
    return (
    <div style={styles}>
      <img style={imageStyle} src={imageUrl} alt='Image Loading'/>
      <h1 style={titleStyle}>{carName}</h1>
      <h1 style={infoStyle}>{km} | {fuel} | {cityName}</h1>
      <h1 style={{...titleStyle}}>{price}</h1>
      <button style={buttonStyle}>Get Seller Details</button>
    </div>
  )
}

export default Product