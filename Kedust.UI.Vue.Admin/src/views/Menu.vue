<template>

  <div class="container">
    <div class="section">

      <h3>Menu</h3>
      <form class="col s12">
        <div class="row">
          <div class="input-field col s6">
            <input id="menu" type="text">
            <label for="menu">Naam</label>
          </div>
          <div class="input-field col s6">
            <button v-if='id === undefined' class="btn waves-effect waves-light">Aanmaken
              <i class="material-icons left">add</i>
            </button>
            <button v-if='id !== undefined' class="btn waves-effect waves-light">Opslaan
              <i class="material-icons left">save</i>
            </button>
          </div>
        </div>
      </form>
    </div>

    <div class="section">
      <ImgBase64Upload></ImgBase64Upload>
    </div>
  </div>

</template>

<script>
import M from 'materialize-css';
import ImgBase64Upload from '@/components/ImgUpload'

export default {
  name: "Menus",
  data() {
    return {
      id: this.$route.params.id,
    }
  },
  mounted() {
    M.updateTextFields();
  },
  components: {
    ImgBase64Upload
  }
}
</script>

<style scoped>

</style>