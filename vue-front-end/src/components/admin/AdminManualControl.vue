<template>
    <div>
        <loading v-if="$store.state.isLoading"></loading>
        <div v-if="!$store.state.isLoading">
            <!-- Text Fields (for numbers) -->
                <!-- Right Asc Hours -->
                <!-- Right Asc Minutes -->
                <!-- Right Asc in Dec -->
                <!-- Declination -->
                <!-- Azimuth -->
                <!-- Elevation -->
            <!-- Button to update from fields -->
            <!-- Dropdown to select update mode -->
            <!-- Buttons to jog by Right Asc and Declination -->
                <!-- H = left    -->
                <!-- J = up      -->
                <!-- K = down    -->
                <!-- L = right   -->
            <!-- Buttons to jog by Azimuth and Elevation -->
                <!-- H = left    -->
                <!-- J = up      -->
                <!-- K = down    -->
                <!-- L = right   -->
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

            modes: {
                "Right Ascension by Hours & Minutes",
                "Right Ascension by Decimal Value",
                "Azimuth and Elevation"
            },

            rules: {
                rightAscHours: val => (val && val.toString().length > 0 && val < 24 && val >= 0) || 'Must be between 0 and 23 hours',
                rightAscMinutes: val => (val && val.toString().length > 0 && val < 60 && val >= 0) || 'Must be between 0 and 59 minutes',
                numRequired: val => (val && val.toString().length > 0 && val <=90 && val >= -90) || 'Must be between 90 and -90',
                azimuth: val => (val && val.toString().length > 0 && val >= 0 && val < 360) || 'Must be between 0 and 360',
                elevation: val => (val && val.toString().length > 0 && val >= 0 && val <= 90) || 'Must be between 0 and 90'
            },
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
    }
};
</script>

<style scoped>

</style>