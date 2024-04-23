<template>
<div>
    <button class="btn btn-outline-secondary dropdown-toggle" 
        type="button" data-bs-toggle="dropdown" aria-expanded="false">
            {{ category }}
    </button>
    <ul class="dropdown-menu">
        <li v-for="(item, i) in items" :key="i">
            <a class="dropdown-item" @click="itemSelection(item)">{{ item }}</a>
        </li>
    </ul>
</div>
</template>

<script setup>
import { ref, defineEmits } from "vue";

const items = ['Electrónica', 'Ropa', 'Hogar', 'Deportes', 'Libros'];
let category = ref('Categoría');
let itemSelected = ref('');

const emit = defineEmits(['dropdownOption'])

const itemSelection = (item) => {
    category.value = item;
    itemSelected.value = item;
    emit('dropdownOption', itemSelected.value);
}

</script>

<style lang="css" scoped>
a {
    cursor: pointer;
}
</style>