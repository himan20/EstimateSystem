

estimateApp.controller('estController',function ($scope,$location, estService) {
    $scope.header = estService.header;
    $scope.submiteCreateForm = function () {

    };
    $scope.modifyEstimateClick = function () {

    };
    $scope.deleteEstimateClick = function () {

    };
    $scope.approveEstimateClick = function () {

    };
    $scope.excelReportClick = function () {

    };
    $scope.pdfreportClick = function () {

    };

    $scope.addNewEstimateClick = function () {
        $location.path('/NewEstimate');
    }
});