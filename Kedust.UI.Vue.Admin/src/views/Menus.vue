<template>

  <div class="container">
    <div class="section">

      <div class="waves-effect btn" @click="this.$router.push({name: 'MenuNew'})">
        <i  class="material-icons left">add</i> Nieuw
      </div>


      <table class="striped responsive-table">
        <thead>
        <tr>
          <th>Menunaam</th>
          <th></th>
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

    </div>
    <br><br>
  </div>

</template>

<script>
import Gateways from "@/gateway";

export default {
  name: "Menus",
  data() {
    return {
      menus: []
    }
  },
  async mounted() {
    Gateways.Menu.getAll().then((data) => this.menus = data);
  },
  methods: {
    Delete(item) {
      Gateways.Menu.delete(item.id).then(() => Gateways.Menu.getAll().then((data) => this.menus = data));
    }
  }
}
</script>

<style scoped>
.btn {
  margin-right: 1rem;
}
</style>