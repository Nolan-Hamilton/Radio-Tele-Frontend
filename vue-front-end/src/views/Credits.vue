<template>
    <v-app>
        <navigation-bar></navigation-bar>
       
        <v-card>
            <v-card-title style="padding: 25px;" class="justify-center headline font-weight-bold">
                Thanks to all of the members of the software and hardware teams that made this project a success.
            </v-card-title>
        </v-card>

        <v-container fluid grid-list-lg>
            <v-layout align-center wrap>
                <v-flex xs2 v-for="dev in devInfo" :key="dev.id">
                    <v-card justify-center height="100%">
                        <v-card-title class="headline font-weight-bold">{{dev.name}}</v-card-title>
                        <v-divider></v-divider>
                        <v-card>
                            <div v-if="dev.pictureUrl == null">
                                <v-avatar size = "150">
                                    <img id="defaultPicture" class="pa-2" src="https://quintinherb.net/images/selfie.jpg" alt="Not found">
                                </v-avatar> 
                            </div>
                            <div v-else>
                                <v-avatar size = "150">
                                    <img id="creditPicture" class="pa-2" :src="dev.pictureUrl" alt="Not found">
                                </v-avatar> 
                            </div>
                        </v-card>
                        <v-card>
                            <v-card-text class="align-left subheading font-weight-thin">Major: {{dev.major}}</v-card-text>
                            <v-card-text class="align-left subheading font-weight-thin">Team: {{dev.team}}</v-card-text>
                            <v-card-text class="align-left subheading font-weight-thin">Active: {{dev.active}}</v-card-text>
                            <v-card-text class="align-left subheading font-weight-thin">What I enjoyed working on: {{dev.work}}</v-card-text>
                            <v-card-text class="align-left subheading font-weight-thin">One of the most interesting parts of the project was: {{dev.liked}}</v-card-text>
                        </v-card>
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
                    pictureUrl: "https://toppng.com/uploads/preview/instagram-default-profile-picture-11562973083brycehrmyv.png",
                    major: "Computer Science",
                    team: "Mobile Application",
                    active: "Fall 2019 - Spring 2020",
                    work: "The mobile application",
                    liked: "Working with AWS, learning the quirks of React Native, learning more about astronomy"
                },
                {
                    name: "Andrew Georgiou",
                    pictureUrl: null,
                    major: "Computer Sciennce",
                    team: "Control Room",
                    active: "Spring 2020 - Fall 2020",
                    work: "Control Room",
                    liked: "Control Room"
                },
                {
                    name: "Anthony Beddia",
                    pictureUrl: null,
                    major: "Computer Sciennce",
                    team: "Front-End",
                    active: "Spring 2021",
                    work: "I really enjoyed working on the celestial body and horizon check implementation.",
                    liked: " I think the most interesting part of the project was getting to work in a real world environment with actual clients."
                },
                {
                    name: "Chris Garrety",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "",
                    active: "",
                    work: "Alpha Centauri",
                    liked: "Alpha Centauri"
                },
                {
                    name: "Cody Spath",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "",
                    active: "",
                    work: "Liked integration between the back-end, front-end and control room, as well as learning about deploying an application to production",
                    liked: "learning about and incorporating new technologies"
                },
                {
                    name: "Dakota Hilbert",
                    pictureUrl: "https://images2.minutemediacdn.com/image/upload/c_crop,h_843,w_1500,x_0,y_10/v1555172614/shape/mentalfloss/iStock-177369626_1.jpg?itok=YfyNMOBR",
                    major: "Computer Science",
                    team: "Front-End",
                    active: "Spring 2020 - Fall 2020 - Spring 2021",
                    work: "Different front-end issues such as sensors, pictures, user management, and interface design",
                    liked: "I found the project to be a very valuable experience in learning real world development skills as part of a large team with multiple software sub-teams and a hardware team"
                },
                {
                    name: "Dan Palmieri",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Control Room",
                    active: "Spring 2021",
                    work: "I would say my favorite part was working on autonomous scripts like Snow Dump & Custom Orientation Movement.",
                    liked: "An interesting part was learning about JSON to write the config file & script for the control room to run specific telescopes from the database."
                },
                {
                    name: "Darin Gordon",
                    pictureUrl: null,
                    major: "Mechanical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Structural Assemblies",
                    liked: "Oppurtunity to design and execute a large scale project as well as gaining experience machining"
                },
                {
                    name: "David Henry",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "",
                    active: "",
                    work: "Liked playing with the scale model Radio Telescope",
                    liked: "being able to work on a great project with amazing people"
                },
                {
                    name: "David McHugh",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Control Room",
                    active: "Spring 2021",
                    work: "It's been a great experience being able to work on this team of talented programmers. I loved working on the control room but most specifically implementing the sensor network features.",
                    liked: "It was really interesting learning how much work all teams need to put in for the simplest task to become a feature."
                },
                {
                    name: "Derek McClellan",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Front-End",
                    active: "",
                    work: "Liked learning Vue.js and the instant gratification that comes with web development",
                    liked: "leading a team of talented people to work towards deployment and integration"
                },
                {
                    name: "Devin Retzlaff",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Front-End",
                    active: "Fall 2019",
                    work: "The user interface",
                    liked: "Working on a project in which I had a lot of helpful previous work experience"
                },
                {
                    name: "Ed Nardo",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Mobile Application",
                    active: "Fall 2019",
                    work: "The mobile application",
                    liked: "applying computers to astronomy"
                },
                {
                    name: "Ezra Moore",
                    pictureUrl: null,
                    major: "Computer Science/The Spice™",
                    team: "",
                    active: "",
                    work: "Liked working with the Hololens and HTC Vive",
                    liked: "Making the telescope fly..."
                },
                {
                    name: "Felix Diaz",
                    pictureUrl: null,
                    major: "Computer Engineering",
                    team: "VR/AR",
                    active: "",
                    work: "Liked working on the virtual reality telescope and planetarium, as well as creating the automated movement in C#",
                    liked: "Creating technology that can introduce people to the joys of radio astronomy and making Kerry's dreams come true"
                },
                {
                    name: "Garrett Ruths",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "VR/AR",
                    active: "",
                    work: "Liked learning in the unity engine, despite the headaches it caused",
                    liked: "being able to work in a large scale team environment"
                },
                {
                    name: "Greg Plachno",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "VR/AR",
                    active: "Fall 2019 - Spring 2020",
                    work: "Simulation",
                    liked: "nModBus4"
                },
                {
                    name: "Jacob Majeski",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "",
                    active: "",
                    work: "Alpha Centauri",
                    liked: "Alpha Centauri"
                },
                {
                    name: "Jacob Minor",
                    pictureUrl: null,
                    major: "Electrical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "electrical design, low level software drivers",
                    liked: "the integration between multiple large teams of engineers"
                },
                {
                    name: "Jason Constantine",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Mobile Application",
                    active: "Fall 2019 - Spring 2020",
                    work: "The mobile application",
                    liked: "Learning a new language and learning about API's"
                },
                {
                    name: "Jason Pierpont",
                    pictureUrl: null,
                    major: "Computer Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Sensor Network",
                    liked: "Developing an embedded sensor network with a super loop software architecture"
                },
                {
                    name: "Jason Porter",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "",
                    active: "",
                    work: "Liked developing a C# application that connects the internet to the hardware",
                    liked: "Implementing his team's work in iterative development cycles"
                },
                {
                    name: "Jessie Furey",
                    pictureUrl: null,
                    major: "Mechanical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Structural Assemblies",
                    liked: "Working with a team to take 3D CAD models and help them come to life"
                },
                {
                    name: "Joel Horne",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Back-End",
                    active: "Fall 2019 - Spring 2020",
                    work: "The backend application",
                    liked: "Being thrown into a project I knew nothing about written in a language I didn't know running in an almost esoteric framework and climbing my way out."
                },
                {
                    name: "Jonathan Myer",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "VR/AR",
                    active: "Fall 2019 - Spring 2020",
                    work: "Virtual Reality",
                    liked: "Learning how to use Unity to represent what the park would look like with the telescope."
                },
                {
                    name: "Jonathan Steck",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "VR/AR",
                    active: "Fall 2020 - Spring 2021",
                    work: "What I liked the most about working on the radio telescope project was being given the chance to work on something I've never worked on before. Before I joined the team I had zero knowledge about C# or Unity, but despite that I was given the opportunity to learn about these things and contribute to the project while I did.",
                    liked: "Being able to work on something for a massive project that you have zero experience in isn't something you'd expect to have happen out in the real world, but here at York College I was given that opportunity to prove myself, and I believe that the opportunity to self-teach how to work on a complex project like this will be greatly beneficial going forward."
                },
                {
                    name: "Joseph Hopkins",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Front-End",
                    active: "",
                    work: "Liked developing the UI/UX of the application",
                    liked: "Being immersed in new and interesting technologies"
                },
                {
                    name: "Joseph Landau",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Back-End",
                    active: "Fall 2019 - Spring 2020",
                    work: "The backend application and infrastructure",
                    liked: "Working with the other developers and setting up the control room server"
                },
                {
                    name: "Joshua Sowa",
                    pictureUrl: null,
                    major: "Mechanical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Structural machining and assembly",
                    liked: "Getting to work with contractors and manage money"
                },
                {
                    name: "Karl Andrand",
                    pictureUrl: null,
                    major: "Electrical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Sensors Network, focusing on communications",
                    liked: "Learning linux and embedded systems"
                },
                {
                    name: "Kate Kennelly",
                    pictureUrl: null,
                    major: "Computer Science and Mathematics",
                    team: "Control Room",
                    active: "Fall 2019 - Spring 2020",
                    work: "Control Room Application",
                    liked: "Being able to see each step of the process from end to end and understanding how it all works together"
                },
                {
                    name: "Kyle Eidson",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Control Room",
                    active: "Fall 2019 - Spring 2020",
                    work: "Control room application",
                    liked: "Integrating the project with a multitude of other systems and seeing them all interact"
                },
                {
                    name: "Logan Ferree",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Back-End",
                    active: "",
                    work: "Liked learning about Kotlin for the back-end software, and being able to break 75% of the unit tests",
                    liked: "learning new technologies and working on a large project"
                },
                {
                    name: "Lucas Gartrell",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Back-End",
                    active: "Spring 2020 - Fall 2020 - Spring 2021",
                    work: "Back-End",
                    liked: "Working in a team environment"
                },
                {
                    name: "Madison Tibbett",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Control Room",
                    active: "Fall 2020",
                    work: "Improving push notification system and implementing email services",
                    liked: "Being a part of the team because I found it to be a valuable learning experience in working on a large project with a team."
                },
                {
                    name: "Marcos Rivera",
                    pictureUrl: null,
                    major: "Mechanical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Assembly Interfaces, Structural Design",
                    liked: "The new skills in machining learned and the oppurtunity to meet with different vendors and engineers."
                },
                {
                    name: "Marie Kiley",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Front-End",
                    active: "Fall 2019 - Spring 2020",
                    work: "Web front end development, focusing on extending appointment functionality",
                    liked: "Being part of something big, working with a large team, and succeeding at difficult objectives"
                },
                {
                    name: "Nick Vandemark",
                    pictureUrl: null,
                    major: "Computer Engineering/Computer Science",
                    team: "Control Room",
                    active: "",
                    work: "Liked integrating the control room software with all the hardware",
                    liked: "working with a bunch of smart people"
                },
                {
                    name: "Nolan Hamilton",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Front-End",
                    active: "Fall 2019 - Spring 2020",
                    work: "Web front end development, focusing on administrator pages",
                    liked: "Learning Vue.js, Node.js, and back end API integration"
                },
                {
                    name: "Patrick Nelson",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Control Room",
                    active: "Spring 2020 - Fall 2020 - Spring 2021",
                    work: "Control room, main focus on overrides",
                    liked: "Learning the control room software, troubleshooting, and working with an awesome team"
                },
                {
                    name: "Philip Norris",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Mobile Application",
                    active: "Spring 2020",
                    work: "Mobile Application",
                    liked: "The struggle of being tossed into a project I knew nothing about, but with the help of previous and current engineers I was able to learn and catch up. In addition, I enjoyed learning new and useful tools such as redux and implementing Back End API integration."
                },
                {
                    name: "Quintin Herb",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Back-End, Front-End",
                    active: "Spring 2020 - Fall 2020 - Spring 2021",
                    work: "Back-end, AWS",
                    liked: "Working with the team and having a great deal of responsibility"
                },
                {
                    name: "Rathana Pim",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Back-End",
                    active: "",
                    work: "Liked learning Kotlin and improving copying and pasting skills",
                    liked: "Working with great people and in multiple teams"
                },
                {
                    name: "Richard Hopkins",
                    pictureUrl: null,
                    major: "Mechanical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Structural elements",
                    liked: "The real world application of the design as a whole, and how it applies to machines in industry."
                },
                {
                    name: "Thomas Albert",
                    pictureUrl: null,
                    major: "Electrical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Sensor network, focusing on wiring and mounting",
                    liked: "Applying knowledge from computer science and embedded systems classes to test sensors"
                },
                {
                    name: "Travis Jones",
                    pictureUrl: null,
                    major: "Computer Engineering",
                    team: "Control Room",
                    active: "",
                    work: "Liked working on the control room software",
                    liked: "the interdisciplinary coordination"
                },
                {
                    name: "Trevor Swann",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Mobile Application",
                    active: "Fall 2020",
                    work: "Adding new UI Elements and functionality, and developing a plan along with the control room team to ensure that communication between the admin application and control room would be encrypted and secure.",
                    liked: "My favorite thing about working on the radio telescope project was seing classmates with different software specialties and interests bring all of our knowledge together on one big project."
                },
                {
                    name: "Vincent Maresca",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Back-End",
                    active: "Fall 2020 - Spring 2021",
                    work: "Back-end",
                    liked: "I enjoyed learning how all of the parts would work together and getting to know how to use Postman."
                },
                {
                    name: "William Taylor",
                    pictureUrl: null,
                    major: "Electrical Engineering",
                    team: "Hardware",
                    active: "",
                    work: "Pedestal Panel, Frame, Test Stand",
                    liked: "Learning more about PLCs and getting to fabricate parts of the project."
                },
                {
                    name: "Zack Henry",
                    pictureUrl: null,
                    major: "Computer Science",
                    team: "Front-End",
                    active: "",
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
