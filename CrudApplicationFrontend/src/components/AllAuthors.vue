<template>
    <div v-if="Authors">{{ Authors }}</div>
</template>

<script>
import axios from 'axios';
import.meta.env

export default {
    data() {
        return {
            Authors: null,
            ApiBase:import.meta.env.VITE_APP_ROOT_API
        }
    },
    mounted() {
        this.GetAuthors();
    },
    methods: {
        async GetAuthors() {
            try {
                const response = await axios.get(this.ApiBase + 'Author/GetAuthors', {
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
