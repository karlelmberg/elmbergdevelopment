import Vue from 'vue';
import { Hooper, Slide, Navigation as HooperNavigation } from 'hooper';
import 'hooper/dist/hooper.css';

var start = new Vue({
    el: '#vueApp',

    components: {
        Hooper,
        Slide, 
        HooperNavigation
    },

    data: {
        listOfRestaurants: [],
        selectedRestaurant: {},
        selectedRestaurantNr: 0, 
        oneDayWeatherList: []
    },

    methods: {

        //Lunch
        getOneDayLunch: function () {
            $('.spinner-background').show();
            $('.edspinner').show();
            var self = this;
            axios.get('/LunchPage/GetOneDayLunch')
                .then(function (response) {
                    console.log(response.data);
                    console.log(response.status);
                    self.listOfRestaurants = response.data.ListOfRestaurants;
                    self.selectedRestaurant = self.listOfRestaurants[self.selectedRestaurantNr];
                    $('.edspinner').hide();
                    $('.spinner-background').hide();
                    $('.hide-vue').show();
                })
                .catch(error => {
                    console.log(error);
                    this.error = true;
                    alert("error");
                });
        }, 

        getNextRestaurant: function () {
            if (this.listOfRestaurants[this.selectedRestaurantNr + 1] != undefined) {
                this.selectedRestaurant = this.listOfRestaurants[this.selectedRestaurantNr + 1];
                this.selectedRestaurantNr += 1;
            }
            else {
                this.selectedRestaurantNr = 0;
                this.selectedRestaurant = this.listOfRestaurants[this.selectedRestaurantNr];
            }
        }, 

        //Weather
        getOneDayWeather: function () {
            $('.spinner-background').show();
            $('.edspinner').show();
            var self = this;
            axios.get('/WeatherPage/GetOneDayWeather')
                .then(function (response) {                   
                    self.oneDayWeatherList = response.data;
                    //self.selectedRestaurant = self.listOfRestaurants[self.selectedRestaurantNr];
                    $('.edspinner').hide();
                    $('.spinner-background').hide();
                    $('.hide-vue').show();
                })
                .catch(error => {
                    console.log(error);
                    this.error = true;
                    alert("error");
                });
        } 
    },

    mounted() {
        this.getOneDayLunch();
        this.getOneDayWeather();
    }
});


