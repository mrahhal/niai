import '@/components/globals';

import Vue from 'vue';
import VueAnalytics from 'vue-analytics';

import App from './App.vue';
import router from './router';

Vue.config.productionTip = false;

if (process.env.NODE_ENV === 'production') {
  Vue.use(VueAnalytics, {
    id: process.env.VUE_APP_GOOGLE_ANALYTICS_TRACKING_ID,
    router,
  });
}

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
