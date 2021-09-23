<template>
  <div class="page">
    <div class="row">
      <TableButton/>
      <ChoiceButton v-for="item in menu" :key="item.id" :item="item"/>
    </div>
    <ShoppingCartButton v-if="itemCount>0"/>
  </div>
</template>

<style scoped>
.page{
  margin: 1rem 1rem 5.25rem 1rem;
}
</style>

<script>

import {mapGetters} from "vuex"
import ChoiceButton from "@/components/ChoiceButton";
import ShoppingCartButton from "@/components/ShoppingCartButton";
import TableButton from "@/components/TableButton";


export default {
  name: 'Menu',
  computed:{
    ...mapGetters({
      menu : "getMenu",
      itemCount: "getOrderCount",
      table: "getTable"
    })
  },
  mounted() {
    if(this.table === undefined){
      this.$router.push({name: "Table"});
    }
  },
  components: {ChoiceButton, ShoppingCartButton, TableButton}
}
</script>

