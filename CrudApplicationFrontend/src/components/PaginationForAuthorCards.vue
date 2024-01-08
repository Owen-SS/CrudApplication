<template>
    <div>
      <h1>Pagination</h1>
      <div class="author">
        <div v-for="author in authors" :key="author.id">
            <div class="author-container">
                <p>{{ author.firstName }}</p>
                <p>{{ author.lastName }}</p>
                <p>{{ author.email }}</p>
                <p>{{ author.quote }}</p>
            </div>
        </div>
      </div>
      <button @click="fetchAuthors">Load More</button>
      <button @click="previousAuthors"> Previous </button>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        authors: [],
        pageSize: 5,
        pageNumber: 0,
        totalPages: 0,
        totalCards:0,
        ApiBase:import.meta.env.VITE_APP_ROOT_API,
      };
    },
    mounted() {
      this.fetchAuthors();
    },
    methods: {
      async fetchAuthors() {
        try {
            this.pageNumber++;
            const response = await axios.get(this.ApiBase + `Pagination/GetAllAuthors?pageNumber=${this.pageNumber}&pageSize=${this.pageSize}`);
          
          if (response.data && response.data.authors.length > 0) {
            this.authors = response.data.authors;
          }
        } catch (error) {
        }
      },
      async previousAuthors() {
        try {
          if(this.pageNumber > 0){
            this.pageNumber --;
            const response = await axios.get(this.ApiBase + `Pagination/GetAllAuthors?pageNumber=${this.pageNumber}&pageSize=${this.pageSize}`);
            if (response.data && response.data.authors.length > 0){
              this.authors = response.data.authors;
            }
          }
        } catch (error) {
          console.log('Error fetching previous authors:', error);
        }
        },
    },
  };
  </script>

<style>
.author{    
    display: grid;
    grid-template-columns: repeat(3, 250px);
    grid-auto-rows: auto;
    grid-gap: 1rem;
    width: 100%;
}

.author-container{
    width: 200px;
    display: flex;
    flex-direction: column;
    background-color: orange;
    border-radius: 10px;
}
</style>
  