<template>
  <div class="page">
    <div class="row" v-if="menu !== undefined">
      <TableButton/>
      <ChoiceButton v-for="item in menu.choices" :key="item.id" :item="item"/>
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
      table: "getTable",
      canOrder: "getCanPlaceOrder"
    })
  },
  async mounted() {
    if(!this.canOrder){
      await this.$router.push({name: "NotAvailable"})
    }
    if(this.table === undefined){
     await this.$router.push({name: "Table"});
    }
  },
  components: {ChoiceButton, ShoppingCartButton, TableButton}
}
</script>

