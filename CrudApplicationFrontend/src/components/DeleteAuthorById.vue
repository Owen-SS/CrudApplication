<template>
    <div>
      <form @submit="deleteAuthorById">
        <input v-model="AuthorId" placeholder="Delete author id" />
        <button type="submit">Submit</button>
      </form>
      <div v-if="deletionSuccess" class="success-message">
        Author successfully deleted!
      </div>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        AuthorId: null,
        deletionSuccess: false,
      };
    },
    methods: {
        deleteAuthorById() {
        console.log(this.AuthorId);
        try {
          const response = axios.delete(
            `https://localhost:44311/api/Author/DeleteAuthor/${this.AuthorId}`
          );
          if (response.status === 200) {
            this.deletionSuccess = true;
          }
        } catch (error) {
          console.error('Error deleting author:', error);
        }
      },
    },
  };
  </script>
  