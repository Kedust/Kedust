<template>
  <div>
    <Nav/>
    <div class="container">
      <router-view/>
    </div>
  </div>
</template>

<script>
import M from "materialize-css";
import Nav from "@/components/Nav";

export default {
  components: {Nav},
  mounted() {
    M.AutoInit()
  }
}
</script>