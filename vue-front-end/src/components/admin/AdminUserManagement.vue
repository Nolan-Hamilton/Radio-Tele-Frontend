<template>
<div>
    <loading v-if="$store.state.isLoading"></loading>
    <v-card v-if="!$store.state.isLoading" width = "100%">
        <v-layout row >
            <v-text-field  v-on:keyup.enter="formatSearchParams" v-on:keyup.down="reset" clearable v-model = "searchParam" class="ml-2 mr-2" label="Search..." append-icon="search" dark></v-text-field>
            <!-- <v-select
            :items="filterTypes"
            label="Filter by"
            v-model="filterType"
            ></v-select>
            -->
        <v-flex xs12 sm4>    
            <v-select
            v-model="chosenFilters"
            :items="filterTypes"
            :menu-props="{ maxHeight: '400' }"
            label="Filters"
            multiple
            clearable
            hint="Select Filters"
            persistent-hint
            ></v-select>
        </v-flex>
        <v-btn @click="reset" class="mt-3 mr-0">Clear</v-btn> 
        <v-btn @click="formatSearchParams" class="mt-3 mr-2">Search</v-btn> 
        
            
            
        </v-layout>
        <v-list >
            <v-list-tile v-for="user in users" :key = "user.id"  @click="hover = !hover">
                <v-list-tile-content>
                    <v-list-tile-title>
                        {{user.firstName}} {{user.lastName}}: {{user.membershipRole}}
                    </v-list-tile-title>
                    <v-list-tile-sub-title>
                        {{user.email}}
                    </v-list-tile-sub-title>
                </v-list-tile-content>
                <v-spacer></v-spacer>
                <slot v-bind="user">
                    <v-btn v-if="user.profilePictureApproved === false" 
                    @click="confirmProfilePic = !confirmProfilePic, chosenUserId = user.id, chosenUserProfilePic = user.profilePicture, chosenUserName = user.firstName + ' ' + user.lastName">
                        Approve Profile Picture
                    </v-btn>
                    <v-btn icon v-bind:href="'/#/users/' + user.id + '/view'">
                        <v-icon>account_circle</v-icon>
                    </v-btn>
                    <div v-if = "user.status === 'Active'">
                        <v-btn icon
                        @click="confirm = !confirm, chosenUserId = user.id, action = 'ban', chosenUserName = user.firstName +' '+ user.lastName" 
                        :disabled="user.membershipRole == 'Admin'">
                            <v-icon>gavel</v-icon>
                        </v-btn>  
                    </div>
                    <div v-else-if="user.status == 'Banned'">
                        <v-btn icon 
                        @click="confirm = !confirm, chosenUserId = user.id, action = 'unban', chosenUserName = user.firstName +' '+ user.lastName">
                            <v-icon>lock_open</v-icon>
                        </v-btn> 
                    </div>
                </slot>
            </v-list-tile>
        </v-list>

        <!-- This dialog is called when the approve profile picture button is pressed -->
        <v-dialog v-model = "confirmProfilePic" persistent max-width="600px">
            <v-card>
                <v-container>
                    <v-flex xs12>
                        <v-card-text class = "headline">
                            Are you sure you want to approve {{chosenUserName}}'s profile picture?
                        </v-card-text>
                    </v-flex>
                    <div style="width: 200px; height: 200px; border-radius: 100%; overflow: hidden; display: block; margin: 20px auto;">
                        <img :src="chosenUserProfilePic" style="width: 100%;">
                    </div>
                    <v-btn @click="approveOrDenyProfilePicture(chosenUserId, 'true'), confirmProfilePic = false" color="green" >Approve</v-btn>
                    <v-btn @click="approveOrDenyProfilePicture(chosenUserId, 'false'), confirmProfilePic = false" color="red" >Deny</v-btn>
                    <v-btn @click.native="confirmProfilePic = false">Cancel</v-btn>
                    
                </v-container>
            </v-card>
        </v-dialog>

        
        <!-- This dialog is called when the ban or unban button is pressed -->
        <v-dialog v-model = "confirm" persistent max-width="600px">
            <v-card>
                <v-container>
                    <v-flex xs12>
                        <v-card-text class = "headline">
                            Are you sure you want to {{action}}<br /> {{chosenUserName}}?
                        </v-card-text>
                    </v-flex>
                    <v-textarea
                    v-if = "action === 'ban'"
                        background-color = "white"
                        outline
                        label="Reason for ban"
                        counter
                        maxlength="120"
                        full-width
                        single-line
                        v-model="banMessage"
                    ></v-textarea>
                    <v-btn @click.native="confirm = false" color = "red">Cancel</v-btn>
                    <span v-if = "action === 'ban'">
                        <v-btn @click="banUser(chosenUserId, banMessage), confirm = false" color = "green" >Submit</v-btn>
                    </span>
                    <span v-if = "action === 'unban'">
                        <v-btn @click="unbanUser(chosenUserId), confirm = false" color = "green" >Submit</v-btn>
                    </span>
                    
                </v-container>
            </v-card>
        </v-dialog>
    </v-card>
        <div v-if="numPages>1 && !$store.state.isLoading" class="text-xs-center">
            <v-pagination
            circle
            v-model="pageDisplay"
            :length="numPages"
            @input="next"></v-pagination>
        </div>
        <v-layout v-if="!$store.state.isLoading" justify-center>
            <v-flex xs12 sm1>
                <v-select
                v-model="selectedPageSize"
                :items="pageSizeList"
                label="Items per page"
                v-on:change="this.pageSizeUpdate"
                ></v-select>
            </v-flex>
        </v-layout>
    </div>
