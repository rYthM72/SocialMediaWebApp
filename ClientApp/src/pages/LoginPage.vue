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
                        <q-form @submit="onLogin">
                            <q-input filled v-model="user.username" label="Username" dense required />
                            <q-input filled v-model="user.password" type="password" label="Password" dense required />
                            <p>Don't have an account? <a href="#">Register Now!</a></p>
                            <q-btn type="submit" color="primary" label="Login" class="q-mt-md full-width" />
                        </q-form>
                    </q-card-section>
                </q-card>
            </q-page>
        </q-page-container>
    </q-layout>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import { useCounterStore } from 'stores/auth.js'
import { useMeta } from 'quasar'


const username = ref('');
const password = ref('');
const user = ref({
    username: null,
    password: null,
})

const store = useCounterStore();

useMeta({
  title: 'SEO.title',
  meta: [
    { name: 'description', content: 'asdadsaaaaaaaadddddddddddddddd' },
    { property: 'og:title', content: 'hello' },
    { property: 'og:description', content: 'safasadssssssssssssssssssssssssssssaaaaaaaaaaa' },
    { property: 'og:image', content: 'https://cdn.quasar.dev/img/mountains.jpg' },
    { property: 'og:url', content: 'www.inqr.com.np' },
    { property: 'og:type', content: 'website' }
  ]
})
async function onLogin() {
    await store.loginStore({
        username: user.value.username,
        password: user.value.password,
    });
}
</script>