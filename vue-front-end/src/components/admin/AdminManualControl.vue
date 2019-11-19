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
                            :disabled="!(mode === 'Right Ascension by Hours & Minutes')"
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
                            :disabled="!(mode === 'Right Ascension by Hours & Minutes')"
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
                            :disabled="!(mode === 'Right Ascension by Decimal Value' || mode === 'Right Ascension by Hours & Minutes' )"
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
                            :disabled="!(mode === 'Azimuth & Elevation')"
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
                            :disabled="!(mode === 'Azimuth & Elevation')"
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
                        <v-btn flat @click="update">Send Command</v-btn>
                        <v-btn flat @click="resetForm">Clear Form</v-btn>
                        <v-btn flat @click="resetForm">Back</v-btn>
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
                        <v-btn flat @click="foo">Right Asc Neg</v-btn> <!-- H = left    -->
                        <v-btn flat @click="foo">Declination Pos</v-btn> <!-- J = up      -->
                        <v-btn flat @click="foo">Declination Neg</v-btn> <!-- K = down    -->
                        <v-btn flat @click="foo">Right Asc Pos</v-btn> <!-- L = right   -->

                        <v-spacer></v-spacer>

                    <!-- Buttons to jog by Azimuth and Elevation -->
                        <v-btn flat @click="foo">Azimuth Neg</v-btn> <!-- H = left    -->
                        <v-btn flat @click="foo">Elevation Pos</v-btn> <!-- J = up      -->
                        <v-btn flat @click="foo">Elevation Neg</v-btn> <!-- K = down    -->
                        <v-btn flat @click="foo">Azimuth Pos</v-btn> <!-- L = right   -->
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
            elavation: null,

            mode: null,

            modes: [
                "Right Ascension by Hours & Minutes",
                "Right Ascension by Decimal Value",
                "Azimuth & Elevation"
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
        update(){
            // This method will update the display to show the correct Right Asc, Declination, Azimuth, and Elevation.
        },
        submit(){
            // This method will use a TCP client to send commands to the telescope.
        }
        // Considering giving each button a seperate method, but also considering cutting down on the number of buttons
    },
    components: {
        Loading
    }
};
</script>

<style scoped>

</style>