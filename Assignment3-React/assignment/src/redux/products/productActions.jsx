import axios from "axios";

export function setProducts(products) {
  return {
    type: 'SET_PRODUCTS',
    payload: products,
  };
}

const fetchProducts=(url)=>{
  return (dispatch,getState)=>{
    const oldState=getState();
    axios(url)
    .then(res=>{
      dispatch(setProducts(res.data.stocks))
    })
    .catch(err=>{
      console.log(err);
      dispatch({type:'SET_PRODUCT',oldState})
    })
  }
}
export default fetchProducts;
