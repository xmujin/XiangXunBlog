import { createRouter, createWebHistory } from 'vue-router'
import Login from "@/pages/Login/Login.vue";
import DashboardHome from "@/pages/Dashboard/Home/DashboardHome.vue";
import {useAuthStore} from "@/stores/auth.ts";
import DashboardLayout from "@/layouts/DashboardLayout.vue";
import PostList from "@/pages/Dashboard/Post/PostList.vue";
import PostPublish from "@/pages/Dashboard/Post/PostPublish.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', redirect: '/dashboard' },
    { path: '/login', component: Login },
    {
      path: '/dashboard',
      component: DashboardLayout,
      meta: { requiresAuth: true },
      children: [
        { path: '', component: DashboardHome },
        { path: 'list', component: PostList },
        { path: 'publish', component: PostPublish },

      ]
    }
  ]
})

router.beforeEach(async (to, from) => {
  const auth = useAuthStore();
  if (to.meta.requiresAuth && !auth.isLoggedIn) {
    return "/login";
  }
})

export default router
