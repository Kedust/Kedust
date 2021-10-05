<template>
  <div>
    <Nav/>
    <div class="container">
      <router-view/>
    </div>
    <Spinner/>
  </div>
</template>

<style>
.back-button {
  position: absolute;
  top: 1rem;
  left: 1rem;
  padding: 0.5rem;
  max-height: 12vh;
  text-align: center;
  display: block;
}
</style>

<script>
import Nav from "@/components/Nav";
import Spinner from "@/components/Spinner";

export default {
  components: {Spinner, Nav}
}
</script>