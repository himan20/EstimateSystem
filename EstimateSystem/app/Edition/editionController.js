

estimateApp.controller('editionController', function ($scope, $location, $window, $routeParams, editionService) {
    //$scope.addNewSchedules = function () {
    //    $location.path('/NewSchedules');
    //}
    $scope.cancelEdition = function () {
        $window.history.back();
    }
    $scope.saveEdition = function () {
        editionService.saveEdition($scope.edition)
            .then(function (result) {
                toaster.pop('success', 'Success', 'Added Successfully!')
                $location.path('/Home');
            }, function (error) {
                toaster.pop('error', 'Sorry', 'Request Failed.Please try again')
            });
    }

    $scope.edition = {
        EST_EditionID: 0, EST_PUBID: 0, EST_ID: 0, Edition: '', Height: 0, Weidth: 0, Total_Size: 0, Rate: 0, NoOfInsertion: 0,
        Total_Cost: 0, Agency_Discount: 0, Total_NetCost:0
    }

    $scope.fetchDataIfEditing = function () {
        $scope.edition.EST_EditionID = $routeParams.EdID;

        if ($scope.edition.EST_EditionID) {
            editionService.getEditionById($scope.edition.EST_EditionID)
                .then(function (result) {
                    console.log(result);
                    $scope.edition = {
                        EST_EditionID: result.data.esT_EditionID,
                        EST_PUBID: result.data.esT_PUBID,
                        EST_ID: result.data.esT_ID,
                        Edition: result.data.edition,
                        Height: result.data.height,
                        Weidth: result.data.weidth,
                        Total_Size: result.data.total_Size,
                        Rate: result.data.rate,
                        NoOfInsertion: result.data.noOfInsertion,
                        Total_Cost: result.data.total_Cost,
                        Agency_Discount: result.data.agency_Discount,
                        Total_NetCost: result.data.total_NetCost
                    };

                }, function (error) {
                    toaster.pop('error', 'Sorry', 'Data could not be retrieved. Please try again later');
                })
        }
    }










    $scope.addNewEditionClick = function () {
        var url = '/Estimate/' + $routeParams.EstID + '/Publication/' + $routeParams.PubID + '/NewEdition' ;
        $location.path(url);
    }
    $scope.modifyEditionClick = function () {
        var edId = $scope.rowsSelected[0].esT_EditionID;
        var url = '/Estimate/' + $routeParams.EstID + '/Publication/' + $routeParams.PubID + '/EditEdition/' + edId;
        $location.path(url);
    };
    $scope.deleteEditionClick = function () {

        var ids = [];
        for (var i = 0; i < $scope.rowsSelected.length; i++) {
            ids.push($scope.rowsSelected[i].esT_EditionID);
        }

        editionService.deleteEditions(ids)
            .then(function (result) {
                toaster.pop('success', 'Success', 'Deletion was Successful!');
                $location.path('/');
            }, function (error) {
                toaster.pop('error', 'Sorry', 'Deletion failed. Please try again later');
            });

    };

    $scope.editions = null;

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
            { name: 'Edition Name', field: 'edition' },
            { name: 'Height', field: 'height' },
            { name: 'Width', field: 'weidth' },
            { name: 'Total Size', field: 'total_Size' },
            { name: 'Rate', field: 'rate' },
            { name: 'No Of Insertions', field: 'noOfInsertion' },
            { name: 'Total Cost', field: 'total_Cost' },
            { name: 'Agency Discount', field: 'agency_Discount' },
            { name: 'Net Cost', field: 'total_NetCost'}

        ],
        data: $scope.editions
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
            else if (rowsSelected.length === 0) {
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

    //$scope.addNewPublication = function () {
    //    $location.path('/NewPublication');
    //}
    //Get Data for Publications grid for selected Estimate
    console.log($routeParams);
    editionService.getAllEditions($routeParams.PubID).then(function (result) {
        //success
        $scope.gridOptions.data = result.data;
    }, function (error) {
        //failure
    });


    $scope.showNewSchedulePage = function () {

        var edId = $scope.rowsSelected[0].esT_EditionID;

        editionService.checkExistingSchedule(edId)
            .then(function (result) {
                console.log(result);
                if (result.data[0]) {
                    var url = '/Estimate/' + $routeParams.EstID + '/Publication/' + $routeParams.PubID + '/Edition/' + edId + '/EditSchedule/' + result.data[0].esT_SchID;
                    $location.path(url);
                }
                else {
                    var url = '/Estimate/' + $routeParams.EstID + '/Publication/' + $routeParams.PubID + '/Edition/' + edId  + '/NewSchedule';
                    $location.path(url);
                }
            }, function (error) {

            });

       
    }
});