<template>
    <div>
        <loading v-if="$store.state.isLoading"></loading>
        <div v-if="!$store.state.isLoading">
            <v-card flat>
                <v-card-title class="headline">Manual Control</v-card-title>
                <v-container grid-list-xs fluid>
                    <v-layout wrap>
                    <!-- Text Fields (for numbers) -->
                        <!-- Right Asc Hours -->
                        <v-flex xs6 sm4>
                            <v-text-field
                            v-model="rightAscHours"
                            :disabled="!(mode === 'Right Ascension by Hours and Minutes')"
                            :validate-on-blur="true"
                            color="blue darken-2"
                            :rules="[rules.rightAscHours]"
                            label="Right Ascension Hours"
                            type="number"
                            class="number"></v-text-field>
                        </v-flex>
                        <!-- Right Asc Minutes -->
                        <v-flex xs6 sm4>
                            <v-text-field
                            v-model="rightAscMinutes"
                            :disabled="!(mode === 'Right Ascension by Hours and Minutes')"
                            :validate-on-blur="true"
                            color="blue darken-2"
                            :rules="[rules.rightAscMinutes]"
                            label="Right Ascension Minutes"
                            type="number"
                            class="number"></v-text-field>
                        </v-flex>
                        <!-- Right Asc in Dec -->
                        <v-flex xs6 sm4>
                            <v-text-field
                            v-model="rightAscDecimal"
                            :disabled="!(mode === 'Right Ascension by Decimal Value')"
                            :validate-on-blur="true"
                            color="blue darken-2"
                            :rules="[rules.azimuth]"
                            label="Right Ascension Decimals"
                            type="number"
                            class="number"></v-text-field>
                        </v-flex>
                        <!-- Declination -->
                        <v-flex xs6 sm4>
                            <v-text-field
                            v-model="declination"
                            :disabled="!(mode === 'Right Ascension by Decimal Value' || mode === 'Right Ascension by Hours and Minutes' )"
                            :validate-on-blur="true"
                            color="blue darken-2"
                            :rules="[rules.declination]"
                            label="Declination"
                            type="number"
                            class="number"></v-text-field>
                        </v-flex>
                        <!-- Azimuth -->
                        <v-flex xs6 sm4>
                            <v-text-field
                            v-model="azimuth"
                            :disabled="!(mode === 'Azimuth and Elevation')"
                            :validate-on-blur="true"
                            color="blue darken-2"
                            :rules="[rules.azimuth]"
                            label="Azimuth"
                            type="number"
                            class="number"></v-text-field>
                        </v-flex>
                        <!-- Elevation -->
                        <v-flex xs6 sm4>
                            <v-text-field
                            v-model="elevation"
                            :disabled="!(mode === 'Azimuth and Elevation')"
                            :validate-on-blur="true"
                            color="blue darken-2"
                            :rules="[rules.elevation]"
                            label="Elevation"
                            type="number"
                            class="number"></v-text-field>
                        </v-flex>
                    </v-layout>
                    <!-- Button to update from fields -->
                    <v-card-actions>
                        <v-btn flat @click="update(0)">Send Command</v-btn>
                        <v-btn flat @click="clearForm">Clear Form</v-btn>
                        <v-btn flat @click="clearForm">Back</v-btn>
                    </v-card-actions>
                    <!-- Dropdown to select update mode -->
                    <v-flex xs12 sm6>
                        <v-select
                        v-model="mode"
                        :items="modes"
                        color="blue darken-2"
                        label="Mode"
                        required
                        ></v-select>
                    </v-flex>
                    <v-card-actions>
                    <!-- Buttons to jog by Right Asc and Declination -->
                        <v-btn flat @click="update(1)">Right Asc Neg</v-btn> <!-- H = left    -->
                        <v-btn flat @click="update(2)">Declination Pos</v-btn> <!-- J = up      -->
                        <v-btn flat @click="update(3)">Declination Neg</v-btn> <!-- K = down    -->
                        <v-btn flat @click="update(4)">Right Asc Pos</v-btn> <!-- L = right   -->

                        <v-spacer></v-spacer>

                    <!-- Buttons to jog by Azimuth and Elevation -->
                        <v-btn flat @click="update(5)">Azimuth Neg</v-btn> <!-- H = left    -->
                        <v-btn flat @click="update(6)">Elevation Pos</v-btn> <!-- J = up      -->
                        <v-btn flat @click="update(7)">Elevation Neg</v-btn> <!-- K = down    -->
                        <v-btn flat @click="update(8)">Azimuth Pos</v-btn> <!-- L = right   -->
                    </v-card-actions>
                </v-container>
            </v-card>
        </div>
    </div>
</template>

