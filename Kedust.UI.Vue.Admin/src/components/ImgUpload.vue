<template>
  <div class="container mt-10">
    <h1>{{test}}</h1>
    <div class="card kedust-green">
      <img style="" :src="this.image" alt="">
      <input @change="handleImage" class="custom-input" type="file" accept="image/*">
    </div>
  </div>
</template>

<script>
export default {
  name:"ImgBase64Upload",
  data(){
    return{
      test: "hoi",
      image:undefined
    }
  },
  methods:{
    handleImage(e){
      const selectImage = e.target.files[0];
      this.createBase64Image(selectImage);
    },
    createBase64Image(fileObject){
      let reader = new FileReader();
      reader.readAsDataURL(fileObject);
      reader.onload = function () {
        this.image = reader.result;
      }.bind(this);
    }
  }
}
</script>