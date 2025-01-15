import React from 'react'
import SortBy from './SortBy'
const styles={
    width:'100%',
    backgroundColor:'white',
    padding:'2%',
    postion:'relative'
}
function InfoBox() {
  return (
    <div style={styles}>
      <SortBy/>
    </div>
  )
}

export default InfoBox