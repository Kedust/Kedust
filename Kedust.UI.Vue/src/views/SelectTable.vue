<template>
  <div class="page">
    <div class="back-button" v-if="tableAvailable" @click="goToMenu"><i class="material-icons">arrow_back</i></div>

    <form @submit="submit">
      <div class="input-field">
        <input id="table_code" type="text" v-model="input">
        <label for="table_code" class="active">Tafelcode</label>
      </div>

      <div class="button primary-bg" @click="submit">Naar de kaart!</div>

    </form>

    <div class="button primary-bg" v-if="!scanCode" @click="scanCode = true">Scan QR code</div>

    <qrcode-stream @decode="onDecode" v-if="scanCode"></qrcode-stream>


  </div>
</template>

<style scoped>
.page {
  margin: 1rem;
  text-align: center;
}
</style>

<script>
import {mapMutations, mapGetters} from "vuex";
import Materialize from "materialize-css";
import Gateway from "@/gateway";
import {QrcodeStream} from 'vue-qrcode-reader'

export default {
  name: 'SelectTable',
  props: {
    code: String
  },
  data() {
    return {
      scanCode: false,
      input: this.table
    }
  },
  components: {
    QrcodeStream
  },
  computed: {
    ...mapGetters({
      table: "getTable",
      tableAvailable: "getTableAvailable"
    })
  },
  async mounted() {
    const table = this.$route.params.code;
    if (table !== undefined) {
      await this.setTableCode(table);
    }
  },
  methods: {
    ...mapMutations({
      setTable: "setTable",
      setMenu: "setMenu",
      loading: "setLoading"
    }),
    onDecode(data) {
      if (data.toLowerCase().startsWith("https://kedust.be/table/")) {
        let code = data.substring("https://kedust.be/table/".length)
        this.setTableCode(code);
      }
    },
    setTableCode(code) {
      this.loading(true);
      Gateway.Table.checkCode(code)
          .then((response) => {
                if (response) {
                  this.setTable(code);
                  return Gateway.Menu.getByTableCode(code).then(async (choicesResult) => {
                    this.setMenu(choicesResult)
                    this.loading(false);
                    await this.$router.push({name: 'Menu'});
                  });
                } else {
                  Materialize.toast({html: "Sorry, die tafel vinden we niet terug...", classes: "toast-danger"});
                  this.loading(false);
                }
              }
          );
    },
    async submit(e) {
      e.preventDefault();
      this.setTableCode(this.input);
    },
    async goToMenu() {
      await this.$router.push({name: "Menu"})
    }
  }
}
</script>