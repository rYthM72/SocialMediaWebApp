import { defineStore } from "pinia";
import { api } from "src/boot/axios";

export const useCounterStore = defineStore("counter", {
  state: () => ({
    token: localStorage.getItem("token"),
    user: "",
  }),

  getters: {
    doubleCount(state) {
      return state.counter * 2;
    },
    getUserInfo() {
      return {
        token: this.token,
        user: this.user,
      };
    },
  },

  actions: {
    increment() {
      this.counter++;
    },
    async loginStore(user) {
      try {
        var response = await api.post("api/Account/login", user);
        const token = response.data.token;
        localStorage.setItem("token", token);
        api.defaults.headers.common["Authorization"] = `Bearer ${token}`;
      } catch (ex) {
        localStorage.removeItem("token");
        console.error(Error);
        delete api.defaults.headers.common["Authorization"];
      }
    },
  },
});
