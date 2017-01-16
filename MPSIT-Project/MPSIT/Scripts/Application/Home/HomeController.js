(function() {
	"use strict";

	angular.module("app").controller("HomeController", [ "$scope", "ApiaryService", homeController ]);

	function homeController($scope, ApiaryService) {
	    $scope.map = { center: { latitude: 0, longitude: 0 }, zoom: 8 };
		
	    ApiaryService.get({ param: "location" }, function (response) {
	        $scope.data = response.data;
	        $scope.map = { center: { latitude: $scope.data[0].Latitude, longitude: $scope.data[0].Longitude }, zoom: 5 };
	        var markers = [];
	        _.each($scope.data, function (marker) {
	            markers.push(
                    {
                        id: marker.Id,
                        latitude: marker.Latitude,
                        longitude: marker.Longitude,
                        title: "Apiary_" + marker.Id,
                        description: marker.BeeSpecies,
                        hivesNo: marker.HivesNo,
                        show: false,
                        icon: "/Content/img/honeycomb_orange.png"
                    });
	        });
	        $scope.map.markers = markers;
	    });

	    $scope.zoomIn = function (apiary) {
	        $scope.map = { center: { latitude: apiary.Latitude, longitude: apiary.Longitude }, zoom: 9 };
	    }
	}
}());