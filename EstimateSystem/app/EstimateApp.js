

var estimateApp = angular.module('estimateApp', ['ngRoute', 'ui.grid', 'ui.grid.pagination', 'ui.grid.selection', 'ui.bootstrap', 'toaster', 'ngAnimate']);

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
        .when('/EditEstimate/:EstID', {
            templateUrl: 'app/Estimate/CreateEstimateTemplate.html',
            controller: 'estController'
        })
        .when('/Estimate/:EstID/Publication', {
            templateUrl: 'app/Publication/Publication.html',
            controller: 'publicationController'
        })
        .when('/Estimate/:EstID/NewPublication', {
            templateUrl: 'app/Publication/CreatePublicationTemplate.html',
            controller : 'publicationController'
        })
        .when('/Estimate/:EstID/EditPublication/:PubID', {
            templateUrl: 'app/Publication/CreatePublicationTemplate.html',
            controller: 'publicationController'
        })
        .when('/Estimate/:EstID/Publication/:PubID/Edition', {
            templateUrl: 'app/Edition/Edition.html',
            controller: 'editionController'
        })
        .when('/Estimate/:EstID/Publication/:PubID/NewEdition', {
            templateUrl: 'app/Edition/CreateEditionTemplate.html',
            controller: 'editionController'
        })
        .when('/Estimate/:EstID/Publication/:PubID/EditEdition/:EdID', {
            templateUrl: 'app/Edition/CreateEditionTemplate.html',
            controller: 'editionController'
        })
        .when('/Estimate/:EstID/Publication/:PubID/Edition/:EdID/Schedule', {
            templateUrl: 'app/Schedule/Schedule.html',
            controller: 'scheduleController'
        })
        .when('/Estimate/:EstID/Publication/:PubID/Edition/:EdID/NewSchedule', {
            templateUrl: 'app/Schedule/CreateScheduleTemplate.html',
            controller: 'scheduleController'
        })
        .when('/Estimate/:EstID/Publication/:PubID/Edition/:EdID/EditSchedule/:SchID', {
            templateUrl: 'app/Schedule/CreateScheduleTemplate.html',
            controller: 'scheduleController'
        })
        .otherwise({
            redirectTo: '/Home'

        });

    //$locationProvider.html5Mode(true);

});
