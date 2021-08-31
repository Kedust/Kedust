<template>
  <div class="page">
    <img src="/img/kedust-full-white.svg" class="logo"/>

    <router-link class="menu-item z-depth-1-half" :to="{name: 'Menu'}" tag="div" >res</router-link>


    <!--    <div>{{id}}</div>-->

<!--    <div>{{name}}</div>-->



    </div>
</template>

<script>

export default {
  name: 'MenuItemDetails',
  props: {
    item: {
      id: Number,
      name: String,
      price: Number,
      description: String
    }
  }
}

</script>

<style scoped>
.page{
  height: 100vh;
   background-color: #f0750f;
 }

.logo{
  display: block;
  margin: 1rem auto 1rem auto;
  max-width: 50vw;
  max-height: 12vh;
}

.button{
  cursor: default;
}

</style>
