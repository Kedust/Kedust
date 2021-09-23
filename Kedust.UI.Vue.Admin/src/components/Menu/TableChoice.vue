<template>
  <table>
    <thead>
    <tr>
      <th>Afbeelding</th>
      <th>Naam</th>
      <th>Omschrijving</th>
      <th>Prijs</th>
    </tr>
    </thead>
    <tbody>
    <TableRowChoice v-for="item in items" :key="item.id" :item="item"/>
    </tbody>
  </table>
</template>

<script>
import TableRowChoice from "@/components/Menu/TableRowChoice";

export default {
  name: "TableChoice",
  props: {
    items: []
  },
  components: {
    TableRowChoice
  }
}
</script>

<style scoped>

</style>