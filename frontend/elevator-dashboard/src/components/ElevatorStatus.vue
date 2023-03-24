<script setup lang="ts">
import type { GetElevatorsResult } from '@/domain'

defineProps<{
  elements: GetElevatorsResult
  title: string
}>()
</script>

<template>
  <div class="container mt-2">
    <h2>{{ title }}</h2>
    <table class="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Funktioniert</th>
          <th scope="col">Beschreibung</th>
          <th scope="col">Hersteller</th>
        </tr>
      </thead>
      <tbody>
    <tr v-for="element in elements" :key="element.id">
      <th scope="row">{{ element.id }}</th>
      <td>{{ element.isOperational ? '✔️' : '❌' }}</td>
      <td>{{ element.properties['description'] }}</td>
      <td>{{ element.manufacturerName }}</td>
    </tr>
  </tbody>
  </table>
  </div>
</template>
