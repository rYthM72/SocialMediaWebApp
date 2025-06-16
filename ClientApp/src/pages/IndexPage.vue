<template>
  <q-page>
    <div class="content-container">
    </div>
  </q-page>
</template>
<script setup>
import { ref, onMounted } from 'vue';
import { useMeta } from 'quasar'


const posts = ref();
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
onMounted(async () => {
  const response = await api.get("contentpost/list");
  posts.value = response.data;

});
</script>
<style scoped src="../css/indexPage.css"></style>