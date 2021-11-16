<template>
  <div class="page">
    <div class="back-button" v-if="tableAvailable" @click="this.$router.push({name:'Menu'})"><i class="material-icons">arrow_back</i></div>

    <form @submit="submit">
      <div class="input-field">
        <input id="table_nr" type="number" v-model="input">
        <label for="table_nr" class="active">Tafelnr</label>
      </div>

      <div class="button primary-bg" @click="submit">Naar de kaart!</div>

    </form>

  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
  text-align: center;
}
</style>

<script>
import {mapMutations, mapGetters} from "vuex";
import Materialize from "materialize-css";
import Gateway from "@/gateway";

export default {
  name: 'SelectTable',
  props: {
    code: String
  },
  data() {
    return {
      scanCode: false,
      input: this.table
    }
  },
  computed: {
    ...mapGetters({
      table: "getTable",
      tableAvailable: "getTableAvailable"
    })
  },
  async mounted() {
    const table = this.$route.params.code;
    if (table !== undefined) {
      await this.setTableCode(table);
    }
  },
  methods: {
    ...mapMutations({
      setTable: "setTable",
      setIsOber: "setIsOber",
      setMenu: "setMenu",
      loading: "setLoading",
    }),
    async submit(e) {
      e.preventDefault();
      this.setTableCode(this.input);
    },
    setTableCode(description) {
      description = description.toLowerCase();
      this.loading(true);
      Gateway.Table.getByDescription(description)
          .then((response) => {
                if (response !== undefined) {
                  this.setTable(response);
                  return Gateway.Menu.getById(this.table.menuId).then(async (menu) => {
                    this.setIsOber(true);
                    this.setMenu(menu);
                    this.loading(false);
                    await this.$router.push({name: 'Menu'});
                  });
                }
                else{
                  Materialize.toast({html: "Sorry, die tafel vinden we niet terug...", classes: "toast-danger"});
                  this.loading(false);
                }
              }
          )
    },
  }
}
</script>