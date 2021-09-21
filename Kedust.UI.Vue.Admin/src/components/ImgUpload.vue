<template>
  <input ref="upload" @change="handleImage" class="hidden" type="file" accept="image/*">
  <img @click="promptNewImage" class="img" :src="this.image" alt="">
</template>

<script>
export default {
  name: "ImgBase64Upload",
  props:{
    className: String
  },
  data() {
    return {
      image: require("@/assets/no_image.svg")
    }
  },
  methods: {
    handleImage(e) {
      const selectImage = e.target.files[0];
      this.createBase64Image(selectImage);
    },
    createBase64Image(fileObject) {
      let reader = new FileReader();
      reader.readAsDataURL(fileObject);
      reader.onload = function () {
        this.image = reader.result;
      }.bind(this);
    },
    promptNewImage(){
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