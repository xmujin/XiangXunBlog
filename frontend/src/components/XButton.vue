<script setup lang="ts">

</script>

<template>
  <button><slot></slot></button>
</template>

<style scoped>

button {
  border: none;
  padding: 5px;
  background-color: #57aef1;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
}

button:hover {
  background-color: #5cb8ff;
}

</style>


