import { useDispatch, useSelector } from "react-redux"
import { products,sortedProducts } from "./mockProducts"
import { sortAscending } from "../components/SortBy"
jest.mock('react-redux')

test('Sort Function Test',()=>{
    expect(products.sort(sortAscending)).toEqual(sortedProducts)
})




