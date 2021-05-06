<template>
<div>
    <navigation-bar class="nav-style"></navigation-bar>
        <v-layout align-center>
            <v-card>
            <v-card-title primary-title>
              <div style="padding: 25px;">
                
                <v-card>
                  <div style="padding: 25px;">
                    <div class="headline">Here are some pictures of various aspects of the radio telescope </div>
                  </div>
                </v-card>
                <v-container grid text-xs-center v-if="approvedPicturesRetrieved">
                  <div v-for="approvedFrontpagePicture in approvedFrontpagePictures" :key="approvedFrontpagePicture.id">
                    <v-card dark class="ma-1 pa-2" max-width="600px">
                      <v-img height="500px" :src="approvedFrontpagePicture.pictureUrl" contain="true"></v-img>
                      <v-card-text class="grey--text">
                        Title: {{ approvedFrontpagePicture.pictureTitle }}
                      </v-card-text>
                      <v-divider></v-divider>
                      <v-card-text class="grey--text">
                        Description: {{ approvedFrontpagePicture.description }}
                      </v-card-text>
                    </v-card>
                  </div>
                </v-container>
              </div>
            </v-card-title>
            <v-footer padless height="40px" fixed="true">
                <v-card-text class="grey--text">
                  York County Astronomical Society
                </v-card-text>
            </v-footer>
            </v-card>
        </v-layout>
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
  name: "Gallery",
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
      ]
    };
  },
  components: {
    NavigationBar
  },
  methods: {
      submit() {
          router.push("/login");
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
  created() {
      this.retrieveApprovedFrontpagePictures();
  },
  mounted() {
   
  },
};
</script>

<style scoped>
#parallax-wrap {
  height: 100%
}

.nav-style {
  margin-left: -1rem;
  margin-right: -1rem;
}
</style>