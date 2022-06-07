<template>
  <button class="btn col-md-6 card-button" @click="addToCart">
    <span class="card-button-inner bag-button w-100 d-block">Add to Bag</span>
  </button>
</template>

<script>
export default {
  name: "AddToCartButton",
  props: {
    productId: String,
    productSizeId: String,
  },
  data() {
    return {
      storagePath: 'cartProducts',
      cart: [],
    }
  },
  methods: {
    extractCart() {
      this.cart = JSON.parse(localStorage.getItem(this.storagePath)) ?? []
    },
    storeCart() {
      localStorage.setItem(this.storagePath, JSON.stringify(this.cart))
    },
    addToCart() {
      this.extractCart()

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

      this.storeCart()
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