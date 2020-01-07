var articles = new Vue({
    el: '#articlesVueApp',
    data: {
        heading: {},
        ingress: {}
    },

    methods: {
        setInitData: function (heading, ingress) {
            this.heading = heading;
            this.ingress = ingress;
        }


    },

    mounted() {
        alert(this.heading);
    },

    created() {
        alert(this.heading);
    },

    //directives: {
    //    init: {
    //        bind: function (el, binding, vnode) {
    //            //vnode.context[binding.arg] = binding.value;
    //            this.heading = binding.value;
    //            alert(this.heading);
    //        }
    //    }
    //}

});

Vue.directive('init', {
    bind: function (el, binding, vnode) {
        vnode.context[binding.arg] = binding.value;
        this.heading = binding.value;
    }
});
