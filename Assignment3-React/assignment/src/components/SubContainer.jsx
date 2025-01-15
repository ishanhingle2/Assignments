import React from 'react'
import InfoBox from './InfoBox'
import Products from './Products'
const styles={
    width:'100%',
    marginLeft:'4px'
}
function SubContainer() {
  return (
    <div style={styles}>
        <InfoBox/>
        <Products/>
    </div>
  )
}

export default SubContainer