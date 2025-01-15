const initalState=[]
const productReducer = (state = initalState, action) => {
    switch (action.type) {
        case 'SET_PRODUCTS':    
        return [...action.payload]
        default:
            return state
    }
}
export default productReducer