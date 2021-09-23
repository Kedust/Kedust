<template>
  <input ref="upload" @change="handleImage" class="hidden" type="file" accept="image/*">
  <img @click="promptNewImage" class="img" :src="this.image ?? require('@/assets/no_image.svg')" alt="">
</template>

<script>
export default {
  name: "ImgUpload",
  props: {
    image: String
  },
  methods: {
    handleImage(e) {
      const selectImage = e.target.files[0];
      let reader = new FileReader();
      reader.readAsDataURL(selectImage);
      reader.onload = function () {
        this.$emit("update:image", reader.result);
      }.bind(this);
    },
    promptNewImage() {
      this.$refs["upload"].click();
    }
  }
}
</script>

<style scoped>
input.hidden {
  display: none;
}
</style>