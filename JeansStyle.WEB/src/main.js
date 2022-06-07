// Dependencies
import {createApp} from 'vue'

// Components
import CartComponent from "@/components/Cart/CartComponent";
import AddToCartButton from "@/components/Cart/AddToCartButton";
import ProductCard from "@/components/Catalog/ProductCard";

createApp({
    components: {
        CartComponent,
        AddToCartButton,
        ProductCard
    },
}).mount('#app')

function addToCart(id, productSizeId = null) {
    let productInCart = cart.find(product => {
        return product.id === id && product.productSizeId === productSizeId
    })

    if (productInCart) {
        productInCart.quantity++
    } else {
        cart.push({
            productId: id,
            productSizeId: productSizeId,
            quantity: 1,
        })
    }

    localStorage.setItem('cartProducts', JSON.stringify(cart))
}