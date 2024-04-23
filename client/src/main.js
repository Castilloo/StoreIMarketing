/* eslint-disable no-unused-vars */
import { createApp } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';
import axios from 'axios';
import vueAxios from 'vue-axios';

import ProductsList from './components/ProductsList.vue';
import ProductDetail from './components/ProductDetail.vue';

import App from './App.vue';

const routes = [
    {
        path: '/', 
        name: 'productsList',
        component: ProductsList
    },
    {
        path: '/detail/:id',
        name: 'detail',
        component: ProductDetail
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
})

createApp(App)
    .use(router)
    .use(vueAxios,axios)
    .mount('#app');
