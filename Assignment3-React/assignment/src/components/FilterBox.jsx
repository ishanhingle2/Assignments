import React from 'react'
import FuelFilter from './FuelFilter'
import PriceFilter from './PriceFilter'
import FilterIcon from './FilterIcon'
import FilterHeading from './FilterHeading'
const styles={
    width:'25vw',
    backgroundColor:'white',
    margin:'0px 10px 0px 0px',
    height:'80vh',
    position:'sticky',
    top:'50px'
}
function FilterBox() {
  return (
    <div style={styles}>
        <FilterHeading/>
        <FuelFilter/>
        <PriceFilter/>
    </div>
  )
}

export default React.memo(FilterBox)