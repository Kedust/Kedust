<template>

  <div class="section">


    <table class="striped responsive-table">
      <thead>
      <tr>
        <th>Tafelcode</th>
        <th>Beschrijving</th>
        <th>Menu</th>
        <th></th>
      </tr>
      </thead>

      <tbody>

      <tr v-for="table in tables" :key="table.id">
        <td>{{ table.code }}</td>
        <td>{{ table.description }}</td>
        <td>{{ table.menu.name }}</td>
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

export default {
  name: "Tables",
  data() {
    return {
      tables: [],
    }
  },
  mounted() {
    this.updateTables();
  },
  methods: {
    updateTables() {
      Gateways.Table.getAll().then((data) =>
          this.tables = data
      )
    },
    delete(item) {
      Gateways.Table.delete(item.id).then(d => {
        if (d)
          this.$router.push({name: "Tables"})
      })
    }
  }
}
</script>

<style scoped>
.btn {
  margin-right: 1rem;
}
</style>