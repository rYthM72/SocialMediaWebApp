<template>
    <q-layout>
        <q-page-container>
            <q-page class="flex flex-center">
                <q-card class="q-pa-md" style="width: 400px; max-width: 90%;">
                    <q-card-section>
                        <div class="text-h6">Sign Up</div>
                        <div class="text-subtitle2">Create a new account</div>
                    </q-card-section>

                    <q-card-section>
                        <q-form @submit="handleSignUp">
                            <q-input filled v-model="email" label="Email" type="email" dense required />
                            <q-input filled v-model="username" label="Username" dense required />
                            <q-input filled v-model="password" label="Password" type="password" dense required />
                            <p>Already have an account? <a href="src/pages/SigninPage.vue">Login Now!</a></p>
                            <q-btn type="submit" color="primary" label="Sign Up" class="q-mt-md full-width" />
                        </q-form>
                    </q-card-section>
                </q-card>
            </q-page>
        </q-page-container>
    </q-layout>
</template>

<script setup>
import { ref } from 'vue';
import { api } from 'src/boot/axios'; // Ensure axios is properly configured

// Reactive variables
const email = ref('');
const username = ref('');
const password = ref('');

// Signup handler
const handleSignUp = async (e) => {
    e.preventDefault();
    try {
        const response = await api.post('api/Account/register', {
            email: email.value,
            username: username.value,
            password: password.value,
        });

        alert('Account created successfully!');
        console.log('Response:', response.data);

        // Optionally, redirect to login page or clear the form
        email.value = '';
        username.value = '';
        password.value = '';
    } catch (error) {
        console.error('Signup failed:', error.response?.data || error.message);
        alert('Signup failed. Please try again.');
    }
};
</script>