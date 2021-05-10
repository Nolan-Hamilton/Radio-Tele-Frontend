<template>
  <div>

    <v-card class="ma-1 pa-2">
      <v-card-title style="padding: 15px;" class="justify-center headline">
          Here you can submit new frontpage and gallery pictures
      </v-card-title>
    </v-card>

    <v-card style="padding: 15px;" class = "elevation-0" color = "transparent">
        <v-btn block large color="primary" @click="submitFrontpagePicture = true">Submit A Frontpage Picture</v-btn>
        <v-dialog v-model="submitFrontpagePicture" width="500">
          <v-card>
            <v-card-title class="headline">Submit Frontpage Picture</v-card-title>
            <v-divider></v-divider>
            <v-card class = "elevation-0" color = "transparent">
                <div v-if="selectedFile == null">
                    <v-avatar size = "100">
                        <img id="defaultPicture" src=" " alt="Default">
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
            <label for="pictureTitle">Picture Title:</label>
            <input type="text" v-model="pictureTitle" placeholder="Enter the picture title" id="pic-title">
            <v-divider></v-divider>
            <label type="text" for="pictureUrl">Picture Url:</label>
            <input v-model="pictureUrl" placeholder="Enter the picture url" id="pic-url">
            <v-divider></v-divider>
            <label type="text" for="pictureDescription">Picture Description:</label>
            <input v-model="pictureDescription" placeholder="Enter the picture description" id="pic-desc">
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

    <v-card color="green darken-3" class="ma-1 pa-2">
      <v-card-title style="padding: 15px;" class="justify-center headline">
          These are the frontpage and gallery pictures that have been approved 
      </v-card-title>
    </v-card>

    <v-container fluid grid-list-lg v-if="approvedPicturesRetrieved">
      <v-layout align-center wrap>
          <v-flex xs4 v-for="approvedFrontpagePicture in approvedFrontpagePictures" :key="approvedFrontpagePicture.id">
              <v-card dark class="ma-1 pa-2">
                <v-img height="500px" :src="approvedFrontpagePicture.pictureUrl" contain="true"></v-img>
                <v-card-text class="grey--text">
                  Title: {{ approvedFrontpagePicture.pictureTitle }}
                </v-card-text>
                <v-divider></v-divider>
                <v-card-text class="grey--text">
                  Description: {{ approvedFrontpagePicture.description }}
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="red darken-3" @click="approveFrontpagePicture(approvedFrontpagePicture.id, 0);">Remove</v-btn>
                </v-card-actions>
              </v-card>
          </v-flex>
      </v-layout>
    </v-container>

    <v-card color="red darken-3" class="ma-1 pa-2">
      <v-card-title style="padding: 15px;" class="justify-center headline">
          These are the frontpage and gallery pictures that have not yet been approved 
      </v-card-title>
    </v-card>

    <v-container fluid grid-list-lg v-if="picturesRetrieved">
      <v-layout align-center wrap>
          <v-flex xs4 v-for="frontpagePicture in frontpagePictures" :key="frontpagePicture.id">
              <v-card v-if="frontpagePicture.approved == 0" dark class="ma-1 pa-2">
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
                  <v-btn color="green darken-3" @click="approveFrontpagePicture(frontpagePicture.id, 1);">Approve</v-btn>
                </v-card-actions>
              </v-card>
          </v-flex>
      </v-layout>
    </v-container>

  </div>
</template>

<script>
import ApiDriver from "../../ApiDriver";
import router from '../../router';
import HttpResponse from '../../utils/HttpResponse';
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
      pictureTitle: null,
      pictureUrl: null, 
      pictureDescription: null,

      // imported data
      dbData: [
      ]
    };
  },
  components: {
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
                    console.log("access denied.");
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
            //clear selected file and picture title, url, description
            this.selectedFile = null;
            this.pictureTitle = null;
            this.pictureUrl = null;
            this.pictureDescription = null;
            this.submitFrontpagePicture = false; 
            //clear file input file
            document.getElementById("file-input").value = "";
            console.log("cancelled");
        },
        submitPicture() {
            
            //if no picture is selected or picture title, url, or description is empty do not make API call
            if (this.selectedFile == null || this.pictureTitle == null || this.pictureUrl == null || this.pictureDescription == null) {
              if (this.selectedFile == null) {
                console.log("A file is required");
              }
              if (this.pictureTitle == null) {
                console.log("A picture title is required");
              }
              if (this.pictureUrl == null) {
                console.log("A picture url is required");
              }
              if (this.pictureDescription == null) {
                console.log("A picture description is required");
              }
            }
            //otherwise make API call
            else {
                
                this.submittedPicture = this.selectedFile;
                this.submitFrontpagePicture = false; 
                console.log("picture submitted");

                //API to put profile picture in back end
                var formData = new FormData();
                formData.append("file", this.submittedPicture);
                console.log(this.submittedPicture);
                for(var pair of formData.entries()) {
                  console.log(pair[0]+ ', '+ pair[1]); 
                }

                //console.log(this.pictureUrl);

                ApiDriver.FrontpagePictures.submit(this.pictureTitle, this.pictureUrl, this.pictureDescription, formData).then(response => {
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
    if (this.$store.state.isAdmin) {
      this.retrieveFrontpagePictures();
      this.retrieveApprovedFrontpagePictures();
    }
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