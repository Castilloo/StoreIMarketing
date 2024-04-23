<template>
<div class="col-md-10 m-auto" style="max-width: 90vw;">
    <h5 v-if="isProps"><i>Productos encontrados por "{{ textFromInput }}"</i></h5>
    <div v-if="products.length === 0" class="row ms-5 mt-5">
        <div class="col">
            <h4 class="col fw-bold">No se encontraron resultados</h4>
        </div>
    </div>
    <div class="row g-0 m-5 border border-secondary-subtle" v-for="item in products" :key="item.id">
        <router-link :to="'/detail/'+item.product.idProduct" class="col-md-4 m-auto">
            <img :src="item.image.url" class="img-fluid rounded-start" alt="...">
        </router-link>
        <div class="col">
            <div class="card-body mt-3">
                <router-link :to="'/detail/'+item.product.idProduct" class="router-link">
                    <h2 class="card-title fw-bold">{{ item.product.name }}</h2>
                </router-link>
                <p class="text-body-secondary mt-0">
                    {{ item.product.brand }} - {{ item.product.isNew ? 'Totalmente nuevo' : 'Usado' }}
                </p>
                <h3 class="fw-bold">USD ${{ item.product.price }}</h3>
                <div class="d-flex">
                    <div class="me-4 w-100">
                        <p class="text-body-secondary m-0">Cómpralo ahora!</p>
                        <p class="card-text text-body-secondary m-0">${{ item.product.price + 100 }} de envio estimado desde {{ item.seller.city }}</p>
                        <p class="card-text fw-bold m-0">{{ item.quantitySold }} vendidos</p>
                    </div>
                    <div class="">
                        <p class="text-body-secondary m-0">Vendedor {{ item.seller.isGoodAssessment ? 'bueno' : 'regular' }}</p>
                        <p class="text-body-secondary m-0">Se ofrecen servicios de aduanas y de seguimiento internacional del envío</p>
                        <p class="text-body-secondary m-0">{{ item.seller.name }}</p>
                    </div>
                    <!-- <button @click="recibir">recibir</button> -->
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script setup>
import { ref, watch } from 'vue';
import axios from 'axios';
import { onMounted, defineProps } from 'vue';

const baseUrl = 'http://localhost:5057/api/store/products';
const props = defineProps({
    textFromInput: {
        type: String,
        required: true
    },
    
});
let products = ref([]);
let isProps = false;

onMounted(() => {
    console.log(props.textFromInput);
});

watch(() => props.textFromInput, (newValue) => {
    console.log('La prop del padre ha cambiado:', newValue);
    isProps = props.textFromInput.trim().length > 0;
    getProducts();
});

const getProducts = async() => {
    try {
        let url = baseUrl;
        if(isProps){
            url = baseUrl + '?name=' + props.textFromInput;
        }
        console.log(url);
        const response = await axios.get(url);
        products.value = response.data.data;

    } catch (error) {
        throw new Error()
    }
}

getProducts();
</script>

<style lang="css" scoped>
.router-link {
    color: black;
    text-decoration: none;
}
.router-link:hover, img {
    cursor: pointer;
    text-decoration: underline;
}

</style>