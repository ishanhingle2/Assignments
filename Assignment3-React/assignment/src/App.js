import logo from './logo.svg';
import './App.css';
import Title from './components/Title';
import MainContainer from './components/MainContainer';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import setProducts from './redux/products/productActions';
import axios from 'axios';
import fetchProducts from './redux/products/productActions';

function App() {
  const dispatch=useDispatch();
  const products = useSelector(state=>state.products)
  useEffect(()=>{
      const urlParams=decodeURIComponent(window.location.search)
      dispatch(fetchProducts("https://stg.carwale.com/api/stocks"+urlParams))
  },[])
  return (
    <div className="App">
      <Title/>
      <MainContainer/>
    </div>
  );
}

export default App;
