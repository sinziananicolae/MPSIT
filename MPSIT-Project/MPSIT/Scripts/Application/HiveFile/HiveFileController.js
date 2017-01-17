(function () {
    "use strict";

    angular.module("app").controller("HiveFileController", ["$scope", "$routeParams", "$location", "HiveService", hiveFileController]);

    function hiveFileController($scope, $routeParams, $location, HiveService) {
        $scope.currentHiveNo = $routeParams.hiveId;
        $scope.hiveFileId = $routeParams.id;

        $scope.hiveTypes = ["Strong", "Medium", "Weak", "Sick"];

        if ($scope.hiveFileId)
            HiveService.get({ param: "file", id: $scope.hiveFileId }, function (response) {
                $scope.hiveFile = response;
            });
        else
            $scope.hiveFile = { HiveId: $scope.currentHiveNo };

        $scope.saveHiveFile = function () {
            $scope.hiveFile.Timestamp = new Date();
            HiveService.create({ param: "file" },  $scope.hiveFile, function (response) {
                $location.path("/hive/" + $scope.currentHiveNo);
            });
        }

    }
}());