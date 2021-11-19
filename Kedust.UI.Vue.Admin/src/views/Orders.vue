<template>
  <h1>Orders</h1>
  <div>
    <div class="row">
      <div class="col s6 input-field">
        <label for="dateFrom">Vanaf datum</label>
        <input id="dateFrom" type="text" v-model.lazy="this.dateFrom" class="datepicker">
      </div>
      <div class="col s6 input-field">
        <label for="TimeFrom">Vanaf datum</label>
        <input id="TimeFrom" type="text" v-model.lazy="this.timeFrom" class="timepicker">
      </div>
    </div>
    <div class="row">
      <div class="col s6 input-field">
        <label for="dateTill">Vanaf datum</label>
        <input id="dateTill" type="text" v-model.lazy="this.dateTill" class="datepicker">
      </div>
      <div class="col s6 input-field">
        <label for="timeTill">Vanaf datum</label>
        <input id="timeTill" type="text" v-model.lazy="this.timeTill" class="timepicker">
      </div>
    </div>
    <button class="btn waves-effect" style="margin-right: 10px;" @click="update">
      <i class="material-icons left">refresh</i>Refresh
    </button>
    <button class="btn waves-effect" @click="update15">
      <i class="material-icons left">refresh</i>Laatste 15 minuten
    </button>
  </div>

  <table class="striped">
    <thead>
    <tr>
      <th>Status</th>
      <th>Tafel</th>
      <th>Tijd besteld</th>
      <th>Bestelling</th>
    </tr>
    </thead>
    <tbody>
    <tr class="row" v-for="order in this.orders" :key="order.id">
      <td>{{ formatStatus(order.status) }}</td>
      <td>{{ order.table.description }}</td>
      <td>{{ formatDate(order.timeOrderPlaced) }}</td>
      <td>{{ formatOrderItems(order.orderItems) }}</td>
    </tr>
    </tbody>
  </table>
</template>

<script>

import Materialize from "materialize-css";
import Moment from "moment";
import Gateways from "@/gateway";
import {mapMutations} from "vuex";

export default {
  name: "Orders",
  data() {
    return {
      dateFrom: Moment(new Date()).format("MMM DD, YYYY"),
      dateTill: Moment(new Date()).format("MMM DD, YYYY"),
      timeFrom: Moment(new Date()).format("hh:mm A"),
      timeTill: Moment(new Date()).subtract(15, "minutes").format("hh:mm A"),
      orders: []
    }
  },
  mounted() {
    Materialize.AutoInit();
    this.update();
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading"
    }),
    formatDate(date) {
      return Moment(date).format("DD-MM-yyy HH:mm:ss")
    },
    formatStatus(status) {
      if (status === 0) return "Nieuw";
      if (status === 50) return "Aan het printen";
      if (status === 100) return "Afgedrukt";
    },
    formatOrderItems(items) {
      return items.map(x => x.amount + " " + x.name).join()
    },
    update15(){
      this.dateFrom= Moment(new Date()).format("MMM DD, YYYY");
      this.dateTill= Moment(new Date()).format("MMM DD, YYYY");
      this.timeFrom= Moment(new Date()).format("hh:mm A");
      this.timeTill= Moment(new Date()).subtract(15, "minutes").format("hh:mm A");
      this.update();
    },
    update() {
      this.setLoading(true);
      let from = (Moment(this.dateFrom + " " + this.timeFrom, "MMM DD, YYYY hh:mm A").format("yyyy-MM-DDTHH:mm"));
      let till = (Moment(this.dateTill + " " + this.timeTill, "MMM DD, YYYY hh:mm A").format("yyyy-MM-DDTHH:mm"));
      Gateways.Order.getAll(from, till).then((m) => {
        this.orders = m;
        this.setLoading(false);

      });
    },
  }
}
</script>

<style scoped>

</style>