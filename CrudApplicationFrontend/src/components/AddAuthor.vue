<template>
    <form @submit.prevent="addAuthor">
      <input v-model="firstName" placeholder="Add author first name here" />
      <input v-model="lastName" placeholder="Add author last name here" />
      <input v-model="email" placeholder="Add author email here" />
      <input v-model="quote" placeholder="Add author quote here" />
      <button type="submit">Submit</button>
    </form>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        author: {},
        authorId: null,
        firstName: null,
        lastName: null,
        email: null,
        quote: null,
        ApiBase: import.meta.env.VITE_APP_ROOT_API
      };
    },
    methods: {
      async addAuthor() {
        try {
          const response = await axios.post(this.ApiBase + 'Author/CreateAuthor', {
            FirstName: this.firstName,
            LastName: this.lastName,
            Email: this.email,
            Quotes: this.quote,
          });
  
          this.author = response.data;
          this.firstName = null;
          this.lastName = null;
          this.email = null;
          this.quote = null;
        } catch (error) {
          console.error('Error adding author:', error);
        }
      },
    },
  };
  </script>
  