<template>
  <div class="page">
    <div class="back-button" @click="goToMenu"><i class="material-icons">arrow_back</i></div>
    <div v-if="itemCount === 0">Er zit nog niets in je winkelmandje.</div>
    <div class="row">
      <ShoppingCartChoice v-for="item in menu" :key="item.id" :item="item"/>
    </div>

    <div v-if="itemCount>0" class="button primary-bg" @click="Send">Verzenden ({{ itemCount }} stuks voor {{ price }} vakjes)</div>
  </div>
</template>

<style scoped>

.page {
  margin: 1rem;
}

</style>

<script>

import {mapGetters, mapMutations} from "vuex"
import ShoppingCartChoice from "@/components/ShoppingCartChoice";
import Gateway from "@/gateway";
import Materialize from "materialize-css";

export default {
  name: 'ShoppingCart',
  mounted() {
    if(this.table === undefined){
      this.$router.push({name: "Table"});
    }
  },
  components: {
    ShoppingCartChoice
  },
  props: {
    items: [
      {
        id: Number,
        name: String,
        description: String,
        category: String,
        price: Number,
        count: Number
      }
    ]
  },
  computed: {
    ...mapGetters({
      menu: "getOrderItems",
      itemCount: "getOrderCount",
      price: "getOrderPrice",
      table: "getTable",
      canOrder: "getCanOrder"
    })
  },
  methods: {
    ...mapMutations({
      setMenu: "setMenu",
      loading: "setLoading"
    }),
    async goToMenu() {
      await this.$router.push({name: 'Menu'});
    },
    async Send() {
      this.loading(true);


      let body = {
        orderItems: this.menu.map(mi => ({choiceId: mi.id, amount: mi.count})),
        tableId: this.table.id
      };

      Gateway.Order.post(body).then(async (result) => {
            if (result) {
              Gateway.Menu.getById(this.table.menuId).then((menu) => {
                this.setMenu(menu);
                this.loading(false)
                this.$router.push({name: 'ThankYou'});
              });
            } else {
              this.loading(false);
              Materialize.toast({
                html: "er is iets fout gegaan, probeer later opnieuw alstublieft",
                classes: "toast-danger"
              });
            }
          }
      );
    }
  }
}
</script>

