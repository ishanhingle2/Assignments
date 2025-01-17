import { fireEvent, render,screen } from "@testing-library/react"
import FuelCheckBox from "../components/FuelCheckBox"
import { useDispatch } from "react-redux"
import { Checkbox } from "@mui/material"

jest.mock('react-redux')
beforeEach(()=>{
     const dispatch_function=(url)=>{}
     useDispatch.mockReturnValue(dispatch_function)
})
describe('FuelCheckBox Testing',()=>{
    it('Inital Testing to check working using fireEvent',()=>{
        render(<FuelCheckBox/>)
        const checkbox=screen.queryByRole('checkbox')
        fireEvent.click(checkbox)
        expect(checkbox.checked).toBeTruthy();
    })

    // To check weather url is updating, when checked box is clicked 
    it('Url Update on Checking',()=>{
        render(<FuelCheckBox value={1}/>)
        const checkbox=screen.queryByRole('checkbox')
        fireEvent.click(checkbox)
        expect(decodeURIComponent(window.location.search)).toContain('1')
    })
})

it("fuel checkbox snapshot",()=>{
    const {component}=render(<Checkbox/>)
    expect(component).toMatchSnapshot()
})