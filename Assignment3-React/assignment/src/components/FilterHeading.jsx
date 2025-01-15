import React from 'react'
import FilterIcon from './FilterIcon'
const Headingstyles = {
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
    backgroundColor:'white',
    margin:"5%"
}

const buttonStyle = {
    backgroundColor: 'white',
    borderWidth: '0px',
    color: 'blue',
    fontSize: '15px'
}
function FilterHeading() {
    const handleClick=()=>{
        const url=new URL(window.location.href)
        url.search=""
        window.history.pushState(null,null,url)
        window.location.reload()
    }
    return (
        <div style={Headingstyles}>
            <h1 style={{ fontSize: '20px', margin: '3%' }}><FilterIcon /> Filters</h1>
            <button style={buttonStyle} onClick={handleClick}>Clear Alll</button>
        </div>
    )
}

export default FilterHeading