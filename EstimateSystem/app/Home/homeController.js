

estimateApp.controller('homeController', function ($scope,toaster, $location, homeService) {
    $scope.addNewEstimateClick = function () {
        $location.path('/NewEstimate');
    }
    $scope.modifyEstimateClick = function () {
        var estimateId = $scope.rowsSelected[0].esT_ID;
        
        var url = '/EditEstimate/' + estimateId;
        $location.path(url);
    };
    $scope.deleteEstimateClick = function () {

        var ids = [];
        for (var i = 0; i < $scope.rowsSelected.length; i++) {
            ids.push($scope.rowsSelected[i].esT_ID);
        }

        homeService.deleteEstimates(ids)
            .then(function (result) {
                toaster.pop('success', 'Success', 'Deletion was Successful!');
                $location.path('/');
            }, function (error) {
                toaster.pop('error', 'Sorry', 'Deletion failed. Please try again later');
            });
        
    };
    $scope.approveEstimateClick = function () {

    };
    $scope.excelReportClick = function () {

    };
    $scope.pdfreportClick = function () {

    };

    $scope.estimates = null;
    
    $scope.isMultipleRowsSelected = true;
    $scope.noRowsSelected = true;
    $scope.rowsSelected = null;

    $scope.gridOptions = {
        enableSorting: true,
        enableFiltering: true,
        paginationPageSizes: [1, 5, 10],
        paginationPageSize: 10,
        enableFullRowSelection: true,
        columnDefs: [
            { name: 'EstimateNo', field: 'esT_NO' },
            { name: 'PeriodFrom', field: 'periodFrom' },
            { name: 'PeriodTo', field: 'periodTo' },
            { name: 'Client', field: 'clientID' },
            { name: 'Brand', field: 'brandID' },
            { name: 'GrossCost', field: 'gross_Cost' },
        ],
        data: $scope.estimates
    }

    $scope.gridOptions.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
            var msg = 'row selected ' + row.isSelected;
            var rowsSelected = $scope.gridApi.selection.getSelectedRows();
            $scope.rowsSelected = rowsSelected; 
            if (rowsSelected.length === 1) {
                $scope.isMultipleRowsSelected = false;
                $scope.noRowsSelected = false;
            }
            else if (rowsSelected.length === 0){
                $scope.noRowsSelected = true;
                $scope.isMultipleRowsSelected = true;
            }
            else {
                $scope.isMultipleRowsSelected = true;
                $scope.noRowsSelected = false;
            }
        });

        gridApi.selection.on.rowSelectionChangedBatch($scope, function (rows) {
            var msg = 'rows changed ' + rows.length;
        });
    }

    //Get Data for Estimates grid
    homeService.getAllEstimates().then(function (result) {
        //success
        $scope.gridOptions.data = result.data;
    }, function (error) {
        //failure
    });

    $scope.showPublications = function () {
        var estimateId = $scope.rowsSelected[0].esT_ID;
        var url = '/Estimate/' + estimateId + '/Publication' 
        $location.path(url);
    }

});