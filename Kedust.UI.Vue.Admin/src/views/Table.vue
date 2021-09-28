<template>

  <div class="input-field">
    <input id="code" type="text" v-model="table.code">
    <label for="code">Code</label>
  </div>

  <div class="input-field">
    <input id="description" type="text" v-model="table.description">
    <label for="description">Description</label>
  </div>

  <select v-if="table.menu" class="browser-default" v-model="table.menu.id">
    <option v-for="menu in menus" :key="menu.id" :value="menu.id">{{ menu.name }}</option>
  </select>
</template>

<script>
import Gateway from "@/gateway";
import M from "materialize-css";

export default {
  name: "Table",
  mounted() {
    this.updateMenus();
    this.updateTable(this.$route.params.id);

    M.updateTextFields();

  },
  data() {
    return {
      menus: [],
      table: {},
      originalTable: {}
    };
  },
  methods: {
    updateMenus() {
      Gateway.Menu.getAll().then((data => this.menus = data));
    },
    updateTable(id) {
      if (id !== undefined) {
        Gateway.Table.get(id).then(value => {
          this.table = value;
          this.originalTable = {...this.table};
        });
      } else {
        this.table = {};
        this.originalTable = {};
      }
    },
    save() {
      Gateway.Table.put(this.table)
          .then((data) => {
            this.updateMenu(data);
          });

    }
  }
}
</script>

<style scoped>

</style>