<template>
  <select name="product_size" v-model="selectedProductSize" class="form-control">
    <option value="">Select size</option>
    <option :value="productSize.size.id" v-for="productSize in productSizes?.productSizes">
      {{productSize.size.name}}
    </option>
  </select>
</template>

<script>
import {ProductSizes} from "@/Classes/ProductSizes";

export default {
  name: "SizeSelector",
  props: {
    productSizes: ProductSizes,
  },
  data() {
    return {
      selectedProductSize: ""
    }
  }
}
</script>

<style scoped>

</style>