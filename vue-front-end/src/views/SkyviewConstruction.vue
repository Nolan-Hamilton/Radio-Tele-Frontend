<template>
    <v-app>
        <navigation-bar></navigation-bar>
        <h1 class="text-style">This page is currently under construction</h1>
        <h3 class="text-style">Please be patient while we implement the necessary features</h3>
        <v-card flat>
                <v-card-title class="headline">Schedule Appointment</v-card-title>
                <v-snackbar
                v-model="snackbar"
                absolute
                top
                right
                color="success">
                <span>Appointment Created</span>
                <v-icon dark>check_circle</v-icon>
                </v-snackbar> 
                <v-form ref="form" @submit.prevent="submit" refs="form">
                <v-container grid-list-xl fluid>
                    <v-layout wrap>
                    <v-flex xs12 sm6>
                        <div class="title-style">Start Date/Time</div>
                        <v-date-picker
                        v-model="startDate"
                        landscape
                        width="175"
                        ></v-date-picker>
                        <v-time-picker
                        v-model="startTime"
                        landscape
                        width="175"
                        v-on:update:period="captureStartPeriod($event)"
                        ></v-time-picker>
                    </v-flex>
                    <v-flex xs12 sm6>
                        <div class="title-style">End Date/Time</div>
                        <v-date-picker
                        v-model="endDate"
                        landscape
                        width="175"
                        ></v-date-picker>
                        <v-time-picker
                        v-model="endTime"
                        landscape
                        width="175"
                        ></v-time-picker>
                    </v-flex> 
                    <v-flex xs12 sm3 v-if="type === 'Point'">
                        <v-text-field
                        v-model="form.rightAscension.hours"
                        :rules="[rules.rightAscHours]"
                        :validate-on-blur="true"
                        color="blue darken-2"
                        :error=form.rightAscension.hasError
                        :error-messages=form.rightAscension.errorMessage
                        onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                        label="Right Ascension Hours"
                        type="number"
                        class="number"
                        required
                        ></v-text-field>
                    </v-flex>
                     <!--
                        Same as Right Ascension Hours, except checks for minutes error handling
                    -->
                    <v-flex xs12 sm3 v-if="type === 'Point'">
                        <v-text-field
                        v-model="form.rightAscension.minutes"
                        :rules="[rules.rightAscMinutes]"
                        :validate-on-blur="true"
                        color="blue darken-2"
                        :error=form.rightAscension.hasError
                        :error-messages=form.rightAscension.errorMessage
                        onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                        label="Right Ascension Minutes"
                        type="number"
                        class="number"
                        required
                        ></v-text-field>
                     </v-flex>
                    <v-flex xs12 sm3 v-if="type === 'Point'">
                        <v-text-field
                        v-model="form.declination.value"
                        :rules="[rules.numRequired]"
                        :validate-on-blur="true"
                        color="blue darken-2"
                        :error=form.declination.hasError
                        :error-messages=form.declination.errorMessage
                        onkeypress='return event.charCode == 45 || (event.charCode >= 48 && event.charCode <= 57)'
                        label="Declination"
                        type="number"
                        required
                        ></v-text-field>
                    </v-flex>

                    
                    <!--
                        v-if="this.$store.state.isResearcher || this.$store.state.isAdmin"
                        only display this part of the form if current user is researcher or admin
                        This is a simple checkbox to choose to make the appointment private or not
                    -->
                    <v-flex v-if="this.$store.state.isResearcher || this.$store.state.isAdmin" xs12>
                        <v-checkbox
                        v-model="form.isPrivate.value"
                        color="green"
                        label="Private"
                        >
                        </v-checkbox>
                    </v-flex>
                    <!--
                        Simple drop down select menu to choose which telescope you want to schedule your appointment for
                        Added to form to make sure user knows which telescope they are scheduling for
                    -->
                    </v-layout>
                </v-container>
                <v-card-actions>
                    <!-- Cancel resets form and closes Modal -->
                    <v-btn flat @click="resetForm">Cancel</v-btn>
                    <v-spacer></v-spacer>
                    <v-btn flat @click="visualize">Visualize</v-btn>
                    <v-spacer></v-spacer>
                    <!-- Submit sends the form to backend to be verified -->
                    <v-btn
                    :disabled="!formIsValid"
                    flat
                    color="primary"
                    type="submit"
                    >Schedule</v-btn>
                </v-card-actions>
            </v-form>
            <img class="image-style" v-bind:src="imageSrc0" v-if="showImage === 'yes'"> 
            <img class="image-style" v-bind:src="imageSrc1" v-if="showImage === 'yes'">
        </v-card>
    </v-app>
</template>

