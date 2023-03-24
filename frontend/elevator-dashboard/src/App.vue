<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark justify-content-center">
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item active">
          <a class="nav-link" href="#"><RouterLink to="/">Home</RouterLink></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#"><RouterLink to="/elevators">Alle Aufzüge</RouterLink></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#"><RouterLink to="/elevatorsfailures">Ausgefallene Aufzüge </RouterLink></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#"><RouterLink to="/elevatormaintenances">Geplante Wartungen</RouterLink></a>
        </li>
      </ul>
    </div>
  </nav>
  <RouterView />
</template>

<script lang="ts">
export default {
  name: 'App'
}
</script>

<style>
#app {
  width: 100%;
}
</style>