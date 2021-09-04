<template>
  <div class="preloader-wrapper big active">
    <div class="spinner-layer">
      <div class="circle-clipper left">
        <div class="circle"></div>
      </div>
      <div class="gap-patch">
        <div class="circle"></div>
      </div>
      <div class="circle-clipper right">
        <div class="circle"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Spinner'
}
</script>
<style scoped>
.preloader-wrapper {
  display: block;
  margin: 0 auto 0 auto;
}

.spinner-layer {
  border-color: #f0750f;
}
</style>