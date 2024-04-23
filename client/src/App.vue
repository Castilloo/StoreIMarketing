<template>
  <div id="app">
    <div class="mt-4">
      <navigation-bar @sendInputText="handleSendText"></navigation-bar>
    </div>
        <router-view :textFromInput="receivedText"></router-view>
  </div>
</template>

  <script setup>
  import NavigationBar from './components/NavigationBar.vue';
  import { ref } from 'vue';

  const receivedText = ref([]);

  const handleSendText = (text) => {
    // console.log('recibidos desde app 💀💀💀', text);
    receivedText.value = text;
  }
  </script>

<style>
#app {
  background-color: honeydew;
}
</style>
