<template>

  <div class="container">
    <div class="section">

      <h3>{{menu.name}}</h3>
      <form class="col s12">
        <div class="row">
          <div class="input-field col s6">
            <button v-if='this.menu === undefined' class="btn waves-effect waves-light">Aanmaken
              <i class="material-icons left">add</i>
            </button>
            <button v-if='this.menu !== undefined' class="btn waves-effect waves-light">Opslaan
              <i class="material-icons left">save</i>
            </button>
          </div>
        </div>
      </form>
    </div>

    <TableChoice :items="items"></TableChoice>

<!--    <div class="section" v-if="items !== undefined">-->
<!--      -->
<!--      -->
<!--      <ImgUpload-->
<!--          v-for="item in items"-->
<!--          :image="item.image"-->
<!--          v-on:selected="imageUpdated($event, item)"-->
<!--          :key="item.id"></ImgUpload>-->
<!--    </div>-->
  </div>

</template>

<script>
import M from 'materialize-css';
import Gateway from "@/gateway"
import TableChoice from "@/components/Menu/TableChoice";

export default {
  name: "Menus",
  mounted() {
    if (this.$route.params.id !== undefined) {
      Gateway.Menu.get(this.$route.params.id)
      .then(data => this.menu = data);
      Gateway.Choice.getByMenu(this.$route.params.id)
      .then(data => this.items = data);

      this.isNew = false;
    }
    else{
      this.isNew = true;
      this.menu = {
        name:""
      };
    }
    M.updateTextFields();
  },
  data() {
    return {
      isNew: true,
      menu: {},
      items: []
    };
  },
  methods: {
    imageUpdated(selectedDate, item) {
      item.image = selectedDate;
    }
  },
  components: {
    TableChoice
  }
}
</script>

<style scoped>
/deep/ .img {
  height: 5rem;
}
</style>