<script lang="ts">
import type { Elevator } from '@/domain';

export default {
    data() {
        return {
            elements: [] as Elevator[]
        };
    },
    methods: {
        async getElevators() {
            const res = await fetch("https://localhost:7220/api/Elevators");
            const finalRes = await res.json() as Elevator[];
            this.elements = finalRes.filter(e => !e.isOperational);
        }
    },
    mounted() {
        this.getElevators();
    },
}

</script>

<template>
  <main>
   <ElevatorStatus :elements="elements" title="Ausgefallene Aufzüge"/>
  </main>
</template>


