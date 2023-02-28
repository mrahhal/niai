import '@/components/globals';

import Vue from 'vue';

import VueGtag from 'vue-gtag';
import App from './App.vue';
import router from './router';

Vue.config.productionTip = false;

if (process.env.NODE_ENV === 'production') {
  Vue.use(VueGtag, {
    config: { id: process.env.VUE_APP_GOOGLE_ANALYTICS_TRACKING_ID },
  });
}

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
