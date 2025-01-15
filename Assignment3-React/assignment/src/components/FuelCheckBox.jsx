import axios from 'axios';
import React, { useEffect, useRef } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import fetchProducts from '../redux/products/productActions';

const styles={
    margin:'4%',
    fontSize:'20px',
    fontWeight:'100',
    fill:'#484848'
}
const updateUrl = (e) => {
    const fuelType = e.target.value
    const currentUrl = new URL(window.location.href);
    const searchParams = new URLSearchParams(currentUrl.search);
    const currentValues = searchParams.get('fuel')
    let updatedValues;
    if (e.target.checked) {
        updatedValues = currentValues ? `${currentValues}+${fuelType}` : fuelType;
    }
    else {
        const fuelArray = currentValues.split('+');
        updatedValues = fuelArray.filter((value) => value !== fuelType).join('+');
    }
    if (updatedValues) currentUrl.searchParams.set('fuel', updatedValues);
    else currentUrl.searchParams.delete('fuel')
    window.history.pushState(null, null, currentUrl);
}

function FuelCheckBox({ type, value}) {
    const dispatch=useDispatch();
    const ref=useRef(null);
    const products=useSelector(state=>state.products);
    useEffect(()=>{
        const fuelQuery=new URLSearchParams(window.location.search).get('fuel')
        if(fuelQuery && fuelQuery.includes(value)) ref.current.checked=true
        else ref.current.checked=false
    })
    const handleClick = (e) => {
        updateUrl(e);
        const params=decodeURIComponent(window.location.search);
        dispatch(fetchProducts('https://stg.carwale.com/api/stocks'+params))
    }
    return (
        <label style={styles}>
            <input type='checkbox' onClick={handleClick} value={value} ref={ref}/>
            {type}
        </label>
    )
}

export default FuelCheckBox