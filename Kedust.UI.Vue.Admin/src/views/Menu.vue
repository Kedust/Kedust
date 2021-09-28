<template>

  <h3>Menu</h3>

  <input type="text" v-model="menu.name"/>

  <h4>Keuzes</h4>

  <button class="btn waves-effect right" @click="save"
          v-if="JSON.stringify(menu)!==JSON.stringify(originalMenu)"><i
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
    <tr v-for="choice in menu.choices" :key="choice.id">
      <td>
        <button class="btn btn-small waves-effect" @click="sortUp(choice)"><i class="material-icons">keyboard_arrow_up</i>
        </button>
        <button class="btn btn-small waves-effect" @click="sortDown(choice)"><i
            class="material-icons">keyboard_arrow_down</i></button>
      </td>
      <td>
        <ImgUpload v-model:image="choice.image"/>
      </td>
      <td><input type="text" v-model="choice.name"/></td>
      <td><input type="text" v-model="choice.description"/></td>
      <td><input type="number" v-model="choice.price"/></td>
      <td>
        <button class="btn" @click="deleteItem(choice)"><i class="material-icons">delete</i></button>
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
      originalMenu: {}
    };
  },
  components: {
    ImgUpload
  },
  methods: {
    updateMenu(id) {
      if (id !== undefined) {
        Gateway.Menu.get(id).then(value => {
          this.menu = value;
          this.sortItems();
          this.originalMenu = {...this.menu, choices:[...this.menu.choices]};
        });
      } else {
        this.menu = {choices:[]};
        this.originalMenu = {choices:[]};
      }
    },
    sortItems() {
      this.menu.choices = this.menu.choices.sort(function (a, b) {
        return a.sorting - b.sorting;
      });
    },
    addItem() {
      let value = 1;
      if(this.menu.choices.length > 0)
      value = Math.max.apply(Math, this.menu.choices.map(function (o) {return o.sorting})) + 1;
      this.menu.choices.push({price: 0, sorting: value})
    },
    deleteItem(item) {
      this.menu.choices = this.menu.choices.filter((i) => item !== i);
    },
    save() {
      Gateway.Menu.save(this.menu)
          .then((data) => {
            this.updateMenu(data);
          });

    },

    sortUp(item) {
      let swapItem = this.menu.choices.find(i => i.sorting === item.sorting - 1);
      if (swapItem === undefined) return;
      let temp = swapItem.sorting;
      swapItem.sorting = item.sorting;
      item.sorting = temp;
      this.sortItems()
    },
    sortDown(item) {
      let swapItem = this.menu.choices.find(i => i.sorting === item.sorting + 1);
      if (swapItem === undefined) return;
      let temp = swapItem.sorting;
      swapItem.sorting = item.sorting;
      item.sorting = temp;
      this.sortItems()
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