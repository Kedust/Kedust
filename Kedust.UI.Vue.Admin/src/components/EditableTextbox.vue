<template>
  <span v-if="!editable">{{ textValue }}</span>
  <input v-if="editable" :value="textValue" @change="this.$emit('update:textValue', this.textValue)">
</template>

<script>
export default {
  name: "EditableTextbox",
  props: {
    editable: Boolean,
    textValue: String
  }
}
</script>

<style scoped>

</style>