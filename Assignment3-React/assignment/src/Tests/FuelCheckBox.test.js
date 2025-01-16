import { fireEvent, render,screen } from "@testing-library/react"
import FuelCheckBox from "../components/FuelCheckBox"
import { useDispatch } from "react-redux"

jest.mock('react-redux')
beforeEach(()=>{
     const dispatch_function=(url)=>{console.log("dipatcher called")}
     useDispatch.mockReturnValue(dispatch_function)
})
describe('FuelCheckBox Testing',()=>{
    it('Inital Testing to check working using fireEvent',()=>{
        render(<FuelCheckBox/>)
        const checkbox=screen.queryByRole('checkbox')
        fireEvent.click(checkbox)
        expect(checkbox.toBeChecked();
    })

    // To check weather url is updating, when checked box is clicked 
    it('Url Update on Checking',()=>{

    })
})