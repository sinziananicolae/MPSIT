(function () {
    "use strict";

    var serviceMetods = {
        get: { method: "GET" },
        create: { method: "POST" },
        update: { method: "PUT" },
        patch: { method: "PATCH" },
        remove: { method: "DELETE" }
    };

    angular.module('services', ['ngResource'])
	    .factory('CloudsimService', ['$resource', function ($resource) {
	        return $resource('/CloudsimServer/api/getResources/:id', { id: "@id" }, serviceMetods);
	    }]);
}());
