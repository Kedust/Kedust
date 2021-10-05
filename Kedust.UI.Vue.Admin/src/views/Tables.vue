<template>

  <div class="section">

    <h1>Tafels</h1>

    <table class="striped responsive-table">
      <thead>
      <tr>
        <th>Tafelcode</th>
        <th>Beschrijving</th>
        <th>Menu</th>
        <th><span class="waves-effect btn right" @click="this.$router.push({name: 'TableNew'})"><i
            class="material-icons">add</i></span></th>
      </tr>
      </thead>

      <tbody>

      <tr v-for="table in tables" :key="table.id">
        <td>{{ table.code }}</td>
        <td>{{ table.description }}</td>
        <td>{{ this.menuById(table.menuId) }}</td>
        <td class="right-align">
          <div class="waves-effect btn" @click="this.$router.push({name: 'TableEdit', params:{id: table.id}})"><i
              class="material-icons">edit</i></div>
          <div class="waves-effect btn red" @click="this.delete(table)"><i class="material-icons">delete</i></div>
        </td>
      </tr>
      </tbody>
    </table>

  </div>

</template>

<script>

import Gateways from "@/gateway"
import {mapMutations} from "vuex";

export default {
  name: "Tables",
  data() {
    return {
      tables: [],
      menus: []
    }
  },
  mounted() {
    this.updateTables();
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading"
    }),
    menuById(id){
      return this.menus.find(m => m.id === id).name
    },
    updateTables() {
      this.setLoading(true);
      Gateways.Menu.getAll().then((m) => {
        this.menus = m;
        Gateways.Table.getAll().then((data) => {
              this.tables = data;
              this.setLoading(false);
            }
        );

      });
    },
    delete(item) {

      this.setLoading(true);
      Gateways.Table.delete(item.id).then(d => {
        if (d)
          this.$router.push({name: "Tables"});
        this.setLoading(false);
      })
    }
  }
}
</script>

<style scoped>
.btn {
  margin-left: 1rem;
}
</style>