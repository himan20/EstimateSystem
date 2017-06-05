

estimateApp.factory('scheduleService', function ($http) {

    var getScheduleById = function (id) {
        return $http.get('Schedule/GetScheduleById?id=' + id);
    }

    var saveSchedule = function (data) {
        return $http.post('Schedule/SaveSchedule', data);
    }
    var getCaptions = function () {
        return $http.get('Schedule/GetCaptions');
    }
    return {
        saveSchedule: saveSchedule,
        getScheduleById: getScheduleById,
        getCaptions: getCaptions 
    }
});