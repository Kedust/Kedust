<template>

  <h3>Menu</h3>

  <input type="text" v-model="menu.name"/>

  <h4>Keuzes</h4>

  <button class="btn waves-effect right" @click="save"
          v-if="JSON.stringify(items)!==JSON.stringify(oldItems) || JSON.stringify(menu)!==JSON.stringify(oldMenu)"><i
      class="material-icons left">save</i>Opslaan
  </button>
  <button class="btn waves-effect right" @click="addItem"><i class="material-icons left">add</i>Nieuw</button>
  <table>
    <thead>
    <tr>
      <th></th>
      <th>Afbeelding</th>
      <th>Naam</th>
      <th>Omschrijving</th>
      <th>Prijs</th>
      <th></th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="item in items" :key="item.id">
      <td>
        <button class="btn btn-small waves-effect" @click="sortUp(item)"><i class="material-icons">keyboard_arrow_up</i>
        </button>
        <button class="btn btn-small waves-effect" @click="sortDown(item)"><i
            class="material-icons">keyboard_arrow_down</i></button>
      </td>
      <td>
        <ImgUpload v-model:image="item.image"/>
      </td>
      <td><input type="text" v-model="item.name"/></td>
      <td><input type="text" v-model="item.description"/></td>
      <td><input type="number" v-model="item.price"/></td>
      <td>
        <button class="btn" @click="deleteItem(item)"><i class="material-icons">delete</i></button>
      </td>
    </tr>
    </tbody>
  </table>
</template>

<script>
import Gateway from "@/gateway"
import ImgUpload from "@/components/ImgUpload";

export default {
  name: "Menus",
  mounted() {
    this.updateMenu(this.$route.params.id)
  },
  data() {
    return {
      menu: {},
      items: [],
      oldItems: [],
      oldMenu: {}
    };
  },
  components: {
    ImgUpload
  },
  methods: {
    updateMenu(id) {
      if (id !== undefined) {
        let menu = Gateway.Menu.get(id);
        let choices = Gateway.Choice.getByMenu(id);
        Promise.all([menu, choices]).then(values => {
          this.menu = values[0];
          this.items = values[1].sort(function (a, b) {
            return a.sorting - b.sorting;
          });
          this.oldItems = [...this.items];
          this.oldMenu = {...this.menu};
        });
      } else {
        this.menu = {};
        this.items = [];
        this.oldMenu = {};
        this.oldItems = [];
      }
    },
    addItem() {
      this.items.push({price: 0})
    },
    deleteItem(item) {
      this.items = this.items.filter((i) => item !== i);
    },
    save() {
      Gateway.Choice.saveByMenu(this.menu, this.items)
          .then((data) => {
            this.updateMenu(data);
          });

    },

    sortUp(item) {
      let swapItem = this.items.find(i => i.sorting === item.sorting - 1);
      if (swapItem === undefined) return;
      let temp = swapItem.sorting;
      swapItem.sorting = item.sorting;
      item.sorting = temp;
      this.items = this.items.sort(function (a, b) {
        return a.sorting - b.sorting;
      });
    },
    sortDown(item) {
      let swapItem = this.items.find(i => i.sorting === item.sorting + 1);
      if (swapItem === undefined) return;
      let temp = swapItem.sorting;
      swapItem.sorting = item.sorting;
      item.sorting = temp;
      this.items = this.items.sort(function (a, b) {
        return a.sorting - b.sorting;
      });
    }
  }
}
</script>

<style scoped>
.btn {
  margin-left: 1rem;
}

/deep/ .img {
  height: 5rem;
}
</style>