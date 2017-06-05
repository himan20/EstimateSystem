

estimateApp.factory('homeService', function ($http) {

    var getAllEstimates = function () {
        return $http.get('Estimate/GetAllEstimates');
    }

    var deleteEstimates = function (ids) {
        return $http.post('Estimate/DeleteEstimates', ids);
    }

    return {
        getAllEstimates: getAllEstimates,
        deleteEstimates: deleteEstimates
    }
});