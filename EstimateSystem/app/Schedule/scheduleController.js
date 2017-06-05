
estimateApp.controller('scheduleController', function ($scope, $location, $window,toaster, $routeParams, scheduleService ) {
    $scope.saveSchedule = function () {
        scheduleService.saveSchedule($scope.schedule)
            .then(function (result) {
                toaster.pop('success', 'Success', 'Added Successfully!')
                $location.path('/Home');
            }, function (error) {
                toaster.pop('error', 'Sorry', 'Request Failed.Please try again')
            });
    }
    $scope.cancelSchedule = function () {
        $window.history.back();
    }

    $scope.schedule = {
        EST_SchID: 0, EST_EditionID: 0, EST_PUBID: 0, EST_ID: 0, Scheduled_Date: new Date(), CaptionID: 0, Language: '', Height: 0, Weidth: 0, Total_Size: 0, Rate: 0, NoOfInsertion: 0,
        Total_Cost: 0, Agency_Discount: 0, Total_NetCost: 0, Captions: []
    }

    $scope.fetchDataIfEditing = function () {
        $scope.schedule.EST_SchID = $routeParams.SchID;
        //console.log($routeParams);
        if ($scope.schedule.EST_SchID) {
            scheduleService.getScheduleById($scope.schedule.EST_SchID)
                .then(function (result) {
                    console.log(result);
                    $scope.schedule = {
                        EST_SchID: result.data.esT_SchID,
                        EST_EditionID: result.data.esT_EditionID,
                        EST_PUBID: result.data.esT_PUBID,
                        EST_ID: result.data.esT_ID,
                        Scheduled_Date: new Date(result.data.scheduled_Date),
                        CaptionID: result.data.captionID,
                        Language: result.data.language,
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

        scheduleService.getCaptions()
            .then(function (result) {
                
                //for (var i = 0; i < result.data.length; i++) {
                //    var obj = {};
                //    obj.caption_Name = result.data[i].caption;
                //    obj.captionID = result.data[i].captionID;
                //    $scope.schedule.Captions.push(obj);
                //}


                $scope.schedule.Captions = result.data;
                $scope.schedule.CaptionID = $scope.schedule.Captions[0].captionID;
                console.log($scope.schedule.Captions);
            }, function (error) {

            });
    }

    $scope.isSchDateOpen = false;
    $scope.openSchDate = function () {
        $scope.isSchDateOpen = true;
    }
    $scope.dateOptions = {
        formatYear: 'yy',
        maxDate: new Date(2020, 5, 22),
        minDate: new Date(),
        startingDay: 1
    }
});