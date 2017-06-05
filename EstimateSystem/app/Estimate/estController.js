

estimateApp.controller('estController',function ($scope,$location,$timeout,toaster, estService, $window, $routeParams) {
    
    $scope.estimate = {
        Campaign: '', Agency: '', PeriodFrom: undefined, PeriodTo: undefined, ClientID: '', BrandID: '', EST_NO: '', PO_Date: undefined, PO_NO: '', EST_Date: new Date(),
        SAC_PER: 0, AAC_PER: 0, Status: 1, Net_Cost: 0, Gross_Cost: 0, EST_ID: 0, Clients: [], Brands: []
    };

    $scope.fetchDataIfEditing = function () {
        $scope.estimate.EST_ID = $routeParams.EstID;

        if ($scope.estimate.EST_ID) {
            estService.getEstimateById($scope.estimate.EST_ID)
                .then(function (result) {
                    console.log(result);
                    $scope.estimate = {
                        Campaign: result.data.campaign,
                        Agency: result.data.agency,
                        PeriodFrom: new Date(result.data.periodFrom),
                        PeriodTo: new Date(result.data.periodTo),
                        ClientID: result.data.clientID,
                        BrandID: result.data.brandID,
                        EST_NO: result.data.esT_NO,
                        PO_Date: new Date(result.data.pO_Date),
                        PO_NO: result.data.pO_NO,
                        EST_Date: new Date(result.data.esT_Date),
                        SAC_PER: result.data.saC_PER,
                        AAC_PER: result.data.aaC_PER,
                        Status: result.data.status,
                        Net_Cost: result.data.net_Cost,
                        Gross_Cost: result.data.gross_Cost,
                        EST_ID: result.data.esT_ID
                    };
                    console.log($scope.estimate);
                    console.log($scope.estimate.Clients);
                }, function (error) {
                    toaster.pop('error', 'Sorry', 'Data could not be retrieved. Please try again later');
                })
                .then(function () {
                    estService.getClients()
                        .then(function (result) {
                            //console.log(result);
                            $scope.estimate.Clients = result.data;
                            //$scope.estimate.ClientID = $scope.estimate.Clients[0].clientID;
                        }, function (error) {

                        });

                    estService.getBrands()
                        .then(function (result) {
                            $scope.estimate.Brands = result.data;
                            //$scope.estimate.BrandID = $scope.estimate.Brands[0].brandID;
                        }, function (error) {

                        });
                }, function () {

                });
        }
        else {
            estService.getClients()
                .then(function (result) {
                    //console.log(result);
                    $scope.estimate.Clients = result.data;
                    $scope.estimate.ClientID = $scope.estimate.Clients[0].clientID;
                }, function (error) {

                });

            estService.getBrands()
                .then(function (result) {
                    $scope.estimate.Brands = result.data;
                    $scope.estimate.BrandID = $scope.estimate.Brands[0].brandID;
                }, function (error) {

                });
        }

        
    }

    
    $scope.cancelEstimate = function () {
        $window.history.back();
    };
    $scope.saveEstimate = function () {
        estService.saveEstimate($scope.estimate)
            .then(function (result) {
            toaster.pop('success', 'Congratulations', 'Estimate has been added successfully!')
            $location.path('/Home');
        }, function (error) {
            toaster.pop('error', 'Sorry', 'Request Failed.Please try again')
        });
    };

    $scope.addNewEstimateClick = function () {
        $location.path('/NewEstimate');
    }

    $scope.periodFromOptions = {
        formatYear: 'yy',
        minDate: new Date(),
        startingDay: 1
    }
    
    var dt = $scope.estimate.PeriodFrom;

    $scope.periodToOptions = {
        formatYear: 'yy',
        minDate: new Date(),
        startingDay: 1
    }

    $scope.poDateOptions = {
        formatYear: 'yy',
        startingDay: 1
    }
    $('#dt').on('blur', function () { $scope.periodToOptions.minDate = $scope.estimate.PeriodFrom; });
    $('#sac').on('blur', function () {
        if (!$scope.estimate.SAC_PER) {
            $scope.$apply(function () { $scope.estimate.SAC_PER = 0; });
        }
    });

    $('#aac').on('blur', function () {
        if (!$scope.estimate.AAC_PER) {
            $scope.$apply(function () { $scope.estimate.AAC_PER = 0; });
        }
    });

    //function validateValue() {
    //    if ($scope.estimate.SAC_PER > 100) {
    //        $scope.estimate.SAC_PER = 100;
    //    } else if ($scope.estimate.SAC_PER < 0) {
    //        $scope.estimate.SAC_PER = 0
    //    }
    //}

    $scope.isDateROOpen = false;
    $scope.isDateOpen = false;
    $scope.isFromOpen = false;
    $scope.isToOpen = false;

    $scope.openDateRO = function () {
        $scope.isDateROOpen = true;
    }

    $scope.openDate = function () {
        $scope.isDateOpen = true;
    }
    $scope.openFromDate = function () {
        $scope.isFromOpen = true;
    }

    $scope.openToDate = function () {
        $scope.isToOpen = true;
    }
});