import { render } from "@testing-library/react"
import FilterIcon from "../components/FilterIcon"
it('snapshot testing',()=>{
    const {component}=render(<FilterIcon/>)
    expect(component).toMatchSnapshot();
})