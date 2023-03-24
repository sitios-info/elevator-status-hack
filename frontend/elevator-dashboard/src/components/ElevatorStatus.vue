<script setup lang="ts">
import type { ElevatorStatusElement } from '@/domain';

defineProps<{
  elements: ElevatorStatusElement[]
}>()
</script>

<template>
     <div class="container mt-2">
      <ul class="list-group">
        <li v-for="element in elements" :key="element.id" class="list-group-item">Elev{{element.id }}, {{ element.author }}</li>
      </ul>
  </div>
</template>