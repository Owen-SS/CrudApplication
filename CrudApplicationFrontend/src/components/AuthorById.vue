<template>
    <div v-if="Author">{{ Author }}</div>
    <form @submit.prevent="getAuthorById">
      <input v-model="AuthorId" placeholder="Find author by id" />
      <button type="submit">Submit</button>
    </form>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        Author: {},
        AuthorId: null,
        ApiBase:import.meta.env.VITE_APP_ROOT_API,
      };
    },
    methods: {
      async getAuthorById() {
        try {
          const response = await axios.get(this.ApiBase + `Author/GetAuthor/${this.AuthorId}`,
            {
              headers: {
                Accept: 'application/json',
              },
            }
          );
          this.Author = response.data;
        } catch (error) {
          console.error('Error fetching author:', error);
        }
      },
    },
  };
  </script>
  