<script>
import router from '../../router';
import ApiDriver from '../../ApiDriver';
import HttpResponse from '../../utils/HttpResponse';
import CurrentUserValidation from  '../../utils/CurrentUserValidation';
import Loading from "../../components/utility/Loading"
export default {   
    name: 'ManualControl',
    data() {
        return{
            rightAscHours: null,
            rightAscMinutes: null,
            rightAscDecimal: null,
            declination: null,

            azimuth: null,
            elevation: null,

            mode: null,

            modes: [
                "Right Ascension by Hours and Minutes",
                "Right Ascension by Decimal Value",
                "Azimuth and Elevation"
            ],

            rules: {
                rightAscHours: val => (val && val.toString().length > 0 && val < 24 && val >= 0) || 'Must be between 0 and 23 hours',
                rightAscMinutes: val => (val && val.toString().length > 0 && val < 60 && val >= 0) || 'Must be between 0 and 59 minutes',
                declination: val => (val && val.toString().length > 0 && val >= 0 && val < 360) || 'Must be between 0 and 360',
                numRequired: val => (val && val.toString().length > 0 && val <=90 && val >= -90) || 'Must be between 90 and -90',
                azimuth: val => (val && val.toString().length > 0 && val >= 0 && val < 360) || 'Must be between 0 and 360',
                elevation: val => (val && val.toString().length > 0 && val >= 0 && val <= 90) || 'Must be between 0 and 90'
            }
        }
    },
    methods:{
        clearForm(){
            this.rightAscHours = null,
            this.rightAscMinutes = null,
            this.rightAscDecimal = null,
            this.declination = null,

            this.azimuth = null,
            this.elevation = null,

            this.mode = null;
        },
        updateRightAsc(){
            if(this.mode === "Right Ascension by Decimal Value") {
                var totalMinutes = this.rightAscDecimal * 4;
                this.rightAscHours = ((totalMinutes - (totalMinutes % 60)) / 60);
                this.rightAscMinutes = (totalMinutes % 60);
            }
            else if(this.mode === "Right Ascension by Hours and Minutes") {
                this.rightAscDecimal = this.rightAscHours * 15 + this.rightAscMinutes * 0.25;
            }
        },
        update(val){
            console.log("Update pressed!");
            console.log(val);

            if(val == 0) {
                this.submit();
            } else if(val == 1) {
                // Right Asc Neg
                if(this.mode === "Right Ascension by Decimal Value") {
                    this.rightAscDecimal = parseFloat(this.rightAscDecimal) - 1;
                }
                else if(this.mode === "Right Ascension by Hours and Minutes") {
                    this.rightAscMinutes = parseInt(this.rightAscMinutes) - 1;
                    if(this.rightAscMinutes < 0) {
                        this.rightAscHours = parseInt(this.rightAscHours) - 1;
                        this.rightAscMinutes = parseInt(this.rightAscMinutes) + 60;
                    }
                }
            } else if(val == 2) {
                // Declination Pos
                if(this.mode === "Right Ascension by Decimal Value" || this.mode === "Right Ascension by Hours and Minutes") {
                    this.declination = parseFloat(this.declination) + 1;
                }
            } else if(val == 3) {
                // Declination Neg
                if(this.mode === "Right Ascension by Decimal Value" || this.mode === "Right Ascension by Hours and Minutes") {
                    this.declination = parseFloat(this.declination) - 1;
                }
            } else if(val == 4) {
                // Right Asc Pos
                if(this.mode === "Right Ascension by Decimal Value") {
                    this.rightAscDecimal = parseFloat(this.rightAscDecimal) + 1;
                }
                else if(this.mode === "Right Ascension by Hours and Minutes") {
                    this.rightAscMinutes = parseInt(this.rightAscMinutes) + 1;
                    if(this.rightAscMinutes >= 60) {
                        this.rightAscHours = parseInt(this.rightAscHours) + 1;
                        this.rightAscMinutes = parseInt(this.rightAscMinutes)  - 60;
                    }
                }
            } else if(val == 5) {
                // Azimuth Neg
                if(this.mode === "Azimuth and Elevation") {
                    this.azimuth = parseFloat(this.azimuth) - 1;
                }
            } else if(val == 6) {
                // Elevation Pos
                if(this.mode === "Azimuth and Elevation") {
                    this.elevation = parseFloat(this.elevation) + 1;
                }
            } else if(val == 7) {
                // Elevation Neg
                if(this.mode === "Azimuth and Elevation") {
                    this.elevation = parseFloat(this.elevation) - 1;
                }
            } else if(val == 8) {
                // Azimuth Pos
                if(this.mode === "Azimuth and Elevation") {
                    this.azimuth = parseFloat(this.azimuth) + 1;
                }
            }


            this.updateRightAsc();
        },
        submit(){
            // This method will use a TCP client to send commands to the telescope.
        }
    },
    components: {
        Loading
    }
};
</script>

<style scoped>

</style>