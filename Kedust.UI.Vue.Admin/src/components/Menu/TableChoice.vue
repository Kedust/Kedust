<template>
  <table>
    <thead>
    <tr>
      <th>Afbeelding</th>
      <th>Naam</th>
      <th>Omschrijving</th>
      <th>Prijs</th>
    </tr>
    </thead>

    <tbody>
    <tr v-for="item in items" :key="item.id" :item="item">
      <td>
        <ImgUpload v-model:image="item.image"/>
      </td>
      <td><input type="text" v-model="item.name"/></td>
      <td><input type="text" v-model="item.description"/></td>
      <td><input type="number" v-model="item.price"/></td>
    </tr>

    </tbody>
  </table>
</template>

<script>

import ImgUpload from "@/components/ImgUpload";
export default {
  name: "TableChoice",
  components: {ImgUpload},
  props:{
    items:Array
  },
  methods:{
  }
}
</script>

<style scoped>

</style>