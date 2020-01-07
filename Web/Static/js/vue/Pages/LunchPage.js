import Vue from 'vue';
import LunchComponent from '../components/LunchComponent.vue';
import FacebookFlowComponent from '../components/FacebookFlowComponent.vue';


var lunch = new Vue({
    el: '#vueApp',
    data: {
            twoValveAndKitchenHtmlTable: {},
            percysHtmlTable: {},
            nilssonsHtmlTable: {},
            qualityViewHtmlTable: {},
            frilagetHtmlTable: {}, 
            twoValveAndKitchenOneDayHtmlTable: {}
    },

    components: {
        "lunch-component": LunchComponent,
        "facebook-flow-component": FacebookFlowComponent
    },

    methods: {
        getLunch: function () {
            $('.spinner-background').show();
            $('.edspinner').show();
            var self = this;
            axios.get('/LunchPage/GetLunch')
                .then(function (response) {
                    console.log(response.data);
                    console.log(response.status);
                    self.twoValveAndKitchenHtmlTable = response.data.TwoValveAndKitchenHtmlTable;                 
                    self.percysHtmlTable = response.data.PercysHtmlTable;
                    self.nilssonsHtmlTable = response.data.NilssonsHtmlTable;
                    self.qualityViewHtmlTable = response.data.QualityViewHtmlTable;
                    self.frilagetHtmlTable = response.data.FrilagetHtmlTable;
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

        getOneDayLunch: function () {
            $('.spinner-background').show();
            $('.edspinner').show();
            var self = this;
            axios.get('/LunchPage/GetOneDayLunch')
                .then(function (response) {
                    console.log(response.data);
                    console.log(response.status);
                    self.twoValveAndKitchenOneDayHtmlTable = response.data.TwoValveAndKitchenOneDayHtmlTable;                  
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
        this.getLunch(); 
    }  
});


