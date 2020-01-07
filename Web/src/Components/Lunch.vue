<template>
    <div id="LunchComponent">
        <p>Test av lunchComponent</p>
    </div>
</template>

<script>
    export default {
        name: "LunchComponent"   
    }
</script>

<!--<template>
    <div id="lunch">
        <div class="lunch">
            <div class="container">
                <div class="row hide-vue">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <h1 class="lunch-heading"><i class="fas fa-utensils"></i>LUNCH</h1>
                    </div>
                </div>
                <div class="row hide-vue">
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <h2 class="restuarant-heading">2 Valv och kök</h2>
                        <p v-html=twoValveAndKitchenHtmlTable></p>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <h2 class="restuarant-heading">Percys</h2>
                        <p v-html=percysHtmlTable></p>
                    </div>
                </div>
                <div class="row hide-vue">
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <h2 class="restuarant-heading">Nilssons</h2>
                        <p v-html=nilssonsHtmlTable></p>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <h2 class="restuarant-heading">Quality view hotel</h2>
                        <p v-html=qualityViewHtmlTable></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>-->
<!--<script>
    export default {
        name: 'lunchComponent',
        data() {
          return {
            message: 'Detta är min nya lunch component',
          };
        },
          };

        var lunch = new Vue({
            el: '#vueApp',
            data: {
                twoValveAndKitchenHtmlTable: {},
                percysHtmlTable: {},
                nilssonsHtmlTable: {},
                qualityViewHtmlTable: {}
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
</script>-->
