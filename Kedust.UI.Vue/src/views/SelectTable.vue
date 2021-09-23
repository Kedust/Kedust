<template>
  <div class="page">
    <div class="back-button" v-if="tableAvailable" @click="goToMenu"><i class="material-icons">arrow_back</i></div>

    <form @submit="setTableCode">
      <div class="input-field">
        <input id="table_code" type="text" v-model="input">
        <label for="table_code" class="active">Tafelcode</label>
      </div>

      <div class="button primary-bg" @click="setTableCode">Naar de kaart!</div>

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
import {mapMutations, mapActions, mapGetters} from "vuex";
import Materialize from "materialize-css";
import Gateway from "@/gateway";

export default {
  name: 'SelectTable',
  props: {
    code: String
  },
  data() {
    return {
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
      this.checkTable(this.input).then(async (result) => {
        if (result) {
          this.setTable(table);
          await this.updateMenu();
          await this.$router.push({name: 'Menu'});
        } else {
          Materialize.toast({
            html: "Sorry, die tafel vinden we niet terug...</br>Geef de code hierboven in alstublieft",
            classes: "toast-danger"
          });
          this.loading(false);
        }
      });


    }

    if (this.table !== undefined) {
      this.input = this.table;
    }
  },
  methods: {
    ...mapMutations({
      setTable: "setTable",
      setMenu: "setMenu",
      loading: "setLoading"
    }),
    ...mapActions({
      checkTable: "checkTable",
      updateMenu: "updateMenu"
    }),
    async goToMenu() {
      await this.$router.push({name: "Menu"})
    },
    async setTableCode(e) {
      e.preventDefault();
      this.loading(true);
      Gateway.Table.checkCode(this.input)
          .then((response) => {
                if (response.success) {
                  this.setTable(this.input);
                  return Gateway.Choice.getByTableCode(this.input).then(async (choicesResult) => {
                    this.setMenu(choicesResult)
                    this.loading(false);
                    await this.$router.push({name: 'Menu'});
                  });
                } else {
                  Materialize.toast({html: "Sorry, die tafel vinden we niet terug...", classes: "toast-danger"});
                  this.loading(false);
                }
              }
          );
    }
  }
}
</script>