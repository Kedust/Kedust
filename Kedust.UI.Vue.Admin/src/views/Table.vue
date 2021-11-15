<template>
  <button class="btn waves-effect right" @click="save"
          :class="{disabled: JSON.stringify(table)===JSON.stringify(originalTable)}"><i
      class="material-icons left">save</i>Opslaan
  </button>
  <h1>
    <i class="material-icons" @click="goToOverview">arrow_back</i>
    Tafel
  </h1>
  <section>
    <div class="input-field">
      <input id="code" type="text" v-model="table.code">
      <label for="code" class="active">Code</label>
    </div>

    <div class="input-field">
      <input id="description" type="text" v-model="table.description">
      <label for="description" class="active">Description</label>
    </div>

    <div class="input-field">
      <select id="menu" class="browser-default" v-model="table.menuId">
        <option v-for="menu in menus" :key="menu.id" :value="menu.id">{{ menu.name }}</option>
      </select>
      <label for="menu" class="active">Menu</label>
    </div>

  </section>
</template>

<script>
import Gateway from "@/gateway";

export default {
  name: "Table",
  mounted() {
    this.updateMenus();
    this.updateTable(this.$route.params.id);
  },
  data() {
    return {
      menus: [],
      table: {
        code:"",
        description:"",
        menuId:0
      },
      originalTable: {menuId:0}
    };
  },
  methods: {
    goToOverview() {
      this.$router.push({name: 'Tables'})
    },
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
      Gateway.Table.save(this.table)
          .then((data) => {
            this.updateTable(data);
          });

    }
  }
}
</script>

<style scoped>

</style>