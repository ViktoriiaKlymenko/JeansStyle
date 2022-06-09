import {emitter} from "@/main";

let cartStoragePath = 'cartProducts'

export function extractCart() {
    return JSON.parse(localStorage.getItem(cartStoragePath)) ?? []
}

export function storeCart(cart) {
    localStorage.setItem(cartStoragePath, JSON.stringify(cart))

    emitter.emit('cartUpdated', cart)
}