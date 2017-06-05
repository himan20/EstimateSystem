

estimateApp.factory('publicationService', function ($http) {

    var getAllPublications = function (id) {
        return $http.get('Publication/GetAllPublicationsForEstimate?id=' + id);
    }

    var deletePublications = function (ids) {
        return $http.post('Publication/DeletePublications', ids);
    }

    var getPublicationById = function (id) {
        return $http.get('Publication/GetPublicationById?id=' + id);
    }

    var savePublication = function (data) {
        return $http.post('Publication/SavePublication', data);
    }

    return {
        getAllPublications: getAllPublications,
        deletePublications: deletePublications,
        getPublicationById: getPublicationById,
        savePublication: savePublication
    }

});