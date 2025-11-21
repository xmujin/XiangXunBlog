<script setup lang="ts">
import {computed, ref} from "vue";
import XButton from "@/components/XButton.vue";

const show = ref(false)
const items = ref([
  { title: "文章列表", path: '/dashboard/list'},
  { title: "文章发布", path: '/dashboard/publish'}
])

// 根据 show 和 index 计算 transitionDelay
const getTransitionDelay = (index: number) => {
  if (show.value) {
    return (index * 0.1) + 's';  // show 为 true 时，index 小的延迟短
  } else {
    return ((items.value.length - index - 1) * 0.1) + 's';  // show 为 false 时，反转延迟
  }
};




</script>

<template>
  <div class="container">
    <div class="side-bar">
      <div class="nav-item">
        <div class="nav-title">
          <XButton id="dropbtn" @click="show = !show">
            文章管理
            <svg v-if="show" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="3773" width="200" height="200"><path d="M512 714.666667c-8.533333 0-17.066667-2.133333-23.466667-8.533334l-341.333333-341.333333c-12.8-12.8-12.8-32 0-44.8 12.8-12.8 32-12.8 44.8 0l320 317.866667 317.866667-320c12.8-12.8 32-12.8 44.8 0 12.8 12.8 12.8 32 0 44.8L533.333333 704c-4.266667 8.533333-12.8 10.666667-21.333333 10.666667z" fill="#2c2c2c" p-id="3774"></path></svg>
            <svg v-else class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="3572" width="200" height="200"><path d="M320 885.333333c-8.533333 0-17.066667-4.266667-23.466667-10.666666-12.8-12.8-10.666667-34.133333 2.133334-44.8L654.933333 512 298.666667 194.133333c-12.8-10.666667-14.933333-32-2.133334-44.8 10.666667-12.8 32-14.933333 44.8-2.133333l384 341.333333c6.4 6.4 10.666667 14.933333 10.666667 23.466667 0 8.533333-4.266667 17.066667-10.666667 23.466667l-384 341.333333c-6.4 6.4-12.8 8.533333-21.333333 8.533333z" fill="#2c2c2c" p-id="3573"></path></svg>
          </XButton>
        </div>
        <TransitionGroup name="list" tag="ul" id="list">
          <li v-for="(item, index) in items"  v-show="show" :key="item.title" :style="{ transitionDelay: getTransitionDelay(index) }">
            <RouterLink :to="item.path">{{ item.title }}</RouterLink>
          </li>
        </TransitionGroup>
      </div>
    </div>

    <div class="main">
      <RouterView />
    </div>
  </div>
</template>

<style scoped>
.container {
  height: 100vh;
  display: grid;
  grid-template-columns: 250px auto;
}

.side-bar {
  background-color: lightslategray;
}

.main {
  padding: 20px;
}

.nav-item {
}

#list {
  color: #e2e2e2;
}

#list > li {
  background-color: #8b9fb3;
  padding: 8px;
}
#dropbtn {
  display: flex;
  justify-content: space-between;
  width: 100%;
  border-radius: 0px;
}

.list-enter-active {
  transition: all 0.3s ease;
}
.list-leave-active {
  transition: all 0.1s ease;
}


.list-enter-from,
.list-leave-to {
  opacity: 0;
}

.icon {
  width: 20px;
  height: 20px;
}

</style>
