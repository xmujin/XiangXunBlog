import { defineStore } from 'pinia'
import {computed, ref} from "vue";
import Cookies from "js-cookie";


export const useAuthStore = defineStore('auth', () => {
  const token = ref(Cookies.get('jwt_token')|| null);

  function setToken(newToken: string) {
    token.value = newToken;
    Cookies.set('jwt_token', newToken, {
      expires: 7, // 7天过期
      path: '/',
      sameSite: 'strict'
    });
  }

  function logout() {
    token.value = null;
    localStorage.removeItem("token");
  }

  // --- getters ---
  const isLoggedIn = computed(() => !!token.value);

  return {
    token,
    setToken,
    logout,
    isLoggedIn,
  };
});
