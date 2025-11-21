<script setup lang="ts">

import XCard from "@/components/XCard.vue";
import XInput from "@/components/XInput.vue";
import XForm from "@/components/XForm.vue";
import XLabel from "@/components/XLabel.vue";
import XButton from "@/components/XButton.vue";
import { useAuthStore } from "@/stores/auth.ts"
import { useRouter } from 'vue-router'

import {ref} from "vue";

const username = ref("");
const password = ref("");

const auth = useAuthStore()
const router = useRouter()
const onSubmit = async () => {
  const response = await fetch("https://localhost:7064/api/User/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      username: username.value,
      password: password.value,
    })
  });

  if(response.status == 200) {
    const res = await response.json();
    auth.setToken(res.token);
    // 切换路由
    router.push("/dashboard");
  } else {
    alert("Login failed.");
  }



}



</script>

<template>

  <div class="bg">
    <XCard class="login">
      <template #header>
        <h2>登录</h2>
      </template>
      <template #main>
        <XForm class="login-form" @submit.prevent="onSubmit">
          <XLabel for="username">用户名</XLabel>
          <XInput v-model="username" type="text" id="username" name="username" class="input-login" placeholder="请输入用户名" />
          <XLabel for="password">密码</XLabel>
          <XInput v-model="password" type="password" id="password" name="password" class="input-login" placeholder="请输入密码" />
          <XButton>登录</XButton>

        </XForm>
      </template>>
      <template #footer>
      </template>>
    </XCard>

  </div>






</template>





<style scoped>



.bg {
  background-color: #b4e8dc;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
}

.login {
  width: 400px;
  height: 300px;
}

.input-login {
  width: 250px;
  height: 33px;
  padding: 12px;
}

#username {
  font-size: 17px;
}

#password {
  letter-spacing: 5px;
  font-size: 17px;
}

</style>
