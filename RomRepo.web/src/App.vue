<script setup>
import { RouterLink, RouterView } from 'vue-router'



</script>

<template>
  <div>
    <header class="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">
      <ul class="nav nav-pills">
        <li class="nav-item">
          <RouterLink class="nav-link" to="/" title="Systems"><i class="bi bi-pc-display-horizontal highlight-link"></i></RouterLink>
        </li>
        <li class="nav-item">
          <RouterLink class="nav-link" to="/about" title="Roms"><i class="bi bi-controller highlight-link"></i></RouterLink>
        </li>
        <li class="nav-item">
          <RouterLink class="nav-link" to="/about" title="Settings"><i class="bi bi-gear highlight-link"></i></RouterLink>
        </li>
        <li class="nav-item">
          <i title="System Status" class="nav-link bi bi-stoplights text-success"></i>
        </li>
      </ul>
      
    </header>
    <div>
      <RouterView />
    </div>
  </div>
</template>

<style scoped>

</style>
