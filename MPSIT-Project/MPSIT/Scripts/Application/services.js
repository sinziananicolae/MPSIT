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
	    .factory('UserService', ['$resource', function ($resource) {
	        return $resource('/api/user', { }, serviceMetods);
	    }])
        .factory('ApiaryService', ['$resource', function ($resource) {
            return $resource('/api/apiary/:param', {param: '@param'}, serviceMetods);
        }]);
}());
