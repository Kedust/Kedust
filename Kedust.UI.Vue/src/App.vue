<template>
  <div>
    <img class="logo" src="/img/kedust-full.svg" alt="Logo"/>
    <Spinner v-if="loading"/>

    <div class="page-container">
      <router-view v-slot="{ Component }">
        <transition mode="out-in">
          <component :is="Component"/>
        </transition>
      </router-view>
    </div>
  </div>
</template>

<script>
import Menu from "@/views/Menu";
import MenuItemDetails from "@/views/MenuItemDetails";
import Spinner from "@/components/Spinner";
import {mapGetters} from "vuex";

export default {
  components: {Spinner, MenuItemDetails, Menu},
  computed: {
    ...mapGetters({
      loading: 'getLoading'
    })
  }
}
</script>

<style>
body {
  font-family: 'Roboto', sans-serif;
  user-select: none;
  cursor: default;
}

.logo {
  display: block;
  margin: 1rem auto 1rem auto;
  max-width: 50vw;
  max-height: 12vh;
}

.button {
  box-shadow: 0 3px 3px 0 rgba(0, 0, 0, 0.14),
  0 1px 7px 0 rgba(0, 0, 0, 0.12),
  0 3px 1px -1px rgba(0, 0, 0, 0.35);
  text-align: center;
  display: block;
  padding: 1rem;
  margin-bottom: 1rem;
}

.primary{
  color: #f0750f;
}
.primary-bg{
  background-color: #f0750f;
  color: white;
}

.border {
  box-shadow: 0 3px 3px 0 rgba(0, 0, 0, 0.14),
  0 1px 7px 0 rgba(0, 0, 0, 0.12),
  0 3px 1px -1px rgba(0, 0, 0, 0.35);

}
</style>
