import Vue from 'vue';
import Router from 'vue-router';

import About from './views/About.vue';
import Home from './views/Home.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      redirect: '/similar',
    },
    {
      path: '/similar',
      name: 'similar',
      component: Home,
    },
    {
      path: '/about',
      name: 'about',
      component: About,
    },
  ],
});
