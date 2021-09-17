<template>
  <div>
    <ul id="dropdown1" class="dropdown-content">
      <li>
        <RouterLink to="Tables" tag="a">Overzicht</RouterLink>
      </li>
      <li>
        <RouterLink to="Tables" tag="a">Nieuw</RouterLink>
      </li>
    </ul>
    <ul id="dropdown2" class="dropdown-content">
      <li>
        <RouterLink to="Tables" tag="a">Overzicht</RouterLink>
      </li>
      <li>
        <RouterLink to="Tables" tag="a">Nieuw</RouterLink>
      </li>
    </ul>
    <nav class="kedust-green" role="navigation">
      <div class="nav-wrapper container"><a id="logo-container" href="#" class="brand-logo">Logo</a>
        <ul class="right hide-on-med-and-down">
          <li><a class="dropdown-trigger" href="#" data-target="dropdown1">Menu's<i class="material-icons right">arrow_drop_down</i></a></li>
          <li><RouterLink to="Tables" tag="a">Tafels</RouterLink></li>
          <li><RouterLink to="Orders" tag="a">Bestellingen</RouterLink></li>
        </ul>

        <ul id="nav-mobile" class="sidenav kedust-green">
          <li><a class="dropdown-trigger" href="#" data-target="dropdown2">Menu's<i class="material-icons right">arrow_drop_down</i></a></li>
          <li>
            <RouterLink to="Tables" tag="a">Tafels</RouterLink>
          </li>
          <li>
            <RouterLink to="Orders" tag="a">Bestellingen</RouterLink>
          </li>
        </ul>

        <a href="#" data-target="nav-mobile" class="sidenav-trigger"><i class="material-icons">menu</i></a>
      </div>
    </nav>

  </div>
</template>

<script>
import M from "materialize-css";

export default {
  name: 'Nav',
  mounted() {
    M.Sidenav.init(document.querySelector('.sidenav'));

    document.querySelectorAll('.dropdown-trigger').forEach(e => new M.Dropdown(e));
  }
}
</script>

<style>

nav {
  background-color: #26a69a;
}

.brand-logo {
  height: 60px;
}
</style>
