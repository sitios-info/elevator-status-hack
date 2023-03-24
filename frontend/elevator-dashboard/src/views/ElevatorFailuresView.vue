<script lang="ts">
import type { ElevatorStatusElement } from '@/domain';

export default {
  data() {
    return {
      elements: [
        {
          id: "sasasas",
          title: "tttt",
          author: "sasas",
          year: 2222

        },
        {
          id: "wwww",
          title: "wwwww",
          author: "ww",
          year: 2222

        }
      ] as ElevatorStatusElement[]
      }
    }
  }

</script>

<template>
  <main>
   <ElevatorStatus :elements="elements"/>
  </main>
</template>


