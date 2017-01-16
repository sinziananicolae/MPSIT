(function () {
    "use strict";

    angular.module("app").controller("MapController",
			["$scope", "ApiaryService", mapController]);

    function mapController($scope, ApiaryService) {
        $scope.map = { center: { latitude: 0, longitude: 0 }, zoom: 8 };

        ApiaryService.get({ param: "all" }, function (response) {
            $scope.data = response.data;
            $scope.map = { center: { latitude: $scope.data[0].Latitude, longitude: $scope.data[0].Longitude }, zoom: 6 };
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
                        ownerEmail: marker.OwnerEmail,
                        show: false,
                        icon: marker.IsOwner ? "/Content/img/home.png" : "/Content/img/honeycomb_orange.png"
                    });
            });
            $scope.map.markers = markers;
        });

    }
}());