<script>
import Event from '../main.js'
import ApiDriver from '../ApiDriver'
import HttpResponse from '../utils/HttpResponse'
import CurrentUserValidation from '../utils/CurrentUserValidation'
import router from '../router';
import CustomErrorHandler from '../utils/CustomErrorHandler.js';
import NavigationBar from "../components/utility/NavigationBar.vue";
export default {
    title: "Radio Telescope 1.1.0",
    name: "TestPage",

    data() {
        name: 'Appointment'
        return {
            form: {
                isPrivate: {
                    value: false
                },
                rightAscension: {
                    hours: null,
                    minutes: null,
                    hasError: false
                },
                declination: {
                    value: null,
                    hasError: false
                }
            },
            startDate: '',
            startTime: '',
            endDate: '',
            endTime: '',
            showImage: 'no',
            imageSrc0: 'https://ak8.picdn.net/shutterstock/videos/13288688/thumb/1.jpg',
            imageSrc1: 'https://ak8.picdn.net/shutterstock/videos/13288688/thumb/1.jpg',

            // Variables to keep track of chosen Appointment type
            type: 'Point',
            selectedType: '',

            // Variable to keep track of whether or not we've updated our start/end times 
            updatedTime: false,
            /* This is the rules obj used in the form validation.
                val => (true or false logic) || 'text to display if false
            */
            rules: {
                dateRequired: val => (val && val.length > 0) || 'Required field',
                rightAscHours: val => (val && val.toString().length > 0 && val < 24 && val >= 0) || 'Must be between 0 and 23 hours',
                rightAscMinutes: val => (val && val.toString().length > 0 && val < 60 && val >= 0) || 'Must be between 0 and 59 minutes',
                rightAscSeconds: val => (val && val.toString().length > 0 && val < 60 && val >= 0) || 'Must be between 0 and 59 seconds',
                numRequired: val => (val && val.toString().length > 0 && val <=90 && val >= -90) || 'Must be between 90 and -90',
                azimuth: val => (val && val.toString().length > 0 && val >= 0 && val < 360) || 'Must be between 0 and 360',
                elevation: val => (val && val.toString().length > 0 && val >= 0 && val <= 90) || 'Must be between 0 and 90'
            },
            snackbar: false,
        }
    }, 

    components: {
        NavigationBar
    },

    methods: {
        // Method to reset the form then close the modal
        resetForm() {
            this.updatedTime = false;
            this.form.isPrivate.value = false;
            this.form.rightAscension.hours = null;
            this.form.rightAscension.minutes = null;
            this.form.declination.value = null;
            this.startTime='';
            this.startDate='';
            this.endDate='';
            this.endTime='';
            this.showImage = "no";
            this.clearErrors();
            this.$emit('close-modal');
        },
        visualize() {
            this.showImage = "yes";
            this.imageSrc0 = "https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg";
            this.imageSrc1 = "https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg";

            // TODO: pull image from API
            /*
            $.ajax({
                type: 'POST',
                url: 'C:/Users/Marie Kiley/Documents/RT-Workspace/SkyviewAPIWork/AAAPI/AAAPI/bin/Debug/netcoreapp3.0/AAAPI.dll/SaveImage',
                data: JSON.stringify(),
                success: function(data) {
                    onSuccess(data);
                }
            });
            */
        }, 
        // Method to submit to back end
        submit() {
            // Clears the errors first to make sure that if backend sends back any errors we only display the current errors
            this.start = this.startDate + " " + this.startTime;
            this.end = this.endDate + " " + this.endTime;
            this.clearErrors();
            
            // Clear the coordinates array to prevent duplicates
            this.coordinates = [];

            // Handles making the selected Appointment Type string compatible with the back-end
            this.handleType();

            // set up form to send to back end with data from form obj
            let form = {
                userId: this.$store.state.currentUserId,
                startTime: new Date(this.start).toUTCString(),
                endTime: new Date(this.end).toUTCString(),
                telescopeId: this.telescopes.indexOf(this.telescopeName) + 1,
                isPublic: !this.form.isPrivate.value,
                hours: this.form.rightAscension.hours,
                minutes: this.form.rightAscension.minutes,
                declination: this.form.declination.value,
                celestialBodyId: this.selectedBody,
                azimuth: this.form.azimuth.value,
                elevation: this.form.elevation.value,
                coordinates: this.coordinates,
                priority: 'PRIMARY' // TODO: make this a selectable option!
            };
                        
            // Call appropriate API CALL and send form in json format
            ApiDriver.Appointment.create(JSON.stringify(form), this.selectedType).then((response) => {
                HttpResponse.then(response, (data) => {
                    // If returns SUCCESS
                    this.snackbar = true;
                    
                    // Reset form before closing Modal as user can schedule multiple Appointments without leaving Scheduler Page
                    this.resetForm()
                        
                    // Call the created-event method on Scheduler.vue page so it knows whether to display the newly created event or not without doing a backend call again
                    this.$emit('created-event', form, data.data);
                    this.$emit('close-modal');
                    }, (status, errors) => {
                        if (parseInt(status) === 403) {
                            HttpResponse.accessDenied(this)
                        } else {
                            this.handleErrors(errors, form);
                        }
                    });
            });
            this.startTime=''
            this.startDate=''
            this.endDate=''
            this.endTime=''
        },
        handleErrors(errors, formObj) {
            for (var field in errors) {
                let message = errors[field][0];
                if (field === "RIGHT_ASCENSION") {
                    CustomErrorHandler.populateError(this.form.rightAscension, message)
                } else if (field === "DECLINATION") {
                    CustomErrorHandler.populateError(this.form.declination, message)
                } else if (field == "ALLOTTED_TIME" && !this.$store.state.isGuest) {
                   //Changing startTime and endTime back to current time instead of UTC to display on request modal
                   //Also adding telescope name into Obj to display on request form
                   formObj.startTime = this.start
                   formObj.endTime = this.end
                   formObj.telescope = this.telescopeName
                   //Sends the information of the form to the requestAppointment function on Scheduler Page.
                   this.$emit('request-appointment', formObj)
                   this.resetForm()
                } else {
                    HttpResponse.generalError(this, message, false)
                }
            }
        },
        handleType() {
            // Handle setting up the proper API call to the back-end
            if(this.type == "Point") {
                this.selectedType = "coordinate";
            }
            else if(this.type == "Celestial Body") {
                this.selectedType = "celestial-body";
            }
            else if(this.type == "Drift Scan") {
                this.selectedType = "drift-scan";
            }
            else if(this.type == "Raster Scan") {
                this.selectedType = "raster-scan";
                
                // Add the two sets of coordinates to a single array to send to the back-end
                this.coordinates.push(this.form.firstCoordinate);
                this.coordinates.push(this.form.secondCoordinate);
            }
        },
        clearErrors() {
            CustomErrorHandler.clearError(this.form.rightAscension);
        },
        numbersOnly(val) {
            val = val.replace(/[^0-9]/g, '');
            return val;
        },
        updateTime() {
             // If the event is not empty, it's had values passed into it from the Scheduler page
            if(Object.keys(this.dragEvent).length !== 0 && (this.startTime != this.dragEvent.startTime || this.endTime != this.dragEvent.endTime)) {
                this.startTime = this.dragEvent.startTime;
                this.endTime = this.dragEvent.endTime;
                this.startDate = this.dragEvent.startDate;
                this.endDate = this.dragEvent.endDate;
                this.updatedTime = true;
                
                // Conditionally disable this.updatedTime if the modal is closing
                // prevents a bug with drag and drop scheduling consecutive appointments
                if(!this.value) {
                    this.updatedTime = false;
                }
            } 
        },
        populateData(data) {
            for (var index in data.content) {
                let body = data.content[index];
                this.bodies.push(body);
            }
        }
    },
    computed: {
        formIsValid() {
            if(this.type == 'Point') {    
                return (
                    this.startTime &&
                    this.endTime &&
                    this.startDate &&
                    this.endDate &&
                    this.form.rightAscension.hours,
                    this.form.rightAscension.minutes,
                    // 0, // this.form.rightAscension.seconds,
                    this.form.declination.value
                )
            }
            else if(this.type == 'Celestial Body') {
                return (
                    this.startTime &&
                    this.endTime &&
                    this.startDate &&
                    this.endDate &&
                    this.selectedBody
                )
            }
            else if(this.type == 'Drift Scan') {
                return (
                    this.startTime &&
                    this.endTime &&
                    this.startDate &&
                    this.endDate &&
                    this.form.elevation.value,
                    this.form.azimuth.value
                )
            }
            else if(this.type == 'Raster Scan') {
                return (
                    this.startTime &&
                    this.endTime &&
                    this.startDate &&
                    this.endDate &&
                    this.form.firstCoordinate.hours,
                    this.form.firstCoordinate.minutes,
                    // 0, // this.form.firstCoordinate.seconds,
                    this.form.firstCoordinate.rightAscension,
                    this.form.firstCoordinate.declination,
                    this.form.secondCoordinate.hours,
                    this.form.secondCoordinate.minutes,
                    // 0, // this.form.secondCoordinate.seconds,
                    this.form.secondCoordinate.rightAscension,
                    this.form.secondCoordinate.declination
                )
            }
        }
    },

    updated: function() {
        // Update our start and end times based on the passed in prop from Scheduler.vue
        // This is only necessary in the case of a drag-n-drop appointment, and only needs to be called once
        if(!this.updatedTime) {
            this.updateTime();
        }
    },

    // Watch for the selected Appt Type to change, and clear the form object of past data when it does
    watch:  {
        type() {
            console.log("appt type changed");
        },
        searchInput(key) {
            this.getCelestialBodies(key);
        }
    }

    // data:type = 'Point'
}
</script>

<style scoped>
.text-style{
    color: #f0ead6;
}
.image-style{
    padding-top: 50px;
    padding-left: 200px;
    padding-right: 200px;
}
</style>