</template>
<script>
import router from '../../router';
import ApiDriver from '../../ApiDriver';
import HttpResponse from '../../utils/HttpResponse';
import CurrentUserValidation from  '../../utils/CurrentUserValidation';
import Loading from "../../components/utility/Loading"
export default {
    name: 'AdminUserManagement',
    data(){
        return{
            data: {
               
            },
            users: [],
            viewUserId: '',
            hover: false,
            confirm: false,
            confirmProfilePic: false,
            chosenUserId: '',
            chosenUserName: '',
            chosenUserProfilePic: '',
            action: '',
            icon:'',

            // Ban-related
            banMessage: "",

            //search
            chosenFilters: [],
            searchParam: '',
            filterTypes: ['First Name','Last Name','Email','Company'],
            chosenFiltersString: '',
            filteredSet: false,

            //adv search
            advSearch: true,

            //pagination
            pageNumber: 0,
            numPages: 0,
            pageDisplay: 1,
            selectedPageSize: "10",
            pageSizeList: [
                '10', '25', '50', '100'
            ]
        }
    },
    methods:{
        reset(){
            //clear selected filters
            this.chosenFilters = []
            this.pageNumber = 0
            this.pageDisplay = 1
            this.getUsers()
            
        },
        advancedSearch(pageNumber){
            
            this.users = []
            //Takes chosenFilters array and sets it to a string with the format "firstName+lastName..."
            //also sets the values in the array to camel case
            
            ApiDriver.User.userSearch(pageNumber, this.selectedPageSize, this.searchParam, this.chosenFiltersString).then((response) => {
                HttpResponse.then(response, data => {
                    this.populateData(data.data)
                },(status, errors) => {})
             }).catch((error) => {
                this.$swal({
                            title: '<span style="color:#f0ead6">Error!<span>',
                            html: '<span style="color:#f0ead6">An error occurred when loading the list of users<span>',
                            type: 'error',
                            background: '#302f2f'
                        }).then(response => {
                            CurrentUserValidation.validateCurrentUser(this.$store);
                        });
            });
        },
        getUsers(){
            //this.$store.commit("loading", true);
            this.filteredSet = false
            this.users = []
            this.$store.commit("loading", true);
            ApiDriver.User.allUsers(this.pageNumber,this.selectedPageSize).then((response) => {
                HttpResponse.then(response, data => {
                    this.populateData(data.data)
                    this.$store.commit("loading", false);
                }, (status, errors) => {})
            }).catch((error) => {
                this.$swal({
                            title: '<span style="color:#f0ead6">Error!<span>',
                            html: '<span style="color:#f0ead6">An error occurred when loading the list of users<span>',
                            type: 'error',
                            background: '#302f2f'
                        }).then(response => {
                            CurrentUserValidation.validateCurrentUser(this.$store);
                        });
            });
        },
        populateData(data){
            for (var index in data.content) {
                let user = data.content[index];
                if (!user.membershipRole) {
                    user.membershipRole = 'Pending Approval';
                }
                this.users.push(user);
                console.log("URL for profile pic: " + user.profilePicture);
                this.numPages = data.totalPages;
            }
            
        },
        next(page) {
            // Handle retrieving a new page of information
            this.pageNumber = page - 1;
            this.pageDisplay = page;
            this.users = [];
            if(!this.filteredSet){
                this.getUsers()
            }else{
                this.advancedSearch(this.pageNumber)
            }
            
        },
        formatSearchParams(){
            for(var i in this.chosenFilters){
                this.chosenFilters[i] = this.chosenFilters[i].replace(" ","")
                this.chosenFilters[i] = this.chosenFilters[i].charAt(0).toLowerCase() + this.chosenFilters[i].slice(1,this.chosenFilters[i].length)
                if (i !== 0) {
                    this.chosenFiltersString = this.chosenFiltersString + "%2B" + this.chosenFilters[i]
                }
            }
             this.chosenFiltersString = this.chosenFiltersString.slice(3,this.chosenFiltersString.length)
             this.filteredSet = true
             this.advancedSearch(0)
        },
        pageSizeUpdate(){
            this.users = []
            if(this.filteredSet){
                this.advancedSearch(this.pageNumber)
            }else{
                this.getUsers()
            }
        },
        approveOrDenyProfilePicture(userId, isApprove){
            ApiDriver.User.approveOrDenyProfilePicture(userId, isApprove).then((response) => {
                if(response.status === 200){
                    for(var i in this.users){
                        if(this.users[i].id === userId){
                            this.users[i].profilePictureApproved = isApprove
                        }
                    }
                }
                router.push("/admin");
            })
        },
        banUser(userId, message){
            ApiDriver.User.ban(userId, message).then((response) => {
                if(response.status === 200){
                    for(var i in this.users){
                        if(this.users[i].id === userId){
                            this.users[i].status = "Banned"
                        }
                    }
                }
            })
        },
        unbanUser(userId){
            ApiDriver.User.unban(userId).then((response) => {
                if(response.status === 200){
                    for(var i in this.users){
                        if(this.users[i].id === userId){
                            this.users[i].status = "Active"
                        }
                    }
                }
            })
        }
    },
    mounted: function(){
        this.getUsers();
    },
    components: {
        Loading,
    }
}

</script>
<style scoped>
    
</style>
