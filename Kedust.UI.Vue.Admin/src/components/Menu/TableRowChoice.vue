<template>
  <tr>
    <td>
      <ImgUpload v-model:image="item.image"/>
    </td>
    <td><input type="text" v-model="item.name"/></td>
    <td><input type="text" v-model="item.description"/></td>
    <td><input type="number" v-model="item.price"/></td>
  </tr>
</template>

<script>
import ImgUpload from "@/components/ImgUpload";

export default {
  name: "TableRowChoice",
  props: {
    item_prop: {
      image: String,
      name: String,
      description: String,
      price: Number
    }
  },
  mounted() {
    console.log(this.item_prop)
    console.log(this.item);
  },
  data(){
    return{
      item: this.item_prop
    }
  },
  components:{
    ImgUpload
  }
}
</script>

<style scoped>

</style>