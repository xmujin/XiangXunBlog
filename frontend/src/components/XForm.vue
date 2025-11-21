<script setup lang="ts">

</script>

<template>
  <form action="">
    <slot></slot>
  </form>
</template>

<style scoped>

form {
  display: flex;
  flex-direction: column;
  gap: 10px;
  padding: 20px;
}

</style>
