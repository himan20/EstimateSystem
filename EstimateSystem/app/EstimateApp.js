

var estimateApp = angular.module('estimateApp', ['ngRoute']);

estimateApp.config(function ($routeProvider) {

    $routeProvider
        .when('/Home', {
            templateUrl: 'app/Home/Home.html',
            controller: 'homeController'
        })
        .when('/NewEstimate', {
            templateUrl: 'app/Estimate/CreateEstimateTemplate.html',
            controller: 'estController'
        })
        .otherwise({
            redirectTo: '/Home'

        });
    //$locationProvider.html5Mode(true);

});
