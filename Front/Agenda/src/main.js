import Vue from 'vue';
import App from './App.vue';

import 'materialize-css';
import 'materialize-css/dist/css/materialize.min.css';

import VuejQueryMask from 'vue-jquery-mask';
import VueRouter from 'vue-router';
import { routes } from "./routes";

Vue.use(VueRouter);
Vue.use(VuejQueryMask);

const router = new VueRouter({ 
  routes,
  mode: 'history' 
});

new Vue({
  el: '#app',
  router,
  render: h => h(App)
})
