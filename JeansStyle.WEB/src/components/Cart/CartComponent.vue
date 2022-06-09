<template>
  <div class="basket">
    <a href="/ShoppingCart/Index/">
      <i class="fa fa-shopping-cart" aria-hidden="true"></i>

      <span class="position-absolute text-white  top-0 start-100 translate-middle badge rounded-pill bg-accent">
        {{ cartItems }}
      </span>
    </a>
  </div>
</template>

<script>
import {extractCart} from "@/components/Cart/cart";
import {emitter} from "@/main";

export default {
  name: "CartComponent",
  data() {
    return {
      cart: [],
    }
  },
  created() {
    this.cart = extractCart()

    emitter.on('cartUpdated', cart => this.cart = cart)
  },
  computed: {
    cartItems() {
      let items = 0
      
      this.cart.forEach(value => {
        items += value.quantity
      })
      
      return items
    }
  }
}
</script>

<style scoped>

</style>