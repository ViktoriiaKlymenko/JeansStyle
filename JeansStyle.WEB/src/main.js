// Dependencies
import {createApp} from 'vue'

// Components
import CartComponent from "@/components/Cart/CartComponent";
import AddToCartButton from "@/components/Cart/AddToCartButton";

createApp({
    components: {
        CartComponent,
        AddToCartButton,
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