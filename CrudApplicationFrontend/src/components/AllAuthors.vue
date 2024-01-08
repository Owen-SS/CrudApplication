<template>
    <div v-if="Authors">{{ Authors }}</div>
</template>

<script>
import axios from 'axios';

export default {
    data() {
        return {
            Authors: null
        }
    },
    mounted() {
        this.GetAuthors();
    },
    methods: {
        async GetAuthors() {
            try {
                const response = await axios.get('https://localhost:44311/api/Author/GetAuthors', {
                    headers: {
                        Accept: 'application/json'
                    }
                });
                this.Authors = response.data;
            } catch (error) {
                console.error('Error fetching authors:', error);
            }
        }
    }
}
</script>
