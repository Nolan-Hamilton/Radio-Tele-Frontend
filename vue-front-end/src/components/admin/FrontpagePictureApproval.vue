<template>
<div>
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
                  <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
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
              
              <v-card>
                  <div style="padding: 25px;">
                    <div class="headline">These pictures have not yet been approved </div>
                  </div>
              </v-card>

              <v-container grid text-xs-center v-if="picturesRetrieved">
                <div v-for="frontpagePicture in frontpagePictures" :key="frontpagePicture.id">
                  <v-card v-if="frontpagePicture.approved == 0" dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                    <v-img height="500px" :src="frontpagePicture.pictureUrl" contain="true"></v-img>
                    <v-card-text class="grey--text">
                      Title: {{ frontpagePicture.pictureTitle }}
                    </v-card-text>
                    <v-divider></v-divider>
                    <v-card-text class="grey--text">
                      Description: {{ frontpagePicture.description }}
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="green" @click="approveFrontpagePicture(frontpagePicture.id, true);">Approve</v-btn>
                        <v-btn color="red" @click="approveFrontpagePicture(frontpagePicture.id, false);">Deny</v-btn>
                    </v-card-actions>
                  </v-card>
                </div>
              </v-container>
              <v-container grid text-xs-center>
                <v-card class = "elevation-0" color = "transparent">
                    <v-btn color="primary" @click="submitFrontpagePicture = true">Submit A Frontpage Picture</v-btn>
                    <v-dialog v-model="submitFrontpagePicture" width="500">
                        <v-card>
                            <v-card-title class="headline">Submit Frontpage Picture</v-card-title>
                            <v-divider></v-divider>
                            <v-card class = "elevation-0" color = "transparent">
                                <div v-if="selectedFile == null">
                                    <v-avatar size = "100">
                                        <img id="defaultPicture" src="https://icdn3.digitaltrends.com/image/50395182-infinite-space-background-with-silhouette-of-telescope.jpg?ver=1" alt="Default">
                                    </v-avatar>     
                                </div>
                                <div v-else>
                                    <v-avatar size = "100">
                                        <img id="previewPicture" src="" alt="Custom">
                                    </v-avatar>
                                </div>
                            </v-card>
                            <v-divider></v-divider>
                            <input type="file" accept="image/*" @change="fileSelected" id="file-input">
                            <v-divider></v-divider>
                            <div v-if="selectedFile == null">
                                <v-card-text> Please Select A File! </v-card-text>
                            </div>
                            
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="red" @click="cancelPicture();">Cancel</v-btn>
                                <v-btn color="primary" @click="submitPicture();">Submit</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                </v-card>
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
import ApiDriver from "../ApiDriver";
import router from '../router';
import HttpResponse from '../utils/HttpResponse';
import { error } from 'util';
export default {
  title: "Radio Telescope 1.1.0",
  name: "FrontpagePictureApproval",
  data() {
    return {
      frontpagePictures: [
        //   { id: 1, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
        //   { id: 2, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
        //   { id: 3, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
      ],
      approvedFrontpagePictures: [
        //   { id: 1, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
        //   { id: 2, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
        //   { id: 3, pictureTitle: "", pictureUrl: "", description: "", approved: 0 },
      ],
      picturesRetrieved: false,
      approvedPicturesRetrieved: false,
      submitFrontpagePicture: false,
      selectedFile: null,
      submittedPicture: null,
      imgSrc: null,

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
      retrieveFrontpagePictures() {
        // Make the API call
        console.log("retrieving front page pictures" );
        ApiDriver.FrontpagePictures.retrieveAll().then((response) => {
            // Handle the server response
            HttpResponse.then(response, (data) => {
                // Populate the data and set the store's boolean back to false
                console.log("Data Returned: " + JSON.stringify(data.data));  // Logging for debugging purposes
                this.setFrontpagePictures(data.data);
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
      setFrontpagePictures(dbData) {
        console.log(this.frontpagePictures);     
        for(var dbIndex in dbData) {                                                             // iterate over all frontpage pictures retrieved from database
            this.frontpagePictures[dbIndex] = dbData[dbIndex];                                 // set the frontpage picture from the database in list on front end
            console.log("Successfully set a frontpage picture!");
        
        }
        console.log("Successfully set frontpage pictures!");
        this.picturesRetrieved = true;
        console.log(this.frontpagePictures);                                                                                                                                                     
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
        console.log("Successfully set frontpage pictures!");
        this.approvedPicturesRetrieved = true;
        console.log(this.approvedFrontpagePictures);                                                                                                                                                     
      },
      approveFrontpagePicture(frontpagePictureId, isApprove) {
          ApiDriver.FrontpagePictures.approvePicture(frontpagePictureId, isApprove).then((response) =>{
                HttpResponse.then(response, (data) => {
                        this.$swal({
                        title: '<span style="color:#f0ead6">Successful Operation<span>',
                        html: '<span style="color:#f0ead6">The frontpage picture has been approved or denied <span>',
                        type: 'success',
                        background: '#302f2f'
                    });
                    this.$emit('input');
                }, (status, errors) => {
                    if(parseInt(status)==403){
                        HttpResponse.accessDenied(this)
                    } else if(parseInt(status)==404){
                        HttpResponse.notFound(this, errors)
                    } else {
                        for(var field in errors) {
                            let message = errors[field][0]
                        }
                        HttpResponse.generalError(this, message, false)
                    }
                })
            }).catch((error) => {
            // Handle an erroneous API call
                console.log(error)
                let message = "An error occurred when attempting to approve or deny picture";
                HttpResponse.generalError(this, message, true);
            });

            //this.retrieveOverrides();                                                           // Update the front-end
            console.log("Successfully approved or denied frontpage picture!")
      },
      fileSelected(event) {
            this.selectedFile = event.target.files[0];
            console.log("fileSelected");
            console.log(event);
            console.log(this.selectedFile);

            var reader = new FileReader();
            var imgtag = document.getElementById("previewPicture");
            imgtag.title = this.selectedFile.name;
            reader.onload = function(event) {
                imgtag.src = event.target.result;
            }
            reader.readAsDataURL(this.selectedFile);
        },
        cancelPicture() {
            this.selectedFile = null;
            this.submitFrontpagePicture = false; 
            //clear file input file
            document.getElementById("file-input").value = "";
            console.log("cancelled");
        },
        submitPicture() {
            if (this.selectedFile == null) {
                console.log("select a file");
            }
            else {
                
                this.submittedPicture = this.selectedFile;
                this.submitFrontpagePicture = false; 
                console.log("picture submitted");

                //API to put profile picture in back end
                // var fd = new FormData();
                // fd.append("profile_picture", this.profilePicture, this.profilePicture.name);
                // console.log(this.profilePicture);
                // console.log(fd);

                ApiDriver.FrontpagePictures.submit(this.submittedPicture).then(response => {
                    // Handle the response
                    HttpResponse.then(response, data => {
                        // Success alert
                        this.$swal({
                            title: '<span style="color:#f0ead6">Success!<span>',
                            html: '<span style="color:#f0ead6">A frontpage picture has been submitted',
                            type: 'success',
                            background: '#302f2f'
                        }).then(response => {
                            // Clear out the modal's information
                            //this.clearPassReset();
                        });
                    }, (status, errors) => {
                        // Access Denied
                        if (parseInt(status) === 403) {
                            // Call the generic access denied handler
                            HttpResponse.accessDenied(this)
                        } 
                        // Not Found
                        else if (parseInt(status) === 404) {
                            // Call the generic invalid resource id handler
                            HttpResponse.notFound(that, errors)
                        } 
                        // Bad request
                        else {
                            // Handle errors
                            this.handleErrors(errors)
                        }
                    })
                }).catch(errors => {
                    // Handle an erroneous API call
                    let message = "An error occurred while submitting a frontpage picture."
                    HttpResponse.generalError(this, message, false)
                });

                //clear file input file
                document.getElementById("file-input").value = "";
                this.selectedFile = null;
            }
        },
  },
  created() {
      this.retrieveFrontpagePictures();
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