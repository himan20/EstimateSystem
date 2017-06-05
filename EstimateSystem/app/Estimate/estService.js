
estimateApp.factory('estService', function ($http) {

    var saveEstimate = function (data) {
        return $http.post('Estimate/SaveEstimate', data);
    }

    var getEstimateById = function (id) {
        return $http.get('Estimate/GetEstimateById?id=' + id);
    }

    var getClients = function () {
        return $http.get('Estimate/GetClients');
    }

    var getBrands = function () {
        return $http.get('Estimate/GetBrands');
    }
    return {
        saveEstimate: saveEstimate,
        getEstimateById: getEstimateById,
        getClients: getClients,
        getBrands: getBrands
    }
});