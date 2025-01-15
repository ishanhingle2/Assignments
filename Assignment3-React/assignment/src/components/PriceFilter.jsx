import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux';
import fetchProducts from '../redux/products/productActions';
import { Slider } from '@mui/material';
const styles = {
    margin: '5%',
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
    fontSize: '20px'
}
const inputStyles = {
    padding: '5%',
    width: '30%'
}
function PriceFilter() {
    const [range, setRange] = useState([0, 21]);
    const dispatch = useDispatch();
    useEffect(() => {
        let budgetQuery = new URLSearchParams(window.location.search).get('budget')
        if (budgetQuery) {
            budgetQuery = budgetQuery.split('-');
            setRange([budgetQuery[0], budgetQuery[1]]);
        }
    }, [])
    const handleMinChange = (e) => {
        setRange([e.target.value, range[1]]);
    }
    const handleMaxChange = (e) => {
        setRange([range[0], e.target.value]);
    }
    const handleChange = (event, newValue) => {
        setRange(newValue);
        handleLostFocus();
    };
    const handleLostFocus = () => {
        const url = new URL(window.location.href)
        const searchParams = new URLSearchParams(url.search);
        const searchString = `${range[0]}-${range[1]}`
        url.searchParams.set('budget', searchString);
        window.history.pushState(null, null, url)
        const newParams = decodeURIComponent(window.location.search)
        dispatch(fetchProducts('https://stg.carwale.com/api/stocks' + newParams))
    }
    return (
        <div>
            <div style={styles}>
                <input style={inputStyles} type='number' min="0" max={range[1]} onChange={handleMinChange} value={range[0]} onBlur={handleLostFocus} />
                -
                <input style={inputStyles} type='number' min={range[0]} max="21" onChange={handleMaxChange} value={range[1]} onBlur={handleLostFocus} />
            </div>
            <Slider
                style={{margin:'6%',width:'85%'}}
                getAriaLabel={() => 'Temperature range'}
                value={range}
                onChange={handleChange}
                valueLabelDisplay="auto"
                min={1}
                max={21}
            />
        </div>
    )
}

export default PriceFilter