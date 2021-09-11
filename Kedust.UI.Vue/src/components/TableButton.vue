<template>
  <div class="table-cart button">
    <div class="flex-container">
      <div>
        <span class="material-icons">table_bar</span>
        <span>{{table}}</span>
      </div>

      <div>
        <span>
          <i class="border material-icons" @click="goTo('Table')">edit</i>
        </span>
<!--        <span>-->
<!--          <i class="border material-icons" @click="goTo('TableHistory')">history</i>-->
<!--        </span>-->
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

.border{
  margin-left: 1rem;
  padding: 0.5rem;
}

.table-cart {
  font-size: 1.25rem;
  background-color: #26a69a;
  color: white;
  padding: 0.5rem 1rem 0.5rem 1rem;
}
</style>
