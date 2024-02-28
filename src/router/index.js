import { createRouter as createRouter, createWebHistory } from 'vue-router'
import { useStore } from 'vuex'
import HomeViewVue from "@/Views/HomeView.vue";
import AboutViewVue from "@/Views/AboutView.vue";
import ContactViewVue from "@/Views/ContactView.vue";


const routes = [
    { path: '/', name: 'Home', component: HomeViewVue },
    { path: '/about', name: 'About', component: AboutViewVue },
    { path: '/contact', name: 'Contact', component: ContactViewVue }
  ];
  // Create the router
const router = createRouter({
    history: createWebHistory(),
    routes: routes
  });
  
  router.beforeEach((to) => {
  
    // Get the Vuex store
    const store = useStore();
  
    // Determine if the route requires Authentication
    const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  
    // If it does and they are not logged in, send the user to "/login"
    if (requiresAuth && store.state.token === '') {
      return { name: "login" };
    }
    // Otherwise, do nothing and they'll go to their next destination
  });
  
  export default router;