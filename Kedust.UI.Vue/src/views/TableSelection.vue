<template>
  <div class="page">
    <div class="input-field">
      <input id="table_code" type="text" v-model="input">
      <label for="table_code">Tafelcode</label>
    </div>
    <div class="button primary-bg" @click="SetTableCode">Naar de kaart!</div>

  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
  text-align: center;
}
</style>

<script>
import {mapMutations, mapActions} from "vuex";

export default {
  name: 'TableSelection',
  props: {
    code: String
  },
  data() {return {
    input: ""
  }},
  mounted() {
    const table = this.$route.params.code;
    if (table !== undefined) {
      this.setTable(table);
      this.updateMenu();
      this.$router.push({name: 'Menu'});
    }
  },
  methods: {
    ...mapMutations({
      setTable: "setTable",
      loading: "setLoading"
    }),
    ...mapActions({
      updateMenu: "fetchMenu"
    }),

    async SetTableCode() {
      this.loading(true);
      //CheckTable
      this.setTable(this.input);
      await this.updateMenu();
      this.loading(false);
      await this.$router.push({name: 'Menu'});
    }
  }
}


</script>