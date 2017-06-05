
estimateApp.controller('publicationController', function ($scope, $location, $window, toaster, $routeParams, publicationService) {
    //Create page
    $scope.addNewEdition = function () {
        $location.path('/NewEdition');
    }
    $scope.cancelPublication = function () {
        $window.history.back();
    }

    $scope.savePublication = function () {
        publicationService.savePublication($scope.pub)
            .then(function (result) {
                toaster.pop('success', 'Success', 'Added Successfully!')
                $location.path('/Home');
            }, function (error) {
                toaster.pop('error', 'Sorry', 'Request Failed.Please try again')
            });
    };

    $scope.pub = {
        EST_PUBID: 0, EST_Publication: '', EST_ID: 0, Pub_Language: '', Total_Edition: 0, Rate: 0, Total_Insertion: 0,
        Total_Cost: 0, Agency_Discount: 0, Total_NetCost: 0
    }


    $scope.fetchDataIfEditing = function () {
        $scope.pub.EST_PUBID = $routeParams.PubID;

        if ($scope.pub.EST_PUBID) {
            publicationService.getPublicationById($scope.pub.EST_PUBID)
                .then(function (result) {
                    console.log(result);
                    $scope.pub = {
                        EST_PUBID: result.data.esT_PUBID,
                        EST_Publication: result.data.esT_Publication,
                        EST_ID: result.data.esT_ID,
                        Pub_Language: result.data.pub_Language,
                        Total_Edition: result.data.total_Edition,
                        Rate: result.data.rate,
                        Total_Insertion: result.data.total_Insertion,
                        Total_Cost: result.data.total_Cost,
                        Agency_Discount: result.data.agency_Discount,
                        Total_NetCost: result.data.total_NetCost
                    };

                }, function (error) {
                    toaster.pop('error', 'Sorry', 'Data could not be retrieved. Please try again later');
                })
        }
    }



    // Grid page
    $scope.addNewPublicationClick = function () {
        var url = '/Estimate/' + $routeParams.EstID + '/NewPublication'; 
        $location.path(url);
    }
    $scope.modifyPublicationClick = function () {
        var pubId = $scope.rowsSelected[0].esT_PUBID;

        var url = '/Estimate/' + $routeParams.EstID + '/EditPublication/' + pubId;
        $location.path(url);
    };
    $scope.deletePublicationClick = function () {

        var ids = [];
        for (var i = 0; i < $scope.rowsSelected.length; i++) {
            ids.push($scope.rowsSelected[i].esT_PUBID);
        }

        publicationService.deletePublications(ids)
            .then(function (result) {
                toaster.pop('success', 'Success', 'Deletion was Successful!');
                $location.path('/');
            }, function (error) {
                toaster.pop('error', 'Sorry', 'Deletion failed. Please try again later');
            });

    };

    $scope.publications = null;

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
            { name: 'Publication', field: 'esT_Publication' },
            { name: 'Language', field: 'pub_Language' },
            { name: 'Rate', field: 'rate' },
            { name: 'Total Edition', field: 'total_Edition' }
        ],
        data: $scope.publications
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
    publicationService.getAllPublications($routeParams.EstID).then(function (result) {
        //success
        $scope.gridOptions.data = result.data;
    }, function (error) {
        //failure
    });


    $scope.showEditions = function () {
        var pubId = $scope.rowsSelected[0].esT_PUBID;
        var url = '/Estimate/' + $routeParams.EstID + '/Publication/' + pubId + '/Edition';
        $location.path(url);
    }

});