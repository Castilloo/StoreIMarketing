<template>
<div class="card m-4" style="max-width: 90vw;" v-for="item in data" :key="item.id">
    <div class="row">
        <div class="col-1 d-flex flex-column image-container">
            <div class="mb-2 m-auto" @click="changePhoto(item.image.url1)">
                <img class="image" :src="item.image.url1" alt="">
            </div>
            <div class="mb-2 m-auto" @click="changePhoto(item.image.url2)">
                <img class="image" :src="item.image.url2" alt="">
            </div>
            <div class="mb-2 m-auto" @click="changePhoto(item.image.url3)" >
                <img class="image" :src="item.image.url3" alt="">
            </div>
            <div class="mb-2 m-auto" @click="changePhoto(item.image.url4)">
                <img class="image" :src="item.image.url4" alt="">
            </div>
            <div class="mb-2 m-auto" @click="changePhoto(item.image.url5)">
                <img class="image" :src="item.image.url5" alt="">
            </div>
        </div>
        <div class="col-4">
            <div class="h-100 d-flex align-items-center">
                <img class="big-image" 
                :src="currentPhoto ? currentPhoto : item.image.url1" alt="">
            </div>
        </div>
        <div class="col">
            <div class="card border-light h-100">
                <h3 class="pt-4 ms-3 fw-bold title">{{ item.product.name }} - {{ item.product.brand }}</h3>
                <div class="card-body">
                    <p class="card-text">{{ item.product.descripcion }}</p>
                    <p class="card-text">Estado: {{ item.product.isNew ? 'Nuevo' : 'De segunda' }}</p>
                    <div class="d-flex mb-3">
                        <label class="me-3 mt-2">Cantidad:</label>
                        <input type="text" class="input-group-text quantity" value="1">
                        <p class="ms-5 mt-2">Hay {{ item.product.quantity }} disponibles / {{ item.quantitySold }} vendidos</p>
                    </div>
                    <div class="row me-3">
                        <div class="col-5">
                            <h5 class="fw-bold">Precio: ${{ item.product.price }}</h5>
                        </div>
                        <div class="col w-100">
                            <div class="buttons d-flex align-items-end flex-column">
                                <a href="#" class="w-100 btn btn-primary mb-1">¡Cómpralo ahora!</a>
                                <a href="#" class="w-100 btn btn-info mb-1">Agregar al carro de compras</a>
                                <a href="#" class="w-100 btn btn-secondary">Agrega a la lista de favoritos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script setup>
import { useRoute } from 'vue-router';

import axios from "axios";
import { ref } from 'vue';

const baseUrl = 'http://localhost:5057/api/store/products/';
let data = ref([]);
let currentPhoto = ref('');

const getProductById = async () => {
    try {
        const route = useRoute();
        const id = route.params.id;
        const url = baseUrl + id
        const response = await axios.get(url);
        data.value = response.data.data;
    } catch (error) {
        throw new Error()
    }
}

const changePhoto = (url) => {
    // console.log(url);
    currentPhoto.value = url;
}

getProductById();
</script>

<style lang="css" scoped>
.image-container {
    width: 110px;
}

.image {
    width: 75px;
    height: 75px;
    cursor: pointer;
}

.big-image {
    width: 30vw;
    min-width: 300px;
}

h5.title {
    font-size: larger;
}

.quantity {
    width: 50px;
}

.btn {
    width: 150px;
}

.btn-info {
    color: bisque;
}
</style>