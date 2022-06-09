<template>
  <select required name="productSizeId" v-model="selectedProductSizeId" class="form-control">
    <option disabled value="">Select size</option>
    <option :value="productSize.id" v-for="productSize in productSizes">
      {{ productSize.name }}
    </option>
  </select>
</template>

<script>
export default {
  name: "SizeSelector",
  props: {
    productSizes: Array,
    value: String,
  },
  data() {
    return {
      selectedProductSizeId: null,
    }
  },
  mounted() {
    this.selectedProductSizeId = this.value
  },
  watch: {
    selectedProductSizeId() {
      this.$emit('input', this.selectedProductSizeId)
    }
  }
}
</script>

<style scoped>

</style>