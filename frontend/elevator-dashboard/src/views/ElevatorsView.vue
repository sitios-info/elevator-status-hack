<script lang="ts">
import type { GetElevatorsResult } from '@/domain';

export default {
  data() {
    return {
      elements: [
              {
                "id": "b1a0e7f4-14fe-4919-8705-105d8b3844be",
                "openStreetMapId": null,
                "properties": {},
                "location": null,
                "manufacturerName": "Bosch working",
                "serialNumber": "A-1732-B-",
                "operator": null,
                "isOperational": true
              },
              {
                "id": "b1a0e7f4-14fe-4919-8705-105d8b3844be",
                "openStreetMapId": null,
                "properties": {},
                "location": null,
                "manufacturerName": "Bosch working",
                "serialNumber": "A-1732-B-",
                "operator": null,
                "isOperational": true
              },
              {
                "id": "b1a0e7f4-14fe-4919-8705-105d8b3844be",
                "openStreetMapId": null,
                "properties": {},
                "location": null,
                "manufacturerName": "Bosch working",
                "serialNumber": "A-1732-B-",
                "operator": null,
                "isOperational": true
              },
              {
                "id": "b1a0e7f4-14fe-4919-8705-105d8b3844be",
                "openStreetMapId": null,
                "properties": {},
                "location": null,
                "manufacturerName": "Bosch working",
                "serialNumber": "A-1732-B-",
                "operator": null,
                "isOperational": true
              },
              {
                "id": "b1a0e7f4-14fe-4919-8705-105d8b3844be",
                "openStreetMapId": null,
                "properties": {},
                "location": null,
                "manufacturerName": "Bosch working",
                "serialNumber": "A-1732-B-",
                "operator": null,
                "isOperational": true
              }
            ] as GetElevatorsResult[]
      }

    
    }
  }

</script>

<template>
  <main>
   <ElevatorStatus :elements="elements" title="Alle Aufzüge"/>
  </main>
</template>


