import { render, screen } from '@testing-library/react';
import { useSelector } from 'react-redux'
import Title from '../components/Title';
jest.mock('react-redux')

beforeEach(()=>{
    useSelector.mockReturnValue("32");
})

test('snapshot testing with mocking useSelector',()=>{
    const {container}=render(<Title/>);
    expect(container).toMatchSnapshot();
})

test('text checking',()=>{
    render(<Title/>)
    const text=screen.queryByTestId('title1').innerHTML;
    expect(text).toBe('32 Used Cars in India')
})
