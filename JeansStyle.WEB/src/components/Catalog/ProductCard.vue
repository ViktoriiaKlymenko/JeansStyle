<template>
  <div class="row product-card">
    <div class="col-md-3">
      <div class="dress-card">
        <div class="dress-card-head">
          <img class="dress-card-img-top" :src="product.image" alt="">
        </div>
        <div class="dress-card-body">
          <h4 class="dress-card-title">{{ product.title }}</h4>
          <small class="dress-card-para-small"><i>Made with love</i></small>
          <p class="dress-card-para">
            <span class="dress-card-price">{{ product.price }} &#36;</span><span
              class="dress-card-crossed"></span><span class="dress-card-off"></span>
          </p>
        </div>
      </div>
    </div>

    <div class="col-md-9">
      <p>
        <b>Gender:</b> {{product.gender.name}}
      </p>
      <p>
        <b>Category:</b> @product.Category.Name
      </p>
      <div class="row g-2 align-items-center">
        <div class="col-auto">
          <label>
            <b>Size:</b>
          </label>
        </div>
        <div class="col-12 col-sm-6 col-md-4 col-lg-3">
          <!--          @Html.DropDownListFor(model => model.Id, (IEnumerable<SelectListItem>)ViewBag.Sizes, new-->
          <!--          {-->
          <!--          @class = "form-control"-->
          <!--          })-->
        </div>
      </div>

      <div class="description">
        <p>Description: @product.Description</p>
      </div>

      <div class="row">
        <add-to-cart-button product-id="@product.Id"></add-to-cart-button>
      </div>
    </div>
  </div>
</template>

<script>
import {Product} from "@/components/Catalog/Product";

export default {
  name: "ProductCard",
  props: {
    product: Product
  },
}
</script>

<style scoped lang="scss">
.dress-card-img-top {
  width: 100%;
  border-radius: 7px 7px 0 0;
}

.dress-card:hover {
  .dress-card-para-small {
    color: #E06C9F;
    font-size: 15px;
  }
}
</style>