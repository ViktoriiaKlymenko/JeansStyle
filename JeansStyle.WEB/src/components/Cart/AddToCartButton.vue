<template>
  <button class="btn col-md-6 card-button" type="submit">
    <span class="card-button-inner bag-button w-100 d-block">Add to Bag</span>
  </button>
</template>

<script>
import {toastSuccess} from "@/main";
import {extractCart, storeCart} from "@/components/Cart/cart";

export default {
  name: "AddToCartButton",
  props: {
    productId: String,
    productSizeId: String,
  },
  data() {
    return {
      cart: [],
    }
  },
  methods: {
    addToCart() {
      this.cart = extractCart()

      let _this = this

      let product = this.cart.find(product => {
        return product.productId === _this.productId && product.productSizeId === _this.productSizeId
      })

      if (!product) {
        this.cart.push({
          productId: this.productId,
          productSizeId: this.productSizeId,
          quantity: 1
        })
      } else {
        product.quantity++
      }

      storeCart(this.cart)

      toastSuccess('Product added to cart!')
    },
  }
}
</script>

<style scoped lang="scss">
.bag-button {
  background: #E06C9F;
  color: white;
  transition: 0.3s ease-in-out;
}

.card-button:hover {
  .bag-button {
    background: #e299b9;
  }
}
</style>