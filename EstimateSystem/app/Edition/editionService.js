

estimateApp.factory('editionService', function ($http) {


    var getAllEditions = function (id) {
        return $http.get('Edition/GetAllEditionsForPublication?id=' + id);
    }

    var deleteEditions = function (ids) {
        return $http.post('Edition/DeleteEditions', ids);
    }

    var getEditionById = function (id) {
        return $http.get('Edition/GetEditionById?id=' + id);
    }

    var saveEdition = function (data) {
        return $http.post('Edition/SaveEdition', data);
    }

    var checkExistingSchedule = function (edId) {
        return $http.get('Schedule/GetAllSchedulesForEdition?id=' + edId);
    }

    return {
        saveEdition: saveEdition,
        getEditionById: getEditionById,
        deleteEditions: deleteEditions,
        getAllEditions: getAllEditions,
        checkExistingSchedule: checkExistingSchedule
    }
});