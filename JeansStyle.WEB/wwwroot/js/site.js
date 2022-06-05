// const { createApp } = Vue
//
// import CartComponent from "./components/CartComponent.vue";

// createApp({
//     data() {
//         return {
//             message: 'data'
//         }
//     },
//     components: {
//       CartComponent  
//     },
// }).mount('#app')

import CartComponent from "./components/CartComponent";

Vue.component('cart-component', CartComponent)

let app = new Vue({
    el: '#app',
    data() {
        return {
            data: 'asd'
        }
    }
})

function addToCookies(id, productSizeId = null) {
    let cart = JSON.parse(localStorage.getItem('cartProducts'))

    if (!cart) {
        cart = []
    }

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
