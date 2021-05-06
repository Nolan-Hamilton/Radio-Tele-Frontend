<template>
<div>
    <v-img height="300px"  src="https://images.pexels.com/photos/110854/pexels-photo-110854.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260">
        <v-layout row>
          <v-flex>
            <v-img height="300px" position="left" style="opacity:.25" src="http://www.astroyork.com/img/YCAS2018b.jpg" contain="true"></v-img>
          </v-flex>
          <v-flex>
            <v-img height="300px" position="right" style="opacity:.25" src="http://www.astroyork.com/img/YCAS2018b.jpg" contain="true"></v-img>
          </v-flex>
        </v-layout>
    </v-img>
        <v-layout align-center>
            <v-card>
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

                <v-flex>
                    <v-btn large block color="deep-purple" @click="submit">LOGIN</v-btn>
                </v-flex>

                <v-card>
                  <div style="padding: 25px;">
                    <div class="headline">Here are some pictures of various aspects of the radio telescope </div>
                  </div>
                </v-card>
                
              <!-- <v-container grid text-xs-center>
                <v-layout row>
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="http://www.astroyork.com/img/JS/9.jpg" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           YCAS member Jim Smailing has taken some excellent pictures of the eclipsing Moon. 
                           These pictures were taken with the combination of a Motorola E5 plus cellphone, 
                           a Vankey cellphone telescope adapter mount, and an Orion ultrascopic 5mm eyepiece 
                           all attached to an Orion Skywatcher 120 f/8 acromatic refractor on an EG-3 equatorial 
                           mount with an Orion EQ-3M single axis drive. The first six photos were taken with a #15 
                           yellow glass filter attached to the eyepiece.
                          </v-card-text>
                      </v-card>
                    </v-flex>
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSnIpIFMmJvFvQUv6wWmBCxdFFBVdC2SjBgR0lTJwFp-QJBi6Mr" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                          </v-card-text>
                      </v-card>
                    </v-flex>  
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="http://www.astroyork.com/img/JS/11.jpg" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           YCAS member Jim Smailing has taken some excellent pictures of the eclipsing Moon. 
                           These pictures were taken with the combination of a Motorola E5 plus cellphone, 
                           a Vankey cellphone telescope adapter mount, and an Orion ultrascopic 5mm eyepiece 
                           all attached to an Orion Skywatcher 120 f/8 acromatic refractor on an EG-3 equatorial 
                           mount with an Orion EQ-3M single axis drive. The first six photos were taken with a #15 
                           yellow glass filter attached to the eyepiece.
                          </v-card-text>
                      </v-card>
                    </v-flex>   
                </v-layout>
                <v-layout row>
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="https://images.pexels.com/photos/110854/pexels-photo-110854.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                          </v-card-text>
                      </v-card>
                    </v-flex>
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="https://ycas.github.io/img/Observatory.jpg" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           This is the York County Astronomical Society Observatory. This is the York County Astronomical Society Observatory. 
                           This is the York County Astronomical Society Observatory. This is the York County Astronomical Society Observatory. 
                           This is the York County Astronomical Society Observatory. This is the York County Astronomical Society Observatory. 
                          </v-card-text>
                      </v-card>
                    </v-flex>  
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="https://cdn7.allevents.in/banners/118f95d0-4a3b-11ea-be32-af02df26b8fe-rimg-w525-h350-gmir.jpg?v=1581142815" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                          </v-card-text>
                      </v-card>
                    </v-flex>   
                </v-layout>
                <v-layout row>
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="http://www.astroyork.com/img/JS/10.jpg" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           This is the York County Astronomical Society Observatory. This is the York County Astronomical Society Observatory. 
                           This is the York County Astronomical Society Observatory. This is the York County Astronomical Society Observatory. 
                           This is the York County Astronomical Society Observatory. This is the York County Astronomical Society Observatory. 
                          </v-card-text>
                      </v-card>
                    </v-flex>
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="https://pxl-ycpedu.terminalfour.net/518x345/prod01/www.ycp.edu/htdocs-media-only/media/york-website/engineering-and-computer-science/facilities/Engineering-FacilityKinsley2013-YCP1.jpg" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           This is the Kinsley Engineering Center. This is the Kinsley Engineering Center. This is the Kinsley Engineering Center. 
                           This is the Kinsley Engineering Center. This is the Kinsley Engineering Center. This is the Kinsley Engineering Center.
                           This is the Kinsley Engineering Center. This is the Kinsley Engineering Center. This is the Kinsley Engineering Center.
                          </v-card-text>
                      </v-card>
                    </v-flex>  
                    <v-flex>
                      <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                          <v-img height="500px" src="https://media.istockphoto.com/photos/telescope-picture-id512605413?k=6&m=512605413&s=612x612&w=0&h=3qyaXj4JJOAY1hjNszpp5SCQFY3SUldFzervpQWz0gQ=" contain="true"></v-img>
                          <v-card-text class="grey--text">
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image.
                           This is a placeholder image. This is a placeholder image. This is a placeholder image. 
                          </v-card-text>
                      </v-card>
                    </v-flex>   
                </v-layout>
              </v-container>

              <v-container grid text-xs-center>
                <div v-for="item in items" :key="item.message">
                  <v-card dark class="ma-1 pa-2" hover="true" ripple="true" max-width="600px">
                    <v-img height="500px" src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSnIpIFMmJvFvQUv6wWmBCxdFFBVdC2SjBgR0lTJwFp-QJBi6Mr" contain="true"></v-img>
                    <v-card-text class="grey--text">
                      This is a placeholder image. This is a placeholder image. This is a placeholder image.
                      This is a placeholder image. This is a placeholder image. This is a placeholder image.
                      This is a placeholder image. This is a placeholder image. This is a placeholder image.
                    </v-card-text>
                  </v-card>
                </div>
              </v-container> -->

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
  name: "LandingPage",
  data() {
    return {
      items: 
      [
        { message: 'Foo' },
        { message: 'Bar' },
        { message: 'Yam' },
        { message: 'Rat' },
        { message: 'Eel' },
        { message: 'Wow' },
        { message: 'Tar' },
        { message: 'Axe' },
        { message: 'Pow' },
      ],

      frontpagePictures: [

      ],
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

            for(var dbIndex in dbData) {                                                             // iterate over all frontpage pictures retrieved from database
                this.frontpagePictures[dbIndex] = dbData[dbIndex];                                 // set the profile picture from the database in list on front end
                console.log("Successfully set a frontpage picture!");
            
            }
            console.log("Successfully set frontpage pictures!");
            console.log(this.frontpagePictures);                                                                                                                                                      
        },
  },
  mounted() {
    this.retrieveFrontpagePictures();
  }
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