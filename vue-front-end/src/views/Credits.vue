<template>
    <v-app>
        <navigation-bar></navigation-bar>
        <v-container fluid grid-list-lg>
            <v-layout align-center wrap>
                <v-flex xs6 v-for="dev in devInfo" :key="dev.id">
                    <v-card justify-center>
                        <v-card-title class="headline">{{dev.name}}</v-card-title>
                        <v-card-text class="align-left subheading font-weight-thin">Major: {{dev.major}}</v-card-text>
                        <v-card-text class="align-left subheading font-weight-thin">Team: {{dev.team}}</v-card-text>
                        <v-card-text class="align-left subheading font-weight-thin">Active: {{dev.active}}</v-card-text>
                        <v-card-text class="align-left subheading font-weight-thin">What I enjoyed working on: {{dev.work}}</v-card-text>
                        <v-card-text class="align-left subheading font-weight-thin">One of the most interesting parts of the project was: {{dev.liked}}</v-card-text>
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
    name: "Credits",
    components: {
        NavigationBar
    },
    data() {
        return {
            devInfo: [
                {
                    name: "Alyssa McDevitt",
                    major: "Computer Science",
                    team: "Mobile Application",
                    active: "Fall 2020",
                    work: "The mobile application",
                    liked: "Working with AWS, learning the quirks of React Native, learning more about astronomy"
                },
                {
                    name: "Andrew Georgiou",
                    major: "Computer Sciennce",
                    work: "Control Room",
                    liked: "Control Room"
                },
                {
                    name: "Anthony Beddia",
                    major: "Computer Sciennce",
                    work: "I really enjoyed working on the celestial body and horizon check implementation.",
                    liked: " I think the most interesting part of the project was getting to work in a real world environment with actual clients."
                },
                {
                    name: "Chris Garrety",
                    major: "Computer Science",
                    work: "Alpha Centauri",
                    liked: "Alpha Centauri"
                },
                {
                    name: "Cody Spath",
                    major: "Computer Science",
                    work: "Liked integration between the back-end, front-end and control room, as well as learning about deploying an application to production",
                    liked: "learning about and incorporating new technologies"
                },
                {
                    name: "Dakota Hilbert",
                    major: "Computer Science",
                    work: "Web Front End Development",
                    liked: "Learning Vue.js, Node.js and working on a large team."
                },
                {
                    name: "Dan Palmieri",
                    major: "Computer Science",
                    work: "I would say my favorite part was working on autonomous scripts like Snow Dump & Custom Orientation Movement.",
                    liked: "An interesting part was learning about JSON to write the config file & script for the control room to run specific telescopes from the database."
                },
                {
                    name: "Darin Gordon",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "David Henry",
                    major: "Computer Science",
                    work: "Liked playing with the scale model Radio Telescope",
                    liked: "being able to work on a great project with amazing people"
                },
                {
                    name: "David McHugh",
                    major: "Computer Science",
                    work: "It's been a great experience being able to work on this team of talented programmers. I loved working on the control room but most specifically implementing the sensor network features.",
                    liked: "It was really interesting learning how much work all teams need to put in for the simplest task to become a feature."
                },
                {
                    name: "Derek McClellan",
                    major: "Computer Science",
                    work: "Liked learning Vue.js and the instant gratification that comes with web development",
                    liked: "leading a team of talented people to work towards deployment and integration"
                },
                {
                    name: "Devin Retzlaff",
                    major: "Computer Science",
                    work: "The user interface",
                    liked: "Working on a project in which I had a lot of helpful previous work experience"
                },
                {
                    name: "Ed Nardo",
                    major: "Computer Science",
                    work: "The mobile application",
                    liked: "_"
                },
                {
                    name: "Ezra Moore",
                    major: "Computer Science/The Spice™",
                    work: "Liked working with the Hololens and HTC Vive",
                    liked: "Making the telescope fly..."
                },
                {
                    name: "Felix Diaz",
                    major: "Computer Engineering",
                    work: "Liked working on the virtual reality telescope and planetarium, as well as creating the automated movement in C#",
                    liked: "Creating technology that can introduce people to the joys of radio astronomy and making Kerry's dreams come true"
                },
                {
                    name: "Garrett Ruths",
                    major: "Computer Science",
                    work: "Liked learning in the unity engine, despite the headaches it caused",
                    liked: "being able to work in a large scale team environment"
                },
                {
                    name: "Greg Plachno",
                    major: "Computer Science",
                    work: "Simulation",
                    liked: "nModBus4"
                },
                {
                    name: "Jacob Majeski",
                    major: "Computer Science",
                    work: "Alpha Centauri",
                    liked: "Alpha Centauri"
                },
                {
                    name: "Jacob Minor",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Jason Constantine",
                    major: "Computer Science",
                    work: "The mobile application",
                    liked: "Learning a new language and learning about API's"
                },
                {
                    name: "Jason Pierpont",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Jason Porter",
                    major: "Computer Science",
                    work: "Liked developing a C# application that connects the internet to the hardware",
                    liked: "Implementing his team's work in iterative development cycles"
                },
                {
                    name: "Jessie Furey",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Joel Horne",
                    major: "Computer Science",
                    work: "The backend application",
                    liked: "Being thrown into a project I knew nothing about written in a language I didn't know running in an almost esoteric framework and climbing my way out."
                },
                {
                    name: "Jon Myer",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Jonathan Steck",
                    major: "Computer Science",
                    work: "What I liked the most about working on the radio telescope project was being given the chance to work on something I've never worked on before. Before I joined the team I had zero knowledge about C# or Unity, but despite that I was given the opportunity to learn about these things and contribute to the project while I did.",
                    liked: "Being able to work on something for a massive project that you have zero experience in isn't something you'd expect to have happen out in the real world, but here at York College I was given that opportunity to prove myself, and I believe that the opportunity to self-teach how to work on a complex project like this will be greatly beneficial going forward."
                },
                {
                    name: "Joseph Hopkins",
                    major: "Computer Science",
                    work: "Liked developing the UI/UX of the application",
                    liked: "Being immersed in new and interesting technologies"
                },
                {
                    name: "Joseph Landau",
                    major: "Computer Science",
                    work: "The backend application and infrastructure",
                    liked: "Working with the other developers and setting up the control room server"
                },
                {
                    name: "Joshua Sowa",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Karl Andrand",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Kate Kennelly",
                    major: "Computer Science and Mathematics",
                    work: "Control Room Application",
                    liked: "Being able to see each step of the process from end to end and understanding how it all works together"
                },
                {
                    name: "Kyle Eidson",
                    major: "Computer Science",
                    work: "Control room application",
                    liked: "Integrating the project with a multitude of other systems and seeing them all interact"
                },
                {
                    name: "Logan Ferree",
                    major: "Computer Science",
                    work: "Liked learning about Kotlin for the back-end software, and being able to break 75% of the unit tests",
                    liked: "learning new technologies and working on a large project"
                },
                {
                    name: "Lucas Gartrell",
                    major: "Computer Science",
                    work: "Back-End",
                    liked: "Working in a team environment"
                },
                {
                    name: "Marcos Rivera",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Marie Kiley",
                    major: "Computer Science",
                    work: "Web front end development, focusing on extending appointment functionality",
                    liked: "Being part of something big, working with a large team, and succeeding at difficult objectives"
                },
                {
                    name: "Nick Vandemark",
                    major: "Computer Engineering/Computer Science",
                    work: "Liked integrating the control room software with all the hardware",
                    liked: "working with a bunch of smart people"
                },
                {
                    name: "Nolan Hamilton",
                    major: "Computer Science",
                    work: "Web front end development, focusing on administrator pages",
                    liked: "Learning Vue.js, Node.js, and back end API integration"
                },
                {
                    name: "Patrick Nelson",
                    major: "Computer Science",
                    work: "Control room, main focus on overrides",
                    liked: "Learning the control room software, troubleshooting, and working with an awesome team"
                },
                {
                    name: "Philip Nelson",
                    major: "",
                    work: "",
                    liked: ""
                },
                {
                    name: "Quintin Herb",
                    major: "Computer Science",
                    work: "Back-end, AWS",
                    liked: "Working with the team and having a great deal of responsibility"
                },
                {
                    name: "Rathana Pim",
                    major: "Computer Science",
                    work: "Liked learning Kotlin and improving copying and pasting skills",
                    liked: "Working with great people and in multiple teams"
                },
                {
                    name: "Richard Hopkins",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Thomas Albert",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Travis Jones",
                    major: "Computer Engineering",
                    work: "Liked working on the control room software",
                    liked: "the interdisciplinary coordination"
                },
                {
                    name: "Vincent Maresca",
                    major: "Computer Science",
                    work: "Back-end",
                    liked: "I enjoyed learning how all of the parts would work together and getting to know how to use Postman."
                },
                {
                    name: "William Taylor",
                    major: "_",
                    work: "_",
                    liked: "_"
                },
                {
                    name: "Zack Henry",
                    major: "Computer Science",
                    work: "Liked implementing multiple appointment types on the front-end",
                    liked: "Getting to know and work with some really cool people"
                },
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
