<template>
  <h1>Menu's</h1>
  <table class="striped responsive-table">
    <thead>
    <tr>
      <th>Menunaam</th>
      <th><span class="waves-effect btn right" @click="this.$router.push({name: 'MenuNew'})"><i
          class="material-icons">add</i></span></th>
    </tr>
    </thead>
    <tbody>
    <tr v-for='item in menus' :key='item.id'>
      <td>{{ item.name }}</td>
      <td class="right-align">
        <div class="waves-effect btn" @click="this.$router.push({name: 'MenuEdit', params:{id: item.id}})"><i
            class="material-icons">edit</i></div>
        <div class="waves-effect btn red" @click="Delete(item)"><i class="material-icons">delete</i></div>
      </td>
    </tr>
    </tbody>
  </table>
</template>

<script>
import Gateways from "@/gateway";
import {mapMutations} from "vuex";

export default {
  name: "Menus",
  data() {
    return {
      menus: []
    }
  },
  async mounted() {
    this.setLoading(true);
    Gateways.Menu.getAll().then((data) => {
      this.menus = data;
      this.setLoading(false);
    });
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading"
    }),
    Delete(item) {
      this.setLoading(true);
      Gateways.Menu.delete(item.id).then(() => Gateways.Menu.getAll().then((data) => {
        this.menus = data
        this.setLoading(false);
      }));
    }
  }
}
</script>

<style scoped>
.btn {
  margin-left: 1rem;
}
</style>