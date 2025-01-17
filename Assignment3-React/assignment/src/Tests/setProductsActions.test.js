import { setProducts } from "../redux/products/productActions";
import { products } from "./mockProducts";

const expectedValue={
    type:'SET_PRODUCTS',
    payload:products,
}

test('Testing set Products',()=>{
    expect(setProducts(products)).toStrictEqual(expectedValue);
})