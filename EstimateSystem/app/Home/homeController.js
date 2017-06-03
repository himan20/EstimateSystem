

estimateApp.controller('homeController', function ($scope, $location) {
    $scope.addNewEstimateClick = function () {
        $location.path('/NewEstimate');
    }
});