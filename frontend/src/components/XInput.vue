<script setup lang="ts">
const model = defineModel()


</script>

<template>
  <input v-model="model" />
</template>

<style scoped>

input {
  box-sizing: border-box;
  padding: 12px 10px;
  border-radius: 4px;
  border: 3px solid #a1c8e6;
  outline: none;
  transition: 0.3s;
}

input:focus {
  border: 2px solid #57aef1;
}


</style>
