<template>
  <div class="row mb-5 product-card">
    <div class="col-12 col-md-4 col-lg-3">
      <div class="dress-card">
        <div class="dress-card-head col-8 col-md-12 offset-2 offset-md-0">
          <img class="dress-card-img-top" :src="product.image" alt="">
        </div>
        <div class="dress-card-body col-8 col-md-12 offset-2 offset-md-0">
          <h4 class="dress-card-title">{{ product.title }}</h4>
          <small class="dress-card-para-small"><i>Made with love</i></small>
          <p class="dress-card-para">
            <span class="dress-card-price">{{ product.price }} &#36;</span><span
              class="dress-card-crossed"></span><span class="dress-card-off"></span>
          </p>
        </div>
      </div>
    </div>

    <div class="col-12 col-md-8 col-lg-9">
      <p>
        <b>Gender:</b> {{ product.gender?.name }}
      </p>
      <p>
        <b>Category:</b> {{ product.category?.name }}
      </p>
      <div class="row g-2 align-items-center">
        <div class="col-auto d-none d-md-block">
          <label>
            <b>Size:</b>
          </label>
        </div>
        <div class="col-12 col-md-4 col-lg-3">
          <size-selector :product-sizes="product.productSizes"></size-selector>
        </div>
      </div>

      <div class="description mt-3 pt-2 border-top">
        <p><b>Description:</b> {{product.description}}</p>
      </div>

      <div class="row">
        <add-to-cart-button product-id="@product.Id"></add-to-cart-button>
      </div>
    </div>
  </div>
</template>

<script>
import AddToCartButton from "@/components/Cart/AddToCartButton";
import SizeSelector from "@/components/regular/SizeSelector";
import {Product} from "@/Classes/Product";
import ImageZoom from "@/components/regular/ImageZoom";

export default {
  name: "ProductCard",
  components: {
    ImageZoom,
    SizeSelector,
    AddToCartButton,
  },
  props: {
    product: Product
  },
}
</script>

<style scoped lang="scss">
.dress-card-img-top {
  width: 100%;
  border-radius: 7px;
}

.dress-card-para-small {
  font-size: 14px;
  transition: 0.3s ease-in-out;
}

.dress-card:hover {
  .dress-card-para-small {
    color: #E06C9F;
    font-size: 15px;
  }
}

@media screen and (min-width: 768px){
  .dress-card-img-top {
    border-radius: 7px 7px 0 0;
  }
}
</style>