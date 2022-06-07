<template>
  <div class="img-zoom" ref="zoomContainer">
    <img :src="image" alt="">
  </div>
</template>

<script>
import ImgZoom from "js-image-zoom"

export default {
  name: "ImageZoom",
  props: {
    image: String,
  },
  data() {
    return {
      width: this.$attrs.width ?? null,
    }
  },
  mounted() {
    if(this.width === null) {
      this.width = this.$refs.zoomContainer.clientWidth
    }
    
    new ImgZoom(this.$refs.zoomContainer, this.$data);
  }
}
</script>

<style scoped>

</style>