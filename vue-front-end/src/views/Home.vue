<template>
  <div id="background" :style="{'background-image':'url(https://images.pexels.com/photos/110854/pexels-photo-110854.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260)'}">
    <navigation-bar class="nav-style"></navigation-bar>
      
    <v-spacer></v-spacer>
    <v-card>
      <v-img
        src="https://media.istockphoto.com/photos/telescope-picture-id512605413?k=6&m=512605413&s=612x612&w=0&h=3qyaXj4JJOAY1hjNszpp5SCQFY3SUldFzervpQWz0gQ="
        height="200px"
      >
      </v-img>

      <v-card-title primary-title>
        <div style="padding: 25px;">
          <div class="headline">Welcome to the York County Astronomical Society Radio Telescope!</div>
          <v-card-text class="grey--text">The York County Astronomical Society, Inc, is a non-profit organization dedicated to the advancement of the science of astronomy.

          The York County Astronomical Society was started in 1989, and currently has about 30 members in 4 counties in Pennsylvania.

          The Society also has special programs to showcase eclipses, meteor showers, comets, and other special events.

          The Society operates the York Learning Center Planetarium bringing astronomy to the public, presenting astronomical shows and related astronomy programs of the night sky.

          The Society hosts numerous groups for private star parties, from Boy and Girl Scout troops, church groups, school classes, and company groups. We also hold two Introduction to Astronomy classes each year.

          The Society owns 6 optical telescopes:

          An 18” Dobsonian,
          a 14” Dobsonian and a 12” Computerized GoTo Telescope,
          a 10” SCT Telescope,
          a 4.5” Newtonian Telescope,
          and a 4” Astro-Physics Refractor Telescope
          </v-card-text>
        </div>
      </v-card-title>
    </v-card>

    <v-card color="indigo darken-2">
      <v-card-title style="padding: 15px;" class="justify-center headline">
          Here are some pictures of various aspects of the radio telescope
      </v-card-title>
    </v-card>

    <v-container fluid grid-list-lg v-if="approvedPicturesRetrieved">
      <v-layout align-center wrap>
          <v-flex xs4 v-for="approvedFrontpagePicture in approvedFrontpagePictures" :key="approvedFrontpagePicture.id">
              <v-card dark class="ma-1 pa-2" color="rgb(64, 64, 64, 0.2)">
                <v-img height="500px" :src="approvedFrontpagePicture.pictureUrl" contain="true"></v-img>
                <v-card-text class="white--text font-weight-bold">
                  Title: {{ approvedFrontpagePicture.pictureTitle }}
                </v-card-text>
                <v-divider></v-divider>
                <v-card-text class="white--text font-weight-bold">
                  Description: {{ approvedFrontpagePicture.description }}
                </v-card-text>
              </v-card>
          </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
import NavigationBar from "../components/utility/NavigationBar.vue";
import ApiDriver from "../ApiDriver";
import router from '../router';
import HttpResponse from '../utils/HttpResponse';
import { error } from 'util';
export default {
  title: "Radio Telescope 1.1.0",
  name: "Home",
  data() {
    return {
      approvedFrontpagePictures: [
        //   { id: 1, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
        //   { id: 2, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
        //   { id: 3, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
      ],
      approvedPicturesRetrieved: false,

      // imported data
      dbData: [
      ],

      show: false
    };
  },
  components: {
    NavigationBar
  },
  methods: {
      handleLoggedIn() {
        // Call the auth api endpoint so we can populate
        // the Vue store with user information
        ApiDriver.Auth.User(this.$store.state.token).then((response) => {
          HttpResponse.then(response, (data) => {
            // Commit the data to the store and update the vue app
            this.$store.commit("login", data.data);
            this.$forceUpdate();
          }, (status, errors) => {
            // Handle if the user logging in has an inactive/disabled account
            this.handleAccountDisabled(errors)
          })
        });
      },
      handleAccountDisabled(errors) {
        let message = "";

        // There will only ever be one error in this scenario
        for (var index in errors) {
          message = errors[index][0]
        }

        // Display the error message in an alert
        this.$swal({
          title: '<span style="color:#f0ead6">Error!</span>',
          html: '<span style="color:#f0ead6">' + message + '</span>',
          type: 'error',
          background: '#302f2f'
        }).then(response => {
            router.push('/login')
        });
      },
      retrieveApprovedFrontpagePictures() {
        // Make the API call
        console.log("retrieving approved front page pictures" );
        ApiDriver.FrontpagePictures.retrieveApproved().then((response) => {
            // Handle the server response
            HttpResponse.then(response, (data) => {
                // Populate the data and set the store's boolean back to false
                console.log("Data Returned: " + JSON.stringify(data.data));  // Logging for debugging purposes
                this.setApprovedFrontpagePictures(data.data);
                this.$store.commit("loading", false)
            }, (status, errors) => {
                // Access Denied
                if (parseInt(status) === 403) {
                    // Call the generic access denied handler
                    HttpResponse.accessDenied(this);
                    console.log("access denied");
                } 
                // Not Found
                else if (parseInt(status) === 404) {
                    // Call the generic invalid resource id handler
                    HttpResponse.notFound(this, errors);
                }
            })
        })
      },
      setApprovedFrontpagePictures(dbData) {
        console.log(this.approvedFrontpagePictures);     
        for(var dbIndex in dbData) {                                                             // iterate over all approved frontpage pictures retrieved from database
            this.approvedFrontpagePictures[dbIndex] = dbData[dbIndex];                                 // set the approved frontpage picture from the database in list on front end
            console.log("Successfully set an approved frontpage picture!");
        
        }
        console.log("Successfully set approved frontpage pictures!");
        this.approvedPicturesRetrieved = true;
        console.log(this.approvedFrontpagePictures);                                                                                                                                                     
      },
  },
  mounted() {
    // Handle the log in when the DOM is loaded
    this.handleLoggedIn();
    this.$store.commit("updateInfo", {page: "Home", info: "Welcome to the York County Astronomical Society\n Radio Telescope application!"})
    this.retrieveApprovedFrontpagePictures();
  }
};
</script>

<style scoped>
#background {
  height: 100%;
  background-size: cover;
}

.nav-style {
  margin-left: -1rem;
  margin-right: -1rem;
}
</style>