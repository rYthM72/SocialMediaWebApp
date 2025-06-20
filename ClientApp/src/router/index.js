import { route } from "quasar/wrappers";
import {
  createRouter,
  createMemoryHistory,
  createWebHistory,
  createWebHashHistory,
} from "vue-router";
import routes from "./routes";
import { LocalStorage } from "quasar";

/*
 * If not building with SSR mode, you can
 * directly export the Router instantiation;
 *
 * The function below can be async too; either use
 * async/await or return a Promise which resolves
 * with the Router instance.
 */

export default route(function (/* { store, ssrContext } */) {
  const createHistory = process.env.SERVER
    ? createMemoryHistory
    : process.env.VUE_ROUTER_MODE === "history"
    ? createWebHistory
    : createWebHashHistory;

  const Router = createRouter({
    scrollBehavior: () => ({ left: 0, top: 0 }),
    routes,

    // Leave this as is and make changes in quasar.conf.js instead!
    // quasar.conf.js -> build -> vueRouterMode
    // quasar.conf.js -> build -> publicPath
    history: createHistory(process.env.VUE_ROUTER_BASE),
  });

  Router.beforeEach((to, from, next) => {
    // to is an object which contains the target path of where the user is navigating to.
    const isAuthenticated = !!localStorage.getItem("token"); // Check if user is logged in
    // console.log("Navigating to:", to);
    // console.log("Requires Auth:", to.meta.requiresAuth);
    // console.log("Authenticated:", isAuthenticated);
    // console.log("Token:", LocalStorage.getItem("authToken"));
    if (to.meta.requiresAuth && !isAuthenticated) {
      next("/login"); // Redirect to login page if not authenticated
    } else {
      next(); // Allow navigation
    }
  });
  return Router;
});
