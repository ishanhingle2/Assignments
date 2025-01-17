import Product from "../components/Product"

const product={
    carName:'Skoda',
    price:'23 lakh',
    priceNumeric:34,
    km:'23',
    fuel:'diesel',
    imageUrl:'',
    cityName:'indore'
}
it('Product card snapshot test',()=>{
    const {component}=<Product product={product}/>
    expect(component).toMatchSnapshot();
})