$(document).ready(function () {

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