<template>
    <q-layout>
        <q-page-container>
            <q-page class="flex flex-center">
                <q-card class="q-pa-md" style="width: 400px; max-width: 90%;">
                    <q-card-section>
                        <div class="text-h6">Login</div>
                        <div class="text-subtitle2">Enter your credentials</div>
                    </q-card-section>

                    <q-card-section>
                        <q-form @submit="handleLogin">
                            <q-input filled v-model="username" label="Username" dense required />
                            <q-input filled v-model="password" type="password" label="Password" dense required />
                            <p>Don't have an account? <a href="src/pages/SigninPage.vue">Register Now!</a></p>
                            <q-btn type="submit" color="primary" label="Login" class="q-mt-md full-width" />
                        </q-form>
                    </q-card-section>
                </q-card>
            </q-page>
        </q-page-container>
    </q-layout>
</template>

<script setup>
import { api } from 'src/boot/axios';
import { ref } from 'vue';

const username = ref('');
const password = ref('');

const handleLogin = async (e) => {
    e.preventDefault();
    try {
        const response = await api.post('api/Account/login', {
            username: username.value,
            password: password.value,
        });



        if (response.data.token) {
            // Assuming the API responds with a token
            alert('Login successful!');
            console.log('Token:', response.data.token);
            // Store token (e.g., localStorage) or navigate to another page
            localStorage.setItem('authToken', response.data.token);
        }
    } catch (error) {
        console.error('Login failed:', error.response?.data || error.message);
        alert('Invalid credentials, please try again.');
    }
};
</script>