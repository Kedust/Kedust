<template>
  <div class="page">
    <h1>{{name}}</h1>
<!--    <h1>Menuitem : {{name}}</h1>-->
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

<style>
</style>
