<template>
    <v-app>
        <navigation-bar></navigation-bar>
        <v-container fluid grid-list-lg>
            <v-layout align-center wrap>
                <v-flex xs6 v-for="dev in devInfo" :key="dev.id">
                    <v-card justify-center>
                        <v-card-title class="headline">{{dev.name}} : {{dev.major}}</v-card-title>
                        <v-card-text class="align-left subheading font-weight-thin">{{dev.work}}</v-card-text>
                        <v-card-text class="align-left subheading font-weight-thin">One of the most interesting parts of the project was {{dev.liked}}</v-card-text>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
    </v-app>
</template>

<script>
import NavigationBar from "../components/utility/NavigationBar.vue";
export default {
    title: "Radio Telescope 1.1.0",
    name: "test",
    components: {
        NavigationBar
    },
    data() {
        return {
            devInfo: [
                {
                    name: "TEST",
                    major: "Testing",
                    work: "Testing",
                    liked: "Testing"
                }
            ]
        }
    },
    mounted() {
        this.$store.commit("updateInfo", {page: "Credits", info: "This page serves as a thank you to all current and former developers, both on\n the software and hardware sides of the project."})
    }
}
</script>

<style scoped>
.align-left{
    text-align: left
}
</style>
