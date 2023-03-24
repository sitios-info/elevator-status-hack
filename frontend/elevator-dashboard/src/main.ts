import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import './assets/main.css'
import ElevatorStatusVue from './components/ElevatorStatus.vue'

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.component('ElevatorStatus', ElevatorStatusVue as any)

app.mount('#app')
