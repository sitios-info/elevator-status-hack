import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/elevators',
      name: 'elevators',
      component: () => import('../views/ElevatorsView.vue')
    },
    {
      path: '/elevatorsfailures',
      name: 'elevatorsfailures',
      component: () => import('../views/ElevatorFailuresView.vue')
    },
    {
      path: '/elevatormaintenances',
      name: 'elevatormaintenances',
      component: () => import('../views/ElevatoMaintenancesrView.vue')
    }
  ]
})

export default router
