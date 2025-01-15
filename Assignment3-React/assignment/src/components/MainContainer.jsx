import React from 'react'
import FilterBox from './FilterBox'
import SubContainer from './SubContainer'
const styles = {
    display: 'flex',
    marginTop:'7%'
}
function MainContainer() {
  return (
    <div style={styles}>
        <FilterBox/>
        <SubContainer/>
    </div>
  )
}

export default MainContainer