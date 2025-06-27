<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-100">
    <div class="w-full max-w-md bg-white rounded-lg shadow-md p-8">
      <h2 class="text-2xl font-bold mb-6 text-center">Login</h2>
      <form @submit.prevent="handleLogin">
        <div class="mb-4">
          <q-input
            v-model="username"
            label="Username"
            outlined
            dense
            required
            :disable="loading"
            class="mb-2"
            placeholder="Enter your username"
            autofocus
          />
        </div>
        <div class="mb-6">
          <q-input
            v-model="password"
            label="Password"
            type="password"
            outlined
            dense
            required
            :disable="loading"
            class="mb-2"
            placeholder="Enter your password"
          />
        </div>
        <div v-if="error" class="mb-4 text-red-500 text-sm text-center">
          {{ error }}
        </div>
        <div class="flex items-center justify-between">
          <q-btn
            type="submit"
            color="primary"
            label="Login"
            :loading="loading"
            class="w-full"
            unelevated
          />
        </div>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { api } from 'src/boot/axios'

const username = ref('')
const password = ref('')
const error = ref('')
const loading = ref(false)
const router = useRouter()

const handleLogin = async () => {
  error.value = ''
  loading.value = true
  try {
    const response = await api.post('login', {
      username: username.value,
      password: password.value
    })
    router.push('/')
  } catch (err) {
    error.value = err.response?.data?.message || 'Login failed. Please try again.'
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
</style>
