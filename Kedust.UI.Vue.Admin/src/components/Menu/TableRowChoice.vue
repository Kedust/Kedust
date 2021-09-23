<template>

  <tr>
    <td><ImgBase64Upload :image="item.image"/></td>
    <td>{{item.name}}</td>
    <td>{{item.description}}</td>
    <td>{{item.price}}</td>
  </tr>
</template>

<script>
import ImgBase64Upload from "@/components/ImgUpload";
export default {
  name: "TableRowChoice",
  components: {ImgBase64Upload},
  props:{
    item: {
      image: String,
      name: String,
      description: String,
      price: Number
    }
  }
}
</script>

<style scoped>

</style>