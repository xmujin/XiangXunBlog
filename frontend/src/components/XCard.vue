<script setup lang="ts">

</script>

<template>
<!--card 组件-->
  <div class="card">
    <header>
      <slot name="header"></slot>
    </header>
    <main>
      <slot name="main"></slot>
    </main>
    <footer>
      <slot name="footer"></slot>
    </footer>
  </div>

</template>

<style scoped>

.card {
  background-color: #e2e2e2;
  border-radius: 20px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  box-sizing: border-box;
  padding: 20px;
  display: flex;
  flex-direction: column;
}

.card > header {
  display: flex;
  justify-content: center;
}


.card > main {
  display: flex;
  flex-direction: column;
  align-items: center;
}


</style>
