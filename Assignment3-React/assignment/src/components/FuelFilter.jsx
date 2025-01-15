import React, { Component, useState } from 'react'
import FuelCheckBox from './FuelCheckBox'
import FilterIcon from './FilterIcon'
import { useDispatch } from 'react-redux'
import fetchProducts from '../redux/products/productActions'

const fuelTypes = ['Petrol', 'Diesel', 'CNG', 'LPG', 'Electric', 'Hybrid']
const styles = {
    backgroundColor: '#f3f3f4',
    display: 'flex',
    flexDirection: 'column',
    margin: '5%'
}

function FuelFilter() {
    return (
        <div style={styles}>
            {
                fuelTypes.map((type, index) => <FuelCheckBox value={index + 1} type={type}/>)
            }
        </div>
    )
}

export default FuelFilter