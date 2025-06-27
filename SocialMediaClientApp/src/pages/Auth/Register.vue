<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-100">
    <div class="w-full max-w-md bg-white rounded-lg shadow-md p-8">
      <h2 class="text-2xl font-bold mb-6 text-center">Register</h2>
      <form @submit.prevent="handleRegister">
        <div class="mb-4">
          <q-input
            v-model="name"
            label="Name"
            outlined
            dense
            required
            :disable="loading"
            class="mb-2"
            placeholder="Enter your name"
            autofocus
          />
        </div>
        <div class="mb-4">
          <q-input
            v-model="email"
            label="Email Address"
            type="email"
            outlined
            dense
            required
            :disable="loading"
            class="mb-2"
            placeholder="Enter your email address"
          />
        </div>
        <div class="mb-4">
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
        <div class="mb-6">
          <q-input
            v-model="confirmPassword"
            label="Confirm Password"
            type="password"
            outlined
            dense
            required
            :disable="loading"
            class="mb-2"
            placeholder="Confirm your password"
          />
        </div>
        <div v-if="error" class="mb-4 text-red-500 text-sm text-center">
          {{ error }}
        </div>
        <div class="flex items-center justify-between">
          <q-btn
            type="submit"
            color="primary"
            label="Register"
            :loading="loading"
            class="w-full"
            unelevated
            :disable="loading"
          />
        </div>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { api } from 'src/boot/axios';
const name = ref('')
const email = ref('')
const password = ref('')
const confirmPassword = ref('')
const error = ref('')
const loading = ref(false)
const router = useRouter()

const handleRegister = async () => {
  error.value = ''
  if (password.value !== confirmPassword.value) {
    error.value = 'Passwords do not match.'
    return
  }
  loading.value = true
  try {
    await api.post('Auth/user-register', {
      name: name.value,
      emailAddress: email.value,
      password: password.value,
      confirmPassword: confirmPassword.value
    })
    router.push('/login')
  } catch (err) {
    error.value = err.response?.data?.message || 'Registration failed. Please try again.'
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
</style>
