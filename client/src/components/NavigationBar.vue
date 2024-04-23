<template>
<div class="container">
  <div class="row pt-3">
      <router-link class="col-2" to="/">
          <img class="w-75" src="@/assets/ebay-logo.png" alt="">
      </router-link>
      <div class="col d-flex align-items-center input-group mb-3">
          <input type="text" class="form-control"
          aria-label="Text input with dropdown button"
          v-model="inputValue">
          <drop-down @dropdown-option="sendDropdown"></drop-down>
          <div class="custom" >
            <button class="btn btn-dark ms-5 w-50" @click="sendInputText">Buscar</button>
          </div>
      </div>
  </div>
</div>
</template>

<script setup>
import DropDown from './DropDown.vue';
import { ref } from 'vue';
import { defineEmits } from 'vue';

let inputValue = ref('');

const emit = defineEmits(['sendInputText']);

const sendDropdown = (value) => {
  console.log('Enviar dorpdown');
  emit('sendInputText', value);
}

const sendInputText = () => {
  // console.log('enviar desde nav💩💩💩');
  emit('sendInputText', inputValue.value);
  inputValue.value = '';
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.custom {
  width: 300px
  }
</style>
