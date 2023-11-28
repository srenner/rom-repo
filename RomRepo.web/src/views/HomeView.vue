<script setup>
import CoreCard from '../components/CoreCard.vue';
let cores = [
  {
    name: "Saturn",
    path: "\\\\nas\\saturn"
  },
  {
    name: "SNES",
    path: "\\\\nas\\snes"
  }
  ];
</script>

<template>
  <main>
    <h1 class="highlight">=== My Systems ===</h1>
    <div class="row">
      <div class="col-6 col-sm-4 col-md-3 col-lg-2">
        <CoreCard v-bind:system="cores[0]"></CoreCard>
      </div>
    </div>
    <hr>
    <div class="row">

      <div v-for="core in cores" :key="core.name" class="col-6 col-sm-4 col-md-3 col-lg-2">
          <CoreCard v-bind:system="core"></CoreCard>
      </div>



    </div>
  </main>
</template>
