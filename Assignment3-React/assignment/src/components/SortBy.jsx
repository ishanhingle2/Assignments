import React from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { setProducts } from '../redux/products/productActions';
const styles={
    positon:'absolute',
    marginLeft:'70%',
    width:'35%'
}
const selectStyle={
    boxSizing:'content-box',
    padding:'5px',
    marginLeft:'2%'
}
const sortAscending=(a,b)=>{
    const priceA=parseFloat(a.price.split(' ')[0])
    const priceB=parseFloat(b.price.split(' ')[0])
    if(priceA<priceB) return -1;
    else if (priceA>priceB) return 1;
    else return 0;
}
function SortBy() {
    const products=useSelector(state=>state.products);
    const dispatch=useDispatch();
    const handleChange=(e)=>{
        const order=e.target.value;
        products.sort(sortAscending);
        if(order=='desc') products.reverse();
        dispatch(setProducts(products));
    }
  return (
    <div style={styles}>
    <span>Sort By :</span>
    <select style={selectStyle} name='order' onChange={handleChange}>
        <option  disabled selected>Default</option>
        <option value='asc'>Price: Low to High</option>
        <option value='desc'>Price: High to Low</option>
    </select>
    </div>
  )
}

export default SortBy