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
    };
  },
  components: {
      
  },
  methods: {
      submit() {
          router.push("/login");
      }, 
  },
  mounted() {
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