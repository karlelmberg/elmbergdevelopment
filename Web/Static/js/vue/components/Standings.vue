
Vue.component('standings-component', {  

template: '
<div class="standings">
    <div class="container standings-table hide-vue">
        <div v-if="premierLeaguePanel">
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=premierLeagueTable></p>
                </div>
            </div>
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=premierLeagueBestGoalScorersTable></p>
                </div>
            </div>
        </div>
        <div v-if="allsvenskanPanel">
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=allsvenskanTable></p>
                </div>
            </div>
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=allsvenskanBestGoalScorersTable></p>
                </div>
            </div>
        </div>
        <div v-if="laLigaPanel">
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=laLigaTable></p>
                </div>
            </div>
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=laLigaBestGoalScorersTable></p>
                </div>
            </div>
        </div>
        <div v-if="bundesLigaPanel">
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=bundesLigaTable></p>
                </div>
            </div>
            <div class="row standings-inner-table">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <p v-html=bundesLigaBestGoalScorersTable></p>
                </div>
            </div>
        </div>
    </div>
</div>
'})
