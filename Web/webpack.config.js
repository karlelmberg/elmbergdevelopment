const HtmlWebpackPlugin = require('html-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');
var package = require('./package.json');
//import HtmlWebpackPlugin from 'html-webpack-plugin';
//import VueLoaderPlugin from 'vue-loader';

const path = require('path');

module.exports = {
    entry: {
        main: './src/main.js',
        //vendor: Object.keys(package.dependencies),
        lunchpage: "./Static/js/vue/Pages/LunchPage.js",
        startpage: "./Static/js/vue/Pages/StartPage.js"
    },

    output: {
        //path: path.resolve(__dirname, '/dist'),
        filename: './[name].bundle.js'
    },

    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.css$/,
                use: ['vue-style-loader', 'css-loader']
            },
        ]
    },

    resolve: {
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        },
        extensions: ['*', '.js', '.vue', '.json']
    },

    //plugins: [

    //    new HtmlWebpackPlugin({
    //        hash: true,
    //        title: 'Main',
    //        myPageHeader: 'Main',
    //        template: './src/index.html',
    //        chunks: ['vendor', 'settings'],
    //        filename: './dist/index.html'
    //    }),

    //    new HtmlWebpackPlugin({
    //        hash: true,
    //        title: 'Lunch page',
    //        myPageHeader: 'Lunch',
    //        template: './src/index.html',
    //        chunks: ['vendor', 'settings'],
    //        filename: './dist/index.html'
    //    })

    //]


    plugins: [
        //new HtmlWebpackPlugin({
        //    template: 'src/index.html',      

        //}),
        new VueLoaderPlugin(),
    ]
};