<script setup>
import Header from './components/Header.vue'
import AllAuthor from './components/AllAuthors.vue'
import AuthorById from './components/AuthorById.vue'
import AddAuthor from './components/AddAuthor.vue'
import DeleteAuthorById from './components/DeleteAuthorById.vue'
</script>

<template>
  <header>
    <div class="wrapper">
      <h1>Hello world</h1>
      <Header/>
      <AllAuthor/>
      <AuthorById/>
      <AddAuthor/>
      <DeleteAuthorById/>
    </div>
  </header>

  <body>
  </body>
</template>
