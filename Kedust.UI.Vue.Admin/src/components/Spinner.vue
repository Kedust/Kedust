<template>
  <div class="loader-background" v-if="loading">
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
  </div>
</template>

<script>
import {mapGetters} from "vuex";

export default {
  name: 'Spinner',
  computed: {
    ...mapGetters({
      loading: "getLoading"
    })
  }
}
</script>
<style scoped>
.preloader-wrapper {
  position: absolute;
  top: 50%;
  right: 50%;
}

.loader-background {
  top: 0;
  left: 0;
  position: absolute;
  height: 100vh;
  width: 100vw;
  background-color: rgba(0, 0, 0, 0.25);
  z-index: 999;
}

.spinner-layer {
  border-color: #26a69a;
}
</style>