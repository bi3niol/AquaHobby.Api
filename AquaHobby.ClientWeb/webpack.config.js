/// <binding ProjectOpened='Hot' />
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
"use strict";

module.exports = {
    entry: "./app/index.js",
    output: {
        filename: "bundle.js"
    },
    //devServer: {
    //    historyApiFallback: {
    //        rewrites: [
    //            { from: /^\/$/, to: '/index.html' }
    //        ]
    //    }
    //},
    module: {
        loaders: [
            {
                test: /\.js$/,
                loader: "babel-loader",
                exclude: /node_modules/,
                query: {
                    presets: ["es2015", "react"]
                }
            }
        ]
    },
    plugins: [
        new webpack.DefinePlugin({
            __API_URL__: JSON.stringify(process.env.API_URL || 'http://aquahobbyapi.azurewebsites.net')
        })
        //new HtmlWebpackPlugin({
        //    template: 'index.html'
        //})
    ]
};