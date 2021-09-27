<template>
  <div class="table-cart button">
    <div class="flex-container">
      <div>
        <span class="material-icons">table_bar</span>
        <span>{{table}}</span>
      </div>

      <div>
        <span>
          <i class="material-icons" @click="goTo('Table')">edit</i>
        </span>
      </div>
    </div>
  </div>
</template>

<script>
import {mapGetters} from "vuex";

export default {
  name: 'TableButton',
  computed: {
    ...mapGetters({
      table: "getTable",
    })
  },
  methods: {
    async goTo(name) {
      await this.$router.push({name});
    },
  }
}
</script>



<style scoped>
.flex-container {
  display: flex;
  justify-content: space-between;
}

.material-icons{
  vertical-align: top;
}

.table-cart {
  font-size: 1.25rem;
  background-color: #26a69a;
  color: white;
  padding: 1rem;
}
</style>
