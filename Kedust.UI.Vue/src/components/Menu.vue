<template>
  <div class="page">
    <div class="row">
      <MenuItem v-for="item in MenuData" :key="item.id" :item="item"/>
    </div>
  </div>
</template>








<script>

import MenuItem from "@/components/MenuItem";
const MenuData = [
    {
      id: 1,
      name: "Plat water",
      description: "Spa",
      category: "Drank",
      price: 1.8
    },
    {
      id: 2,
      name: "Spuitwater",
      description: "Spa",
      category: "Drank",
      price: 1.8
    }

  ];

export default {
  name: 'Menu',
  components: {MenuItem},
  data() {
    return {
      MenuData
    }
  },
  props: {
    items: [
      {
        id: Number,
        name: String,
        description: String,
        category: String,
        price: Number
      }
    ]
  }
}
</script>